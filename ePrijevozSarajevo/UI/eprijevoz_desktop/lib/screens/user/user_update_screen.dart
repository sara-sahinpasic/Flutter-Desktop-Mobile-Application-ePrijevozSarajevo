import 'dart:async';
import 'package:eprijevoz_desktop/models/country.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/country_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class UpdateUserDialog extends StatefulWidget {
  final User user;
  final VoidCallback onUserUpdated; //refresh table with new data

  const UpdateUserDialog({
    required this.user,
    required this.onUserUpdated,
    super.key,
  });

  @override
  State<UpdateUserDialog> createState() => _UpdateUserDialogState();
}

class _UpdateUserDialogState extends State<UpdateUserDialog> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  SearchResult<User>? userResultForStatus;
  late CountryProvider countryProvider;
  SearchResult<Country>? countryResult;
  int? selectedCountryId;
  bool isLoading = true;
  final _formKey = GlobalKey<FormBuilderState>();

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    countryProvider = context.read<CountryProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    countryResult = await countryProvider.get();

    setState(() {
      isLoading = false;

      selectedCountryId = widget.user.userCountryId ??
          (countryResult?.result.isNotEmpty ?? false
              ? countryResult!.result.first.countryId
              : null);
    });
  }

  DropdownMenuItem<int> getInititalCountry() {
    final country = countryResult?.result.firstWhere(
        (country) => country.countryId == widget.user.userCountryId);
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
                  child: Column(children: [
                    const SizedBox(
                      height: 15,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Ime:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 80,
                        ),
                        Expanded(
                          child: FormBuilderTextField(
                            name: 'firstName',
                            initialValue: widget.user.firstName,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                            ]),
                            cursorColor: Colors.green.shade800,
                            decoration: const InputDecoration(
                              enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.black),
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
                          "Prezime:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 50,
                        ),
                        Expanded(
                          child: FormBuilderTextField(
                            name: 'lastName',
                            initialValue: widget.user.lastName,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                            ]),
                            cursorColor: Colors.green.shade800,
                            decoration: const InputDecoration(
                              enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.black),
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
                          "Broj telefona:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 15,
                        ),
                        Expanded(
                          child: FormBuilderTextField(
                            name: 'phoneNumber',
                            initialValue: widget.user.phoneNumber,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                              FormBuilderValidators.match(
                                r'^\+?[1-9]\d{1,14}$',
                                errorText:
                                    "Format broja telefona: +387641236548.",
                              ),
                              FormBuilderValidators.maxLength(13,
                                  errorText:
                                      "Maksimalna dužina kontakt broja je 13."),
                              FormBuilderValidators.minLength(12,
                                  errorText:
                                      "Minimalna dužina kontakt broja je 12."),
                            ]),
                            cursorColor: Colors.green.shade800,
                            decoration: const InputDecoration(
                              enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.black),
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
                          "Adresa:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 60,
                        ),
                        Expanded(
                          child: FormBuilderTextField(
                            name: 'address',
                            initialValue: widget.user.address,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                              FormBuilderValidators.match(
                                  r'^[A-Za-z]+(?: [A-Za-z]+)* \d+$',
                                  errorText:
                                      "Format adrese: Naziv ulice kućni broj")
                            ]),
                            cursorColor: Colors.green.shade800,
                            decoration: const InputDecoration(
                              enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.black),
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
                          "Grad:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 75,
                        ),
                        Expanded(
                          child: FormBuilderTextField(
                            name: 'city',
                            initialValue: widget.user.city,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                              FormBuilderValidators.match(r'^[a-zA-Z\s]*$',
                                  errorText:
                                      "Ovo polje može sadržavati isključivo slova."),
                            ]),
                            cursorColor: Colors.green.shade800,
                            decoration: const InputDecoration(
                              enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.black),
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
                          "Poštanski broj:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 10,
                        ),
                        Expanded(
                          child: FormBuilderTextField(
                            name: 'zipCode',
                            initialValue: widget.user.zipCode,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                              FormBuilderValidators.integer(
                                  errorText: "Format poštanskog broja: 71000"),
                              FormBuilderValidators.maxLength(5,
                                  errorText:
                                      "Maksimalna dužina poštanskog broja je 5."),
                              FormBuilderValidators.minLength(4,
                                  errorText:
                                      "Minimalna dužina poštanskog broja je 4."),
                            ]),
                            cursorColor: Colors.green.shade800,
                            decoration: const InputDecoration(
                              enabledBorder: OutlineInputBorder(
                                borderSide: BorderSide(color: Colors.black),
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
                          "Država:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(
                          width: 60,
                        ),
                        Expanded(
                          child: FormBuilderDropdown(
                            name: "userCountryId",
                            items: getCountryItems(),
                            initialValue: selectedCountryId?.toString(),
                            onChanged: (value) {
                              setState(() {
                                selectedCountryId = int.parse(value as String);
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
                              request['userCountryId'] = selectedCountryId;

                              try {
                                setState(() {
                                  isLoading = true;
                                });

                                await userProvider.update(
                                    widget.user.userId!, request);
                                widget.onUserUpdated();
                                Navigator.pop(context, true);

                                showDialog(
                                  context: context,
                                  builder: (context) => AlertDialog(
                                    title: const Text(
                                      "Update",
                                      style: TextStyle(
                                          color: Colors.green,
                                          fontWeight: FontWeight.bold),
                                    ),
                                    content: const Text("Korisnik je ažuriran"),
                                    actions: [
                                      TextButton(
                                        child: const Text("OK",
                                            style:
                                                TextStyle(color: Colors.black)),
                                        onPressed: () => Navigator.pop(context),
                                      )
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
                                        "Korisničko ime mora biti jedinstveno."),
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
