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
