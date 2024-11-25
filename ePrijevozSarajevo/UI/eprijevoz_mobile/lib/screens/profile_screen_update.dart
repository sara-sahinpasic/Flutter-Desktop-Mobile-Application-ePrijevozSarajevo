import 'dart:convert';
import 'dart:io';

import 'package:eprijevoz_mobile/models/country.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/country_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UpdateProfileScreen extends StatefulWidget {
  User? user;
  VoidCallback onUserUpdated;
  UpdateProfileScreen({this.user, required this.onUserUpdated, super.key});

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
  int? _selectedCountryId;
  @override
  void initState() {
    countryProvider = context.read<CountryProvider>();
    userProvider = context.read<UserProvider>();

    _ftsFirstNameController.text = widget?.user?.firstName ?? '';
    _ftsLastNameController.text = widget?.user?.lastName ?? '';
    _ftsPhoneNumberController.text = widget?.user?.phoneNumber ?? '';
    _ftsAddressController.text = widget?.user?.address ?? '';
    _ftsZipCodeController.text = widget?.user?.zipCode ?? '';
    _ftsCityController.text = widget?.user?.city ?? '';
    //_ftsCountryController.text = widget?.user?.countryId ?? '';

    initForm();
    super.initState();
  }

  Future initForm() async {
    countryResult = await countryProvider.get();
    userResult = await userProvider.get();

    setState(() {
      _selectedCountryId = widget?.user?.countryId ??
          (countryResult?.result.isNotEmpty ?? false
              ? countryResult!.result.first.countryId
              : null);

      _initialValue = {
        'firstName': widget?.user?.firstName,
        'lastName': widget?.user?.lastName,
        'phoneNumber': widget?.user?.phoneNumber,
        'address': widget?.user?.address,
        'zipCode': widget?.user?.zipCode,
        'city': widget?.user?.city,
        'country': _selectedCountryId?.toString(),
      };
    });
  }

  final TextEditingController _ftsFirstNameController = TextEditingController();
  final TextEditingController _ftsLastNameController = TextEditingController();
  final TextEditingController _ftsPhoneNumberController =
      TextEditingController();
  final TextEditingController _ftsAddressController = TextEditingController();
  final TextEditingController _ftsZipCodeController = TextEditingController();
  final TextEditingController _ftsCityController = TextEditingController();
  final TextEditingController _ftsCountryController = TextEditingController();
  final TextEditingController _ftsProfileImageController =
      TextEditingController();

  List<DropdownMenuItem<String>> getItems() {
    var list = countryResult?.result
            .map((item) => DropdownMenuItem(
                value: item.countryId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  File? _image;
  String? _base64Image;
  void getImage() async {
    var result = await FilePicker.platform.pickFiles(type: FileType.image);

    if (result != null && result.files.single.path != null) {
      _image = File(result.files.single.path!);
      _base64Image = base64Encode(_image!.readAsBytesSync());
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(
            children: [
              Container(
                padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
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
                padding: const EdgeInsets.fromLTRB(15.0, 0.0, 15.0, 0.0),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: 10, vertical: 5),
                      child: FormBuilderTextField(
                        name: 'firstName',
                        controller: _ftsFirstNameController,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Ime",
                          labelStyle: TextStyle(color: Colors.black),
                          hintText: 'Unesite ime',
                          hintStyle:
                              TextStyle(color: Colors.black, fontSize: 13),
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
                        controller: _ftsLastNameController,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Prezime",
                          labelStyle: TextStyle(color: Colors.black),
                          hintText: 'Unesite prezime',
                          hintStyle:
                              TextStyle(color: Colors.black, fontSize: 13),
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
                        controller: _ftsPhoneNumberController,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Broj telefona",
                          labelStyle: TextStyle(color: Colors.black),
                          hintText: 'Unesite broj telefona',
                          hintStyle:
                              TextStyle(color: Colors.black, fontSize: 13),
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
                        controller: _ftsAddressController,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Adresa",
                          labelStyle: TextStyle(color: Colors.black),
                          hintText: 'Unesite adresu',
                          hintStyle:
                              TextStyle(color: Colors.black, fontSize: 13),
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
                        controller: _ftsZipCodeController,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Poštnaski broj",
                          labelStyle: TextStyle(color: Colors.black),
                          hintText: 'Unesite poštanski broj',
                          hintStyle:
                              TextStyle(color: Colors.black, fontSize: 13),
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
                        controller: _ftsCityController,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Grad",
                          labelStyle: TextStyle(color: Colors.black),
                          hintText: 'Unesite grad',
                          hintStyle:
                              TextStyle(color: Colors.black, fontSize: 13),
                          prefixIcon: Icon(Icons.location_pin),
                          prefixIconColor: Colors.black,
                        ),
                      ),
                    ),
                    Row(
                      children: [
                        const Column(
                          children: [
                            Text(
                              "Slika: ",
                              style: TextStyle(fontSize: 20),
                            ),
                          ],
                        ),
                        Expanded(
                          child: Padding(
                              padding: const EdgeInsets.fromLTRB(
                                  97.0, 0.0, 0.0, 0.0),
                              child: FormBuilderField(
                                name: "profileImage",
                                builder: (field) {
                                  return InputDecorator(
                                    decoration: const InputDecoration(
                                        labelText: "Odaberite sliku"),
                                    child: ListTile(
                                      leading: const Icon(Icons.image),
                                      title: const Text("Slika"),
                                      trailing: const Icon(
                                        Icons.file_upload,
                                      ),
                                      onTap: getImage,
                                    ),
                                  );
                                },
                              )),
                        )
                      ],
                    ),
                    SizedBox(
                      height: 60,
                      width: 350,
                      child: FormBuilderDropdown(
                        name: "countryId",
                        items: getItems(),
                        initialValue: _selectedCountryId?.toString(),
                        onChanged: (value) {
                          setState(() {
                            _selectedCountryId = int.parse(value as String);
                          });
                        },
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
                    _formKey.currentState?.saveAndValidate();
                    var request = Map.from(_formKey.currentState!.value);
                    request['countryId'] = _selectedCountryId;
                    request['profileImage'] = _base64Image;

                    if (widget.user != null) {
                      User updatedUser = await userProvider.update(
                          widget.user!.userId!, request);
                      widget.onUserUpdated(); // Notify ProfileScreen
                      //Navigator.pop(context, true); // Return success flag
                      Navigator.pop(
                          context, updatedUser); // Return success flag
                    }

                    showDialog(
                        context: context,
                        builder: (context) => AlertDialog(
                              title: const Text("Update"),
                              content: const Text("Korisnik je ažuriran"),
                              actions: [
                                TextButton(
                                  child: const Text(
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
                    backgroundColor: Colors.black,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(10.0),
                    ),
                    padding: const EdgeInsets.symmetric(vertical: 10.0),
                  ),
                  child: const Text(
                    "Update",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
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
