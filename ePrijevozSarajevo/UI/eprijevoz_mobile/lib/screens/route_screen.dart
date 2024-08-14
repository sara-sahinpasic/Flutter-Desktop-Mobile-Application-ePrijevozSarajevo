import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class RouteScreen extends StatefulWidget {
  Station? station;
  Route? route;
  RouteScreen({super.key, this.station, this.route});

  @override
  State<RouteScreen> createState() => _RouteScreenState();
}

class _RouteScreenState extends State<RouteScreen> {
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;

  // Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  int? _selectedStartStationId;
  int? _selectedEndStationId;

  List<Station> uniqueStartStations = [];
  List<Station> endStations = [];

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();

    super.initState();

    _initialValue = {
      'startStationId': widget?.route?.startStationId?.toString(),
      'endStationId': widget?.route?.endStationId?.toString(),
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

    setState(() {
      // Filter unique start stations
      uniqueStartStations =
          getUniqueStartStations(routeResult!.result, stationResult!.result);

      // Populate end stations based on the selected start station if any
      if (widget.route?.startStationId != null &&
          widget.route!.startStationId! > 0) {
        _selectedStartStationId = widget.route!.startStationId!;
        endStations =
            getEndStationsForSelectedStartStation(_selectedStartStationId!);
      } else {
        _selectedStartStationId = null;
        _selectedEndStationId = null;
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
            ?.where((route) => route.startStationId == startStationId)
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

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Container(
        child: Column(
          children: [
            _buildResultView(),
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
            height: 50,
          ),
          Center(
            child: SizedBox(
                width: 200,
                height: 140,
                child: Image.asset("assets/images/location_logo.png",
                    height: 100, width: 100)),
          ),
          Row(
            children: [
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(
                      30.0, 30.0, 30.0, 0.0), // left, top, right, bottom
                  child: FormBuilderDropdown(
                    name: "startStationId",
                    decoration: InputDecoration(
                      label: Text("Polazna stanica"),
                    ),
                    items: uniqueStartStations
                        .map((station) => DropdownMenuItem<String>(
                            value: station.stationId.toString(),
                            child: Text(station.name ?? "")))
                        .toList(),
                    onChanged: (value) {
                      setState(() {
                        _selectedStartStationId =
                            int.tryParse(value.toString()) ?? null;
                        endStations = _selectedStartStationId != null
                            ? getEndStationsForSelectedStartStation(
                                _selectedStartStationId!)
                            : [];
                        _selectedEndStationId = null; // Reset end station
                      });
                    },
                    initialValue: _selectedStartStationId?.toString(),
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
                      30.0, 30.0, 30.0, 0.0), // left, top, right, bottom
                  child: FormBuilderDropdown(
                    name: "endStationId",
                    decoration: InputDecoration(
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
                      _selectedEndStationId = station?.stationId ?? 0;
                    },
                    initialValue: _selectedEndStationId?.toString(),
                  ),
                ),
              ),
            ],
          ),
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
