import 'package:eprijevoz_mobile/main.dart';
import 'package:eprijevoz_mobile/models/country.dart';
import 'package:eprijevoz_mobile/models/request.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/country_provider.dart';
import 'package:eprijevoz_mobile/providers/request_provider.dart';
import 'package:eprijevoz_mobile/providers/status_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/profile_screen_update.dart';
import 'package:eprijevoz_mobile/screens/request/request_options_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class ProfileScreen extends StatefulWidget {
  const ProfileScreen({
    super.key,
  });

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  late UserProvider userProvider;
  late StatusProvider statusProvider;
  SearchResult<User>? userResult;
  SearchResult<Status>? statusResult;
  late RequestProvider requestProvider;
  SearchResult<Request>? requestResult;
  late CountryProvider countryProvider;
  SearchResult<Country>? countryResult;
  bool? hasActiveRequest = false;
  bool? isButtonClicked = false;
  Request? userRequest;
  String? userStatusName;
  String? userCountryName;
  User? user;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    statusProvider = context.read<StatusProvider>();
    requestProvider = context.read<RequestProvider>();
    countryProvider = context.read<CountryProvider>();
    initForm();
  }

  int? userId;
  var userFirstName = "";
  var userLastName = "";
  var userBirthday = "";
  var userPhoneNumber = "";
  var userAddress = "";
  var userCity = "";
  var userZipCode = "";
  var userStatusId = "";
  var userCountryId = "";
  Widget? userImageWidget;

  Future initForm() async {
    userResult = await userProvider.get();
    statusResult = await statusProvider.get();
    requestResult = await requestProvider.get();
    countryResult = await countryProvider.get();

    user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    userId = int.tryParse('${user?.userId}');
    userFirstName = '${user?.firstName}';
    userLastName = '${user?.lastName}';
    if (user?.dateOfBirth != null) {
      userBirthday = user?.dateOfBirth.toString() ?? '';
    } else {
      userBirthday = '';
    }
    userPhoneNumber = '${user?.phoneNumber}';
    userAddress = '${user?.address}';
    userCity = '${user?.city}';
    userZipCode = '${user?.zipCode}';
    userStatusId = '${user?.userStatusId}';
    userCountryId = '${user?.userCountryId}';
    userImageWidget = user?.profileImage != null
        ? SizedBox(
            width: 200,
            height: 200,
            child: imageFromString('${user?.profileImage}'),
          )
        : const Icon(
            Icons.person,
            size: 100,
          );

    userStatusName = statusResult?.result
            .firstWhere((status) => status.statusId == user?.userStatusId)
            .name ??
        "";

    userCountryName = countryResult?.result
            .firstWhere((country) => country.countryId == user?.userCountryId)
            .name ??
        "";
    //Refresh UI
    setState(() {
      _initialValue = {
        'firstName': userFirstName,
        'lastName': userLastName,
        'phoneNumber': userPhoneNumber,
        'address': userAddress,
        'zipCode': userZipCode,
        'city': userCity,
        'country': userCountryId,
        'profileImage': userImageWidget
      };
    });

    userRequest = requestResult?.result.firstWhere(
        (request) => request.userId == userId && request.active == true);

    if (userRequest != null) {
      hasActiveRequest = true; //active
    } else {
      hasActiveRequest = false;
    }
  }

  /*Future refreshUserData() async {
    var request = Map.from(_formKey.currentState?.value ?? {});
    print("Request: ${request}");
    userResult = await userProvider.get(filter: request);

    if (userResult != null && userResult!.result.isNotEmpty) {
      setState(() {
        user = userResult?.result.first;
      });
    }
  }*/
  Future refreshUserData() async {
    // Ensure the form state is saved
    if (_formKey.currentState?.saveAndValidate() ?? false) {
      // Retrieve the form values
      var request = Map.from(_formKey.currentState!.value);

      print("Request: $request");
      userResult = await userProvider.get(filter: request);

      if (userResult != null && userResult!.result.isNotEmpty) {
        setState(() {
          user = userResult?.result.first;
        });
      }
    }
  }

  bool value = false;
  void changeData() {
    value = true;
  }

//default_image.jpg
  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        child: Padding(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          _buildResultView(),
          const SizedBox(height: 15),
          _buildActionButtons(),
        ],
      ),
    ));
  }

  Widget _buildResultView() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Padding(
        padding: const EdgeInsets.fromLTRB(10.0, 0.0, 0.0, 0.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Row(
              children: [
                Center(
                  child: userImageWidget,
                ),
                TextButton(
                  onPressed: () => Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) => const LoginPage())),
                  child: const Padding(
                    padding: EdgeInsets.fromLTRB(190, 0, 0, 0),
                    child: Text(
                      "Odjava",
                      style: TextStyle(
                        color: Colors.red,
                        decoration: TextDecoration.underline,
                        decorationColor: Colors.red,
                        decorationThickness: 1.0,
                        fontSize: 15,
                      ),
                    ),
                  ),
                ),
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Korisnički broj: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(25.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '$userId',
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Ime: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(124.0, 0.0, 0.0, 0.0),
                      child: Text(
                        userFirstName,
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Prezime: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(83.0, 0.0, 0.0, 0.0),
                      child: Text(
                        userLastName,
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Datum rođenja: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(23.0, 0.0, 0.0, 0.0),
                      child: Text(
                        userBirthday.isNotEmpty
                            ? formatDate(DateTime.parse(userBirthday))
                            : "",
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Adresa: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(94.0, 0.0, 0.0, 0.0),
                      child: Text(
                        userAddress,
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Poštanski broj: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(28.0, 0.0, 0.0, 0.0),
                      child: Text(
                        userZipCode,
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Grad: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(116.0, 0.0, 0.0, 0.0),
                      child: Text(
                        userCity,
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Država: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Expanded(
                  child: Padding(
                    padding: const EdgeInsets.fromLTRB(97.0, 0.0, 0.0, 0.0),
                    child: Text(
                      '$userCountryName',
                      style: const TextStyle(
                          fontWeight: FontWeight.bold, fontSize: 20),
                      overflow: TextOverflow.ellipsis,
                    ),
                  ),
                )
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Status: ",
                      style: TextStyle(fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(100.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '$userStatusName',
                        style: const TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
          ],
        ),
      ),
    );
  }

  Widget _buildActionButtons() {
    return Column(
      children: [
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {
              if (hasActiveRequest == true) {
                setState(() {
                  isButtonClicked = true; // Set the button as clicked
                });
                ScaffoldMessenger.of(context).showSnackBar(
                  const SnackBar(
                    content: Text("Vaš zahtjev je trenutno na obradi."),
                  ),
                );
              } else {
                Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => const RequestOptionsScreen(),
                  ),
                );
              }
            },
            style: ElevatedButton.styleFrom(
              padding:
                  const EdgeInsets.symmetric(vertical: 15.0, horizontal: 30.0),
              backgroundColor: (hasActiveRequest == true && isButtonClicked!)
                  ? Colors.grey.shade300
                  : Colors.black,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10.0),
              ),
              side: BorderSide(color: Colors.grey.shade300),
              elevation: 5,
            ),
            child: const Text(
              "Zahtjev",
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
            ),
          ),
        ),
        // request
        const SizedBox(height: 10),
        // update
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () async {
              User isUpdated = await Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => UpdateProfileScreen(
                    user: user,
                    // onUserUpdated: refreshUserData,
                  ),
                ),
              );

              if (isUpdated != user) {
                setState(() async {
                  await refreshUserData(); // Refresh only if the profile was updated
                });
              }
              //value ? refreshUserData() : const Text("Ništa");
            },
            style: ElevatedButton.styleFrom(
              backgroundColor: Colors.black,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10.0),
              ),
              padding: const EdgeInsets.symmetric(vertical: 10.0),
            ),
            child: const Text(
              "Izmjeni podatke",
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
            ),
          ),
        ),
        const SizedBox(height: 10),
        // delete
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () async {
              final bool userConfirmedDeletion = await showDialog(
                  context: context,
                  builder: (dialogContext) => AlertDialog(
                          title: const Text("Delete"),
                          content: const Text(
                              "Da li želite obrisati korinički nalog?"),
                          actions: [
                            TextButton(
                                child: const Text(
                                  "OK",
                                  style: TextStyle(color: Colors.green),
                                ),
                                onPressed: () async {
                                  Navigator.pop(dialogContext, true);
                                }),
                            TextButton(
                                child: const Text(
                                  "Cancel",
                                  style: TextStyle(color: Colors.red),
                                ),
                                onPressed: () =>
                                    Navigator.pop(dialogContext, false))
                          ]));
              if (userConfirmedDeletion) {
                bool success = await userProvider.delete(userId!);
                if (mounted) {
                  await showDialog(
                    context: context,
                    builder: (dialogDeleteContext) => AlertDialog(
                      title: Text(success ? "Success" : "Error"),
                      content: Text(
                        success
                            ? "Korisnički nalog uspješno obrisan."
                            : "Korisnički nalog nije obrisan.",
                      ),
                      actions: [
                        TextButton(
                          onPressed: () {
                            Navigator.of(dialogDeleteContext)
                                .pop(); // close the dialog
                            if (success) {
                              Navigator.of(context).pushReplacement(
                                MaterialPageRoute(
                                    builder: (context) => LoginPage()),
                              );
                            }
                          },
                          child: const Text("OK",
                              style: TextStyle(color: Colors.green)),
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
              "Obriši profil",
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
            ),
          ),
        ),
      ],
    );
  }
}
