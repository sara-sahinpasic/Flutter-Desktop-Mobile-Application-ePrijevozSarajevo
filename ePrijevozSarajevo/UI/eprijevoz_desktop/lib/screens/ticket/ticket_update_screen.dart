import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/ticket.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/ticket_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class TicketUpdateDialog extends StatefulWidget {
  final Function onDone;
  final Ticket ticket;
  const TicketUpdateDialog(
      {required this.onDone, required this.ticket, super.key});

  @override
  State<TicketUpdateDialog> createState() => _TicketUpdateDialogState();
}

class _TicketUpdateDialogState extends State<TicketUpdateDialog> {
  late TicketProvider ticketProvider;
  SearchResult<Ticket>? ticketResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  String? countryName;
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  int? currentUserId;

  @override
  void initState() {
    ticketProvider = context.read<TicketProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();
    _initialValue = {
      'name': widget.ticket.name,
      'price': widget.ticket.price?.toStringAsFixed(2)
    };
    initForm();
  }

  Future initForm() async {
    ticketResult = await ticketProvider.get();
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
                        "Naziv karte:",
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
                      const SizedBox(height: 15),
                      const Text(
                        "Cijena:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderTextField(
                        name: 'price',
                        decoration: InputDecoration(
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.circular(8.0),
                          ),
                          hintText: "Unesite cijenu",
                        ),
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Ovo polje ne može bit prazno.",
                          ),
                          FormBuilderValidators.numeric(
                              errorText:
                                  "Format cijene mora biti decimalni: 1.50"),
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
                                  request['price'] =
                                      double.parse(request['price']);
                                  request['modifiedDate'] =
                                      DateTime.now().toIso8601String();
                                  request['currentUserId'] = currentUserId;

                                  try {
                                    await ticketProvider.update(
                                        widget.ticket.ticketId!, request);
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
