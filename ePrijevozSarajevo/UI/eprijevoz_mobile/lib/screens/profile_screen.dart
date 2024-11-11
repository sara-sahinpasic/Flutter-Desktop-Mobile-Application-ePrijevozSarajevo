import 'package:eprijevoz_mobile/models/request.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/request_provider.dart';
import 'package:eprijevoz_mobile/providers/status_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/request/request_options_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class ProfileScreen extends StatefulWidget {
  ProfileScreen({
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
  bool? hasActiveRequest = false;
  bool? isButtonClicked = false;
  var userRequest;

  // Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    statusProvider = context.read<StatusProvider>();
    requestProvider = context.read<RequestProvider>();
    initForm();
  }

  var userId;
  var userFirstName = "";
  var userLastName = "";
  var userBirthday = "";
  var userAddress = "";
  var userCity = "";
  var userPLZ = "";
  var userCountry = "";
  var userStatus = "";

  Future initForm() async {
    userResult = await userProvider.get();
    statusResult = await statusProvider.get();
    requestResult = await requestProvider.get();

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    userId = int.tryParse('${user?.userId}');

    userFirstName = '${user?.firstName}';
    userLastName = '${user?.lastName}';
    if (user?.dateOfBirth != null) {
      userBirthday = user?.dateOfBirth.toString() ?? '';
    } else {
      userBirthday = '';
    }
    userAddress = '${user?.address}';
    userCity = '';
    userPLZ = '';
    userCountry = '';
    userStatus = '${user?.userStatusId}';
    //Refresh UI
    setState(() {});

    userRequest = requestResult?.result.firstWhere(
      (request) => request.userId == userId && request.active == true,
      orElse: () => null!,
    );

    if (userRequest != null) {
      hasActiveRequest = true; //active
    } else {
      hasActiveRequest = false;
    }
  }

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
        padding: const EdgeInsets.fromLTRB(30.0, 0.0, 0.0, 0.0),
        child: Column(
          children: [
            Row(
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(0.0, 30.0, 0.0, 10.0),
                  child: Image.asset("assets/images/logo.png",
                      height: 100, width: 100),
                ),
              ],
            ),
            Row(
              children: [
                const Column(
                  children: [
                    Text(
                      "Korisnički broj: ",
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(25.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '2024${userId}',
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
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(124.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '${userFirstName}',
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
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(83.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '${userLastName}',
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
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
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
                            : 'N/A',
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
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(94.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '${userAddress}',
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
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(116.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '${userCity}',
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
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(27.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '${userPLZ}',
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
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(97.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '${userCountry}',
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
                      "Status: ",
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                    ),
                  ],
                ),
                Column(
                  children: [
                    Padding(
                      padding: const EdgeInsets.fromLTRB(101.0, 0.0, 0.0, 0.0),
                      child: Text(
                        '${userStatus}',
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
                    builder: (context) => RequestOptionsScreen(),
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
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {},
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
        SizedBox(
          width: double.infinity,
          child: ElevatedButton(
            onPressed: () {},
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
