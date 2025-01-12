import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/screens/manufacturer/manufacturer_lsit_screen.dart';
import 'package:eprijevoz_desktop/screens/route/route_add_screen.dart';
import 'package:eprijevoz_desktop/screens/route/route_update_screen.dart';
import 'package:eprijevoz_desktop/screens/station/station_list_screen.dart';
import 'package:eprijevoz_desktop/screens/ticket/ticket_list_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle_type/vehicle_type_list_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/route.dart';

class RouteListScreen extends StatefulWidget {
  final Station? station;
  final Route? route;

  const RouteListScreen({
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
  final _formKey = GlobalKey<FormBuilderState>();
  int selectedStationId = 0;
  bool isLoading = false;
  DateTime selectedDate = DateTime.now();

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    routeResult = await routeProvider.get();

    setState(() {
      isLoading = false;
    });

    try {
      var request = Map.from(_formKey.currentState?.value ?? {});
      routeResult = await routeProvider.get(filter: request);
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false;
      });
    }
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

  List<Route> getUniqueRoutes(List<Station> stations) {
    List<Route> result = [];
    if (routeResult != null) {
      result = filterDuplicates(routeResult!.result);

      result.sort((a, b) {
        final stationA = stations.firstWhere(
          (station) => station.stationId == a.startStationId,
        );
        final stationB = stations.firstWhere(
          (station) => station.stationId == b.startStationId,
        );
        return (stationA.name ?? '').compareTo(stationB.name ?? '');
      });
    }
    return result;
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
                "Za prikaz rezultata, neophodno je odabrati datum i traženu stanicu, te pritisnuti dugme "
                '"Pretraga"'
                ".",
                style: TextStyle(fontWeight: FontWeight.w400),
              ),
            ),
            const SizedBox(
              height: 20,
            ),
            _buildSearch(),
            isLoading
                ? const Center(child: CircularProgressIndicator())
                : _buildResultView()
          ],
        ));
  }

  void _refreshData() async {
    setState(() {
      isLoading = true;
    });
    try {
      // search:
      // set the filter for a date range covering the entire selected day
      var filter = {
        'StartStationIdGTE': selectedStationId,
        'DateGTE':
            DateTime(selectedDate.year, selectedDate.month, selectedDate.day),
      };
      routeResultForTime = await routeProvider.get(filter: filter);
      if (routeResultForTime?.count == 0) {
        await showDialog(
          context: context,
          builder: (context) => AlertDialog(
            title: const Text(
              "Warning",
              style:
                  TextStyle(color: Colors.orange, fontWeight: FontWeight.bold),
            ),
            content: const Text(
              "Nema pronađenog plana vožnje s zadatom pretragom.",
            ),
            actions: [
              TextButton(
                child: const Text("OK", style: TextStyle(color: Colors.black)),
                onPressed: () {
                  Navigator.pop(context);
                },
              ),
            ],
          ),
        );
      }
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  Widget _buildSearch() {
    return FormBuilder(
      key: _formKey,
      child: SizedBox(
        width: double.infinity,
        child: Row(
          children: [
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
            const Text(
              "Startna stanica:",
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
            ),
            const SizedBox(width: 15),
            Expanded(
              child: FormBuilderDropdown(
                name: "startStationId",
                items:
                    getUniqueRoutes(stationResult?.result ?? []).map((route) {
                  var station = stationResult?.result.firstWhere(
                    (element) => element.stationId == route.startStationId,
                  );
                  return DropdownMenuItem<String>(
                    value: route.startStationId?.toString(),
                    child: Text(
                      station?.name ?? "",
                    ),
                  );
                }).toList(),
                onChanged: (value) {
                  var station = stationResult?.result.firstWhere(
                      ((station) => station.stationId.toString() == value));
                  selectedStationId = station?.stationId ?? 0;
                },
              ),
            ),
            const SizedBox(width: 15),
            ElevatedButton(
              onPressed: () async {
                _refreshData();
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
              height: 20,
            ),
            Row(
              children: [
                // station
                TextButton(
                  onPressed: () => Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => const StationListScreen(),
                    ),
                  ),
                  child: Row(
                    children: [
                      Icon(
                        Icons.arrow_forward,
                        color: Colors.green.shade800,
                      ),
                      const SizedBox(width: 5),
                      Text(
                        "Sekcija stanice",
                        style: TextStyle(
                          color: Colors.green.shade800,
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.green.shade800,
                          decorationThickness: 1,
                        ),
                      ),
                    ],
                  ),
                ),
                // tickets
                TextButton(
                  onPressed: () => Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => const TicketListScreen(),
                    ),
                  ),
                  child: Row(
                    children: [
                      Icon(
                        Icons.arrow_forward,
                        color: Colors.green.shade800,
                      ),
                      const SizedBox(width: 5),
                      Text(
                        "Sekcija karte",
                        style: TextStyle(
                          color: Colors.green.shade800,
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.green.shade800,
                          decorationThickness: 1,
                        ),
                      ),
                    ],
                  ),
                ),
                // issued tickets
                TextButton(
                  onPressed: () => Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => const VehicleTypeListScreen(),
                    ),
                  ),
                  child: Row(
                    children: [
                      Icon(
                        Icons.arrow_forward,
                        color: Colors.green.shade800,
                      ),
                      const SizedBox(width: 5),
                      Text(
                        "Sekcija izdane karte",
                        style: TextStyle(
                          color: Colors.green.shade800,
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.green.shade800,
                          decorationThickness: 1,
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
            const SizedBox(
              height: 20,
            ),
            //
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
                                formatTime(e.departure),
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(Text(
                                formatTime(e.arrival),
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
                                            onDone: () => _refreshData(),
                                          ));
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
                                            .name;

                                        final endStationName = stationResult
                                            ?.result
                                            .firstWhere((station) =>
                                                station.stationId ==
                                                e.endStationId)
                                            .name;

                                        return AlertDialog(
                                          title: const Text(
                                            "Delete",
                                            style: TextStyle(
                                                fontWeight: FontWeight.bold),
                                          ),
                                          content: Text(
                                            "Da li želite obrisati rutu: $startStationName - $endStationName, s polaskom u ${formatDateTimeUI(e.departure!)}?",
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
                                                  setState(() {});
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
                                                        "Ruta $startStationName - $endStationName, s polaskom u ${formatDateTimeUI(e.departure!)} je uspješno obrisana.",
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
                                                      "Greška prilikom brisanja rute.\n$error";

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
                                                _refreshData();
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
                  showDialog(
                      context: context,
                      builder: (BuildContext context) => RouteAddDialog(
                            onDone: () => _refreshData(),
                          ));
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
