// import 'package:eprijevoz_mobile/models/user.dart';
// import 'package:eprijevoz_mobile/screens/home_screen.dart';
// import 'package:eprijevoz_mobile/screens/profile_screen.dart';
// import 'package:eprijevoz_mobile/screens/ticket_screen.dart';
// import 'package:flutter/material.dart';

// class MasterScreen extends StatefulWidget {
//   User? user;
//   MasterScreen(this.title, this.child, {super.key});
//   String title;
//   Widget child;

//   @override
//   State<MasterScreen> createState() => _MasterScreenState();
// }

// class _MasterScreenState extends State<MasterScreen> {
//   int _currentIndex = 0;

//   // List of widgets for each tab
//   final List<Widget> _pages = [
//     HomePage(), // Replace with your actual Home Screen Widget
//     ProfileScreen(), // Replace with your actual Profile Screen Widget
//     TicketScreen(), // Replace with your actual Settings Screen Widget
//   ];

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       body: Row(
//         children: [
//           Expanded(
//             child: Padding(
//               padding: const EdgeInsets.all(40.0),
//               child: Column(
//                 crossAxisAlignment: CrossAxisAlignment.start,
//                 children: [
//                   SizedBox(
//                     height: 80,
//                   ),
//                   Align(
//                     alignment: Alignment.centerLeft,
//                     child: Text(
//                       widget.title,
//                       style: TextStyle(
//                         fontWeight: FontWeight.bold,
//                         fontSize: 40,
//                         color: Colors.green.shade800,
//                       ),
//                     ),
//                   ),
//                   Expanded(child: widget.child),
//                 ],
//               ),
//             ),
//           ),
//         ],
//       ),
//       bottomNavigationBar: BottomNavigationBar(
//         fixedColor: Colors.black,
//         items: [
//           BottomNavigationBarItem(
//             icon: Icon(Icons.home),
//             label: 'Home',
//           ),
//           BottomNavigationBarItem(
//             icon: Icon(Icons.person),
//             label: 'Profile',
//           ),
//           BottomNavigationBarItem(
//             icon: Icon(Icons.settings),
//             label: 'Settings',
//           ),
//         ],
//       ),
//     );
//   }
// }

// import 'package:eprijevoz_mobile/models/user.dart';
// import 'package:eprijevoz_mobile/screens/home_screen.dart';
// import 'package:eprijevoz_mobile/screens/profile_screen.dart';
// import 'package:eprijevoz_mobile/screens/ticket_screen.dart';
// import 'package:flutter/material.dart';

// class MasterScreen extends StatefulWidget {
//   User? user;
//   MasterScreen(this.title, this.child, {super.key});
//   String title;
//   Widget child;

//   @override
//   State<MasterScreen> createState() => _MasterScreenState();
// }

// class _MasterScreenState extends State<MasterScreen> {
//   int _currentIndex = 0;

//   late List<Widget> _pages;

//   @override
//   void initState() {
//     super.initState();

//     // Initialize pages with the user object if needed
//     _pages = [
//       HomePage(), // Pass the User object if needed
//       ProfileScreen(), // Pass the User object if needed
//       TicketScreen(), // Pass the User object if needed
//     ];
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       body: Row(
//         children: [
//           Expanded(
//             child: Padding(
//               padding: const EdgeInsets.all(40.0),
//               child: Column(
//                 crossAxisAlignment: CrossAxisAlignment.start,
//                 children: [
//                   SizedBox(
//                     height: 80,
//                   ),
//                   Align(
//                     alignment: Alignment.centerLeft,
//                     child: Text(
//                       widget.title,
//                       style: TextStyle(
//                         fontWeight: FontWeight.bold,
//                         fontSize: 40,
//                         color: Colors.green.shade800,
//                       ),
//                     ),
//                   ),
//                   Expanded(
//                       child:
//                           _pages[_currentIndex]), // Display the selected page
//                 ],
//               ),
//             ),
//           ),
//         ],
//       ),
//       bottomNavigationBar: BottomNavigationBar(
//         fixedColor: Colors.black,
//         currentIndex: _currentIndex, // Set the current selected index
//         onTap: (index) {
//           setState(() {
//             _currentIndex = index; // Update the index when a tab is tapped
//           });
//         },
//         items: const [
//           BottomNavigationBarItem(
//             icon: Icon(Icons.home),
//             label: 'Home',
//           ),
//           BottomNavigationBarItem(
//             icon: Icon(Icons.person),
//             label: 'Profile',
//           ),
//           BottomNavigationBarItem(
//             icon: Icon(Icons.settings),
//             label: 'Settings',
//           ),
//         ],
//       ),
//     );
//   }
// }

import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/screens/home_screen.dart';
import 'package:eprijevoz_mobile/screens/profile_screen.dart';
import 'package:eprijevoz_mobile/screens/ticket_screen.dart';
import 'package:flutter/material.dart';

class MasterScreen extends StatefulWidget {
  User? user;
  MasterScreen(this.title, this.child, {super.key});
  String title;
  Widget child;

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  int _currentIndex = 0;

  late List<Widget> _pages;

  @override
  void initState() {
    super.initState();

    // Initialize pages with the user object if needed
    _pages = [
      HomePage(), // Pass the User object if needed
      ProfileScreen(), // Pass the User object if needed
      TicketScreen(), // Pass the User object if needed
    ];
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Row(
        children: [
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
                  Expanded(
                      child:
                          _pages[_currentIndex]), // Display the selected page
                ],
              ),
            ),
          ),
        ],
      ),
      bottomNavigationBar: BottomNavigationBar(
        fixedColor: Colors.black,
        currentIndex: _currentIndex, // Set the current selected index
        onTap: (index) {
          setState(() {
            _currentIndex = index; // Update the index when a tab is tapped
          });
        },
        items: const [
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.person),
            label: 'Profile',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.settings),
            label: 'Settings',
          ),
        ],
      ),
    );
  }
}
