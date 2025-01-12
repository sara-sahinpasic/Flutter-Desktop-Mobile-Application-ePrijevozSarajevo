import 'package:eprijevoz_desktop/models/request.dart';
import 'package:eprijevoz_desktop/providers/request_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class RequestRejectDialog extends StatefulWidget {
  final Request? request;
  final Function onDone;
  const RequestRejectDialog({required this.onDone, this.request, super.key});

  @override
  State<RequestRejectDialog> createState() => _RequestRejectDialogState();
}

class _RequestRejectDialogState extends State<RequestRejectDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  final Map<String, dynamic> _initialValue = {};
  late RequestProvider requestProvider;
  late UserProvider userProvider;
  final TextEditingController ftsRejectReasonController =
      TextEditingController();
  bool isLoading = true;

  @override
  void initState() {
    requestProvider = context.read<RequestProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(
        "Odbij zahtjev",
        style: TextStyle(fontWeight: FontWeight.bold),
      ),
      content: SingleChildScrollView(
        child: SizedBox(
          width: 500,
          child: isLoading
              ? const Center(
                  child: CircularProgressIndicator(),
                )
              : FormBuilder(
                  key: _formKey,
                  initialValue: _initialValue,
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      const SizedBox(height: 15),
                      const Text(
                        "Razlog odbijanja traženog statusa:",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 15),
                      ),
                      const SizedBox(height: 10),
                      Flexible(
                        child: FormBuilderTextField(
                          controller: ftsRejectReasonController,
                          name: 'rejectionReason',
                          validator: FormBuilderValidators.compose([
                            FormBuilderValidators.required(
                                errorText: "Ovo polje ne može bit prazno."),
                          ]),
                          maxLines: 2,
                          keyboardType: TextInputType.multiline,
                          cursorColor: Colors.green.shade800,
                          decoration: const InputDecoration(
                            enabledBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.black),
                              borderRadius: BorderRadius.only(
                                topLeft: Radius.circular(10),
                                topRight: Radius.circular(10),
                                bottomLeft: Radius.circular(10),
                                bottomRight: Radius.circular(10),
                              ),
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 15),
                      ElevatedButton(
                        onPressed: () async {
                          if (_formKey.currentState?.saveAndValidate() ??
                              false) {
                            String? rejectionReason =
                                ftsRejectReasonController.text;

                            try {
                              setState(() {
                                isLoading = true;
                              });

                              await requestProvider.rejectRequest(
                                  widget.request!.requestId!, rejectionReason);

                              showDialog(
                                context: context,
                                builder: (context) => AlertDialog(
                                  title: const Text(
                                    "Success",
                                    style: TextStyle(
                                        color: Colors.green,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  content: const Text("Zahtjev je odbijen."),
                                  actions: [
                                    TextButton(
                                      child: const Text("OK",
                                          style:
                                              TextStyle(color: Colors.black)),
                                      onPressed: () async {
                                        await widget.onDone();
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
                                  title: const Text(
                                    "Error",
                                    style: TextStyle(
                                        color: Colors.red,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  content: Text(
                                      "Greška prilikom odbijanja zahtjeva.\n$error"),
                                  actions: [
                                    TextButton(
                                      child: const Text("OK",
                                          style:
                                              TextStyle(color: Colors.black)),
                                      onPressed: () {
                                        Navigator.pop(context);
                                      },
                                    ),
                                  ],
                                ),
                              );
                            } finally {
                              setState(() {
                                isLoading = false;
                              });
                            }
                          }
                        },
                        style: ElevatedButton.styleFrom(
                          backgroundColor:
                              const Color.fromRGBO(72, 156, 118, 100),
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(2.0),
                          ),
                          minimumSize: const Size(double.infinity, 50),
                        ),
                        child: const Text("Odbij zahtjev",
                            style: TextStyle(fontSize: 18)),
                      ),
                    ],
                  ),
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
