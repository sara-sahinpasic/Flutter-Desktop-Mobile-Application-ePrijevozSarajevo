import 'package:eprijevoz_mobile/models/moodTracker30012025.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/models/vrijednostRaspolozenja.dart';
import 'package:eprijevoz_mobile/providers/mood_tracker_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/providers/vrijednost_raspolozenja_provider.dart';
import 'package:eprijevoz_mobile/screens/moodTracker/frmMoodTracker30012025.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class frmMoodTracker30012025New extends StatefulWidget {
  const frmMoodTracker30012025New({super.key});

  @override
  State<frmMoodTracker30012025New> createState() =>
      _frmMoodTracker30012025NewState();
}

class _frmMoodTracker30012025NewState extends State<frmMoodTracker30012025New> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;

  late MoodTrackerProvider moodTrackerProvider;
  SearchResult<MoodTracker30012025>? moodTrackerResult;

  late VrijednostRaspolozenjaProvider vrijednostRaspolozenjaProvider;
  SearchResult<VrijednostRaspolozenja>? vrijednostRaspolozenjaResult;

  bool isLoading = true;

  int? selectedUser;
  int? selectedRaspolozenje;
  DateTime selectedDepartureDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    moodTrackerProvider = context.read<MoodTrackerProvider>();
    vrijednostRaspolozenjaProvider =
        context.read<VrijednostRaspolozenjaProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    try {
      userResult = await userProvider.get();
      vrijednostRaspolozenjaResult = await vrijednostRaspolozenjaProvider.get();
      moodTrackerResult = await moodTrackerProvider.get();

      setState(() {
        isLoading = false;
      });
    } catch (e) {
      setState(() {
        isLoading = false;
      });
    }
  }

  List<DropdownMenuItem<String>> getUserItems() {
    var list = userResult?.result
            .map((item) => DropdownMenuItem(
                value: item.userId.toString(),
                child: Text("${item.firstName ?? ""} ${item.lastName ?? ""}")))
            .toList() ??
        [];
    return list;
  }

  List<DropdownMenuItem<String>> getRaspolozenjeItems() {
    var list = vrijednostRaspolozenjaResult?.result
            .map((item) => DropdownMenuItem(
                value: item.vrijednostRaspolozenjaId.toString(),
                child: Text("${item.naziv ?? ""} ")))
            .toList() ??
        [];
    return list;
  }

  Future<void> selectDateTimeFunc(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: selectedDepartureDate,
      firstDate: DateTime(2000),
      lastDate: DateTime(2100),
    );

    if (pickedDate != null) {
      final TimeOfDay? pickedTime = await showTimePicker(
        context: context,
        initialTime: selectedTime,
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
          selectedDepartureDate = fullPickedDateTime;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            _buildResultView(),
            const SizedBox(height: 15),
          ],
        ),
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }

  final _formKey = GlobalKey<FormBuilderState>();

  Widget _buildResultView() {
    return Column(children: [
      Container(
        padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
        color: Colors.green.shade800,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            const Text(
              "frmMoodTrackerNew",
              style: TextStyle(
                fontWeight: FontWeight.bold,
                fontSize: 25,
                color: Colors.white,
              ),
            ),
            IconButton(
                onPressed: () {
                  Navigator.pop(context);
                },
                icon: const Icon(
                  Icons.cancel_outlined,
                  color: Colors.white,
                  size: 20,
                )),
          ],
        ),
      ),
      FormBuilder(
        key: _formKey,
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            Padding(
              padding: const EdgeInsets.fromLTRB(15.0, 15.0, 15.0, 0.0),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
                    child: FormBuilderDropdown(
                      decoration: InputDecoration(label: Text("Korisnik")),
                      name: "userId",
                      items: getUserItems(),
                      initialValue: selectedUser?.toString(),
                      onChanged: (value) {
                        setState(() {
                          selectedUser = int.parse(value as String);
                        });
                      },
                      validator: FormBuilderValidators.compose([
                        FormBuilderValidators.required(
                            errorText: "Odaberite korisnika."),
                      ]),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
                    child: FormBuilderDropdown(
                      decoration: InputDecoration(label: Text("Raspolozenje")),
                      name: "VrijednostRaspolozenjaId",
                      items: getRaspolozenjeItems(),
                      initialValue: selectedRaspolozenje?.toString(),
                      onChanged: (value) {
                        setState(() {
                          selectedRaspolozenje = int.parse(value as String);
                        });
                      },
                      validator: FormBuilderValidators.compose([
                        FormBuilderValidators.required(
                            errorText: "Odaberite raspoloženje."),
                      ]),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
                    child: FormBuilderTextField(
                      name: 'opisRaspolozenja',
                      validator: FormBuilderValidators.compose([
                        FormBuilderValidators.required(
                            errorText: "Ovo polje ne može bit prazno."),
                      ]),
                      style: const TextStyle(color: Colors.black, fontSize: 18),
                      decoration: const InputDecoration(
                        border: OutlineInputBorder(),
                        labelText: "Opis raspolozenja",
                        labelStyle: TextStyle(color: Colors.black),
                        hintText: 'Unesite opis raspolozenja',
                        hintStyle: TextStyle(color: Colors.black, fontSize: 13),
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
                    child: SizedBox(
                      width: double.infinity,
                      height: 55,
                      child: ElevatedButton(
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.white,
                          shape: BeveledRectangleBorder(
                              borderRadius: BorderRadius.circular(0.0),
                              side: const BorderSide(color: Colors.black)),
                          minimumSize: const Size(250, 40),
                        ),
                        onPressed: () async {
                          await selectDateTimeFunc(context);
                          setState(() {});
                        },
                        child: Text(
                          '${formatDateTime(selectedDepartureDate)} ',
                          style: const TextStyle(color: Colors.black),
                        ),
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 10, vertical: 5),
                    child: SizedBox(
                      width: double.infinity,
                      height: 55,
                      child: ElevatedButton(
                        onPressed: () async {
                          if (_formKey.currentState?.saveAndValidate() ??
                              false) {
                            var request =
                                Map.from(_formKey.currentState!.value);
                            request['userId'] = selectedUser;
                            request['vrijednostRaspolozenjaId'] =
                                selectedRaspolozenje;
                            request['datumEvidencije'] =
                                selectedDepartureDate.toIso8601String();

                            try {
                              await moodTrackerProvider.insert(request);
                              showDialog(
                                context: context,
                                builder: (context) => AlertDialog(
                                  title: const Text("Success"),
                                  content: const Text(
                                    "Zapis je uspješno dodan.",
                                    style: TextStyle(
                                        color: Colors.green,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  actions: [
                                    TextButton(
                                      child: const Text("OK",
                                          style:
                                              TextStyle(color: Colors.black)),
                                      onPressed: () {
                                        Navigator.of(context).push(
                                            MaterialPageRoute(
                                                builder: (context) =>
                                                    const frmMoodTracker30012025()));
                                      },
                                    ),
                                  ],
                                ),
                              );
                            } catch (error) {
                              showDialog(
                                context: context,
                                builder: (context) => AlertDialog(
                                  title: const Text("Error",
                                      style: TextStyle(
                                          color: Colors.red,
                                          fontWeight: FontWeight.bold)),
                                  content: Text(
                                      'Greška prilikom dodavanja zapisa \n$error'),
                                  actions: [
                                    TextButton(
                                      child: const Text("OK",
                                          style:
                                              TextStyle(color: Colors.black)),
                                      onPressed: () {
                                        Navigator.pop(context, false);
                                      },
                                    ),
                                  ],
                                ),
                              );
                            }
                          }
                        },
                        style: ElevatedButton.styleFrom(
                          backgroundColor: Colors.black,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                          padding: const EdgeInsets.symmetric(vertical: 10.0),
                        ),
                        child: const Text(
                          "Dodaj",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 20),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ],
        ),
      )
    ]);
  }
}
