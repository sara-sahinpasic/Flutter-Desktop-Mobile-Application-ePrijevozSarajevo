import 'package:eprijevoz_desktop/models/malfunction.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/malfunction_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class MalfunctionAddScreen extends StatefulWidget {
  final Function onDone;
  const MalfunctionAddScreen({required this.onDone, super.key});

  @override
  State<MalfunctionAddScreen> createState() => _MalfunctionAddScreenState();
}

class _MalfunctionAddScreenState extends State<MalfunctionAddScreen> {
  late MalfunctionProvider malfunctionProvider;
  SearchResult<Malfunction>? malfunctionResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  late VehicleProvider vehicleProvider;
  SearchResult<Vehicle>? vehicleResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  int? selectedVehicleId;
  int? selectedStationId;
  bool? isFixed = false;
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  int? currentUserId;

  @override
  void initState() {
    malfunctionProvider = context.read<MalfunctionProvider>();
    vehicleProvider = context.read<VehicleProvider>();
    stationProvider = context.read<StationProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    malfunctionResult = await malfunctionProvider.get();
    vehicleResult = await vehicleProvider.get();
    stationResult = await stationProvider.get();
    userResult = await userProvider.get();

    currentUserId = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username)
        .userId;

    setState(() {
      isLoading = false;
    });
  }

  DateTime? dateOfMalfunction;
  final TextEditingController _dateOfMalfunctionController =
      TextEditingController();
  Future<void> selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: dateOfMalfunction ?? DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime(2100),
    );

    if (picked != null && picked != dateOfMalfunction) {
      setState(() {
        dateOfMalfunction = picked;
        _dateOfMalfunctionController.text = formatDate(picked);
      });
    }
  }

  List<DropdownMenuItem<String>> getVehicle() {
    var list = vehicleResult?.result
            .map((item) => DropdownMenuItem(
                value: item.vehicleId.toString(),
                child: Text(item.registrationNumber ?? "")))
            .toList() ??
        [];
    return list;
  }

  List<DropdownMenuItem<String>> getStatione() {
    var list = stationResult?.result
            .map((item) => DropdownMenuItem(
                value: item.stationId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(
        "Novi zapis",
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
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(height: 15),
                      const Text(
                        "Opis kvara:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderTextField(
                        name: 'description',
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Ovo polje ne može bit prazno.",
                          ),
                        ]),
                        maxLines: 2,
                        keyboardType: TextInputType.multiline,
                        cursorColor: Colors.green.shade800,
                        decoration: const InputDecoration(
                          enabledBorder: OutlineInputBorder(
                            borderSide: BorderSide(color: Colors.black),
                            borderRadius: BorderRadius.only(
                              topLeft: Radius.circular(10),
                              topRight: Radius.circular(10),
                              bottomLeft: Radius.circular(10),
                              bottomRight: Radius.circular(10),
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 25),
                      const Text(
                        "Datum kvara:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      const SizedBox(height: 5),
                      GestureDetector(
                        onTap: () => selectDate(context),
                        child: AbsorbPointer(
                            child: FormBuilderTextField(
                                name: 'dateOfMalufunction',
                                controller: _dateOfMalfunctionController,
                                validator: FormBuilderValidators.compose([
                                  FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno.",
                                  ),
                                ]),
                                cursorColor: Colors.green.shade800,
                                decoration: const InputDecoration(
                                  enabledBorder: OutlineInputBorder(
                                    borderSide: BorderSide(color: Colors.black),
                                    borderRadius: BorderRadius.all(
                                      Radius.circular(10),
                                    ),
                                  ),
                                ))),
                      ),
                      const SizedBox(height: 25),
                      const Text(
                        "Vozilo:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      FormBuilderDropdown(
                        name: "vehicleIdId",
                        items: getVehicle(),
                        initialValue: selectedVehicleId?.toString(),
                        onChanged: (value) {
                          setState(() {
                            selectedVehicleId = int.parse(value as String);
                          });
                        },
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Odaberite vozilo.",
                          ),
                        ]),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(
                              Radius.circular(10),
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 25),
                      const Text(
                        "Najbliža stanica gdje se desio kvar:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      FormBuilderDropdown(
                        name: "StationId",
                        items: getStatione(),
                        initialValue: selectedStationId?.toString(),
                        onChanged: (value) {
                          setState(() {
                            selectedStationId = int.parse(value as String);
                          });
                        },
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Odaberite stanicu.",
                          ),
                        ]),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(
                              Radius.circular(10),
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 25),
                      Checkbox(
                        checkColor: Colors.black,
                        value: isFixed,
                        onChanged: (bool? value) {
                          setState(() {
                            isFixed = value ?? false;
                          });
                        },
                      ),
                      const Text(
                        "Popravljen?",
                        style: TextStyle(
                            fontSize: 16, fontWeight: FontWeight.bold),
                      ),
                      const SizedBox(height: 25),
                      Row(
                        children: [
                          Expanded(
                            child: ElevatedButton(
                              onPressed: () async {
                                if (_formKey.currentState?.saveAndValidate() ??
                                    false) {
                                  var request =
                                      Map.from(_formKey.currentState!.value);

                                  request['dateOfMalufunction'] =
                                      dateOfMalfunction?.toIso8601String();
                                  request['fixed'] = isFixed;
                                  request['VehicleId'] = selectedVehicleId;
                                  request['StationId'] = selectedStationId;
                                  request['modifiedDate'] =
                                      DateTime.now().toIso8601String();
                                  request['currentUserId'] = currentUserId;

                                  try {
                                    setState(() {
                                      isLoading = true;
                                    });

                                    await malfunctionProvider.insert(request);

                                    showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                        title: const Text("Success"),
                                        content: const Text(
                                            "Zapis je uspješno dodan."),
                                        actions: [
                                          TextButton(
                                            child: const Text(
                                              "OK",
                                              style: TextStyle(
                                                  color: Colors.black),
                                            ),
                                            onPressed: () async {
                                              await widget.onDone();
                                              Navigator.pop(context);
                                              Navigator.pop(context, true);
                                            },
                                          )
                                        ],
                                      ),
                                    );
                                  } catch (error) {
                                    showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                        title: const Text("Error"),
                                        content: Text(
                                          "Greška prilikom dodavanja zapisa: $error",
                                        ),
                                        actions: [
                                          TextButton(
                                            onPressed: () =>
                                                Navigator.pop(context),
                                            child: const Text("OK"),
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
                              child: const Text(
                                "Dodaj",
                                style: TextStyle(fontSize: 18),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context, false),
          child: const Text(
            "Cancel",
            style: TextStyle(color: Colors.red, fontSize: 18),
          ),
        ),
      ],
    );
  }
}
