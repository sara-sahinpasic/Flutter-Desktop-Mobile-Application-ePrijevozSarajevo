import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UserAddDialog extends StatefulWidget {
  User? user;
  UserAddDialog({super.key, this.user});
  @override
  State<UserAddDialog> createState() => _UserAddDialogState();
}

class _UserAddDialogState extends State<UserAddDialog> {
  //Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  SearchResult<User>? userResult;
  late UserProvider userProvider;
  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    _initialValue = {
      'firstName': widget?.user?.firstName,
      'lastName': widget?.user?.lastName,
      'userName': widget?.user?.userId,
      'email': widget?.user?.email,
      'phoneNumber': widget?.user?.phoneNumber,
      'address': widget?.user?.address,
      'password': widget?.user?.password,
      'passwordConfirmation': widget?.user?.passwordConfirmation
    };
  }

  TextEditingController _ftsFirstNameController = TextEditingController();
  TextEditingController _ftsLastNameController = TextEditingController();
  TextEditingController _ftsUserNameController = TextEditingController();
  TextEditingController _ftsEmailController = TextEditingController();
  TextEditingController _ftsPasswordController = TextEditingController();
  TextEditingController _ftsPasswordConfirmationController =
      TextEditingController();
  TextEditingController _ftsPhoneNumberController = TextEditingController();
  TextEditingController _ftsAddressController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Novi korisnik"),
      content: Container(
        width: 800,
        height: 400,
        child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(
            children: [
              SizedBox(
                height: 15,
              ),
              Row(
                children: [
                  Text(
                    "Ime:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 70,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsFirstNameController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
                  SizedBox(
                    width: 15,
                  ),
                  Text(
                    "Prezime:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 75,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsLastNameController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
              SizedBox(
                height: 20,
              ),
              Row(
                children: [
                  Text(
                    "Email:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 60,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsEmailController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
                  SizedBox(
                    width: 15,
                  ),
                  Text(
                    "Korisničko ime:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 25,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsUserNameController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
              SizedBox(
                height: 20,
              ),
              Row(
                children: [
                  Text(
                    "Password:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 30,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsPasswordController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
                  SizedBox(
                    width: 15,
                  ),
                  Text(
                    "Password potvrda:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 5,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsPasswordConfirmationController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
              SizedBox(
                height: 20,
              ),
              Row(
                children: [
                  Text(
                    "Broj telefona:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 5,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsPhoneNumberController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
                  SizedBox(
                    width: 15,
                  ),
                  Text(
                    "Adresa:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 85,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsAddressController,
                      cursorColor: Colors.green.shade800,
                      decoration: InputDecoration(
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
              SizedBox(
                height: 35,
              ),
              Row(
                children: [
                  Expanded(
                    child: ElevatedButton(
                      onPressed: () async {
                        if (_formKey.currentState?.saveAndValidate() ?? false) {
                          var request = {
                            'firstName': _ftsFirstNameController.text,
                            'lastName': _ftsLastNameController.text,
                            'userName': _ftsUserNameController.text,
                            'email': _ftsEmailController.text,
                            'password': _ftsPasswordController.text,
                            'passwordConfirmation':
                                _ftsPasswordConfirmationController.text,
                            'phoneNumber': _ftsPhoneNumberController.text,
                            'address': _ftsAddressController.text,
                          };
                          try {
                            await userProvider.insert(request);
                            showDialog(
                              context: context,
                              builder: (context) => AlertDialog(
                                title: Text("Success"),
                                content: Text("Korisnik je uspješno dodan."),
                                actions: [
                                  TextButton(
                                    child: Text("OK",
                                        style: TextStyle(color: Colors.green)),
                                    onPressed: () {
                                      Navigator.pop(context);
                                      Navigator.pop(context,
                                          true); // Close the dialog and return success
                                    },
                                  ),
                                ],
                              ),
                            );
                          } catch (error) {
                            showDialog(
                              context: context,
                              builder: (context) => AlertDialog(
                                title: Text("Error"),
                                content: Text(
                                    "Greška prilikom dodavanja korisnika."),
                                actions: [
                                  TextButton(
                                    child: Text("OK",
                                        style: TextStyle(color: Colors.red)),
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
                        backgroundColor:
                            const Color.fromRGBO(72, 156, 118, 100),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(2.0),
                        ),
                        minimumSize: const Size(100, 65),
                      ),
                      child:
                          const Text("Dodaj", style: TextStyle(fontSize: 18)),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
      actions: [
        TextButton(
            onPressed: () => Navigator.pop(context),
            child: Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }
}
