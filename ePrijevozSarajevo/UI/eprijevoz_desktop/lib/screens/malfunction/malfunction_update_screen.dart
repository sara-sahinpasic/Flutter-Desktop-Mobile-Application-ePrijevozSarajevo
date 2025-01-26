import 'package:eprijevoz_desktop/models/malfunction.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/providers/malfunction_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class MalfunctionUpdateScreen extends StatefulWidget {
  final Malfunction malfunction;
  final VoidCallback onDone;
  const MalfunctionUpdateScreen(
      {required this.malfunction, required this.onDone, super.key});

  @override
  State<MalfunctionUpdateScreen> createState() =>
      _MalfunctionUpdateScreenState();
}

class _MalfunctionUpdateScreenState extends State<MalfunctionUpdateScreen> {
  late MalfunctionProvider malfunctionProvider;
  SearchResult<Malfunction>? malfunctionResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  Malfunction? malfunction;
  bool? isFixed = false;

  @override
  void initState() {
    malfunctionProvider = context.read<MalfunctionProvider>();

    super.initState();

    // _initialValue = {'fixed': widget.malfunction.fixed};
    initForm();
  }

  Future initForm() async {
    malfunctionResult = await malfunctionProvider.get();

    setState(() {
      isLoading = false;
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
                      const SizedBox(height: 25),
                      Row(
                        children: [
                          Checkbox(
                            checkColor: Colors.black,
                            // value: isFixed,
                            value: widget.malfunction.fixed,
                            onChanged: (bool? value) {
                              setState(() {
                                isFixed = value ?? false;
                                widget.malfunction.fixed = value ?? false;
                              });
                            },
                          ),
                          const Text(
                            "Da li je kvar na vozilu popravljen?",
                            style: TextStyle(
                                fontSize: 16, fontWeight: FontWeight.bold),
                          ),
                        ],
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
                                  request['fixed'] = isFixed;
                                  try {
                                    await malfunctionProvider.update(
                                        widget.malfunction.malfunctionId!,
                                        request);
                                    widget.onDone();
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
                                              widget.onDone();
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
