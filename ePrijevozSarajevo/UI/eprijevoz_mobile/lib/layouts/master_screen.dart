import 'package:eprijevoz_mobile/screens/home_screen.dart';
import 'package:eprijevoz_mobile/screens/profile_screen.dart';
import 'package:eprijevoz_mobile/screens/route_screen.dart';
import 'package:eprijevoz_mobile/screens/ticket_screen.dart';
import 'package:flutter/material.dart';

class MasterScreen extends StatefulWidget {
  MasterScreen({super.key});

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  int _currentIndex = 0;

  late List<Widget> _pages;
  late List<String> _titles;

  @override
  void initState() {
    super.initState();

    // Initialize the pages and corresponding titles
    _pages = [
      HomePage(),
      RouteScreen(),
      TicketScreen(),
      ProfileScreen(),
    ];

    _titles = [
      "Početna",
      "Rute",
      "Karte",
      "Profil",
    ];
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Row(
        children: [
          Expanded(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Container(
                  color: Colors.green.shade800,
                  child: Align(
                    alignment: Alignment.centerLeft,
                    child: Padding(
                      padding: const EdgeInsets.fromLTRB(50.0, 35.0, 0.0, 20.0),
                      child: Text(
                        _titles[
                            _currentIndex], // Use the title corresponding to the selected tab
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 40,
                          color: Colors.white,
                        ),
                      ),
                    ),
                  ),
                ),
                Expanded(
                  child: _pages[_currentIndex], // Display the selected page
                ),
              ],
            ),
          ),
        ],
      ),
      //footer
      bottomNavigationBar: Theme(
        data: Theme.of(context).copyWith(
          canvasColor: Colors.green.shade800,
        ),
        child: BottomNavigationBar(
          fixedColor: Colors.black,
          backgroundColor: Colors.green,
          currentIndex: _currentIndex, // Set the current selected index
          onTap: (index) {
            setState(() {
              _currentIndex = index; // Update the index when a tab is tapped
            });
          },
          items: const [
            BottomNavigationBarItem(
              icon: Icon(
                Icons.home_outlined,
                size: 30,
              ),
              label: 'Početna',
            ),
            BottomNavigationBarItem(
              icon: Icon(
                Icons.sync_outlined,
                size: 30,
              ),
              label: 'Rute',
            ),
            BottomNavigationBarItem(
              icon: Icon(
                Icons.message_outlined, //color: Colors.white,
                size: 30,
              ),
              label: 'Karte',
            ),
            BottomNavigationBarItem(
              icon: Icon(
                Icons.person_outline,
                size: 30,
              ),
              label: 'Profil',
            ),
          ],
        ),
      ),
    );
  }
}
