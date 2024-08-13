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

  //Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  int? _selectedStartStationId;
  int? _selectedEndStationId;

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();

    super.initState();

    _initialValue = {
      'startStationId': widget?.route?.startStationId?.toString(),
      'endStationId': widget?.route?.startStationId?.toString(),
      'stationId': widget?.station?.stationId?.toString(),
      //'departure': widget?.route?.departure?.toString(),
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
      //isLoading = false;
      _selectedStartStationId = widget?.route?.startStationId ?? 0;
      _selectedEndStationId = widget?.route?.endStationId ?? 0;
    });
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
            _buildResultVIew(),
          ],
        ),
      ),
    );
  }

  Widget _buildResultVIew() {
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
                    items: routeResult?.result
                            .map((e) => DropdownMenuItem<String>(
                                value: e.startStationId.toString(),
                                child: Text(
                                  stationResult?.result
                                          .firstWhere((element) =>
                                              element.stationId ==
                                              e.startStationId)
                                          .name ??
                                      "",
                                )))
                            .toList() ??
                        [],
                    onChanged: (value) {
                      var station = stationResult?.result.firstWhere(
                          ((station) => station.stationId.toString() == value));
                      _selectedStartStationId = station?.stationId ?? 0;
                    },
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
                    items: routeResult?.result
                            .map((e) => DropdownMenuItem<String>(
                                value: e.endStationId.toString(),
                                child: Text(
                                  stationResult?.result
                                          .firstWhere((element) =>
                                              element.stationId ==
                                              e.endStationId)
                                          .name ??
                                      "",
                                )))
                            .toList() ??
                        [],
                    onChanged: (value) {
                      var station = stationResult?.result.firstWhere(
                          ((station) => station.stationId.toString() == value));
                      _selectedEndStationId = station?.stationId ?? 0;
                    },
                  ),
                ),
              ),
            ],
          ),
          Row(
            children: [],
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
