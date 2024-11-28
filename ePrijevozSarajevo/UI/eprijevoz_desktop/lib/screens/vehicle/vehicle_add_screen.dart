import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class VehicleAddDialog extends StatefulWidget {
  Vehicle? vehicle;
  VehicleAddDialog({super.key, this.vehicle});

  @override
  State<VehicleAddDialog> createState() => _VehicleAddDialogState();
}

class _VehicleAddDialogState extends State<VehicleAddDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late VehicleProvider vehicleProvider;
  SearchResult<Manufacturer>? manufacturerResult;
  late ManufacturerProvider manufacturerProvider;
  SearchResult<Type>? typeResult;
  late TypeProvider typeProvider;
  bool isLoading = true;
  int? selectedManufacturerId;
  int? selectedTypeId;

  @override
  void initState() {
    vehicleProvider = context.read<VehicleProvider>();
    manufacturerProvider = context.read<ManufacturerProvider>();
    typeProvider = context.read<TypeProvider>();

    super.initState();

    _initialValue = {
      'number': widget.vehicle?.number.toString(),
      'registrationNumber': widget.vehicle?.registrationNumber,
      'buildYear': widget.vehicle?.buildYear.toString(),
      'manufacturerId': selectedManufacturerId.toString(),
      'typeId': selectedTypeId.toString()
    };

    initForm();
  }

  Future initForm() async {
    manufacturerResult = await manufacturerProvider.get();
    typeResult = await typeProvider.get();

    setState(() {
      isLoading = false;

      selectedManufacturerId = widget.vehicle?.manufacturerId ??
          (manufacturerResult?.result.isNotEmpty ?? false
              ? manufacturerResult!.result.first.manufacturerId
              : null);

      selectedTypeId = widget.vehicle?.typeId ??
          (typeResult?.result.isNotEmpty ?? false
              ? typeResult!.result.first.typeId
              : null);
    });
  }

  List<DropdownMenuItem<String>> getManufacturer() {
    var list = manufacturerResult?.result
            .map((item) => DropdownMenuItem(
                value: item.manufacturerId.toString(),
                child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  List<DropdownMenuItem<String>> getType() {
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
      title: const Text("Novo vozilo",
          style: TextStyle(fontWeight: FontWeight.bold)),
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
                  child: Column(
                    children: [
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
                            width: 130,
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
                          const Text(
                            "Registracijska oznaka:",
                            style: TextStyle(
                                fontWeight: FontWeight.bold, fontSize: 15),
                          ),
                          const SizedBox(
                            width: 50,
                          ),
                          Expanded(
                            child: FormBuilderTextField(
                              name: 'registrationNumber',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                                FormBuilderValidators.maxLength(9,
                                    errorText:
                                        "Maksimalna dužina registracijske oznake je 9."),
                                FormBuilderValidators.minLength(9,
                                    errorText:
                                        "Minimalna dužina registracijske oznake je 9."),
                                FormBuilderValidators.match(
                                  r'^[A-Z]\d{2}-[A-Z]-\d{3}$',
                                  errorText:
                                      "Format registracijske oznake: A10-L-123.",
                                ),
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
                          const Text(
                            "Godina proizvodnje:",
                            style: TextStyle(
                                fontWeight: FontWeight.bold, fontSize: 15),
                          ),
                          const SizedBox(
                            width: 63,
                          ),
                          Expanded(
                            child: FormBuilderTextField(
                              name: 'buildYear',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                                FormBuilderValidators.maxLength(4,
                                    errorText: "Godina se sastoji od 4 cifre."),
                                FormBuilderValidators.minLength(4,
                                    errorText: "Godina se sastoji od 4 cifre."),
                                FormBuilderValidators.min(1960,
                                    errorText:
                                        "Godina proizvodnje ne može biti manja od 1960."),
                                FormBuilderValidators.max(2025,
                                    errorText:
                                        "Godina proizvodnje ne može biti veća od 2025.")
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
                          const Text(
                            "Proizvođač:",
                            style: TextStyle(
                                fontWeight: FontWeight.bold, fontSize: 15),
                          ),
                          const SizedBox(
                            width: 125,
                          ),
                          Expanded(
                            child: FormBuilderDropdown(
                              name: "manufacturerId",
                              items: getManufacturer(),
                              initialValue: selectedManufacturerId?.toString(),
                              onChanged: (value) {
                                setState(() {
                                  selectedManufacturerId =
                                      int.parse(value as String);
                                });
                              },
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Odaberite proizvođača."),
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
                            "Tip vozila:",
                            style: TextStyle(
                                fontWeight: FontWeight.bold, fontSize: 15),
                          ),
                          const SizedBox(
                            width: 135,
                          ),
                          Expanded(
                            child: FormBuilderDropdown(
                              name: "typeId",
                              items: getType(),
                              initialValue: selectedTypeId?.toString(),
                              onChanged: (value) {
                                setState(() {
                                  selectedTypeId = int.parse(value as String);
                                });
                              },
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Odaberite tip vozila."),
                              ]),
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(
                        height: 25,
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

                                request['manufacturerId'] =
                                    selectedManufacturerId;
                                request['typeId'] = selectedTypeId;

                                try {
                                  setState(() {
                                    isLoading = true;
                                  });

                                  await vehicleProvider.insert(request);
                                  showDialog(
                                    context: context,
                                    builder: (context) => AlertDialog(
                                      title: const Text("Success"),
                                      content: const Text(
                                          "Vozilo je uspješno dodano."),
                                      actions: [
                                        TextButton(
                                          child: const Text("OK",
                                              style: TextStyle(
                                                  color: Colors.black)),
                                          onPressed: () {
                                            Navigator.pop(context);
                                            Navigator.pop(context, true);
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
                                      content: const Text(
                                          "Registracijska oznaka mora biti jedinstvena."),
                                      actions: [
                                        TextButton(
                                          child: const Text(
                                            "OK",
                                            style:
                                                TextStyle(color: Colors.black),
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
                    ],
                  ),
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
