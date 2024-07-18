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
  RouteAddDialog({this.station, super.key});

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

  int _selectedStartStationId = 0;
  int _selectedEndStationId = 0;
  int _selectedVehicleId = 0;
  bool? isChecked = true;

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();
    vehicleProvider = context.read<VehicleProvider>();
    typeProvider = context.read<TypeProvider>();

    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    routeResult = await routeProvider.get();
    vehicleResult = await vehicleProvider.get();
    typeResult = await typeProvider.get();

    setState(() {
      // _selectedStartStationId = widget?.user?.userStatusId ?? 0;
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Dodavanje"),
      content: Container(
        width: 500,
        height: 510,
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
                    // initialValue: getInititalStatus(),
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
                    // initialValue: getInititalStatus(),
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
                    // initialValue: getInititalStatus(),
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
                        _selectTime(context);
                        print("Selektovano vrijeme: ${selectedTime}");
                        setState(() {});
                      },
                      child: Text(
                        '${formatTime(selectedDate)} ',
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
                        _selectTime(context);
                        print("Selektovano vrijeme: ${selectedTime}");
                        setState(() {});
                      },
                      child: Text(
                        '${formatTime(selectedDate)} ',
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
            Row(
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
            ),
            SizedBox(
              height: 25,
            ),
            // SizedBox(
            //   height: 20,
            // ),
            Row(
              children: [
                Expanded(
                    child: ElevatedButton(
                  onPressed: () async {
                    _formKey.currentState?.saveAndValidate();
                    var request = Map.from(_formKey.currentState!.value);
                    // Update userStatusId with the selected statusId
                    // request['userStatusId'] = _selectedStatusId;

                    // if (request['firstName'] == "AAA") {
                    //   request['firstName'] = "BBB";
                    // }

                    // if (widget.user != null) {
                    //   await userProvider.update(widget.user!.userId!, request);
                    //   Navigator.pop(context);
                    // }

                    // print("Testtt: ${widget.user!.userId!}, ${request}}");
                    // widget.onUpdate();

                    showDialog(
                        context: context,
                        builder: (context) => AlertDialog(
                              title: Text("Update"),
                              content: Text("Korisnik je ažuriran"),
                              actions: [
                                TextButton(
                                  child: Text(
                                    "OK",
                                    style: TextStyle(color: Colors.green),
                                  ),
                                  onPressed: () {
                                    Navigator.pop(context);
                                  },
                                )
                              ],
                            ));
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

  TimeOfDay selectedTime = TimeOfDay.now();

  Future<void> _selectTime(BuildContext context) async {
    final TimeOfDay? pickedTime = await showTimePicker(
        context: context,
        initialTime: selectedTime,
        builder: (BuildContext context, Widget? child) {
          // Make child optional (Widget? child)
          return MediaQuery(
            data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: false),
            child: child!,
          );
        });

    if (pickedTime != null && pickedTime != selectedTime) {
      selectedTime = pickedTime;
      setState(() {});
    }
  }
}
