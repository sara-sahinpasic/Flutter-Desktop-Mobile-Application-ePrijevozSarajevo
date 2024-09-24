import 'package:flutter/material.dart' hide Route;

class TicketChooseScreen extends StatefulWidget {
  TicketChooseScreen({super.key});
  @override
  State<TicketChooseScreen> createState() => _TicketChooseScreenState();
}

class _TicketChooseScreenState extends State<TicketChooseScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(children: [
        Container(
          padding: EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
          color: Colors.green.shade800,
          child: Row(
            mainAxisAlignment:
                MainAxisAlignment.spaceBetween, // space between text and icon
            children: [
              Text(
                "Pretraga",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 40,
                  color: Colors.white,
                ),
              ),
              IconButton(
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                  icon: Icon(
                    Icons.cancel_outlined,
                    color: Colors.white,
                    size: 40,
                  ))
            ],
          ),
        ),
        Row(
          children: [
            Padding(
              padding: const EdgeInsets.fromLTRB(150.0, 50.0, 0.0, 0.0),
              child: Icon(
                Icons.location_on,
                size: 100,
              ),
            ),
          ],
        ),
      ]),
      //footer
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
