import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:flutter/material.dart';

class VehicleListScreen extends StatelessWidget {
  VehicleListScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Vozila",
        Container(
          child: Column(
            children: [_buildSearch(), _buildResultView()],
          ),
        ));
  }

  TextEditingController inputController = TextEditingController();
  Widget _buildSearch() {
    //return Placeholder();
    return Row(
      children: [
        const Text(
          "Registracijska oznaka:",
          style: TextStyle(fontSize: 16, fontWeight: FontWeight.bold),
        ),
        const SizedBox(
          width: 10,
        ),
        const Expanded(
          child: TextField(
            decoration: InputDecoration(
                contentPadding: EdgeInsets.symmetric(horizontal: 5),
                labelText: "Unesite registracijsku oznaku u formatu: A12-K-123",
                border: OutlineInputBorder(
                    borderSide: BorderSide(color: Colors.black, width: 5))),
          ),
        ),
        const SizedBox(
          width: 10,
        ),
        ElevatedButton(
            style: ElevatedButton.styleFrom(
                backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(2),
                )),
            onPressed: () async {
              //TODO: add call to API
            },
            child: const Text("Pretraži"))
      ],
    );
    //);
  }

  _buildResultView() {
    return const Placeholder();
  }
}
