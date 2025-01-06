import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UpdateRouteDialog extends StatefulWidget {
  final Route route;
  final Function onDone;
  const UpdateRouteDialog({
    required this.route,
    required this.onDone,
    super.key,
  });

  @override
  State<UpdateRouteDialog> createState() => _UpdateRouteDialogState();
}

class _UpdateRouteDialogState extends State<UpdateRouteDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  DateTime selectedDepartureDateTime = DateTime.now();
  TimeOfDay selectedArrivalTime = TimeOfDay.now();
  TimeOfDay selectedDepartureTime = TimeOfDay.now();
  DateTime selectedArrivalDateTime = DateTime.now();
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  bool isLoading = true;

  @override
  void initState() {
    routeProvider = context.read<RouteProvider>();

    super.initState();

    _initialValue = {
      'departure': widget.route.departure,
      'arrival': widget.route.arrival,
    };

    initForm();
  }

  Future initForm() async {
    routeResult = await routeProvider.get();

    setState(() {
      isLoading = false;

      if (widget.route.departure != null) {
        selectedDepartureDateTime = widget.route.departure!;
      }
      if (widget.route.arrival != null) {
        selectedArrivalDateTime = widget.route.arrival!;
      }
    });
  }

  Future<void> selectDepartureDateTime(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: selectedDepartureDateTime,
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
    );

    if (pickedDate != null) {
      final TimeOfDay? pickedTime = await showTimePicker(
          context: context,
          initialTime: TimeOfDay.fromDateTime(selectedDepartureDateTime));

      if (pickedTime != null) {
        final DateTime fullPickedDateTime = DateTime(
          pickedDate.year,
          pickedDate.month,
          pickedDate.day,
          pickedTime.hour,
          pickedTime.minute,
        );

        setState(() {
          selectedDepartureDateTime = fullPickedDateTime;
        });
      }
    }
  }

  Future<void> selectArrivalDateTime(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: selectedArrivalDateTime,
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
    );

    if (pickedDate != null) {
      final TimeOfDay? pickedTime = await showTimePicker(
        context: context,
        initialTime: TimeOfDay.fromDateTime(selectedArrivalDateTime),
      );

      if (pickedTime != null) {
        final DateTime fullPickedDateTime = DateTime(
          pickedDate.year,
          pickedDate.month,
          pickedDate.day,
          pickedTime.hour,
          pickedTime.minute,
        );

        setState(() {
          selectedArrivalDateTime = fullPickedDateTime;
        });
      }
    }
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
                  child: Column(children: [
                    const SizedBox(
                      height: 15,
                    ),
                    Row(
                      children: [
                        const Text(
                          "Polazak:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(width: 50),
                        Expanded(
                          child: ElevatedButton(
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.white,
                              shape: BeveledRectangleBorder(
                                borderRadius: BorderRadius.circular(0.0),
                                side: const BorderSide(color: Colors.black),
                              ),
                              minimumSize: const Size(450, 40),
                            ),
                            onPressed: () async {
                              selectDepartureDateTime(context);
                            },
                            child: Text(
                              formatDateTimeUI(selectedDepartureDateTime),
                              style: const TextStyle(color: Colors.black),
                            ),
                          ),
                        ),
                      ],
                    ),
                    //
                    Row(
                      children: [
                        const Text(
                          "Dolazak:",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 15),
                        ),
                        const SizedBox(width: 48),
                        Expanded(
                          child: ElevatedButton(
                            style: ElevatedButton.styleFrom(
                              backgroundColor: Colors.white,
                              shape: BeveledRectangleBorder(
                                borderRadius: BorderRadius.circular(0.0),
                                side: const BorderSide(color: Colors.black),
                              ),
                              minimumSize: const Size(450, 40),
                            ),
                            onPressed: () async {
                              selectArrivalDateTime(context);
                            },
                            child: Text(
                              formatDateTimeUI(selectedArrivalDateTime),
                              style: const TextStyle(color: Colors.black),
                            ),
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(height: 25),
                    Row(
                      children: [
                        SizedBox(
                          width: 420,
                          child: ElevatedButton(
                            onPressed: () async {
                              if (_formKey.currentState?.saveAndValidate() ??
                                  false) {
                                var request =
                                    Map.from(_formKey.currentState!.value);

                                DateTime departureDateTime = DateTime(
                                  selectedDepartureDateTime.year,
                                  selectedDepartureDateTime.month,
                                  selectedDepartureDateTime.day,
                                  selectedDepartureDateTime.hour,
                                  selectedDepartureDateTime.minute,
                                );

                                DateTime arrivalDateTime = DateTime(
                                  selectedArrivalDateTime.year,
                                  selectedArrivalDateTime.month,
                                  selectedArrivalDateTime.day,
                                  selectedArrivalDateTime.hour,
                                  selectedArrivalDateTime.minute,
                                );

                                request['departure'] =
                                    departureDateTime.toIso8601String();
                                request['arrival'] =
                                    arrivalDateTime.toIso8601String();

                                try {
                                  await routeProvider.update(
                                      widget.route.routeId!, request);
                                  Navigator.pop(context, true);

                                  showDialog(
                                    context: context,
                                    builder: (context) => AlertDialog(
                                      title: const Text("Update"),
                                      content: const Text(
                                          "Vremena uspješno ažurirana."),
                                      actions: [
                                        TextButton(
                                          child: const Text("OK",
                                              style: TextStyle(
                                                  color: Colors.black)),
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
                                    builder: (dialogContext) => AlertDialog(
                                      title: const Text(
                                        "Error",
                                        style: TextStyle(
                                            color: Colors.red,
                                            fontWeight: FontWeight.bold),
                                      ),
                                      content: Text(
                                          "Greška prilikom ažuriranja rute.->\n$error"),
                                      actions: [
                                        TextButton(
                                          child: const Text(
                                            "OK",
                                            style:
                                                TextStyle(color: Colors.black),
                                          ),
                                          onPressed: () {
                                            Navigator.pop(dialogContext, false);
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
                              minimumSize: const Size(200, 50),
                            ),
                            child: const Text(
                              "Ažuriraj",
                              style: TextStyle(fontSize: 18),
                            ),
                          ),
                        ),
                        const SizedBox(width: 5),
                        Expanded(
                          child: TextButton(
                            onPressed: () => Navigator.pop(context),
                            child: const Text(
                              "Cancel",
                              style: TextStyle(color: Colors.red, fontSize: 16),
                            ),
                          ),
                        ),
                      ],
                    )
                  ]),
                ),
        ),
      ),
    );
  }
}
