import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/status_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/request_options_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class ProfileScreen extends StatefulWidget {
  //User? user;
  ProfileScreen({
    super.key,
    //this.user
  });

  @override
  State<ProfileScreen> createState() => _ProfileScreenState();
}

class _ProfileScreenState extends State<ProfileScreen> {
  late UserProvider userProvider;
  late StatusProvider statusProvider;
  SearchResult<User>? userResult;
  SearchResult<Status>? statusResult;

  // Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    statusProvider = context.read<StatusProvider>();
    initForm();
  }

  var userId = "";
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

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    userId = '${user?.userId}';
    userFirstName = '${user?.firstName}';
    userLastName = '${user?.lastName}';
    // userBirthday = '${user?.dateOfBirth}';
    // Safely convert the dateOfBirth to string if it's not null
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

    // Find user status using userStatusId
    // var userStatusObject = statusResult?.result
    //     .firstWhere((status) => status.statusId == user?.userStatusId);
    // userStatus = '${userStatusObject?.name ?? 'Unknown Status'}';

    print("User ima status: ${userStatus}");

    //Refresh UI
    setState(() {});
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
                Column(
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        //formatDate(DateTime.parse('${userBirthday}')),
                        // Safely check for null and format the date of birth
                        userBirthday.isNotEmpty
                            ? formatDate(DateTime.parse(userBirthday))
                            : 'N/A', // Default text if no birthday available
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 20),
                      ),
                    ),
                  ],
                )
              ],
            ),
            Row(
              children: [
                Column(
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
                        style: TextStyle(
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
              Navigator.of(context).push(MaterialPageRoute(
                  builder: (context) => RequestOptionsScreen()));
            },
            style: ElevatedButton.styleFrom(
              backgroundColor: Colors.black,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10.0),
              ),
              padding: const EdgeInsets.symmetric(vertical: 10.0),
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
