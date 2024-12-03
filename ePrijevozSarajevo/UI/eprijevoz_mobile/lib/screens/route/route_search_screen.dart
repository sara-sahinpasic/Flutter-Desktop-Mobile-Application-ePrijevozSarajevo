import 'dart:convert';

import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/route/route_options_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class RouteSearchScreen extends StatefulWidget {
  Station? station;
  Route? route;
  RouteSearchScreen({super.key, this.station, this.route});

  @override
  State<RouteSearchScreen> createState() => _RouteSearchScreenState();
}

class _RouteSearchScreenState extends State<RouteSearchScreen> {
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  int? selectedStartStationId;
  int? selectedEndStationId;
  List<Station> uniqueStartStations = [];
  List<Station> endStations = [];
  DateTime selectedDepartureDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();
  bool isLoading = false;

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();

    super.initState();

    _initialValue = {
      'startStationId': widget.route?.startStationId?.toString(),
      'endStationId': widget.route?.endStationId?.toString(),
      'stationId': widget.station?.stationId?.toString(),
      'routeId': widget.route?.routeId.toString()
    };

    initForm();
  }

  Future initForm() async {
    setState(() {
      isLoading = true;
    });

    try {
      stationResult = await stationProvider.get();
      routeResult = await routeProvider.get();
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false;
      });
    }

    if (routeResult?.result != null) {
      routeResult!.result = filterDuplicates(routeResult!.result);
    }

    setState(() {
      // filter unique start stations
      uniqueStartStations =
          getUniqueStartStations(routeResult!.result, stationResult!.result);

      // populate end stations based on the selected start station if any
      if (widget.route?.startStationId != null &&
          widget.route!.startStationId! > 0) {
        selectedStartStationId = widget.route!.startStationId!;
        endStations =
            getEndStationsForSelectedStartStation(selectedStartStationId!);
      } else {
        selectedStartStationId = null;
        selectedEndStationId = null;
      }
    });
  }

  List<Station> getUniqueStartStations(
      List<Route> routes, List<Station> stations) {
    final seenStationIds = <int>{};
    return routes
        .where((route) => seenStationIds.add(route.startStationId!))
        .map((route) => stations
            .firstWhere((station) => station.stationId == route.startStationId))
        .toList();
  }

  List<Station> getEndStationsForSelectedStartStation(int startStationId) {
    return routeResult?.result
            .where((route) => route.startStationId == startStationId)
            .map((route) => stationResult?.result.firstWhere(
                (station) => station.stationId == route.endStationId))
            .where((station) => station != null)
            .cast<Station>()
            .toList() ??
        [];
  }

  List<Route> filterDuplicates(List<Route> data) {
    final seen = <Tuple<int, int>>{};
    return data
        .where((dataModel) =>
            seen.add(Tuple(dataModel.startStationId!, dataModel.endStationId!)))
        .toList();
  }

  Future<void> selectDepartureDateTime(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: selectedDepartureDate,
      firstDate: DateTime(2000),
      lastDate: DateTime(2100),
    );

    if (pickedDate != null) {
      final TimeOfDay? pickedTime = await showTimePicker(
        context: context,
        initialTime: selectedTime,
      );

      if (pickedTime != null) {
        final DateTime fullPickedDateTime = DateTime(
          pickedDate.year,
          pickedDate.month,
          pickedDate.day,
          pickedTime.hour,
          pickedTime.minute,
        );

        setState(() {
          selectedDepartureDate = fullPickedDateTime;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          children: [
            isLoading
                ? const Center(child: CircularProgressIndicator())
                : _buildResultView(),
          ],
        ),
      ),
    );
  }

  Widget _buildResultView() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Column(
        children: [
          const SizedBox(
            height: 20,
          ),
          Center(
              child: SizedBox(
            width: 200,
            height: 140,
            child: IconButton(
              onPressed: () {},
              icon: const Icon(
                Icons.location_on,
                color: Colors.black,
                size: 100,
              ),
            ),
          )),
          Row(
            children: [
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(
                      20.0, 15.0, 20.0, 0.0), // left, top, right, bottom
                  child: FormBuilderDropdown(
                    name: "startStationId",
                    decoration: const InputDecoration(
                      label: Text("Polazna stanica"),
                    ),
                    items: uniqueStartStations
                        .map((station) => DropdownMenuItem<String>(
                            value: station.stationId.toString(),
                            child: Text(station.name ?? "")))
                        .toList(),
                    onChanged: (value) {
                      setState(() {
                        selectedStartStationId = int.tryParse(value.toString());
                        endStations = selectedStartStationId != null
                            ? getEndStationsForSelectedStartStation(
                                selectedStartStationId!)
                            : [];
                        selectedEndStationId = null; // Reset end station
                      });
                    },
                    initialValue: selectedStartStationId?.toString(),
                  ),
                ),
              ),
            ],
          ),
          Row(
            children: [
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(
                      20.0, 10.0, 20.0, 0.0), // left, top, right, bottom
                  child: FormBuilderDropdown(
                    name: "endStationId",
                    decoration: const InputDecoration(
                      label: Text("Cilj"),
                    ),
                    items: endStations
                        .map((station) => DropdownMenuItem<String>(
                            value: station.stationId.toString(),
                            child: Text(station.name ?? "")))
                        .toList(),
                    onChanged: (value) {
                      var station = stationResult?.result.firstWhere(
                          ((station) => station.stationId.toString() == value));
                      selectedEndStationId = station?.stationId ?? 0;
                    },
                    initialValue: selectedEndStationId?.toString(),
                  ),
                ),
              ),
            ],
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(
                20.0, 30.0, 20.0, 0.0), // left, top, right, bottom
            child: Row(
              children: [
                SizedBox(
                  width: 370,
                  height: 50,
                  child: ElevatedButton(
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.white,
                      shape: BeveledRectangleBorder(
                          borderRadius: BorderRadius.circular(0.0),
                          side: const BorderSide(color: Colors.black)),
                      minimumSize: const Size(250, 40),
                    ),
                    onPressed: () async {
                      await selectDepartureDateTime(context);
                      setState(() {});
                    },
                    child: Text(
                      '${formatDateTime(selectedDepartureDate)} ',
                      style: const TextStyle(color: Colors.black),
                    ),
                  ),
                ),
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(
                20.0, 20.0, 20.0, 0.0), // left, top, right, bottom
            child: Row(
              children: [
                SizedBox(
                  width: 370,
                  height: 50,
                  child: ElevatedButton(
                      onPressed: () async {
                        setState(() {
                          isLoading = true;
                        });

                        try {
                          var filter = {
                            'StartStationIdGTE': selectedStartStationId,
                            'EndStationIdGTE': selectedEndStationId,
                            'DateGTE': selectedDepartureDate
                          };
                          routeResult = await routeProvider.get(filter: filter);
                        } catch (e) {
                          debugPrint('Error: $e');
                        } finally {
                          setState(() {
                            isLoading = false;
                          });
                        }

                        if (routeResult?.result != null) {
                          const JsonEncoder.withIndent('  ')
                              .convert(routeResult!.result);
                        }

                        if (routeResult != null &&
                            routeResult!.result.isNotEmpty) {
                          Navigator.of(context).push(MaterialPageRoute(
                              builder: (context) => RouteOptionsScreen(
                                  routes: routeResult!
                                      .result))); // send founded routes on another screen
                        } else {
                          showDialog(
                            context: context,
                            builder: (BuildContext context) {
                              return AlertDialog(
                                title: const Text("Nema pronađenih ruta."),
                                content: const Text(
                                    "Molimo, pokušajte drugačiju pretragu."),
                                actions: [
                                  TextButton(
                                    onPressed: () {
                                      Navigator.of(context).pop();
                                    },
                                    child: const Text(
                                      "OK",
                                      style: TextStyle(color: Colors.black),
                                    ),
                                  ),
                                ],
                              );
                            },
                          );
                        }
                      },
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.black,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0),
                        ),
                        padding: const EdgeInsets.symmetric(vertical: 10.0),
                      ),
                      child: const Text(
                        "Pretraži",
                        style: TextStyle(fontSize: 19),
                      )),
                )
              ],
            ),
          )
        ],
      ),
    );
  }
}

class Tuple<T1, T2> {
  final T1 item1;
  final T2 item2;

  Tuple(this.item1, this.item2);

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is Tuple &&
          runtimeType == other.runtimeType &&
          item1 == other.item1 &&
          item2 == other.item2;

  @override
  int get hashCode => item1.hashCode ^ item2.hashCode;
}
