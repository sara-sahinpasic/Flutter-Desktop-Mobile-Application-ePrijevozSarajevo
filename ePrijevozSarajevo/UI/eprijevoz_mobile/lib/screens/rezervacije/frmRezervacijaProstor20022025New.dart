import 'package:eprijevoz_mobile/models/radni_prostor.dart';
import 'package:eprijevoz_mobile/models/rezervacija_prostora20022025.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status_rezervacije.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/radni_prostor_provider.dart';
import 'package:eprijevoz_mobile/providers/rezervacija_prostora20022025_provider.dart';
import 'package:eprijevoz_mobile/providers/status_rezervacije.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/rezervacije/frmRezervacijaProstor20022025.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class frmRezervacijaProstor20022025New extends StatefulWidget {
  const frmRezervacijaProstor20022025New({super.key});

  @override
  State<frmRezervacijaProstor20022025New> createState() =>
      _frmRezervacijaProstor20022025NewState();
}

class _frmRezervacijaProstor20022025NewState
    extends State<frmRezervacijaProstor20022025New> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;

  late StatusRezervacijeProvider statusRezervacijeProvider;
  SearchResult<StatusRezervacije>? statusRezervacijeResult;

  late RadniProstorProvider radniProstorProvider;
  SearchResult<RadniProstor>? radniProstorResultResult;

  late RezervacijaProstora20022025Provider rezervacijaProstora20022025Provider;
  SearchResult<RezervacijaProstora20022025>? rezervacijaProstora20022025Result;

  bool isLoading = true;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();

    statusRezervacijeProvider = context.read<StatusRezervacijeProvider>();

    radniProstorProvider = context.read<RadniProstorProvider>();

    rezervacijaProstora20022025Provider =
        context.read<RezervacijaProstora20022025Provider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    try {
      userResult = await userProvider.get();

      statusRezervacijeResult = await statusRezervacijeProvider.get();

      radniProstorResultResult = await radniProstorProvider.get();

      rezervacijaProstora20022025Result =
          await rezervacijaProstora20022025Provider.get();

      setState(() {
        isLoading = false;
      });
    } catch (e) {
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

//početak rezervacije
  DateTime? dateOfOD;
  final TextEditingController _dateOfOD = TextEditingController();
  Future<void> selectDateOD(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: dateOfOD ?? DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime(2100),
    );

    if (picked != null && picked != dateOfOD) {
      setState(() {
        dateOfOD = picked;
        _dateOfOD.text = formatDateTimeAPI(picked);
      });
    }
  }

  //trajanje rezervacije
  DateTime? dateOfDO;
  final TextEditingController _dateOfDO = TextEditingController();
  Future<void> selectDateDO(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: dateOfDO ?? DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime(2100),
    );

    if (picked != null && picked != dateOfOD) {
      setState(() {
        dateOfDO = picked;
        _dateOfDO.text = formatDateTimeAPI(picked);
      });
    }
  }

/*
  DateTime selectedDepartureDateTimeVar = DateTime.now();
  final TextEditingController _dateOfODTrajanje = TextEditingController();
  Future<void> selectDepartureDateTime(BuildContext context) async {
    final DateTime? pickedDate = await showDatePicker(
      context: context,
      initialDate: selectedDepartureDateTimeVar,
      firstDate: DateTime(2000),
      lastDate: DateTime(2101),
    );

    if (pickedDate != null) {
      final TimeOfDay? pickedTime = await showTimePicker(
          context: context,
          initialTime: TimeOfDay.fromDateTime(selectedDepartureDateTimeVar));

      if (pickedTime != null) {
        final DateTime fullPickedDateTime = DateTime(
          pickedDate.year,
          pickedDate.month,
          pickedDate.day,
          pickedTime.hour,
          pickedTime.minute,
        );

        setState(() {
          selectedDepartureDateTimeVar = fullPickedDateTime;
        });
      }
    }
  }*/

  //

  int? selectedUserId;
  List<DropdownMenuItem<String>> getUserItems() {
    var list = userResult?.result
            .map((item) => DropdownMenuItem(
                value: item.userId.toString(),
                child: Text("${item.firstName ?? ""} ${item.lastName ?? ""}")))
            .toList() ??
        [];
    return list;
  }

  int? selectedRadniProstorId;
  List<DropdownMenuItem<String>> getRadniProstorItems() {
    var list = radniProstorResultResult?.result
            .map((item) => DropdownMenuItem(
                value: item.radniProstorId.toString(),
                child: Text("${item.oznaka ?? ""} - ${item.kapacitet ?? ""}")))
            .toList() ??
        [];
    return list;
  }

  int? selectedStatuRezervacijeId;
  List<DropdownMenuItem<String>> getStatusRezeravijeItems() {
    var list = statusRezervacijeResult?.result
            .map((item) => DropdownMenuItem(
                value: item.statusRezervacijeId.toString(),
                child: Text("${item.naziv ?? ""} ")))
            .toList() ??
        [];
    return list;
  }

  Widget _buildResultView() {
    return Column(
      children: [
        Container(
          padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
          color: Colors.green.shade800,
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              const Text(
                "frmRezervacijaProstor20022025New",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  fontSize: 12,
                  color: Colors.white,
                ),
              ),
              IconButton(
                  onPressed: () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (context) =>
                            const frmRezervacijaProstor20022025(),
                      ),
                    );
                  },
                  icon: const Icon(
                    Icons.cancel_outlined,
                    color: Colors.white,
                    size: 40,
                  )),
            ],
          ),
        ),
        const SizedBox(height: 15),
        Column(
          children: [
            _buildDataTable(),
          ],
        ),
        const SizedBox(height: 15),
      ],
    );
  }

  final _formKey = GlobalKey<FormBuilderState>();
  Widget _buildDataTable() {
    return FormBuilder(
        key: _formKey,
        child:
            Column(crossAxisAlignment: CrossAxisAlignment.stretch, children: [
          Padding(
              padding: const EdgeInsets.fromLTRB(15.0, 15.0, 15.0, 0.0),
              child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.center,
                  children: [
                    const SizedBox(
                      height: 15,
                    ),
                    SizedBox(
                      height: 60,
                      width: double.infinity,
                      child: FormBuilderDropdown(
                        decoration: const InputDecoration(
                            label: Text(
                          "Korisnik",
                          style: TextStyle(color: Colors.black),
                        )),
                        name: "userId",
                        items: getUserItems(),
                        initialValue: selectedUserId?.toString(),
                        onChanged: (value) {
                          setState(() {
                            selectedUserId = int.parse(value as String);
                          });
                        },
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: "Odaberite ."),
                        ]),
                      ),
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    SizedBox(
                      height: 60,
                      width: double.infinity,
                      child: FormBuilderDropdown(
                        decoration: const InputDecoration(
                            label: Text(
                          "Radni prostor",
                          style: TextStyle(color: Colors.black),
                        )),
                        name: "radniProstorId",
                        items: getRadniProstorItems(),
                        initialValue: selectedRadniProstorId?.toString(),
                        onChanged: (value) {
                          setState(() {
                            selectedRadniProstorId = int.parse(value as String);
                          });
                        },
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: "Odaberite ."),
                        ]),
                      ),
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    SizedBox(
                      height: 60,
                      width: double.infinity,
                      child: GestureDetector(
                        onTap: () => selectDateOD(context),
                        child: AbsorbPointer(
                          child: FormBuilderTextField(
                            name: 'pocetakRezervacije',
                            controller: _dateOfOD,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                errorText: "Ovo polje ne može bit prazno.",
                              ),
                            ]),
                            style: const TextStyle(
                                color: Colors.black, fontSize: 18),
                            decoration: const InputDecoration(
                              border: OutlineInputBorder(),
                              labelText: "Pocetak rezervacije ",
                              labelStyle: TextStyle(color: Colors.black),
                              hintText: 'Unesite datum ',
                              hintStyle:
                                  TextStyle(color: Colors.black, fontSize: 13),
                              prefixIcon: Icon(Icons.date_range),
                              prefixIconColor: Colors.black,
                            ),
                          ),
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    SizedBox(
                      height: 60,
                      width: double.infinity,
                      child: GestureDetector(
                        onTap: () => selectDateOD(context),
                        child: AbsorbPointer(
                          child: FormBuilderTextField(
                            name: 'trajanjeRezervacije',
                            controller: _dateOfOD,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                errorText: "Ovo polje ne može bit prazno.",
                              ),
                            ]),
                            style: const TextStyle(
                                color: Colors.black, fontSize: 18),
                            decoration: const InputDecoration(
                              border: OutlineInputBorder(),
                              labelText: "Trajanje rezervacijee ",
                              labelStyle: TextStyle(color: Colors.black),
                              hintText: 'Unesite datum ',
                              hintStyle:
                                  TextStyle(color: Colors.black, fontSize: 13),
                              prefixIcon: Icon(Icons.date_range),
                              prefixIconColor: Colors.black,
                            ),
                          ),
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    SizedBox(
                      height: 60,
                      width: double.infinity,
                      child: FormBuilderTextField(
                        name: 'napomena',
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: "Ovo polje ne može bit prazno."),
                        ]),
                        style:
                            const TextStyle(color: Colors.black, fontSize: 18),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Napomena",
                          labelStyle: TextStyle(color: Colors.black),
                          hintText: 'Unesite  ',
                          hintStyle:
                              TextStyle(color: Colors.black, fontSize: 13),
                          prefixIcon: Icon(Icons.description),
                          prefixIconColor: Colors.black,
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 15,
                    ),
                    SizedBox(
                      height: 60,
                      width: double.infinity,
                      child: ElevatedButton(
                        onPressed: () async {
                          if (_formKey.currentState?.saveAndValidate() ??
                              false) {
                            var request =
                                Map.from(_formKey.currentState!.value);

                            try {
                              await rezervacijaProstora20022025Provider
                                  .insert(request);
                              showDialog(
                                context: context,
                                builder: (context) => AlertDialog(
                                  title: const Text("Success"),
                                  content: const Text(
                                    "uspješno dodan.",
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
                                                    const frmRezervacijaProstor20022025()));
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
                                      'Greška prilikom dodavanja  \n$error'),
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
                          "Kreiraj ",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 20),
                        ),
                      ),
                    ),
                  ]))
        ]));
  }
}
