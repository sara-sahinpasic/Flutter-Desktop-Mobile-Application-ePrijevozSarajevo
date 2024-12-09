import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/screens/home_screen.dart';
import 'package:eprijevoz_desktop/screens/request/request_list_screen.dart';
import 'package:eprijevoz_desktop/screens/route/route_list_screen.dart';
import 'package:eprijevoz_desktop/screens/statistic_screen.dart';
import 'package:eprijevoz_desktop/screens/user/user_list_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle/vehicle_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class MasterScreen extends StatefulWidget {
  final String title;
  final Widget child;

  const MasterScreen(
    this.title,
    this.child, {
    super.key,
  });

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  late UserProvider userProvider;
  var userNameUI = "";
  SearchResult<User>? userResult;

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

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Row(
          children: [
            Container(
              width: 300,
              color: Colors.black,
              child: ListView(
                children: [
                  const SizedBox(
                    height: 120,
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(15, 0, 15, 0),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        Icon(Icons.person,
                            color: Colors.green.shade800, size: 45),
                        const SizedBox(
                          width: 10,
                        ),
                        Expanded(
                          child: Text(
                            "Zdravo, \n$userNameUI",
                            style: TextStyle(
                              color: Colors.green.shade800,
                              fontWeight: FontWeight.bold,
                              fontSize: 20,
                            ),
                            overflow: TextOverflow.ellipsis,
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(
                    height: 45,
                  ),
                  ListTile(
                    leading: const Icon(
                      Icons.home,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text("Početna",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w400,
                            fontSize: 25)),
                    onTap: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => const HomePage()));
                    },
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: const Icon(
                      Icons.people,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Korisnici",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => const UserListScreen()));
                    },
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: const Icon(
                      Icons.directions_car,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Vozila",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) => const VehicleListScreen()));
                    },
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: const Icon(
                      Icons.sync,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Plan vožnje",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) => const RouteListScreen()));
                    },
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: const Icon(
                      Icons.request_page,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Zahtjevi",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) => const RequestListScreen()));
                    },
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: const Icon(
                      Icons.bar_chart,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Statistika",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) => const StatisticScreen()));
                    },
                  )
                ],
              ),
            ),
            Expanded(
              child: Padding(
                padding: const EdgeInsets.all(40.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    const SizedBox(
                      height: 80,
                    ),
                    Align(
                      alignment: Alignment.centerLeft,
                      child: Text(
                        widget.title,
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 40,
                          color: Colors.green.shade800,
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 10,
                    ),
                    Expanded(child: widget.child),
                  ],
                ),
              ),
            ),
          ],
        ),
        bottomNavigationBar: BottomAppBar(
          color: Colors.black,
          child: Center(
            child: Text(
              "© 2023/2024 RSII::FIT",
              style: TextStyle(
                  color: Colors.green.shade800, fontWeight: FontWeight.bold),
            ),
          ),
        ));
  }
}
