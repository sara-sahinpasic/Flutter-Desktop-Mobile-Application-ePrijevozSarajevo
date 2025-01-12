import 'package:eprijevoz_desktop/models/country.dart';
import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/country_provider.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class ManufacturerAddDialog extends StatefulWidget {
  final Function onDone;
  const ManufacturerAddDialog({required this.onDone, super.key});

  @override
  State<ManufacturerAddDialog> createState() => _ManufacturerAddDialogState();
}

class _ManufacturerAddDialogState extends State<ManufacturerAddDialog> {
  late ManufacturerProvider manufacturerProvider;
  SearchResult<Manufacturer>? manufacturerResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  String? countryName;
  late CountryProvider countryProvider;
  SearchResult<Country>? countryResult;
  int? selectedCountryId;
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  int? currentUserId;

  @override
  void initState() {
    manufacturerProvider = context.read<ManufacturerProvider>();
    countryProvider = context.read<CountryProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    manufacturerResult = await manufacturerProvider.get();
    countryResult = await countryProvider.get();
    userResult = await userProvider.get();

    selectedCountryId = countryResult?.result.first.countryId;

    currentUserId = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username)
        .userId;

    setState(() {
      isLoading = false;
    });
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
                                  request['currentUserId'] = currentUserId;

                                  try {
                                    setState(() {
                                      isLoading = true;
                                    });

                                    await manufacturerProvider.insert(request);

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
