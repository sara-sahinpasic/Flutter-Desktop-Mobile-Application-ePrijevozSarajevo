import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/screens/route_add_screen.dart';
import 'package:eprijevoz_desktop/screens/route_update_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/route.dart';

class RouteListScreen extends StatefulWidget {
  Station? station;
  Route? route;

  RouteListScreen({
    super.key,
    this.route,
    this.station,
  });

  @override
  State<RouteListScreen> createState() => _RouteListScreenState();
}

class _RouteListScreenState extends State<RouteListScreen> {
  late RouteProvider routeProvider;
  late StationProvider stationProvider;
  SearchResult<Route>? routeResult;
  SearchResult<Route>? routeResultForTime;
  SearchResult<Station>? stationResult;
  //Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  int _selectedStationId = 0;
  bool isLoading = true;
  DateTime selectedDate = DateTime.now();

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  @override
  void initState() {
    super.initState();
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();
    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    routeResult = await routeProvider.get();

    //filter duplih naziva svih učitanih stanica
    if (routeResult?.result != null) {
      routeResult!.result = filterDuplicates(routeResult!.result);
    }

    setState(() {
      isLoading = false;
    });
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        initialDate: selectedDate,
        firstDate: DateTime(2015, 8),
        lastDate: DateTime(2101));

    if (picked != null && picked != selectedDate) {
      selectedDate = picked;
      setState(() {});
    }
  }

  List<Route> filterDuplicates(List<Route> data) {
    final seen = <int>{};
    return data
        .where((dataModel) => seen.add(dataModel.startStationId!))
        .toList();
  }

  Future refreshTable() async {
    var request = Map.from(_formKey.currentState?.value ?? {});
    routeResult = await routeProvider.get(filter: request);
    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Plan vožnje",
        Column(
          children: [
            const SizedBox(
              height: 5,
            ),
            const Align(
              alignment: Alignment.centerLeft,
              child: Text(
                "Za prikaz rezultata, neophodno je odabrati traženu stanicu i datum, te pritisnuti dugme "
                '"Pretraga"'
                ".",
                style: TextStyle(fontWeight: FontWeight.w400),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            _buildSearch(),
            _buildResultView()
          ],
        ));
  }

  Widget _buildSearch() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Container(
        width: double.infinity,
        child: Row(
          children: [
            const Flexible(
              child: Text(
                "Startna stanica:",
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
              ),
            ),
            const SizedBox(width: 15),
            Expanded(
              child: FormBuilderDropdown(
                name: "startStationId",
                items: routeResult?.result
                        .map((e) => DropdownMenuItem<String>(
                            value: e.startStationId.toString(),
                            child: Text(
                              stationResult?.result
                                      .firstWhere((element) =>
                                          element.stationId == e.startStationId)
                                      .name ??
                                  "",
                            )))
                        .toList() ??
                    [],
                onChanged: (value) {
                  var station = stationResult?.result.firstWhere(
                      ((station) => station.stationId.toString() == value));
                  _selectedStationId = station?.stationId ?? 0;
                },
              ),
            ),
            const SizedBox(width: 15),
            const Text(
              "Datum:",
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
            ),
            const SizedBox(width: 15),
            Column(
              children: <Widget>[
                ElevatedButton(
                  style: ElevatedButton.styleFrom(
                    backgroundColor: Colors.white,
                    shape: BeveledRectangleBorder(
                        borderRadius: BorderRadius.circular(0.0),
                        side: const BorderSide(color: Colors.black)),
                    minimumSize: const Size(250, 40),
                  ),
                  onPressed: () => _selectDate(context),
                  child: Text(
                    '${formatDate(selectedDate)} ',
                    style: const TextStyle(color: Colors.black),
                  ),
                ),
              ],
            ),
            const SizedBox(width: 15),
            Flexible(
              child: ElevatedButton(
                onPressed: () async {
                  // Search:
                  // Set the filter for a date range covering the entire selected day
                  var filter = {
                    'StartStationIdGTE': _selectedStationId,
                    'DateGTE': DateTime(selectedDate.year, selectedDate.month,
                        selectedDate.day),
                  };
                  routeResultForTime = await routeProvider.get(filter: filter);
                  setState(() {});
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(2.0),
                  ),
                  minimumSize: const Size(100, 65),
                ),
                child: const Text("Pretraga", style: TextStyle(fontSize: 18)),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildResultView() {
    return Expanded(
      child: SingleChildScrollView(
        child: FormBuilder(
            child: Column(
          children: [
            const SizedBox(
              height: 40,
            ),
            Container(
              color: Colors.black,
              width: double.infinity,
              child: DataTable(
                headingRowColor: MaterialStateColor.resolveWith(
                    (states) => const Color.fromRGBO(72, 156, 118, 100)),
                columns: const <DataColumn>[
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        'Vrijeme polaska',
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 18),
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        'Vrijeme dolaska',
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 18),
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        'Cilj',
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 18),
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        '',
                      ),
                    ),
                  ),
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        '',
                      ),
                    ),
                  ),
                ],
                rows: routeResultForTime?.result
                        .map(
                          (e) => DataRow(
                            cells: [
                              DataCell(Text(
                                formatTime(e.departure) ?? "",
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(Text(
                                formatTime(e.arrival) ?? "",
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(Text(
                                stationResult?.result
                                        .firstWhere((element) =>
                                            element.stationId == e.endStationId)
                                        .name ??
                                    "",
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),

                              //update
                              DataCell(IconButton(
                                onPressed: () {
                                  showDialog(
                                      context: context,
                                      builder: (BuildContext context) =>
                                          UpdateRouteDialog(
                                            route: e,
                                            // onRouteUpdated: refreshTable,
                                          ));
                                  /*if (result == true)
                                    refreshTable(); //refresh table with new data*/
                                },
                                icon: const Icon(
                                  Icons.tips_and_updates_rounded,
                                  color: Colors.white,
                                ),
                              )),

                              //delete
                              DataCell(
                                IconButton(
                                  onPressed: () async {
                                    await showDialog(
                                      context: context,
                                      builder: (dialogContext) {
                                        final startStationName = stationResult
                                                ?.result
                                                .firstWhere((station) =>
                                                    station.stationId ==
                                                    e.startStationId)
                                                .name ??
                                            "Unknown";
                                        final endStationName = stationResult
                                                ?.result
                                                .firstWhere((station) =>
                                                    station.stationId ==
                                                    e.endStationId)
                                                .name ??
                                            "Unknown";

                                        return AlertDialog(
                                          title: const Text(
                                            "Delete",
                                            style: TextStyle(
                                                fontWeight: FontWeight.bold),
                                          ),
                                          content: Text(
                                            "Da li želite obrisati rutu: $startStationName - $endStationName, s polaskom u ${formatDateTime(e.departure!)}?",
                                          ),
                                          actions: [
                                            TextButton(
                                              child: const Text(
                                                "OK",
                                                style: TextStyle(
                                                    color: Colors.black),
                                              ),
                                              onPressed: () async {
                                                Navigator.pop(dialogContext);
                                                try {
                                                  await routeProvider
                                                      .delete(e.routeId!);

                                                  await showDialog(
                                                    context: context,
                                                    builder:
                                                        (successDialogContext) =>
                                                            AlertDialog(
                                                      title: const Text(
                                                        "Success",
                                                        style: TextStyle(
                                                            color: Colors.green,
                                                            fontWeight:
                                                                FontWeight
                                                                    .bold),
                                                      ),
                                                      content: Text(
                                                        "Ruta $startStationName - $endStationName, s polaskom u ${formatDateTime(e.departure!)} je uspješno obrisana.",
                                                      ),
                                                      actions: [
                                                        TextButton(
                                                          onPressed: () =>
                                                              Navigator.pop(
                                                                  successDialogContext),
                                                          child: const Text(
                                                            "OK",
                                                            style: TextStyle(
                                                                color: Colors
                                                                    .black),
                                                          ),
                                                        ),
                                                      ],
                                                    ),
                                                  );
                                                } catch (error) {
                                                  String errorMessage =
                                                      "Greška prilikom brisanja rute.";

                                                  await showDialog(
                                                    context: context,
                                                    builder:
                                                        (errorDialogContext) =>
                                                            AlertDialog(
                                                      title: const Text(
                                                        "Error",
                                                        style: TextStyle(
                                                            color: Colors.red,
                                                            fontWeight:
                                                                FontWeight
                                                                    .bold),
                                                      ),
                                                      content: Text(
                                                        errorMessage,
                                                      ),
                                                      actions: [
                                                        TextButton(
                                                          onPressed: () =>
                                                              Navigator.pop(
                                                                  errorDialogContext),
                                                          child: const Text(
                                                            "OK",
                                                            style: TextStyle(
                                                                color: Colors
                                                                    .black),
                                                          ),
                                                        ),
                                                      ],
                                                    ),
                                                  );
                                                }
                                              },
                                            ),
                                            TextButton(
                                              child: const Text("Cancel",
                                                  style: TextStyle(
                                                      color: Colors.red)),
                                              onPressed: () => Navigator.pop(
                                                  dialogContext, false),
                                            ),
                                          ],
                                        );
                                      },
                                    );
                                  },
                                  icon: const Icon(Icons.delete_forever_rounded,
                                      color: Colors.white),
                                ),
                              )
                            ],
                          ),
                        )
                        .toList()
                        .cast<DataRow>() ??
                    [],
              ),
            ),
            const SizedBox(
              height: 15,
            ),
            ElevatedButton(
                onPressed: () async {
                  await showDialog(
                    context: context,
                    builder: (dialogAddContext) => RouteAddDialog(),
                  );
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(2.0),
                  ),
                  minimumSize: const Size(double.infinity, 65),
                ),
                child: const Text(
                  "Dodaj",
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                ))
          ],
        )),
      ),
    );
  }
}
