import 'package:eprijevoz_desktop/models/request.dart';
import 'package:eprijevoz_desktop/providers/request_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class RequestApproveDialog extends StatefulWidget {
  final Request? request;

  RequestApproveDialog({this.request, Key? key}) : super(key: key);

  @override
  State<RequestApproveDialog> createState() => _RequestApproveDialogState();
}

class _RequestApproveDialogState extends State<RequestApproveDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  late RequestProvider requestProvider;
  late UserProvider userProvider;

  @override
  void initState() {
    super.initState();
    requestProvider = context.read<RequestProvider>();
    userProvider = context.read<UserProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Odobri zahtjev"),
      content: SizedBox(
        width: 500,
        child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: [
              const SizedBox(height: 15),
              const Text(
                "Datum istjecanja zahtjeva:",
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
              ),
              const SizedBox(height: 10),
              FormBuilderDateTimePicker(
                name: 'expirationDate',
                initialEntryMode: DatePickerEntryMode.calendar,
                inputType: InputType.date,
                //format: DateFormat("yyyy-MM-dd"),
                decoration: InputDecoration(
                  labelText: 'Odaberite datum',
                  border: OutlineInputBorder(),
                ),
                //validator: FormBuilderValidators.required(context),
              ),
              const SizedBox(height: 30),
              ElevatedButton(
                onPressed: () async {
                  if (_formKey.currentState?.saveAndValidate() ?? false) {
                    DateTime expirationDate =
                        _formKey.currentState?.value['expirationDate'];
                    try {
                      await requestProvider.approveRequest(
                          widget.request!.requestId!, expirationDate);

                      showDialog(
                        context: context,
                        builder: (context) => AlertDialog(
                          title: const Text("Success"),
                          content: const Text("Zahtjev uspješno odobren."),
                          actions: [
                            TextButton(
                              child: const Text("OK",
                                  style: TextStyle(color: Colors.green)),
                              onPressed: () {
                                Navigator.pop(context);
                                Navigator.pop(context, true);
                              },
                            ),
                          ],
                        ),
                      );
                    } catch (error) {
                      showDialog(
                        context: context,
                        builder: (context) => AlertDialog(
                          title: const Text("Error"),
                          content:
                              const Text("Greška prilikom odobrenja zahtjeva."),
                          actions: [
                            TextButton(
                              child: const Text("OK",
                                  style: TextStyle(color: Colors.red)),
                              onPressed: () {
                                Navigator.pop(context);
                              },
                            ),
                          ],
                        ),
                      );
                    }
                  }
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                  minimumSize: const Size(100, 45),
                ),
                child: const Text("Odobri", style: TextStyle(fontSize: 18)),
              ),
            ],
          ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context),
          child: const Text(
            "Cancel",
            style: TextStyle(color: Colors.red, fontSize: 18),
          ),
        ),
      ],
    );
  }
}
