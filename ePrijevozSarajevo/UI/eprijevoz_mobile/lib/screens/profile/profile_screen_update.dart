import 'dart:convert';
import 'dart:io';
import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/country.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/country_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:form_builder_validators/form_builder_validators.dart';

class UpdateProfileScreen extends StatefulWidget {
  final User user;
  const UpdateProfileScreen({required this.user, super.key});

  @override
  State<UpdateProfileScreen> createState() => _UpdateProfileScreenState();
}

class _UpdateProfileScreenState extends State<UpdateProfileScreen> {
  late CountryProvider countryProvider;
  SearchResult<Country>? countryResult;
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  int? selectedCountryId;
  bool isLoading = true;
  File? _image;
  String? _base64Image;

  @override
  void initState() {
    countryProvider = context.read<CountryProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();

    _initialValue = {
      'firstName': widget.user.firstName,
      'lastName': widget.user.lastName,
      'phoneNumber': widget.user.phoneNumber,
      'address': widget.user.address,
      'city': widget.user.city,
      'zipCode': widget.user.zipCode,
      'countryId': widget.user.userCountryId?.toString(),
      'profileImage': widget.user.profileImage
    };

    initForm();
  }

  Future initForm() async {
    countryResult = await countryProvider.get();
    userResult = await userProvider.get();

    setState(() {
      isLoading = false;

      selectedCountryId = widget.user.userCountryId ??
          (countryResult?.result.isNotEmpty ?? false
              ? countryResult!.result.first.countryId
              : null);
    });
  }

  void getImage() async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if (result != null && result.files.single.path != null) {
      if (!mounted) return; // prevents calling setState if widget is disposed
      _image = File(result.files.single.path!);
      _base64Image = base64Encode(_image!.readAsBytesSync());
      setState(() {});
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

  DropdownMenuItem<int> getInititalCountry() {
    final country = countryResult?.result.firstWhere(
        (country) => country.countryId == widget.user.userCountryId);
    return DropdownMenuItem(
        value: country?.countryId ?? -1, child: Text(country?.name ?? ""));
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
                initialValue: _initialValue,
                child: ConstrainedBox(
                  constraints: BoxConstraints(
                      minHeight: MediaQuery.of(context).size.height),
                  child: IntrinsicHeight(
                    child: Column(
                      mainAxisSize: MainAxisSize.min,
                      children: [
                        Container(
                          padding:
                              const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
                          color: Colors.green.shade800,
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.spaceBetween,
                            children: [
                              const Text(
                                "Update",
                                style: TextStyle(
                                  fontWeight: FontWeight.bold,
                                  fontSize: 40,
                                  color: Colors.white,
                                ),
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
                          padding:
                              const EdgeInsets.fromLTRB(15.0, 15.0, 15.0, 0.0),
                          child: Column(
                            mainAxisAlignment: MainAxisAlignment.center,
                            crossAxisAlignment: CrossAxisAlignment.center,
                            children: [
                              Padding(
                                padding: const EdgeInsets.symmetric(
                                    horizontal: 10, vertical: 5),
                                child: FormBuilderTextField(
                                  name: 'firstName',
                                  initialValue: widget.user.firstName,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
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
                                  initialValue: widget.user.lastName,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
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
                                child: FormBuilderTextField(
                                  name: 'phoneNumber',
                                  initialValue: widget.user.phoneNumber,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
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
                                  initialValue: widget.user.address,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
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
                                  initialValue: widget.user.zipCode,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
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
                              Padding(
                                padding: const EdgeInsets.symmetric(
                                    horizontal: 10, vertical: 5),
                                child: FormBuilderTextField(
                                  name: 'city',
                                  initialValue: widget.user.city,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                    FormBuilderValidators.match(
                                        r'^[a-zA-Z\s]*$',
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
                                    prefixIcon: Icon(Icons.location_pin),
                                    prefixIconColor: Colors.black,
                                  ),
                                ),
                              ),
                              FormBuilderDropdown(
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
                              SizedBox(
                                height: 60,
                                width: 400,
                                child: FormBuilderField(
                                  name: "profileImage",
                                  builder: (field) {
                                    return GestureDetector(
                                      onTap: getImage,
                                      child: const InputDecorator(
                                        decoration: InputDecoration(
                                            labelText: "Odaberite sliku"),
                                        child: ListTile(
                                          leading: Icon(Icons.image),
                                          title: Text("Slika"),
                                          trailing: Icon(
                                            Icons.file_upload,
                                          ),
                                        ),
                                      ),
                                    );
                                  },
                                ),
                              ),
                              const SizedBox(
                                height: 15,
                              )
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
                                var request =
                                    Map.from(_formKey.currentState!.value);

                                request['countryId'] = selectedCountryId;
                                request['profileImage'] =
                                    _base64Image ?? widget.user.profileImage;

                                try {
                                  User updatedUser = await userProvider.update(
                                    widget.user.userId!,
                                    request,
                                  );

                                  Navigator.pop(context, updatedUser);

                                  showDialog(
                                    context: context,
                                    builder: (context) => AlertDialog(
                                      title: const Text(
                                        "Update",
                                        style: TextStyle(color: Colors.green),
                                      ),
                                      content:
                                          const Text("Korisnik je ažuriran"),
                                      actions: [
                                        TextButton(
                                          child: const Text(
                                            "OK",
                                            style:
                                                TextStyle(color: Colors.black),
                                          ),
                                          onPressed: () {
                                            Navigator.of(context).push(
                                                MaterialPageRoute(
                                                    builder: (context) =>
                                                        const MasterScreen(
                                                          initialIndex: 3,
                                                        )));
                                          },
                                        ),
                                      ],
                                    ),
                                  );
                                } catch (e) {
                                  showDialog(
                                    context: context,
                                    builder: (context) => AlertDialog(
                                      title: const Text(
                                        "Error",
                                        style: TextStyle(color: Colors.red),
                                      ),
                                      content: Text(
                                          "Korisnički podaci nisu ažurirani. \n$e"),
                                      actions: [
                                        TextButton(
                                          child: const Text(
                                            "OK",
                                            style:
                                                TextStyle(color: Colors.black),
                                          ),
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
                              backgroundColor: Colors.black,
                              shape: RoundedRectangleBorder(
                                borderRadius: BorderRadius.circular(10.0),
                              ),
                              padding:
                                  const EdgeInsets.symmetric(vertical: 10.0),
                            ),
                            child: const Text(
                              "Update",
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
              ),
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
