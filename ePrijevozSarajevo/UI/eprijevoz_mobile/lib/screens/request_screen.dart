import 'package:eprijevoz_mobile/screens/request_options_screen.dart';
import 'package:flutter/material.dart';

class RequestScreen extends StatelessWidget {
  const RequestScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          Container(
            padding: EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
            color: Colors.green.shade800,
            child: Row(
              mainAxisAlignment:
                  MainAxisAlignment.spaceBetween, // space between text and icon
              children: [
                Text(
                  "Zahtjev",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 40,
                    color: Colors.white,
                  ),
                ),
                IconButton(
                    onPressed: () {
                      Navigator.of(context).pop(MaterialPageRoute(
                          builder: (context) => RequestOptionsScreen()));
                    },
                    icon: Icon(
                      Icons.cancel_outlined,
                      color: Colors.white,
                      size: 40,
                    ))
              ],
            ),
          ),
        ],
      ),
      //footer
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
