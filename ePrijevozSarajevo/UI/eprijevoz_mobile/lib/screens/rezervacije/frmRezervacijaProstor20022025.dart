import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/radni_prostor.dart';
import 'package:eprijevoz_mobile/models/rezervacija_prostora20022025.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status_rezervacije.dart';
import 'package:eprijevoz_mobile/models/total_dto.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/radni_prostor_provider.dart';
import 'package:eprijevoz_mobile/providers/rezervacija_prostora20022025_provider.dart';
import 'package:eprijevoz_mobile/providers/status_rezervacije.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/rezervacije/frmRezervacijaProstor20022025New.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class frmRezervacijaProstor20022025 extends StatefulWidget {
  const frmRezervacijaProstor20022025({super.key});

  @override
  State<frmRezervacijaProstor20022025> createState() =>
      _frmRezervacijaProstor20022025State();
}

class _frmRezervacijaProstor20022025State
    extends State<frmRezervacijaProstor20022025> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;

  late StatusRezervacijeProvider statusRezervacijeProvider;
  SearchResult<StatusRezervacije>? statusRezervacijeResult;

  late RadniProstorProvider radniProstorProvider;
  SearchResult<RadniProstor>? radniProstorResultResult;

  late RezervacijaProstora20022025Provider rezervacijaProstora20022025Provider;
  SearchResult<RezervacijaProstora20022025>? rezervacijaProstora20022025Result;

  List<TotalDto>? totalListResult;

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

      totalListResult = await rezervacijaProstora20022025Provider.totalList();

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

  Widget _buildResultView() {
    return isLoading
        ? const Center(
            child: CircularProgressIndicator(),
          )
        : Column(
            children: [
              Container(
                padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
                color: Colors.green.shade800,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    const Text(
                      "frmRezervacijaProstor20022025",
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 12,
                        color: Colors.white,
                      ),
                    ),
                    TextButton(
                      onPressed: () {
                        Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) =>
                                const frmRezervacijaProstor20022025New()));
                      },
                      child: const Text(
                        "Rezerviši ",
                        style: TextStyle(
                            color: Colors.red,
                            fontSize: 15,
                            fontWeight: FontWeight.normal,
                            decoration: TextDecoration.underline,
                            decorationColor: Colors.red,
                            decorationThickness: 1),
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
                          size: 40,
                        )),
                  ],
                ),
              ),
              const SizedBox(height: 15),
              const SizedBox(height: 15),
              const SizedBox(height: 15),
              /*Column(
                children: [
                  _buildSearch(),
                ],
              ),*/
              const SizedBox(height: 15),
              Column(
                children: [
                  _buildDataTable(),
                ],
              ),
              const SizedBox(height: 15),
              /* Column(
                children: [
                  _buildCount(),
                ],
              ),*/
              const SizedBox(height: 15),
            ],
          );
  }

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

  /*Widget _buildSearch() {
    return Container(
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: Row(
          children: [
            const SizedBox(
              width: 20,
            ),
            const SizedBox(
              width: 20,
            ),
            SizedBox(
              height: 60,
              width: 150,
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
                  FormBuilderValidators.required(errorText: "Odaberite ."),
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
                    style: const TextStyle(color: Colors.black, fontSize: 18),
                    decoration: const InputDecoration(
                      border: OutlineInputBorder(),
                      labelText: "Pocetak rezervacije ",
                      labelStyle: TextStyle(color: Colors.black),
                      hintText: 'Unesite datum ',
                      hintStyle: TextStyle(color: Colors.black, fontSize: 13),
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
                    style: const TextStyle(color: Colors.black, fontSize: 18),
                    decoration: const InputDecoration(
                      border: OutlineInputBorder(),
                      labelText: "Trajanje rezervacijee ",
                      labelStyle: TextStyle(color: Colors.black),
                      hintText: 'Unesite datum ',
                      hintStyle: TextStyle(color: Colors.black, fontSize: 13),
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
                style: const TextStyle(color: Colors.black, fontSize: 18),
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: "Napomena",
                  labelStyle: TextStyle(color: Colors.black),
                  hintText: 'Unesite  ',
                  hintStyle: TextStyle(color: Colors.black, fontSize: 13),
                  prefixIcon: Icon(Icons.description),
                  prefixIconColor: Colors.black,
                ),
              ),
            ),
            const SizedBox(
              height: 15,
            ),
            const SizedBox(
              width: 20,
            ),
            ElevatedButton(
              onPressed: () async {
                setState(() {
                  isLoading = true;
                });
                try {
                  var filter = {
                    'DatumEvidencije': _dateOfOD.text,
                    'RadniProstorId': selectedRadniProstorId,
                    'UserId': selectedUserId
                  };

                  rezervacijaProstora20022025Result =
                      await rezervacijaProstora20022025Provider.get(
                          filter: filter);

                  totalListResult = await rezervacijaProstora20022025Provider
                      .totalList(filter: filter);
                } catch (e) {
                  debugPrint('Error: $e');
                } finally {
                  setState(() {
                    isLoading = false;
                  });
                }
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(2.0),
                ),
                minimumSize: const Size(100, 65),
              ),
              child: const Text("Pretraga", style: TextStyle(fontSize: 18)),
            ),
          ],
        ),
      ),
    );
  }*/

  Widget _buildDataTable() {
    return Container(
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: DataTable(
          columns: const <DataColumn>[
            DataColumn(
              label: Flexible(
                child: Text(
                  'Ime i prezime',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
            DataColumn(
              label: Flexible(
                child: Text(
                  'Radni prostor: Oznaka - Kapacitet ',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
            DataColumn(
              label: Flexible(
                child: Text(
                  'Datum rezervacije ',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
            DataColumn(
              label: Flexible(
                child: Text(
                  'Trajanje rezervacije ',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
            DataColumn(
              label: Flexible(
                child: Text(
                  'Status',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
          ],
          rows: rezervacijaProstora20022025Result?.result
                  .map(
                    (e) => DataRow(
                      cells: [
                        DataCell(Text(
                          "${userResult?.result.firstWhere((element) => element.userId == e.userId).firstName ?? ""}"
                          " "
                          "${userResult?.result.firstWhere((element) => element.userId == e.userId).lastName ?? ""}",
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                        DataCell(Text(
                          "${radniProstorResultResult?.result.firstWhere((element) => element.radniProstorId == e.radniProstorId).oznaka ?? ""}"
                          " -"
                          "${radniProstorResultResult?.result.firstWhere((element) => element.radniProstorId == e.radniProstorId).kapacitet ?? ""}",
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                        DataCell(Text(
                          formatDate(e.pocetakRezervacije),
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                        DataCell(Text(
                          formatTime(e.trajanjeRezervacije),
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                        DataCell(Text(
                          "${statusRezervacijeResult?.result.firstWhere((element) => element.statusRezervacijeId == e.statusRezervacijeId).naziv ?? ""}",
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                      ],
                    ),
                  )
                  .toList()
                  .cast<DataRow>() ??
              [],
        ),
      ),
    );
  }

  Widget _buildCount() {
    var result = totalListResult
        ?.map((e) => Row(
              children: [
                const SizedBox(
                  width: 20,
                ),
                Text(
                    "${statusRezervacijeResult?.result.firstWhere((element) => element.statusRezervacijeId == e.vrijednostRaspolozenjaId).naziv ?? ""}"
                    ": "
                    "${e.countRaspolozenja}"),
              ],
            ))
        .toList();
    return Column(
      children: result ?? [],
    );
  }
}
