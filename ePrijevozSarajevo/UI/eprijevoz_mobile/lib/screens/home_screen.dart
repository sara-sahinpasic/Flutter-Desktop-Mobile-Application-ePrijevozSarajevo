// import 'package:eprijevoz_mobile/layouts/master_screen.dart';
// import 'package:flutter/material.dart';

// class HomePage extends StatefulWidget {
//   const HomePage({super.key});
//   @override
//   State<HomePage> createState() => _HomePageState();
// }

// class _HomePageState extends State<HomePage> {
//   @override
//   Widget build(BuildContext context) {
//     return MasterScreen(
//         "Početna",
//         Column(
//           children: [
//             _buildResultVIew(),
//           ],
//         ));
//   }

//   Widget _buildResultVIew() {
//     return Expanded(
//       child: Center(
//         child: Text("data"),
//       ),
//     );
//   }
// }

// import 'package:flutter/material.dart';

// class HomePage extends StatefulWidget {
//   const HomePage({super.key});
//   @override
//   State<HomePage> createState() => _HomePageState();
// }

// class _HomePageState extends State<HomePage> {
//   @override
//   Widget build(BuildContext context) {
//     return Column(
//       children: [
//         _buildResultVIew(),
//       ],
//     );
//   }

//   Widget _buildResultVIew() {
//     return Expanded(
//       child: Center(
//         child: Text("Home Page Content"),
//       ),
//     );
//   }
// }

import 'package:flutter/material.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});
  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        _buildResultVIew(),
      ],
    );
  }

  Widget _buildResultVIew() {
    return Expanded(
      child: Center(
        child: Text("Home Page Content"),
      ),
    );
  }
}
