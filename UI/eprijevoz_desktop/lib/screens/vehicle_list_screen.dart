import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:flutter/material.dart';

class VehicleListScreen extends StatelessWidget {
  const VehicleListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Lista vozila",
        Column(
          children: [
            Text("Lista vozila placeholder"),
            SizedBox(
              height: 8,
            ),
            ElevatedButton(
              onPressed: () {
                Navigator.pop(context);
              },
              child: Text("Nazad"),
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
              ),
            )
          ],
        ));
  }
}
