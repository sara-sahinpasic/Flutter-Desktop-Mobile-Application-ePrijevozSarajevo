import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/main.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:analog_clock/analog_clock.dart';
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

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Početna",
        Column(
          children: [
            SizedBox(
              height: 5,
            ),
            _buildResultVIew(),
          ],
        ));
  }

  Widget _buildResultVIew() {
    return Expanded(
        child: SingleChildScrollView(
      child: Row(
        children: [
          SizedBox(
            height: 15,
          ),
          Text(
            "Dobro došli, ${userNameUI}!",
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30),
          ),
          Spacer(),
          TextButton(
              child: Text(
                "Odjava",
                style: TextStyle(
                    decoration: TextDecoration.underline,
                    decorationColor: Colors.red,
                    color: Colors.red,
                    fontWeight: FontWeight.bold,
                    fontSize: 30),
              ),
              onPressed: () => Navigator.of(context)
                  .push(MaterialPageRoute(builder: (context) => LoginPage()))),
          SizedBox(
            height: 15,
          ),

          //ANALOG CLOCK
        ],
      ),
    ));
  }
}
