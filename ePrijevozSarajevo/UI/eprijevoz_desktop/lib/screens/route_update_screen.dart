import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UpdateRouteDialog extends StatefulWidget {
  Route route;
  UpdateRouteDialog({required this.route, super.key});

  @override
  State<UpdateRouteDialog> createState() => _UpdateRouteDialogState();
}

class _UpdateRouteDialogState extends State<UpdateRouteDialog> {
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  TimeOfDay selectedDepartureTime = TimeOfDay.now();
  TimeOfDay selectedArrivalTime = TimeOfDay.now();

  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;

  @override
  void initState() {
    super.initState();

    routeProvider = context.read<RouteProvider>();
    /*if (widget.route.departure != null && widget.route.arrival != null) {
      selectedDepartureTime = TimeOfDay.fromDateTime(widget.route.departure!);
      selectedArrivalTime = TimeOfDay.fromDateTime(widget.route.departure!);
    }*/
    initForm();
  }

  Future initForm() async {
    routeResult = await routeProvider.get();
    setState(() {
      _initialValue = {
        'departure': widget.route.departure,
        'arrival': widget.route.arrival,
      };

      if (widget.route.departure != null) {
        selectedDepartureTime = TimeOfDay.fromDateTime(widget.route.departure!);
      }
      if (widget.route.arrival != null) {
        selectedArrivalTime = TimeOfDay.fromDateTime(widget.route.arrival!);
      }
    });
  }

  Future<void> _selectDepartureTime(BuildContext context) async {
    final TimeOfDay? pickedTime = await showTimePicker(
      context: context,
      initialTime: selectedDepartureTime,
      builder: (BuildContext context, Widget? child) {
        return MediaQuery(
          data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: true),
          child: child!,
        );
      },
    );

    if (pickedTime != null) {
      setState(() {
        selectedDepartureTime = pickedTime;
      });
    }
  }

  Future<void> _selectArrivalTime(BuildContext context) async {
    final TimeOfDay? pickedTime = await showTimePicker(
      context: context,
      initialTime: selectedArrivalTime,
      builder: (BuildContext context, Widget? child) {
        return MediaQuery(
          data: MediaQuery.of(context).copyWith(alwaysUse24HourFormat: true),
          child: child!,
        );
      },
    );

    if (pickedTime != null) {
      setState(() {
        selectedArrivalTime = pickedTime;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Update"),
      content: SizedBox(
        width: 500,
        height: 150,
        child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(children: [
            const SizedBox(
              height: 15,
            ),
            Row(
              children: [
                const Text(
                  "Vrijeme polaska:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
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
                      _selectDepartureTime(context);
                    },
                    child: Text(
                      '${selectedDepartureTime.hour}:${selectedDepartureTime.minute}',
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
                  "Vrijeme dolaska:",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
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
                      _selectArrivalTime(context);
                    },
                    child: Text(
                      '${selectedArrivalTime.hour}:${selectedArrivalTime.minute}',
                      style: const TextStyle(color: Colors.black),
                    ),
                  ),
                ),
              ],
            ),
            //
            const SizedBox(height: 25),
            Row(
              children: [
                SizedBox(
                  width: 420,
                  child: ElevatedButton(
                    onPressed: () async {
                      _formKey.currentState?.saveAndValidate();
                      var request = Map.from(_formKey.currentState!.value);

                      DateTime departureDateTime = DateTime(
                        widget.route.departure!.year,
                        widget.route.departure!.month,
                        widget.route.departure!.day,
                        selectedDepartureTime.hour,
                        selectedDepartureTime.minute,
                      );

                      DateTime arrivalDateTime = DateTime(
                        widget.route.arrival!.year,
                        widget.route.arrival!.month,
                        widget.route.arrival!.day,
                        selectedArrivalTime.hour,
                        selectedArrivalTime.minute,
                      );

                      request['departure'] =
                          departureDateTime.toIso8601String();
                      request['arrival'] = arrivalDateTime.toIso8601String();

                      if (widget.route != null) {
                        await routeProvider.update(
                            widget.route!.routeId!, request);
                        Navigator.pop(context, true);
                      }

                      showDialog(
                        context: context,
                        builder: (context) => AlertDialog(
                          title: const Text("Update"),
                          content: const Text("Vremena su ažurirana"),
                          actions: [
                            TextButton(
                              child: const Text(
                                "OK",
                                style: TextStyle(color: Colors.green),
                              ),
                              onPressed: () {
                                Navigator.pop(context);
                              },
                            )
                          ],
                        ),
                      );
                    },
                    style: ElevatedButton.styleFrom(
                      backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
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
    );
  }
}
