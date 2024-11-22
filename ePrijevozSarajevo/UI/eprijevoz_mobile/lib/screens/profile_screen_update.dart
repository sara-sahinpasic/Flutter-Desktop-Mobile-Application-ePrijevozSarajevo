import 'package:flutter/material.dart';

class UpdateProfileScreen extends StatefulWidget {
  const UpdateProfileScreen({super.key});

  @override
  State<UpdateProfileScreen> createState() => _UpdateProfileScreenState();
}

class _UpdateProfileScreenState extends State<UpdateProfileScreen> {
  final TextEditingController _ftsFirstNameController = TextEditingController();
  final TextEditingController _ftsLastNameController = TextEditingController();
  final TextEditingController _ftsPhoneNumberController =
      TextEditingController();
  final TextEditingController _ftsAddressController = TextEditingController();
  final TextEditingController _ftsZipCodeController = TextEditingController();
  final TextEditingController _ftsCountryController = TextEditingController();
  final TextEditingController _ftsProfileImageController =
      TextEditingController();

  @override
  /*Widget build(BuildContext context) {
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
                  "Update",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 40,
                    color: Colors.white,
                  ),
                ),
                IconButton(
                    onPressed: () {
                      //Navigator.of(context).pop(MaterialPageRoute(
                      //    builder: (context) => ProfileScreen()));
                    },
                    icon: const Icon(
                      Icons.cancel_outlined,
                      color: Colors.white,
                      size: 40,
                    ))
              ],
            ),
          ),
          const Padding(
            padding: EdgeInsets.fromLTRB(15.0, 135.0, 20.0, 135.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
                  child: TextField(
                    controller: _ftsFirstNameController,
                    style: const TextStyle(color: Colors.white, fontSize: 18),
                    decoration: InputDecoration(
                      border: OutlineInputBorder(),
                      labelText: "Ime",
                      labelStyle: TextStyle(color: Colors.white),
                      hintText: 'Unesite ime',
                      hintStyle: TextStyle(color: Colors.white, fontSize: 13),
                      prefixIcon: Icon(Icons.person),
                      prefixIconColor: Colors.white,
                    ),
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
                  // if (_selectedTicketTypeId != null) {
                  //   // Create a Request object
                  //   var newRequest = {
                  //     'userStatusId': _selectedTicketTypeId!,
                  //     'userId': userId,
                  //   };
                  //   // Send the request to the server
                  //   await requestProvider.insert(newRequest);

                  //   // Navigate to the next screen if needed
                  //   Navigator.of(context).push(MaterialPageRoute(
                  //       builder: (context) => const RequestScreen()));
                  // } else {
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
                },
                //},
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.black,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10.0),
                  ),
                  padding: const EdgeInsets.symmetric(vertical: 10.0),
                ),
                child: const Text("Update",
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
  }*/

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
                  "Update",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 40,
                    color: Colors.white,
                  ),
                ),
                IconButton(
                  onPressed: () {
                    //Navigator.of(context).pop();
                  },
                  icon: const Icon(
                    Icons.cancel_outlined,
                    color: Colors.white,
                    size: 40,
                  ),
                )
              ],
            ),
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(15.0, 135.0, 20.0, 135.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
                  child: TextField(
                    controller: _ftsFirstNameController,
                    style: const TextStyle(color: Colors.black, fontSize: 18),
                    decoration: const InputDecoration(
                      border: OutlineInputBorder(),
                      labelText: "Ime",
                      labelStyle: TextStyle(color: Colors.black),
                      hintText: 'Unesite ime',
                      hintStyle: TextStyle(color: Colors.black, fontSize: 13),
                      prefixIcon: Icon(Icons.person),
                      prefixIconColor: Colors.black,
                    ),
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
                await showDialog(
                  context: context,
                  builder: (dialogContext) => AlertDialog(
                    title: const Text(
                      "Zahtjev za povlasticom na osnovu statusa",
                      style:
                          TextStyle(fontSize: 17, fontWeight: FontWeight.bold),
                    ),
                    content: const Text(
                      "Da li želite da zatražite status kojim je moguće ostvariti povlasticu?",
                      style:
                          TextStyle(fontSize: 15, fontWeight: FontWeight.w500),
                    ),
                    actions: [
                      TextButton(
                        child: const Text(
                          "OK",
                          style: TextStyle(color: Colors.green),
                        ),
                        onPressed: () async {
                          Navigator.pop(dialogContext, true);
                        },
                      ),
                      TextButton(
                        child: const Text(
                          "Cancel",
                          style: TextStyle(color: Colors.red),
                        ),
                        onPressed: () => Navigator.pop(context, false),
                      )
                    ],
                  ),
                );
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.black,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10.0),
                ),
                padding: const EdgeInsets.symmetric(vertical: 10.0),
              ),
              child: const Text(
                "Update",
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
              ),
            ),
          ),
        ],
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
