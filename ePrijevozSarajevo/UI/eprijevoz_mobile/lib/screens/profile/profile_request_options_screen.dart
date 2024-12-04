import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/request_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/screens/profile/profile_screen.dart';
import 'package:eprijevoz_mobile/screens/profile/profile_request_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../../models/request.dart';

class RequestOptionsScreen extends StatefulWidget {
  const RequestOptionsScreen({super.key});

  @override
  State<RequestOptionsScreen> createState() => _RequestOptionsScreenState();
}

class _RequestOptionsScreenState extends State<RequestOptionsScreen> {
  int? _selectedTicketTypeId;
  late RequestProvider requestProvider;
  late UserProvider userProvider;
  SearchResult<Request>? requestResult;
  SearchResult<User>? userResult;
  int? userId;

  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    requestProvider = context.read<RequestProvider>();
    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    userId = user?.userId;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
        children: [
          Container(
            padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
            color: Colors.green.shade800,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Text(
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
                          builder: (context) => ProfileScreen()));
                    },
                    icon: const Icon(
                      Icons.cancel_outlined,
                      color: Colors.white,
                      size: 40,
                    ))
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(15.0, 135.0, 20.0, 135.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                ListTile(
                  title: const Text(
                    "Mjesečna karta - Radnik",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                  ),
                  leading: Radio<int>(
                    value: 4,
                    activeColor: Colors.green,
                    groupValue: _selectedTicketTypeId,
                    onChanged: (int? value) {
                      setState(() {
                        _selectedTicketTypeId = value;
                      });
                    },
                  ),
                ),
                ListTile(
                  title: const Text(
                    "Mjesečna karta - Đak / Student",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                  ),
                  leading: Radio<int>(
                    value: 2,
                    groupValue: _selectedTicketTypeId,
                    activeColor: Colors.green,
                    onChanged: (int? value) {
                      setState(() {
                        _selectedTicketTypeId = value;
                      });
                    },
                  ),
                ),
                ListTile(
                  title: const Text(
                    "Mjesečna karta - Nezaposlen",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                  ),
                  leading: Radio<int>(
                    value: 5,
                    activeColor: Colors.green,
                    groupValue: _selectedTicketTypeId,
                    onChanged: (int? value) {
                      setState(() {
                        _selectedTicketTypeId = value;
                      });
                    },
                  ),
                ),
                ListTile(
                  title: const Text(
                    "Mjesečna karta - Penzioner",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                  ),
                  leading: Radio<int>(
                    value: 3,
                    activeColor: Colors.green,
                    groupValue: _selectedTicketTypeId,
                    onChanged: (int? value) {
                      setState(() {
                        _selectedTicketTypeId = value;
                      });
                    },
                  ),
                ),
              ],
            ),
          ),
          SizedBox(
            width: double.infinity,
            height: 55,
            child: ElevatedButton(
                onPressed: () async {
                  if (_selectedTicketTypeId != null) {
                    // Create a Request object
                    var newRequest = {
                      'userStatusId': _selectedTicketTypeId!,
                      'userId': userId,
                    };
                    // Send the request to the server
                    await requestProvider.insert(newRequest);

                    // Navigate to the next screen if needed
                    Navigator.of(context).push(MaterialPageRoute(
                        builder: (context) => const RequestScreen()));
                  } else {
                    // Handle case where no option was selected
                    await showDialog(
                        context: context,
                        builder: (dialogContext) => AlertDialog(
                              title: const Text(
                                "Zahtjev za povlasticom na osnovu statusa",
                                style: TextStyle(
                                    fontSize: 17, fontWeight: FontWeight.bold),
                              ),
                              content: const Text(
                                "Da li želite da zatražite status kojim je moguće ostvariti povlasticu?",
                                style: TextStyle(
                                    fontSize: 15, fontWeight: FontWeight.w500),
                              ),
                              actions: [
                                TextButton(
                                    child: const Text(
                                      "OK",
                                      style: TextStyle(color: Colors.green),
                                    ),
                                    onPressed: () async {
                                      Navigator.pop(dialogContext, true);
                                    }),
                                TextButton(
                                    child: const Text(
                                      "Cancel",
                                      style: TextStyle(color: Colors.red),
                                    ),
                                    onPressed: () =>
                                        Navigator.pop(context, false))
                              ],
                            ));
                  }
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.black,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10.0),
                  ),
                  padding: const EdgeInsets.symmetric(vertical: 10.0),
                ),
                child: const Text("Pošalji zahtjev",
                    style:
                        TextStyle(fontWeight: FontWeight.bold, fontSize: 20))),
          )
        ],
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
