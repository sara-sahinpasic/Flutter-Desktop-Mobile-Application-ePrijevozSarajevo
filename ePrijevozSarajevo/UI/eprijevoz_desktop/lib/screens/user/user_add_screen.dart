import 'package:eprijevoz_desktop/models/country.dart';
import 'package:eprijevoz_desktop/models/role.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/models/userRole.dart';
import 'package:eprijevoz_desktop/providers/country_provider.dart';
import 'package:eprijevoz_desktop/providers/role_provider.dart';
import 'package:eprijevoz_desktop/providers/userRole_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class UserAddDialog extends StatefulWidget {
  const UserAddDialog({
    super.key,
  });
  @override
  State<UserAddDialog> createState() => _UserAddDialogState();
}

class _UserAddDialogState extends State<UserAddDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  SearchResult<User>? userResult;
  late UserProvider userProvider;
  bool isLoading = true;
  late CountryProvider countryProvider;
  SearchResult<Country>? countryResult;
  int? selectedCountryId;
  late RoleProvider roleProvider;
  SearchResult<Role>? roleResult;
  int? selectedRoleId;
  late UserRoleProvider userRoleProvider;
  SearchResult<UserRole>? userRoleResult;
  DateTime? dateOfBirth;
  final TextEditingController _dateOfBirthController = TextEditingController();
  User? user;
  Country? country;
  Role? role;
  bool isPasswordVisible = false;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    countryProvider = context.read<CountryProvider>();
    roleProvider = context.read<RoleProvider>();
    userRoleProvider = context.read<UserRoleProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    countryResult = await countryProvider.get();
    roleResult = await roleProvider.get();
    userRoleResult = await userRoleProvider.get();

    setState(() {
      isLoading = false;

      selectedCountryId = user?.userCountryId ??
          (countryResult?.result.isNotEmpty ?? false
              ? countryResult!.result.first.countryId
              : null);

      selectedRoleId = role?.roleId ??
          (roleResult?.result.isNotEmpty ?? false
              ? roleResult!.result.first.roleId
              : null);
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

  List<DropdownMenuItem<String>> getRoleItems() {
    var list = roleResult?.result
            .map((item) => DropdownMenuItem(
                value: item.roleId.toString(), child: Text(item.name ?? "")))
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
        _dateOfBirthController.text = formatDate(picked);
        //formatDateTimeAPI(picked);
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(
        "Novi korisnik",
        style: TextStyle(fontWeight: FontWeight.bold),
      ),
      content: SingleChildScrollView(
        child: SizedBox(
          width: 800,
          child: isLoading
              ? const Center(
                  child: CircularProgressIndicator(),
                )
              : FormBuilder(
                  key: _formKey,
                  child: Column(
                    children: [
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Ime:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'firstName',
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(width: 20),
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Prezime:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'lastName',
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(width: 20),
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Datum rođenja:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                GestureDetector(
                                  onTap: () => selectDate(context),
                                  child: AbsorbPointer(
                                      child: FormBuilderTextField(
                                          name: 'dateOfBirth',
                                          controller: _dateOfBirthController,
                                          validator:
                                              FormBuilderValidators.compose([
                                            FormBuilderValidators.required(
                                              errorText:
                                                  "Ovo polje ne može bit prazno.",
                                            ),
                                          ]),
                                          cursorColor: Colors.green.shade800,
                                          decoration: const InputDecoration(
                                            enabledBorder: OutlineInputBorder(
                                              borderSide: BorderSide(
                                                  color: Colors.black),
                                              borderRadius: BorderRadius.all(
                                                Radius.circular(10),
                                              ),
                                            ),
                                          ))),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Email:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'email',
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                    FormBuilderValidators.email(
                                        errorText:
                                            "Format email-a: mail@mail.com"),
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(width: 20),
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Korisničko ime:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'userName',
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Password:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'password',
                                  obscureText: !isPasswordVisible,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: InputDecoration(
                                    enabledBorder: const OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
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
                                          isPasswordVisible =
                                              !isPasswordVisible;
                                        });
                                      },
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(width: 20),
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Password potvrda:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'passwordConfirmation',
                                  obscureText: !isPasswordVisible,
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: InputDecoration(
                                    enabledBorder: const OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
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
                                          isPasswordVisible =
                                              !isPasswordVisible;
                                        });
                                      },
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Broj telefona:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'phoneNumber',
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
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(width: 20),
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Adresa:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'address',
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                    FormBuilderValidators.match(
                                        r'^[A-Za-z]+(?: [A-Za-z]+)* \d+$',
                                        errorText:
                                            "Format adrese: Naziv ulice kućni broj")
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ],
                      ),
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Grad:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'city',
                                  validator: FormBuilderValidators.compose([
                                    FormBuilderValidators.required(
                                        errorText:
                                            "Ovo polje ne može bit prazno."),
                                    FormBuilderValidators.match(
                                        r'^[a-zA-Z\s]*$',
                                        errorText:
                                            "Ovo polje može sadržavati isključivo slova."),
                                  ]),
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
                            ),
                          ),
                          const SizedBox(width: 20),
                          Expanded(
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "Poštanski broj:",
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 15),
                                ),
                                const SizedBox(height: 5),
                                FormBuilderTextField(
                                  name: 'zipCode',
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
                                  cursorColor: Colors.green.shade800,
                                  decoration: const InputDecoration(
                                    enabledBorder: OutlineInputBorder(
                                      borderSide:
                                          BorderSide(color: Colors.black),
                                      borderRadius: BorderRadius.all(
                                        Radius.circular(10),
                                      ),
                                    ),
                                  ),
                                ),
                              ],
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
                          const SizedBox(width: 85),
                          Expanded(
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
                                  errorText: "Odaberite državu.",
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
                          ),
                          const SizedBox(width: 15),
                        ],
                      ),
                      const SizedBox(height: 15),
                      Row(
                        children: [
                          const Text(
                            "Uloga:",
                            style: TextStyle(
                                fontWeight: FontWeight.bold, fontSize: 15),
                          ),
                          const SizedBox(width: 95),
                          Expanded(
                            child: FormBuilderDropdown(
                              name: "roleId",
                              items: getRoleItems(),
                              initialValue: selectedRoleId?.toString(),
                              onChanged: (value) {
                                setState(() {
                                  selectedRoleId = int.parse(value as String);
                                });
                              },
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                  errorText: "Odaberite ulogu.",
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
                          ),
                          const SizedBox(width: 15),
                        ],
                      ),
                      const SizedBox(height: 20),
                      Row(
                        children: [
                          Expanded(
                            child: ElevatedButton(
                              onPressed: () async {
                                if (_formKey.currentState?.saveAndValidate() ??
                                    false) {
                                  var userRequest =
                                      Map.from(_formKey.currentState!.value);
                                  userRequest['userCountryId'] =
                                      selectedCountryId;
                                  userRequest['modifiedDate'] =
                                      DateTime.now().toIso8601String();

                                  userRequest['dateOfBirth'] =
                                      dateOfBirth?.toIso8601String();

                                  userRequest['roleId'] = selectedRoleId;
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
                                                style: TextStyle(
                                                    color: Colors.black)),
                                            onPressed: () {
                                              Navigator.pop(context);
                                              Navigator.pop(context,
                                                  true); // close the dialog and return success if adding is successful => true
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
                                                style: TextStyle(
                                                    color: Colors.black)),
                                            onPressed: () {
                                              Navigator.pop(context,
                                                  false); // adding is not successful => false
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
                              child: const Text("Dodaj",
                                  style: TextStyle(fontSize: 18)),
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
            onPressed: () => Navigator.pop(context),
            child: const Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }
}
