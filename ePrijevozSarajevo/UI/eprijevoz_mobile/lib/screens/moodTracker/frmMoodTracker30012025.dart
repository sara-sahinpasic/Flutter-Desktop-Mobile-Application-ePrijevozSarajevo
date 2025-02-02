import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/countRaspolozenja.dart';
import 'package:eprijevoz_mobile/models/moodTracker30012025.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/models/vrijednostRaspolozenja.dart';
import 'package:eprijevoz_mobile/providers/mood_tracker_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/providers/vrijednost_raspolozenja_provider.dart';
import 'package:eprijevoz_mobile/screens/moodTracker/frmMoodTracker30012025New.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class frmMoodTracker30012025 extends StatefulWidget {
  const frmMoodTracker30012025({super.key});

  @override
  State<frmMoodTracker30012025> createState() => _frmMoodTracker30012025State();
}

class _frmMoodTracker30012025State extends State<frmMoodTracker30012025> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;

  late VrijednostRaspolozenjaProvider vrijednostRaspolozenjaProvider;
  SearchResult<VrijednostRaspolozenja>? vrijednostRaspolozenjaResult;

  late MoodTrackerProvider moodTrackerProvider;
  SearchResult<MoodTracker30012025>? moodTrackerResult;

  CountRaspolozenja? moodTrackerResultCount;

  final _formKey = GlobalKey<FormBuilderState>();

  int? selectedUser;
  DateTime selectedDepartureDate = DateTime.now();
  TimeOfDay selectedTime = TimeOfDay.now();
  int? selectedRaspolozenje;

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

  bool isLoading = true;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    moodTrackerProvider = context.read<MoodTrackerProvider>();
    vrijednostRaspolozenjaProvider =
        context.read<VrijednostRaspolozenjaProvider>();

    initForm();

    super.initState();
  }

  Future initForm() async {
    try {
      userResult = await userProvider.get();
      moodTrackerResult = await moodTrackerProvider.get();
      vrijednostRaspolozenjaResult = await vrijednostRaspolozenjaProvider.get();
      moodTrackerResultCount = await moodTrackerProvider.countRaspolozenja();

      setState(() {
        isLoading = false;
      });
    } catch (e) {
      print(e);
      setState(() {
        isLoading = false;
      });
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

  Widget _buildResultView() {
    return Column(children: [
      Container(
        padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
        color: Colors.green.shade800,
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            const Text(
              "frmMoodTracker",
              style: TextStyle(
                fontWeight: FontWeight.bold,
                fontSize: 25,
                color: Colors.white,
              ),
            ),
            IconButton(
                onPressed: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                      builder: (context) => const MasterScreen(
                        initialIndex: 0,
                      ),
                    ),
                  );
                },
                icon: const Icon(
                  Icons.cancel_outlined,
                  color: Colors.white,
                  size: 20,
                )),
            TextButton(
                child: const Text(
                  "Dodaj",
                  style: TextStyle(
                      decoration: TextDecoration.underline,
                      decorationColor: Colors.red,
                      color: Color.fromARGB(255, 212, 16, 2),
                      fontWeight: FontWeight.bold,
                      fontSize: 20),
                ),
                onPressed: () => Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => const frmMoodTracker30012025New()))),
          ],
        ),
      ),
      Column(
        children: [
          const SizedBox(
            height: 30,
          ),
          _buildSearch(),
        ],
      ),
      // data table
      Column(
        children: [
          const SizedBox(
            height: 30,
          ),
          _buildDataTable(),
        ],
      ),
      // count
      Row(
        children: [
          const SizedBox(
            height: 30,
          ),
          _countData(),
        ],
      ),
    ]);
  }

  Widget _countData() {
    return Column(
      children: [
        Text("Sretan: ${moodTrackerResultCount?.sretanCount}"),
        Text("Tuzan: ${moodTrackerResultCount?.tuzanCount}"),
        Text("Uzbuđen: ${moodTrackerResultCount?.uzbudenCount}"),
        Text("Umoran: ${moodTrackerResultCount?.umoranCount}"),
        Text("Pod stresom: ${moodTrackerResultCount?.podStresomCount}"),
        const SizedBox(
          height: 20,
        ),
      ],
    );
  }

  Widget _buildSearch() {
    return Column(
      children: [
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
                      padding: const EdgeInsets.symmetric(
                          horizontal: 10, vertical: 5),
                      child: FormBuilderDropdown(
                        decoration: const InputDecoration(
                            label: Text(
                          "Korisnik",
                          style: TextStyle(color: Colors.black),
                        )),
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
                      padding: const EdgeInsets.symmetric(
                          horizontal: 10, vertical: 5),
                      child: FormBuilderDropdown(
                        decoration: const InputDecoration(
                            label: Text(
                          "Raspoloženje",
                          style: TextStyle(color: Colors.black),
                        )),
                        name: "vrijednostRaspolozenjaId",
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
                      padding: const EdgeInsets.symmetric(
                          horizontal: 10, vertical: 5),
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
                      padding: const EdgeInsets.symmetric(
                          horizontal: 10, vertical: 5),
                      child: SizedBox(
                        width: double.infinity,
                        height: 55,
                        child: ElevatedButton(
                          onPressed: () async {
                            setState(() {
                              isLoading = true;
                            });
                            try {
                              var filter = {
                                'userId': selectedUser,
                                'vrijednostRaspolozenjaId':
                                    selectedRaspolozenje,
                                'datumEvidencije': selectedDepartureDate,
                              };
                              moodTrackerResult =
                                  await moodTrackerProvider.get(filter: filter);
                            } catch (e) {
                              debugPrint('Error: $e');
                            } finally {
                              setState(() {
                                isLoading = false;
                              });
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
                            "Pretraga",
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
      ],
    );
  }

  Widget _buildDataTable() {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: DataTable(
        columns: const <DataColumn>[
          DataColumn(
            label: Text(
              'Ime i prezime korisnika',
              softWrap: true,
              overflow: TextOverflow.visible,
              style: TextStyle(
                  color: Colors.black,
                  fontWeight: FontWeight.bold,
                  fontSize: 18),
            ),
          ),
          DataColumn(
            label: Text(
              'Raspoloženje',
              softWrap: true,
              overflow: TextOverflow.visible,
              style: TextStyle(
                  color: Colors.black,
                  fontWeight: FontWeight.bold,
                  fontSize: 18),
            ),
          ),
          DataColumn(
            label: Text(
              'Opis',
              softWrap: true,
              overflow: TextOverflow.visible,
              style: TextStyle(
                  color: Colors.black,
                  fontWeight: FontWeight.bold,
                  fontSize: 18),
            ),
          ),
          DataColumn(
            label: Text(
              'Datum',
              style: TextStyle(
                  color: Colors.white,
                  fontWeight: FontWeight.bold,
                  fontSize: 18),
            ),
          ),
        ],
        rows: moodTrackerResult?.result
                .map((e) {
                  var userFirstName = userResult?.result
                          .where((element) => element.userId == e.userId)
                          .firstOrNull
                          ?.firstName ??
                      "";
                  var userLastName = userResult?.result
                          .where((element) => element.userId == e.userId)
                          .firstOrNull
                          ?.lastName ??
                      "";
                  var raspolozenje = vrijednostRaspolozenjaResult?.result
                          .where((element) =>
                              element.vrijednostRaspolozenjaId ==
                              e.vrijednostRaspolozenjaId)
                          .firstOrNull
                          ?.naziv ??
                      "";
                  return DataRow(
                    cells: [
                      DataCell(Text(
                        "$userFirstName $userLastName",
                        style:
                            const TextStyle(color: Colors.black, fontSize: 17),
                      )),
                      DataCell(Text(
                        raspolozenje,
                        style:
                            const TextStyle(color: Colors.black, fontSize: 17),
                      )),
                      DataCell(Text(
                        e.opis ?? "",
                        style:
                            const TextStyle(color: Colors.black, fontSize: 17),
                      )),
                      DataCell(Text(
                        formatDate(e.datumEvidencije),
                        style:
                            const TextStyle(color: Colors.black, fontSize: 17),
                      )),
                    ],
                  );
                }) //map
                .toList()
                .cast<DataRow>() ??
            [],
      ),
    );
  }
}
