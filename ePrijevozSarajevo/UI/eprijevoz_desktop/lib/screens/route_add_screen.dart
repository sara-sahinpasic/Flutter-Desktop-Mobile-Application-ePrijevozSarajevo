import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class RouteAddDialog extends StatefulWidget {
  Station? station;
  Vehicle? vehicle;
  Route? route;
  RouteAddDialog({this.station, this.vehicle, this.route, super.key});

  @override
  State<RouteAddDialog> createState() => _RouteAddDialogState();
}

class _RouteAddDialogState extends State<RouteAddDialog> {
  //Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  SearchResult<Route>? routeResult;
  SearchResult<Station>? stationResult;
  SearchResult<Vehicle>? vehicleResult;
  SearchResult<Type>? typeResult;

  late StationProvider stationProvider;
  late RouteProvider routeProvider;
  late VehicleProvider vehicleProvider;
  late TypeProvider typeProvider;

  int? _selectedStartStationId;
  int? _selectedEndStationId;
  int? _selectedVehicleId;
  bool? isChecked = true;

  DateTime selectedDepartureDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();
  //
  DateTime selectedArrivalDate = DateTime.now();

  @override
  void initState() {
    super.initState();
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();
    vehicleProvider = context.read<VehicleProvider>();
    typeProvider = context.read<TypeProvider>();

    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    vehicleResult = await vehicleProvider.get();
    typeResult = await typeProvider.get();

    setState(() {
      _selectedStartStationId = widget?.route?.startStationId ??
          (stationResult?.result.isNotEmpty ?? false
              ? stationResult!.result.first.stationId
              : null);

      _selectedEndStationId = widget?.route?.endStationId ??
          (stationResult?.result.isNotEmpty ?? false
              ? stationResult!.result.first.stationId
              : null);

      _selectedVehicleId = widget?.route?.vehicleId ??
          (vehicleResult?.result.isNotEmpty ?? false
              ? vehicleResult!.result.first.vehicleId
              : null);

      _initialValue = {
        'startStationId': widget?.route?.startStationId,
        'endStationId': widget?.route?.endStationId,
        'vehicleId': widget?.route?.vehicleId,
        'arrival': widget?.route?.arrival,
        'departure': widget?.route?.departure
      };
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Nova ruta"),
      content: Container(
        width: 500,
        height: 410,
        child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(children: [
            SizedBox(
              height: 15,
            ),
            Row(
              children: [
                const Text(
                  "Polazna stanica:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                ),
                const SizedBox(
                  width: 85,
                ),
                Expanded(
                  child: FormBuilderDropdown(
                    name: "startStationId",
                    items: getStation(),
                    initialValue: _selectedStartStationId?.toString(),
                    onChanged: (value) {
                      setState(() {
                        _selectedStartStationId = int.parse(value as String);
                      });
                    },
                  ),
                ),
              ],
            ),
            SizedBox(
              height: 15,
            ),
            Row(
              children: [
                const Text(
                  "Ciljna stanica:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                ),
                const SizedBox(
                  width: 100,
                ),
                Expanded(
                  child: FormBuilderDropdown(
                    name: "endStationId",
                    items: getStation(),
                    initialValue: _selectedEndStationId?.toString(),
                    onChanged: (value) {
                      setState(() {
                        _selectedEndStationId = int.parse(value as String);
                      });
                    },
                  ),
                ),
              ],
            ),
            SizedBox(
              height: 15,
            ),
            Row(
              children: [
                const Text(
                  "Vozilo:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                ),
                const SizedBox(
                  width: 150,
                ),
                Expanded(
                  child: FormBuilderDropdown(
                    name: "vehicleId",
                    items: getVehicle(),
                    initialValue: _selectedVehicleId?.toString(),
                    onChanged: (value) {
                      setState(() {
                        _selectedVehicleId = int.parse(value as String);
                      });
                    },
                  ),
                ),
              ],
            ),
            SizedBox(
              height: 35,
            ),
            Row(
              children: [
                const Text(
                  "Vrijeme polaska:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                ),
                const SizedBox(
                  width: 10,
                ),
                Expanded(
                    child: Column(
                  children: [
                    ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.white,
                        shape: BeveledRectangleBorder(
                            borderRadius: BorderRadius.circular(0.0),
                            side: BorderSide(color: Colors.black)),
                        minimumSize: Size(250, 40),
                      ),
                      onPressed: () async {
                        /* _selectTime(context);
                        print("Selektovano vrijeme: ${selectedTime}");
                        setState(() {});*/
                        await _selectDepartureDateTime(context);
                        print("Selected DateTime: ${selectedDepartureDate}");
                        setState(() {});
                      },
                      child: Text(
                        /* '${formatTime(selectedDate)} ',
                        style: TextStyle(color: Colors.black),*/
                        '${formatDateTime(selectedDepartureDate)} ',
                        style: TextStyle(color: Colors.black),
                      ),
                    ),
                  ],
                )),
              ],
            ),
            SizedBox(
              height: 25,
            ),
            Row(
              children: [
                const Text(
                  "Vrijeme dolaska:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                ),
                const SizedBox(
                  width: 10,
                ),
                Expanded(
                    child: Column(
                  children: [
                    ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.white,
                        shape: BeveledRectangleBorder(
                            borderRadius: BorderRadius.circular(0.0),
                            side: BorderSide(color: Colors.black)),
                        minimumSize: Size(250, 40),
                      ),
                      onPressed: () async {
                        /* _selectTime(context);
                        print("Selektovano vrijeme: ${selectedTime}");
                        setState(() {});*/
                        await _selectArrivalDateTime(context);
                        print("Selected DateTime: ${selectedArrivalDate}");
                        setState(() {});
                      },
                      child: Text(
                        /*'${formatTime(selectedDate)} ',
                        style: TextStyle(color: Colors.black),*/
                        '${formatDateTime(selectedArrivalDate)} ',
                        style: TextStyle(color: Colors.black),
                      ),
                    ),
                  ],
                )),
              ],
            ),
            SizedBox(
              height: 15,
            ),
            /* Row(
              children: [
                Expanded(
                    child: CheckboxListTile(
                  title: Text("Aktivna ruta vikendima?"),
                  value: isChecked,
                  onChanged: (newValue) {
                    setState(() {
                      isChecked = newValue;
                    });
                  },
                  controlAffinity:
                      ListTileControlAffinity.leading, //  <-- leading Checkbox
                )),
              ],
            ),
            // SizedBox(
            //   height: 15,
            // ),
            Row(
              children: [
                Expanded(
                    child: CheckboxListTile(
                  title: Text("Aktivna ruta praznicima?"),
                  value: isChecked,
                  onChanged: (newValue) {
                    setState(() {
                      isChecked = newValue;
                    });
                  },
                  controlAffinity:
                      ListTileControlAffinity.leading, //  <-- leading Checkbox
                )),
              ],
            ),*/
            SizedBox(
              height: 25,
            ),
            Row(
              children: [
                Expanded(
                    child: ElevatedButton(
                  onPressed: () async {
                    if (_formKey.currentState?.saveAndValidate() ?? false) {
                      var request = {
                        'startStationId': _selectedStartStationId,
                        'endStationId': _selectedEndStationId,
                        'vehicleId': _selectedVehicleId,
                        'arrival': formatDateTime(selectedArrivalDate),
                        'departure': formatDateTime(selectedDepartureDate),
                      };

                      try {
                        await routeProvider.insert(request);
                        showDialog(
                          context: context,
                          builder: (context) => AlertDialog(
                            title: Text("Success"),
                            content: Text("Ruta je uspješno dodana."),
                            actions: [
                              TextButton(
                                child: Text("OK",
                                    style: TextStyle(color: Colors.green)),
                                onPressed: () {
                                  setState(() {});
                                  //Navigator.pop(context);
                                  Navigator.pop(context,
                                      true); // Close the dialog and return success
                                },
                              ),
                            ],
                          ),
                        );
                      } catch (error) {
                        showDialog(
                          context: context,
                          builder: (context) => AlertDialog(
                            title: Text("Error"),
                            content: Text("Greška prilikom dodavanja rute."),
                            actions: [
                              TextButton(
                                child: Text("OK",
                                    style: TextStyle(color: Colors.red)),
                                onPressed: () {
                                  Navigator.pop(context);
                                },
                              ),
                            ],
                          ),
                        );
                      }
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(2.0),
                    ),
                    minimumSize: const Size(100, 65),
                  ),
                  child: const Text("Dodaj", style: TextStyle(fontSize: 18)),
                )),
              ],
            ),
          ]),
        ),
      ),
      actions: [
        TextButton(
            onPressed: () => Navigator.pop(context),
            child: Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }

  Future<void> _selectDepartureDateTime(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: selectedDepartureDate,
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
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

  Future<void> _selectArrivalDateTime(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: selectedArrivalDate,
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
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
          selectedArrivalDate = fullPickedDateTime;
        });
      }
    }
  }

  // String formatDateTime(DateTime dateTime) {
  //   return "${dateTime.year}-${dateTime.month.toString().padLeft(2, '0')}-${dateTime.day.toString().padLeft(2, '0')} ${dateTime.hour.toString().padLeft(2, '0')}:${dateTime.minute.toString().padLeft(2, '0')}";
  // }

  //

  List<DropdownMenuItem<String>> getStation() {
    var list = stationResult?.result
            .map((item) => DropdownMenuItem(
                value: item.stationId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  List<DropdownMenuItem<String>> getVehicle() {
    var list = typeResult?.result
            .map((item) => DropdownMenuItem(
                value: item.typeId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }
}
