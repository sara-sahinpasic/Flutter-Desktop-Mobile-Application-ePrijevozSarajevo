import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/main.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:provider/provider.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  var userNameUI = "";
  late UserProvider userProvider;
  SearchResult<User>? userResult;

  @override
  void initState() {
//    super.initState();

    userProvider = context.read<UserProvider>();

    super.initState();

    // _initialValue = {
    //   'firstName': widget?.user?.firstName,
    //   'lastName': widget?.user?.lastName,
    //   'userName': widget?.user?.userId,
    // };

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    userNameUI = '${user?.firstName} ${user?.lastName}';

    setState(() {});
  }

  String weekdays() {
    DateTime now = DateTime.now();
    List<String> weekdays = [
      'Ponedjeljak',
      'Utorak',
      'Srijeda',
      'Četvrtak',
      'Petak',
      'Subota',
      'Nedjelja'
    ];
    String currentDay = weekdays[now.weekday - 1];
    return "${currentDay}, ${formatDate(now)} ";
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "",
        Container(
          color: Colors.black,
          child: Column(
            children: [
              _buildResultVIew(),
            ],
          ),
        ));
  }

  Widget _buildResultVIew() {
    return Expanded(
        child: Center(
      child: SingleChildScrollView(
        child: Container(
          color: Colors.black,
          width: 1000,
          height: 500,
          child: Card(
            color: Colors.black,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Padding(
                  padding: const EdgeInsets.only(top: 40, bottom: 25),
                  child: Center(
                    child: SizedBox(
                        width: 200,
                        height: 140,
                        child: Image.asset("assets/images/logo.png",
                            height: 100, width: 100)),
                  ),
                ),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        "Dobro došli, ${userNameUI}!",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 30),
                      ),
                    ],
                  ),
                ),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        "${weekdays()}",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 25),
                      ),
                    ],
                  ),
                ),
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 35, vertical: 0),
                  child: Row(children: [
                    Spacer(),
                    TextButton(
                        child: Text(
                          "Odjava",
                          style: TextStyle(
                              decoration: TextDecoration.underline,
                              decorationColor: Colors.red,
                              color: Colors.red,
                              fontWeight: FontWeight.bold,
                              fontSize: 20),
                        ),
                        onPressed: () => Navigator.of(context).push(
                            MaterialPageRoute(
                                builder: (context) => LoginPage()))),
                  ]),
                ),
              ],
            ),
          ),
        ),
      ),
    ));
  }
}
