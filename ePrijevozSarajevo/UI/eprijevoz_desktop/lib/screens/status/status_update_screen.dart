import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/status.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/status_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class StatusUpdateDialog extends StatefulWidget {
  final Function onDone;
  final Status status;
  const StatusUpdateDialog(
      {required this.onDone, required this.status, super.key});

  @override
  State<StatusUpdateDialog> createState() => _StatusUpdateDialogState();
}

class _StatusUpdateDialogState extends State<StatusUpdateDialog> {
  late StatusProvider statusProvider;
  SearchResult<Status>? statusResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  String? countryName;
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  int? currentUserId;

  @override
  void initState() {
    statusProvider = context.read<StatusProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();
    _initialValue = {
      'name': widget.status.name,
      'discount': widget.status.discount?.toStringAsFixed(2)
    };
    initForm();
  }

  Future initForm() async {
    statusResult = await statusProvider.get();
    userResult = await userProvider.get();

    setState(() {
      isLoading = false;

      currentUserId = userResult?.result
          .firstWhere((user) => user.userName == AuthProvider.username)
          .userId;
    });
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(
        "Update",
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
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(height: 15),
                      const Text(
                        "Naziv statusa:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderTextField(
                        name: 'name',
                        decoration: InputDecoration(
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                          hintText: "Unesite naziv",
                        ),
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Ovo polje ne može bit prazno.",
                          ),
                          FormBuilderValidators.match(
                            r'^[a-zA-Z\s]*$',
                            errorText:
                                "Ovo polje može sadržavati isključivo slova.",
                          ),
                        ]),
                      ),
                      //
                      const SizedBox(height: 15),
                      const Text(
                        "Povlastica:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderTextField(
                        name: 'discount',
                        decoration: InputDecoration(
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                          hintText: "Unesite povlasticu",
                        ),
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Ovo polje ne može bit prazno.",
                          ),
                          FormBuilderValidators.numeric(
                              errorText:
                                  "Format broja povlastice mora biti decimalni: 0.10"),
                        ]),
                      ),
                      const SizedBox(height: 25),
                      Row(
                        children: [
                          Expanded(
                            child: ElevatedButton(
                              onPressed: () async {
                                if (_formKey.currentState?.saveAndValidate() ??
                                    false) {
                                  var request =
                                      Map.from(_formKey.currentState!.value);
                                  request['discount'] =
                                      double.parse(request['discount']);
                                  request['modifiedDate'] =
                                      DateTime.now().toIso8601String();
                                  request['currentUserId'] = currentUserId;

                                  try {
                                    await statusProvider.update(
                                        widget.status.statusId!, request);
                                    Navigator.pop(context, true);

                                    showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                        title: const Text("Update"),
                                        content:
                                            const Text("Zapis je ažuriran."),
                                        actions: [
                                          TextButton(
                                            child: const Text(
                                              "OK",
                                              style: TextStyle(
                                                  color: Colors.black),
                                            ),
                                            onPressed: () async {
                                              await widget.onDone();
                                              Navigator.pop(context, true);
                                            },
                                          )
                                        ],
                                      ),
                                    );
                                  } catch (error) {
                                    showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                        title: const Text("Error"),
                                        content: Text(
                                          "Greška prilikom ažuriranja zapisa: $error",
                                        ),
                                        actions: [
                                          TextButton(
                                            onPressed: () =>
                                                Navigator.pop(context),
                                            child: const Text("OK"),
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
                                minimumSize: const Size(100, 65),
                              ),
                              child: const Text(
                                "Ažuriraj",
                                style: TextStyle(fontSize: 18),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context, false),
          child: const Text(
            "Cancel",
            style: TextStyle(color: Colors.red, fontSize: 18),
          ),
        ),
      ],
    );
  }
}
