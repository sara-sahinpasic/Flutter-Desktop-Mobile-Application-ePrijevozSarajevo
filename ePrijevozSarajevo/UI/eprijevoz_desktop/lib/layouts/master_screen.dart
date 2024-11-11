import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/screens/home_screen.dart';
import 'package:eprijevoz_desktop/screens/request/request_list_screen.dart';
import 'package:eprijevoz_desktop/screens/route_list_screen.dart';
import 'package:eprijevoz_desktop/screens/user_list_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class MasterScreen extends StatefulWidget {
  User? user;
  MasterScreen(this.title, this.child, {super.key});
  String title;
  Widget child;

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
//late
  late UserProvider userProvider;
  var userNameUI = "";
//SearchResult
  SearchResult<User>? userResult;
//Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  @override
  void initState() {
    userProvider = context.read<UserProvider>();

    super.initState();

    _initialValue = {
      'firstName': widget?.user?.firstName,
      'lastName': widget?.user?.lastName,
      'userName': widget?.user?.userId,
    };

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);
    userNameUI = '${user?.firstName} ${user?.lastName}';
    print("user kolicina: ${userResult?.result.length}");
    print("username spaseni: ${AuthProvider.username}");
    print("lista username: ${userResult?.result.map((e) => e.userName)}");

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Row(
          children: [
            Container(
              width: 250,
              color: Colors.black,
              child: ListView(
                children: [
                  const SizedBox(
                    height: 80,
                  ),
                  Icon(Icons.person, color: Colors.green.shade800, size: 50),
                  const SizedBox(
                    height: 20,
                  ),
                  Center(
                    child: Text(
                      "Zdravo, ${userNameUI}",
                      style: TextStyle(
                        color: Colors.green.shade800,
                        fontWeight: FontWeight.bold,
                        fontSize: 20,
                      ),
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
                      Navigator.of(context).push(
                          MaterialPageRoute(builder: (context) => HomePage()));
                      // Navigator.pop(context);
                      //Navigator.pop(context);
                      // Navigator.pushAndRemoveUntil(
                      //   context,
                      //   MaterialPageRoute(builder: (context) => UserListScreen()),
                      //   (Route<dynamic> route) => false,
                      // );
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
                          builder: (context) => UserListScreen()));
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
                          builder: (context) => VehicleListScreen()));
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
                          builder: (context) => RouteListScreen()));
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
                          builder: (context) => RequestListScreen()));
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
                      Navigator.pop(context);
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
                    SizedBox(
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
                    SizedBox(
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
