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
import 'package:eprijevoz_mobile/screens/profile/profile_screen_update.dart';
import 'package:eprijevoz_mobile/screens/profile/profile_request_options_screen.dart';
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
  bool isLoading = true;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    statusProvider = context.read<StatusProvider>();
    requestProvider = context.read<RequestProvider>();
    countryProvider = context.read<CountryProvider>();

    super.initState();

    initForm();
  }

  Widget? userImageWidget;

  Future initForm() async {
    userResult = await userProvider.get();
    statusResult = await statusProvider.get();
    requestResult = await requestProvider.get();
    countryResult = await countryProvider.get();

    user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

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
      isLoading = false;

      _initialValue = {
        'firstName': user?.firstName,
        'lastName': user?.lastName,
        'userName': user?.userName,
        'phoneNumber': user?.phoneNumber,
        'address': user?.address,
        'zipCode': user?.zipCode,
        'city': user?.city,
        'country': user?.userCountryId,
        'profileImage': userImageWidget
      };
    });

    userRequest = requestResult?.result.firstWhere(
        (request) => request.userId == user?.userId && request.active == true);

    if (userRequest != null) {
      hasActiveRequest = true; //active
    } else {
      hasActiveRequest = false;
    }
  }

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

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        child: Padding(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          isLoading
              ? const Center(
                  child: CircularProgressIndicator(),
                )
              : _buildResultView(),
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
                        "${user?.userId}",
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
                        "${user?.firstName}",
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
                        "${user?.lastName}",
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
                        formatDate(user!.dateOfBirth),
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
                        "${user?.address}",
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
                        "${user?.zipCode}",
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
                        "${user?.city}",
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
        // request
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {
              if (hasActiveRequest == true) {
                setState(() {
                  isButtonClicked = true; // set the button as clicked
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
        const SizedBox(height: 10),
        // update
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () async {
              await Navigator.push(
                context,
                MaterialPageRoute(
                  builder: (context) => UpdateProfileScreen(
                    user: user,
                  ),
                ),
              );
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
                bool success = await userProvider.delete(user!.userId!);
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
                            Navigator.of(dialogDeleteContext).pop();
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
