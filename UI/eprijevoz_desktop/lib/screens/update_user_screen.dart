import 'dart:async';

import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/status.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/status_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UpdateUserDialog extends StatefulWidget {
  Status? status;
  User user;
  VoidCallback onUserUpdated; //refresh table with new data

  UpdateUserDialog({
    required this.user,
    required this.onUserUpdated,
    this.status,
    super.key,
  });

  @override
  State<UpdateUserDialog> createState() => _UpdateUserDialogState();
}

class _UpdateUserDialogState extends State<UpdateUserDialog> {
  late UserProvider userProvider;
  late StatusProvider statusProvider;
  SearchResult<User>? userResult;
  SearchResult<Status>? statusResult;
  SearchResult<User>? userResultForStatus;

  int _selectedStatusId = 0;
  String? initialStatusId;

  bool isLoading = true;

//Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    statusProvider = context.read<StatusProvider>();

    _ftsFirstNameController.text = widget?.user?.firstName ?? '';
    _ftsLastNameController.text = widget?.user?.lastName ?? '';
    _ftsAddressController.text = widget?.user?.address ?? '';
    _ftsPhoneController.text = widget?.user?.phoneNumber ?? '';

    _initialValue = {
      'firstName': widget?.user?.firstName,
      'lastName': widget?.user?.lastName,
      'userName': widget?.user?.userId,
      'dateOfBirth': widget?.user?.dateOfBirth?.toString(),
      'phoneNumber': widget?.user?.phoneNumber,
      'address': widget?.user?.address,
      'userStatusId': widget?.user?.userStatusId?.toString(),
      'statusId': widget?.status?.statusId?.toString(),
    };

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    statusResult = await statusProvider.get();

    // if (widget.user.userStatusId == null) {
    //   initialStatusId = statusResult?.result
    //       .firstWhere((element) => element.statusId == widget.user.userStatusId)
    //       .name;
    // } else
    //   initialStatusId = statusResult?.result.first.name;

    print("zahtjev: ${userResult?.result.length}");
    print("zahtjev1: ${userResult?.result.map((e) => e.userStatusId)}");

    setState(() {
      isLoading = false;
      _selectedStatusId = widget?.user?.userStatusId ?? 0;
      //initialStatusId = _selectedStatusId.toString();
    });
  }

  final TextEditingController _ftsFirstNameController = TextEditingController();
  final TextEditingController _ftsLastNameController = TextEditingController();
  final TextEditingController _ftsPhoneController = TextEditingController();
  final TextEditingController _ftsAddressController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Update"),
      content: Container(
        // color: Colors.red,
        width: 500,
        height: 450,
        child: isLoading
            ? Center(child: CircularProgressIndicator())
            : FormBuilder(
                key: _formKey,
                initialValue: _initialValue,
                child: Column(children: [
                  SizedBox(
                    height: 15,
                  ),
                  Row(
                    children: [
                      const Text(
                        "Ime:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      const SizedBox(
                        width: 80,
                      ),
                      Expanded(
                        child: FormBuilderTextField(
                          name: 'firstName',
                          controller: _ftsFirstNameController,
                          cursorColor: Colors.green.shade800,
                          decoration: InputDecoration(
                            enabledBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.black),
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  Row(
                    children: [
                      const Text(
                        "Prezime:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      const SizedBox(
                        width: 50,
                      ),
                      Expanded(
                        child: FormBuilderTextField(
                          name: 'lastName',
                          controller: _ftsLastNameController,
                          cursorColor: Colors.green.shade800,
                          decoration: InputDecoration(
                            enabledBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.black),
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  Row(
                    children: [
                      const Text(
                        "Broj telefona:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      const SizedBox(
                        width: 15,
                      ),
                      Expanded(
                        child: FormBuilderTextField(
                          name: 'phoneNumber',
                          controller: _ftsPhoneController,
                          cursorColor: Colors.green.shade800,
                          decoration: InputDecoration(
                            enabledBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.black),
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  Row(
                    children: [
                      const Text(
                        "Adresa:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      const SizedBox(
                        width: 60,
                      ),
                      Expanded(
                        child: FormBuilderTextField(
                          name: 'address',
                          controller: _ftsAddressController,
                          cursorColor: Colors.green.shade800,
                          decoration: InputDecoration(
                            enabledBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.black),
                            ),
                          ),
                        ),
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  Row(
                    children: [
                      const Text(
                        "Status:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      const SizedBox(
                        width: 60,
                      ),
                      Expanded(
                        child: FormBuilderDropdown(
                          name: "userStatusId",
                          items: getItems(),
                          initialValue: widget.user.userStatusId?.toString(),
                          onChanged: (value) {
                            setState(() {
                              _selectedStatusId = int.parse(value as String);
                            });
                          },
                        ),
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 35,
                  ),
                  Row(
                    children: [
                      Expanded(
                          child: ElevatedButton(
                        onPressed: () async {
                          _formKey.currentState?.saveAndValidate();
                          var request = Map.from(_formKey.currentState!.value);
                          // Update userStatusId with the selected statusId
                          request['userStatusId'] = _selectedStatusId;

                          // if (request['firstName'] == "AAA") {
                          //   request['firstName'] = "BBB";
                          // }

                          if (widget.user != null) {
                            var updatedUser = await userProvider.update(
                                widget.user!.userId!, request);
                            widget
                                .onUserUpdated(); //refresh table with new data
                            Navigator.pop(context, true);
                          }

                          print("Testtt: ${widget.user!.userId!}, ${request}}");

                          showDialog(
                              context: context,
                              builder: (context) => AlertDialog(
                                    title: Text("Update"),
                                    content: Text("Korisnik je ažuriran"),
                                    actions: [
                                      TextButton(
                                        child: Text(
                                          "OK",
                                          style: TextStyle(color: Colors.green),
                                        ),
                                        onPressed: () {
                                          Navigator.pop(context);
                                        },
                                      )
                                    ],
                                  ));
                        },
                        style: ElevatedButton.styleFrom(
                          backgroundColor:
                              const Color.fromRGBO(72, 156, 118, 100),
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(2.0),
                          ),
                          minimumSize: const Size(100, 65),
                        ),
                        child: const Text("Ažuriraj",
                            style: TextStyle(fontSize: 18)),
                      )),
                    ],
                  ),
                ]),
              ),
      ),
      actions: [
        TextButton(
            onPressed: () => Navigator.pop(context, false),
            child: Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }

  /* getInititalStatus() {
    if (getItems() != null && getItems().length > 0) {
      return getItems()[widget.user.userStatusId ?? 0];
    } else {
      return null;
    }
  }

  getItems() {
    return statusResult?.result
            .map((item) => DropdownMenuItem(
                value: item.statusId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
  }*/
  DropdownMenuItem<int> getInititalStatus() {
    final status = statusResult?.result.firstWhere(
        (status) => status.statusId == widget.user.userStatusId,
        orElse: () => Status(statusId: -1, name: 'No Status'));
    return DropdownMenuItem(
        value: status?.statusId ?? -1, child: Text(status?.name ?? ""));
  }

  List<DropdownMenuItem<String>> getItems() {
    var list = statusResult?.result
            .map((item) => DropdownMenuItem(
                value: item.statusId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    // list.add((DropdownMenuItem(value: -1, child: Text('No Status'))));
    return list;
  }
}
