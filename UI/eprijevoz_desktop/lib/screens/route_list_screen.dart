//import 'dart:ffi';
import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/route.dart';

class RouteListScreen extends StatefulWidget {
  Station? station;
  Route? route;

  RouteListScreen({
    super.key,
    this.station,
    this.route,
  });

  @override
  State<RouteListScreen> createState() => _RouteListScreenState();
}

class _RouteListScreenState extends State<RouteListScreen> {
  //late
  late RouteProvider routeProvider;
  late StationProvider stationProvider;
  //SearchResult
  SearchResult<Route>? routeResult;
  SearchResult<Station>? stationResult;
  SearchResult<Route>? routeResultForTime;

  //Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  //selected
  int _selectedStationId = 0;

  bool isLoading = true;

  DateTime selectedDate = DateTime.now();
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

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();

    super.initState();

    _initialValue = {
      'startStationId': widget?.route?.startStationId?.toString(),
      'stationId': widget?.station?.stationId?.toString(),
    };

    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    routeResult = await routeProvider.get();

    if (routeResult?.result != null) {
      routeResult!.result = filterDuplicates(routeResult!.result);
    }

    print("test: ${stationResult?.result.length}");
    print("dan: ${stationResult?.result.map((e) => e.name)}");

    print("noć: ${routeResult?.result.length}");
    print(
        "ludilo: ${routeResult?.result.map((e) => e.startStationId)} : ${routeResult?.result.map((e) => e.departure)}");

    setState(() {
      isLoading = false;
    });
  }

  List<Route> filterDuplicates(List<Route> data) {
    final seen = <int>{};
    return data
        .where((dataModel) => seen.add(dataModel.startStationId!))
        .toList();
  }

  Future refreshTable() async {
    routeResult = await routeProvider.get();
    routeResult?.result = filterDuplicates(routeResult!.result);

    //pretrazi ponovo rute za odabranu stanicu i datum
    var filter = {
      'StartStationIdGTE': _selectedStationId,
      'DateGTE': selectedDate
    };
    routeResultForTime = await routeProvider.get(filter: filter);
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
            SizedBox(
              height: 5,
            ),
            Align(
              alignment: Alignment.centerLeft,
              child: Text(
                "Za prikaz rezultata, neophodno je odabrati traženu stanicu i datum, te pritisnuti dugme "
                '"Pretraga"'
                ".",
                style: TextStyle(fontWeight: FontWeight.w400),
              ),
            ),
            SizedBox(
              height: 20,
            ),
            isLoading ? Container() : _buildSearch(),
            Expanded(child: _buildResultView())
          ],
        ));
  }

  TextEditingController _ftsStartStationController = TextEditingController();
  TextEditingController _ftsArrivalController = TextEditingController();

  Widget _buildSearch() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Row(children: [
        Text(
          "Startna stanica:",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        ),
        SizedBox(
          width: 15,
        ),
        Expanded(
          child: FormBuilderDropdown(
            name: "startStationId",
            //decoration: InputDecoration(labelText: "Odabir stanice"),
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
        SizedBox(width: 15),
        Text(
          "Datum:",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        ),
        SizedBox(
          width: 15,
        ),
        Column(
          children: <Widget>[
            //Text("${selectedDate.toLocal()}".split(' ')[0]),
            ElevatedButton(
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.white,
                shape: BeveledRectangleBorder(
                    borderRadius: BorderRadius.circular(0.0),
                    side: BorderSide(color: Colors.black)),
                minimumSize: Size(250, 40),
              ),
              onPressed: () => _selectDate(context),
              child: Text(
                '${formatDate(selectedDate)} ',
                style: TextStyle(color: Colors.black),
              ),
            ),
          ],
        ),
        //)
        // ),
        const SizedBox(
          width: 15,
        ),
        ElevatedButton(
          onPressed: () async {
            print("StartStationIdGTE: ${_selectedStationId}");
            print("DateGTE: ${selectedDate}");

            //Search:
            var filter = {
              'StartStationIdGTE': _selectedStationId,
              'DateGTE': selectedDate
            };
            routeResultForTime = await routeProvider.get(filter: filter);
            print(
                "tetsni: ${routeResultForTime?.result.map((e) => e.startStationId)}");

            setState(() {});

            //_ftsRegistrationMarkController.clear();
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
      ]),
    );
  }

  Widget _buildResultView() {
    return Expanded(
      child: SingleChildScrollView(
        child: FormBuilder(
            child: Column(
          children: [
            SizedBox(
              height: 40,
            ),
            Container(
              color: Colors.black,
              width: double.infinity,
              child: DataTable(
                headingRowColor: MaterialStateColor.resolveWith(
                    (states) => Color.fromRGBO(72, 156, 118, 100)),
                columns: const <DataColumn>[
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        'Vrijeme',
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
                                formatTime(e.arrival) ?? "",
                                style: TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(IconButton(
                                onPressed: () {
                                  //code
                                },
                                icon: const Icon(
                                  Icons.tips_and_updates_rounded,
                                  color: Colors.white,
                                ),
                              )),
                              DataCell(IconButton(
                                onPressed: () {
                                  showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                            title: Text("Delete"),
                                            content: Text(
                                                "Da li želite obrisati odabranu stanicu, s polaskom u ${formatTime(e.departure)}?"),
                                            actions: [
                                              TextButton(
                                                  child: Text(
                                                    "OK",
                                                    style: TextStyle(
                                                        color: Colors.green),
                                                  ),
                                                  onPressed: () async {
                                                    Navigator.pop(context);
                                                    bool success =
                                                        await routeProvider
                                                            .delete(e.routeId!);
                                                    showDialog(
                                                        context: context,
                                                        builder:
                                                            (deleteDialogContext) =>
                                                                AlertDialog(
                                                                  title: Text(success
                                                                      ? "Success"
                                                                      : "Error"),
                                                                  content: Text(success
                                                                      ? "Odabrana stanica s polaskom u ${formatTime(e.departure)}, uspješno obrisana."
                                                                      : "Odabrana stanica s polaskom u ${formatTime(e.departure)}, nije obrisana."),
                                                                  actions: [
                                                                    TextButton(
                                                                      child:
                                                                          Text(
                                                                        "OK",
                                                                        style: TextStyle(
                                                                            color:
                                                                                Colors.green),
                                                                      ),
                                                                      onPressed:
                                                                          () {
                                                                        Navigator.pop(
                                                                            deleteDialogContext);
                                                                        refreshTable();
                                                                      },
                                                                    )
                                                                  ],
                                                                ));
                                                  }),
                                              TextButton(
                                                  child: Text(
                                                    "Cancel",
                                                    style: TextStyle(
                                                        color: Colors.red),
                                                  ),
                                                  onPressed: () =>
                                                      Navigator.pop(context))
                                            ],
                                          ));
                                },
                                icon: const Icon(
                                  Icons.delete_forever_rounded,
                                  color: Colors.white,
                                ),
                              )),
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
                onPressed: () {},
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
          //),
          //],
        )),
      ),
    );
  }
}
