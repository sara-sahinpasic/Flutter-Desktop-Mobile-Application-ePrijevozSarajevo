import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';

class UpdateRouteDialog extends StatefulWidget {
  Route? route;
  //final VoidCallback onUpdate;

  UpdateRouteDialog(this.route,
      //this.onUpdate,
      {super.key});

  @override
  State<UpdateRouteDialog> createState() => _UpdateRouteDialogState();
}

class _UpdateRouteDialogState extends State<UpdateRouteDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  DateTime selectedDate = DateTime.now();
  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
        context: context,
        initialDate: selectedDate,
        firstDate: DateTime(2015, 8),
        lastDate: DateTime(2101));

    if (picked != null && picked != selectedDate) {
      selectedDate = picked;
      setState(() {});
    }
  }

  TimeOfDay selectedTime = TimeOfDay.now();

  Future<void> _selectTime(BuildContext context) async {
    final TimeOfDay? pickedTime = await showTimePicker(
        context: context,
        initialTime: selectedTime,
        builder: (BuildContext context, Widget? child) {
          // Make child optional (Widget? child)
          return MediaQuery(
            data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: false),
            child: child!,
          );
        });

    if (pickedTime != null && pickedTime != selectedTime) {
      selectedTime = pickedTime;
      setState(() {});
    }
  }

  @override
  final TextEditingController _ftsArrivalController = TextEditingController();

  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Update"),
      content: Container(
        // color: Colors.red,
        width: 500,
        height: 450,
        child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(children: [
            SizedBox(
              height: 15,
            ),
            Row(
              children: [
                const Text(
                  "Vrijeme polaska:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                ),
                const SizedBox(
                  width: 80,
                ),
                Expanded(
                    child:
                        /*FormBuilderTextField(
                    name: 'firstName',
                    controller: _ftsArrivalController,
                    cursorColor: Colors.green.shade800,
                    decoration: InputDecoration(
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(color: Colors.black),
                      ),
                    ),
                  ),*/
                        Column(
                  children: [
                    ElevatedButton(
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.white,
                        shape: BeveledRectangleBorder(
                            borderRadius: BorderRadius.circular(0.0),
                            side: BorderSide(color: Colors.black)),
                        minimumSize: Size(250, 40),
                      ),
                      onPressed: () async {
                        _selectTime(context);
                        print("Selektovano vrijeme: ${selectedTime}");
                        setState(() {});
                      },
                      child: Text(
                        '${formatTime(selectedDate)} ',
                        style: TextStyle(color: Colors.black),
                      ),
                    ),
                  ],
                )),
              ],
            ),
            SizedBox(
              height: 15,
            ),
            Row(
              children: [
                Expanded(
                    child: ElevatedButton(
                  onPressed: () async {
                    _formKey.currentState?.saveAndValidate();
                    var request = Map.from(_formKey.currentState!.value);

                    /* // Update userStatusId with the selected statusId
                    //request['userStatusId'] = _selectedStatusId;

                    // if (request['firstName'] == "AAA") {
                    //   request['firstName'] = "BBB";
                    // }

                    // if (widget.user != null) {
                    //   await userProvider.update(widget.user!.userId!, request);
                    //   Navigator.pop(context);
                    // }

                    // print("Testtt: ${widget.user!.userId!}, ${request}}");
                    // widget.onUpdate();*/

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
                    backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(2.0),
                    ),
                    minimumSize: const Size(100, 65),
                  ),
                  child: const Text("Ažuriraj", style: TextStyle(fontSize: 18)),
                )),
              ],
            ),
          ]),
        ),
      ),
      actions: [
        TextButton(
            onPressed: () => Navigator.pop(context),
            child: Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }
}
