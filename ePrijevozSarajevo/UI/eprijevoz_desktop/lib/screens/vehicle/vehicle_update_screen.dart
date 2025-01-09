import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class VehicleUpdateDialog extends StatefulWidget {
  final Function onDone;
  final Vehicle vehicle;
  const VehicleUpdateDialog(
      {required this.onDone, required this.vehicle, super.key});

  @override
  State<VehicleUpdateDialog> createState() => _VehicleUpdateDialogState();
}

class _VehicleUpdateDialogState extends State<VehicleUpdateDialog> {
  late VehicleProvider vehicleProvider;
  SearchResult<Vehicle>? vehicleResult;
  bool isLoading = true;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    vehicleProvider = context.read<VehicleProvider>();

    super.initState();
    _initialValue = {
      'number': widget.vehicle.number.toString(),
    };
    initForm();
  }

  Future initForm() async {
    vehicleResult = await vehicleProvider.get();
    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(
        "Update",
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
                  initialValue: _initialValue,
                  child: Column(children: [
                    const SizedBox(
                      height: 15,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Broj vozila:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 50,
                        ),
                        Expanded(
                          child: FormBuilderTextField(
                            name: 'number',
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                              FormBuilderValidators.integer(
                                  errorText: "Format broja vozila: 10"),
                              FormBuilderValidators.maxLength(3,
                                  errorText:
                                      "Maksimalna dužina broja vozila je 3."),
                              FormBuilderValidators.minLength(1,
                                  errorText:
                                      "Minimalna dužina broja vozila je 1."),
                            ]),
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
                        ),
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

                              try {
                                await vehicleProvider.update(
                                    widget.vehicle.vehicleId!, request);
                                Navigator.pop(context, true);

                                showDialog(
                                  context: context,
                                  builder: (context) => AlertDialog(
                                    title: const Text("Update"),
                                    content: const Text("Zapis je ažuriran."),
                                    actions: [
                                      TextButton(
                                        child: const Text(
                                          "OK",
                                          style: TextStyle(color: Colors.black),
                                        ),
                                        onPressed: () async {
                                          await widget.onDone();
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
                                      "Greška prilikom ažuriranja zapisa: $error",
                                    ),
                                    actions: [
                                      TextButton(
                                        onPressed: () => Navigator.pop(context),
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
                          child: const Text("Ažuriraj",
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
            onPressed: () => Navigator.pop(context, false),
            child: const Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }
}
