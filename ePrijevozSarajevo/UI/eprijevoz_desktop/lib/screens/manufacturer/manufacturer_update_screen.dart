import 'package:eprijevoz_desktop/models/country.dart';
import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/providers/country_provider.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class ManufacturerUpdateDialog extends StatefulWidget {
  final Function onDone;
  final Manufacturer manufacturer;
  const ManufacturerUpdateDialog(
      {required this.manufacturer, required this.onDone, super.key});

  @override
  State<ManufacturerUpdateDialog> createState() =>
      _ManufacturerUpdateDialogState();
}

class _ManufacturerUpdateDialogState extends State<ManufacturerUpdateDialog> {
  late ManufacturerProvider manufacturerProvider;
  SearchResult<Manufacturer>? manufacturerResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  String? manufacturerName;
  late CountryProvider countryProvider;
  SearchResult<Country>? countryResult;
  int? selectedCountryId;

  @override
  void initState() {
    manufacturerProvider = context.read<ManufacturerProvider>();
    countryProvider = context.read<CountryProvider>();

    super.initState();
    _initialValue = {
      'name': widget.manufacturer.name,
    };
    initForm();
  }

  Future initForm() async {
    manufacturerResult = await manufacturerProvider.get();
    countryResult = await countryProvider.get();

    setState(() {
      isLoading = false;

      selectedCountryId = widget.manufacturer.manufacturerCountryId ??
          (countryResult?.result.isNotEmpty ?? false
              ? countryResult!.result.first.countryId
              : null);
    });
  }

  DropdownMenuItem<int> getInititalCountry() {
    final country = countryResult?.result.firstWhere((country) =>
        country.countryId == widget.manufacturer.manufacturerCountryId);
    return DropdownMenuItem(
        value: country?.countryId ?? -1, child: Text(country?.name ?? ""));
  }

  List<DropdownMenuItem<String>> getCountryItems() {
    var list = countryResult?.result
            .map((item) => DropdownMenuItem(
                value: item.countryId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
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
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          const Text(
                            "Naziv proizvođača:",
                            style: TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 16,
                            ),
                          ),
                          const SizedBox(width: 20),
                          Expanded(
                            child: FormBuilderTextField(
                              name: 'name',
                              decoration: InputDecoration(
                                border: OutlineInputBorder(
                                  borderRadius: BorderRadius.circular(8.0),
                                ),
                                hintText: "Unesite naziv",
                              ),
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno.",
                                ),
                                FormBuilderValidators.match(
                                  r'^[a-zA-Z\s]*$',
                                  errorText:
                                      "Ovo polje može sadržavati isključivo slova.",
                                ),
                              ]),
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          const Text(
                            "Država:",
                            style: TextStyle(
                                fontWeight: FontWeight.bold, fontSize: 15),
                          ),
                          const SizedBox(
                            width: 115,
                          ),
                          Expanded(
                            child: FormBuilderDropdown(
                              name: "manufacturerCountryId",
                              items: getCountryItems(),
                              initialValue: selectedCountryId?.toString(),
                              onChanged: (value) {
                                setState(() {
                                  selectedCountryId =
                                      int.parse(value as String);
                                });
                              },
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Odaberite državu."),
                              ]),
                            ),
                          ),
                        ],
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
                                  request['modifiedDate'] =
                                      DateTime.now().toIso8601String();
                                  request['manufacturerCountryId'] =
                                      selectedCountryId;

                                  try {
                                    await manufacturerProvider.update(
                                        widget.manufacturer.manufacturerId!,
                                        request);
                                    Navigator.pop(context, true);

                                    showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                        title: const Text("Update"),
                                        content:
                                            const Text("Zapis je ažuriran."),
                                        actions: [
                                          TextButton(
                                            child: const Text(
                                              "OK",
                                              style: TextStyle(
                                                  color: Colors.black),
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
                                "Ažuriraj",
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
