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
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class RouteAddDialog extends StatefulWidget {
  final Station? station;
  final Vehicle? vehicle;
  final Route? route;
  final Function onDone;

  const RouteAddDialog({
    super.key,
    this.station,
    this.vehicle,
    this.route,
    required this.onDone,
  });

  @override
  State<RouteAddDialog> createState() => _RouteAddDialogState();
}

class _RouteAddDialogState extends State<RouteAddDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  SearchResult<Route>? routeResult;
  SearchResult<Station>? stationResult;
  SearchResult<Vehicle>? vehicleResult;
  SearchResult<Type>? typeResult;
  late StationProvider stationProvider;
  late RouteProvider routeProvider;
  late VehicleProvider vehicleProvider;
  late TypeProvider typeProvider;
  int? selectedStartStationId;
  int? selectedEndStationId;
  int? selectedVehicleId;
  bool? isChecked = true;
  bool isLoading = true;
  DateTime selectedDepartureDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();
  DateTime selectedArrivalDate = DateTime.now();

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();
    vehicleProvider = context.read<VehicleProvider>();
    typeProvider = context.read<TypeProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    vehicleResult = await vehicleProvider.get();
    typeResult = await typeProvider.get();

    setState(() {
      isLoading = false;

      selectedStartStationId = widget.route?.startStationId ??
          (stationResult?.result.isNotEmpty ?? false
              ? stationResult!.result.first.stationId
              : null);

      selectedEndStationId = widget.route?.endStationId ??
          (stationResult?.result.isNotEmpty ?? false
              ? stationResult!.result.first.stationId
              : null);

      selectedVehicleId = widget.route?.vehicleId ??
          (vehicleResult?.result.isNotEmpty ?? false
              ? vehicleResult!.result.first.vehicleId
              : null);
    });
  }

  Future<void> selectDepartureDateTime(BuildContext context) async {
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

  Future<void> selectArrivalDateTime(BuildContext context) async {
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

  List<DropdownMenuItem<String>> getStation() {
    final sortedStations = stationResult?.result ?? [];

    // sort stations by their names
    sortedStations.sort((a, b) => (a.name ?? '').compareTo(b.name ?? ''));

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

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(
        "Nova ruta",
        style: TextStyle(fontWeight: FontWeight.bold),
      ),
      content: SingleChildScrollView(
        child: SizedBox(
          width: 500,
          child: isLoading
              ? const Center(
                  child: CircularProgressIndicator(),
                )
              : FormBuilder(
                  key: _formKey,
                  child: Column(children: [
                    const SizedBox(
                      height: 15,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Polazna stanica:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 85,
                        ),
                        Expanded(
                          child: FormBuilderDropdown(
                            name: "startStationId",
                            items: getStation(),
                            initialValue: selectedStartStationId?.toString(),
                            onChanged: (value) {
                              setState(() {
                                selectedStartStationId =
                                    int.parse(value as String);
                              });
                            },
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Odaberite polaznu stanicu."),
                            ]),
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Ciljna stanica:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 100,
                        ),
                        Expanded(
                          child: FormBuilderDropdown(
                            name: "endStationId",
                            items: getStation(),
                            initialValue: selectedEndStationId?.toString(),
                            onChanged: (value) {
                              setState(() {
                                selectedEndStationId =
                                    int.parse(value as String);
                              });
                            },
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Odaberite ciljnu stanicu."),
                            ]),
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Vozilo:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 150,
                        ),
                        Expanded(
                          child: FormBuilderDropdown(
                            name: "vehicleId",
                            items: getVehicle(),
                            initialValue: selectedVehicleId?.toString(),
                            onChanged: (value) {
                              setState(() {
                                selectedVehicleId = int.parse(value as String);
                              });
                            },
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Odaberite vozilo."),
                            ]),
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(
                      height: 35,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Vrijeme polaska:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
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
                                    side:
                                        const BorderSide(color: Colors.black)),
                                minimumSize: const Size(250, 40),
                              ),
                              onPressed: () async {
                                await selectDepartureDateTime(context);
                                setState(() {});
                              },
                              child: Text(
                                formatDateTimeUI(selectedDepartureDate),
                                style: const TextStyle(color: Colors.black),
                              ),
                            ),
                          ],
                        )),
                      ],
                    ),
                    const SizedBox(
                      height: 25,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Vrijeme dolaska:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
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
                                    side:
                                        const BorderSide(color: Colors.black)),
                                minimumSize: const Size(250, 40),
                              ),
                              onPressed: () async {
                                await selectArrivalDateTime(context);
                                setState(() {});
                              },
                              child: Text(
                                formatDateTimeUI(selectedArrivalDate),
                                style: const TextStyle(color: Colors.black),
                              ),
                            ),
                          ],
                        )),
                      ],
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    Row(
                      children: [
                        Expanded(
                            child: ElevatedButton(
                          onPressed: () async {
                            if (_formKey.currentState?.saveAndValidate() ??
                                false) {
                              var request =
                                  Map.from(_formKey.currentState!.value);

                              request['startStationId'] =
                                  selectedStartStationId;
                              request['endStationId'] = selectedEndStationId;
                              request['vehicleId'] = selectedVehicleId;
                              selectedEndStationId;
                              request['arrival'] =
                                  formatDateTimeAPI(selectedArrivalDate);
                              request['departure'] =
                                  formatDateTimeAPI(selectedDepartureDate);

                              try {
                                setState(() {
                                  isLoading = true;
                                });

                                await routeProvider.insert(request);
                                await showDialog(
                                  context: context,
                                  builder: (dialogContext) => AlertDialog(
                                    title: const Text(
                                      "Success",
                                      style: TextStyle(
                                          fontWeight: FontWeight.bold,
                                          color: Colors.green),
                                    ),
                                    content:
                                        const Text("Ruta je uspješno dodana."),
                                    actions: [
                                      TextButton(
                                        child: const Text(
                                          "OK",
                                          style: TextStyle(color: Colors.black),
                                        ),
                                        onPressed: () async {
                                          await widget.onDone();
                                          Navigator.pop(dialogContext);
                                          Navigator.pop(dialogContext, true);
                                        },
                                      ),
                                    ],
                                  ),
                                );
                              } catch (error) {
                                showDialog(
                                  context: context,
                                  builder: (dialogContext) => AlertDialog(
                                    title: const Text(
                                      "Error",
                                      style: TextStyle(
                                          color: Colors.red,
                                          fontWeight: FontWeight.bold),
                                    ),
                                    content: Text(
                                        "Greška prilikom dodavanja rute.->\n$error"),
                                    actions: [
                                      TextButton(
                                        child: const Text(
                                          "OK",
                                          style: TextStyle(color: Colors.black),
                                        ),
                                        onPressed: () {
                                          Navigator.pop(dialogContext, false);
                                        },
                                      ),
                                    ],
                                  ),
                                );
                              } finally {
                                setState(() {
                                  isLoading = false;
                                });
                              }
                            }
                          },
                          style: ElevatedButton.styleFrom(
                            backgroundColor:
                                const Color.fromRGBO(72, 156, 118, 100),
                            shape: RoundedRectangleBorder(
                              borderRadius: BorderRadius.circular(2.0),
                            ),
                            minimumSize: const Size(100, 65),
                          ),
                          child: const Text("Dodaj",
                              style: TextStyle(fontSize: 18)),
                        )),
                      ],
                    ),
                  ]),
                ),
        ),
      ),
      actions: [
        TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }
}
