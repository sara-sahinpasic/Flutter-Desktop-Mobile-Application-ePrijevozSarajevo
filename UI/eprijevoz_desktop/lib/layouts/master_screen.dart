import 'package:eprijevoz_desktop/screens/user_list_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle_list_screen.dart';
import 'package:flutter/material.dart';

class MasterScreen extends StatefulWidget {
  MasterScreen(this.title, this.child, {super.key});
  String title;
  Widget child;

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      drawer: Drawer(
        child: ListView(
          children: [
            ListTile(
              leading: Icon(Icons.home, color: Colors.white),
              title: Text("Početna"),
              onTap: () {
                Navigator.pop(context);
                Navigator.pop(context);
                // Navigator.pushAndRemoveUntil(
                //   context,
                //   MaterialPageRoute(builder: (context) => UserListScreen()),
                //   (Route<dynamic> route) => false,
                // );
              },
            ),
            ListTile(
              title: Text("Zaposlenici"),
              onTap: () {
                Navigator.of(context).push(
                    MaterialPageRoute(builder: (context) => UserListScreen()));
              },
            ),
            ListTile(
              title: Text("Vozila"),
              onTap: () {
                Navigator.of(context).pushReplacement(MaterialPageRoute(
                    builder: (context) => VehicleListScreen()));
              },
            ),
            ListTile(
              title: Text("Plan vožnje"),
              onTap: () {
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: Text("Zahtjevi"),
              onTap: () {
                Navigator.pop(context);
              },
            ),
            ListTile(
              title: Text("Statistika"),
              onTap: () {
                Navigator.pop(context);
              },
            )
          ],
        ),
      ),
      body: widget.child,
    );
  }
}
