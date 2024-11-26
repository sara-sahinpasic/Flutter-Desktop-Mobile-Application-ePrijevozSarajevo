import 'package:eprijevoz_desktop/main.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/screens/user_list_screen.dart';
import 'package:flutter/material.dart';
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
  bool isLoading = true;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    super.initState();
    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    userNameUI = '${user?.firstName} ${user?.lastName}';

    setState(() {
      isLoading = false;
    });
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
    return "$currentDay, ${formatDate(now)}";
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Center(
      child: Container(
        constraints: const BoxConstraints(
          maxHeight: 500,
          maxWidth: 500,
        ),
        child: Card(
            color: Colors.black,
            child: isLoading
                ? Container()
                : Column(
                    children: [
                      _buildResultVIew(),
                    ],
                  )),
      ),
    ));
  }

  Widget _buildResultVIew() {
    return Expanded(
        child: Center(
      child: SingleChildScrollView(
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
              padding: const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Expanded(
                    child: Center(
                      child: Text(
                        "Dobro došli, ${userNameUI}!",
                        style: const TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                            fontSize: 27),
                      ),
                    ),
                  ),
                ],
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(
                    weekdays(),
                    style: const TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.bold,
                        fontSize: 25),
                  ),
                ],
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 35, vertical: 0),
              child: Row(children: [
                TextButton(
                    child: Text(
                      "Start",
                      style: TextStyle(
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.green.shade800,
                          color: Colors.green.shade800,
                          fontWeight: FontWeight.bold,
                          fontSize: 30),
                    ),
                    onPressed: () => Navigator.of(context).push(
                        MaterialPageRoute(
                            builder: (context) => UserListScreen()))),
                const Spacer(),
                TextButton(
                    child: const Text(
                      "Odjava",
                      style: TextStyle(
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.red,
                          color: Color.fromARGB(255, 212, 16, 2),
                          fontWeight: FontWeight.bold,
                          fontSize: 27),
                    ),
                    onPressed: () => Navigator.of(context).push(
                        MaterialPageRoute(
                            builder: (context) => const LoginPage()))),
              ]),
            ),
          ],
        ),
      ),
    ));
  }
}
