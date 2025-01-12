import 'package:eprijevoz_mobile/main.dart';
import 'package:eprijevoz_mobile/models/country.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/country_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class ProfileNewUserScreen extends StatefulWidget {
  const ProfileNewUserScreen({super.key});

  @override
  State<ProfileNewUserScreen> createState() => _ProfileNewUserScreenState();
}

class _ProfileNewUserScreenState extends State<ProfileNewUserScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  bool isLoading = true;
  late UserProvider userProvider;
  late CountryProvider countryProvider;
  SearchResult<Country>? countryResult;
  int? selectedCountryId;
  DateTime? dateOfBirth;
  final TextEditingController _dateOfBirthController = TextEditingController();
  User? user;
  bool isPasswordVisible = false;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    countryProvider = context.read<CountryProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    try {
      var result = await countryProvider.get();
      setState(() {
        countryResult = result;
        isLoading = false;

        selectedCountryId = user?.userCountryId ??
            (result.result.isNotEmpty ? result.result.first.countryId : null);
      });
    } catch (e) {
      setState(() {
        isLoading = false;
      });
    }
  }

  List<DropdownMenuItem<String>> getCountryItems() {
    var list = countryResult?.result
            .map((item) => DropdownMenuItem(
                value: item.countryId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  Future<void> selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: dateOfBirth ?? DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime(2100),
    );

    if (picked != null && picked != dateOfBirth) {
      setState(() {
        dateOfBirth = picked;
        _dateOfBirthController.text = formatDateTimeAPI(picked);
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: isLoading
            ? const Center(
                child: CircularProgressIndicator(),
              )
            : FormBuilder(
                key: _formKey,
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.stretch,
                  children: [
                    Container(
                      padding:
                          const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
                      color: Colors.green.shade800,
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          const Text(
                            "Novi korisnik",
                            style: TextStyle(
                              fontWeight: FontWeight.bold,
                              fontSize: 40,
                              color: Colors.white,
                            ),
                            textAlign: TextAlign.center,
                          ),
                          IconButton(
                            onPressed: () {
                              Navigator.of(context).pop();
                            },
                            icon: const Icon(
                              Icons.cancel_outlined,
                              color: Colors.white,
                              size: 40,
                            ),
                          )
                        ],
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.fromLTRB(15.0, 15.0, 15.0, 0.0),
                      child: Column(
                        mainAxisAlignment: MainAxisAlignment.center,
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'firstName',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                              ]),
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Ime",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite ime',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.person),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'lastName',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                              ]),
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Prezime",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite prezime',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.person),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: GestureDetector(
                              onTap: () => selectDate(context),
                              child: AbsorbPointer(
                                child: FormBuilderTextField(
                                  name: 'dateOfBirth',
                                  controller: _dateOfBirthController,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                      errorText:
                                          "Ovo polje ne može bit prazno.",
                                    ),
                                  ]),
                                  style: const TextStyle(
                                      color: Colors.black, fontSize: 18),
                                  decoration: const InputDecoration(
                                    border: OutlineInputBorder(),
                                    labelText: "Datum rođenja",
                                    labelStyle: TextStyle(color: Colors.black),
                                    hintText: 'Unesite datum rođenja',
                                    hintStyle: TextStyle(
                                        color: Colors.black, fontSize: 13),
                                    prefixIcon: Icon(Icons.date_range),
                                    prefixIconColor: Colors.black,
                                  ),
                                ),
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'email',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                                FormBuilderValidators.email(
                                    errorText: "Format email-a: mail@mail.com"),
                              ]),
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Email",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite email',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.email),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'userName',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                              ]),
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Korisničko ime",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite korisničko ime',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.person),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'password',
                              obscureText: !isPasswordVisible,
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                              ]),
                              cursorColor: Colors.green.shade800,
                              decoration: InputDecoration(
                                labelText: "Password",
                                labelStyle:
                                    const TextStyle(color: Colors.black),
                                hintText: 'Unesite password',
                                hintStyle: const TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: const Icon(Icons.password),
                                prefixIconColor: Colors.black,
                                enabledBorder: const OutlineInputBorder(
                                  borderSide: BorderSide(color: Colors.black),
                                  borderRadius: BorderRadius.all(
                                    Radius.circular(10),
                                  ),
                                ),
                                suffixIcon: IconButton(
                                  icon: Icon(
                                    isPasswordVisible
                                        ? Icons.visibility
                                        : Icons.visibility_off,
                                  ),
                                  onPressed: () {
                                    setState(() {
                                      isPasswordVisible = !isPasswordVisible;
                                    });
                                  },
                                ),
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'passwordConfirmation',
                              obscureText: !isPasswordVisible,
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                              ]),
                              cursorColor: Colors.green.shade800,
                              decoration: InputDecoration(
                                labelText: "Password potvrda",
                                labelStyle:
                                    const TextStyle(color: Colors.black),
                                hintText: 'Unesite potvrdu password-a',
                                hintStyle: const TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: const Icon(Icons.password),
                                prefixIconColor: Colors.black,
                                enabledBorder: const OutlineInputBorder(
                                  borderSide: BorderSide(color: Colors.black),
                                  borderRadius: BorderRadius.all(
                                    Radius.circular(10),
                                  ),
                                ),
                                suffixIcon: IconButton(
                                  icon: Icon(
                                    isPasswordVisible
                                        ? Icons.visibility
                                        : Icons.visibility_off,
                                  ),
                                  onPressed: () {
                                    setState(() {
                                      isPasswordVisible = !isPasswordVisible;
                                    });
                                  },
                                ),
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'phoneNumber',
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
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Broj telefona",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite broj telefona',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.phone),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'address',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                                FormBuilderValidators.match(
                                    r'^[A-Za-z]+(?: [A-Za-z]+)* \d+$',
                                    errorText:
                                        "Format adrese: Naziv ulice kućni broj")
                              ]),
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Adresa",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite adresu',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.location_history),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'city',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                                FormBuilderValidators.match(r'^[a-zA-Z\s]*$',
                                    errorText:
                                        "Ovo polje može sadržavati isključivo slova."),
                              ]),
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Grad",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite grad',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.location_city),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          Padding(
                            padding: const EdgeInsets.symmetric(
                                horizontal: 10, vertical: 5),
                            child: FormBuilderTextField(
                              name: 'zipCode',
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Ovo polje ne može bit prazno."),
                                FormBuilderValidators.integer(
                                    errorText:
                                        "Format poštanskog broja: 71000"),
                                FormBuilderValidators.maxLength(5,
                                    errorText:
                                        "Maksimalna dužina poštanskog broja je 5."),
                                FormBuilderValidators.minLength(4,
                                    errorText:
                                        "Minimalna dužina poštanskog broja je 4."),
                              ]),
                              style: const TextStyle(
                                  color: Colors.black, fontSize: 18),
                              decoration: const InputDecoration(
                                border: OutlineInputBorder(),
                                labelText: "Poštanski broj",
                                labelStyle: TextStyle(color: Colors.black),
                                hintText: 'Unesite poštanski broj',
                                hintStyle: TextStyle(
                                    color: Colors.black, fontSize: 13),
                                prefixIcon: Icon(Icons.numbers),
                                prefixIconColor: Colors.black,
                              ),
                            ),
                          ),
                          SizedBox(
                            height: 60,
                            child: FormBuilderDropdown(
                              name: "userCountryId",
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
                    ),
                    SizedBox(
                      width: double.infinity,
                      height: 55,
                      child: ElevatedButton(
                        onPressed: () async {
                          if (_formKey.currentState?.saveAndValidate() ??
                              false) {
                            var userRequest =
                                Map.from(_formKey.currentState!.value);
                            userRequest['userCountryId'] = selectedCountryId;

                            try {
                              await userProvider.insert(userRequest);
                              showDialog(
                                context: context,
                                builder: (context) => AlertDialog(
                                  title: const Text("Success"),
                                  content: const Text(
                                    "Korisnik je uspješno dodan.",
                                    style: TextStyle(
                                        color: Colors.green,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  actions: [
                                    TextButton(
                                      child: const Text("OK",
                                          style:
                                              TextStyle(color: Colors.black)),
                                      onPressed: () {
                                        Navigator.of(context).push(
                                            MaterialPageRoute(
                                                builder: (context) =>
                                                    const LoginPage()));
                                      },
                                    ),
                                  ],
                                ),
                              );
                            } catch (error) {
                              showDialog(
                                context: context,
                                builder: (context) => AlertDialog(
                                  title: const Text("Error",
                                      style: TextStyle(
                                          color: Colors.red,
                                          fontWeight: FontWeight.bold)),
                                  content: Text(
                                      'Greška prilikom dodavanja korisnika \n$error'),
                                  actions: [
                                    TextButton(
                                      child: const Text("OK",
                                          style:
                                              TextStyle(color: Colors.black)),
                                      onPressed: () {
                                        Navigator.pop(context, false);
                                      },
                                    ),
                                  ],
                                ),
                              );
                            }
                          }
                        },
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.black,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                          padding: const EdgeInsets.symmetric(vertical: 10.0),
                        ),
                        child: const Text(
                          "Kreiraj račun",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 20),
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 25,
                    ),
                  ],
                ),
              ),
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
