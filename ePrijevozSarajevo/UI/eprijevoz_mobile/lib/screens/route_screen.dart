import 'package:flutter/material.dart';

class RouteScreen extends StatefulWidget {
  const RouteScreen({super.key});

  @override
  State<RouteScreen> createState() => _RouteScreenState();
}

class _RouteScreenState extends State<RouteScreen> {
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
        child: Text("Route Page Content"),
      ),
    );
  }
}
