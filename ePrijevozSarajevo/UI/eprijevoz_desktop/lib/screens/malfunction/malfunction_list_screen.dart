import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/malfunction.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/malfunction_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:eprijevoz_desktop/screens/malfunction/malfunction_add_screen.dart';
import 'package:eprijevoz_desktop/screens/malfunction/malfunction_update_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class MalfunctionListScreen extends StatefulWidget {
  const MalfunctionListScreen({super.key});

  @override
  State<MalfunctionListScreen> createState() => _MalfunctionListScreenState();
}

class _MalfunctionListScreenState extends State<MalfunctionListScreen> {
  late MalfunctionProvider malfunctionProvider;
  SearchResult<Malfunction>? malfunctionResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Malfunction? malfunction;
  late VehicleProvider vehicleProvider;
  SearchResult<Vehicle>? vehicleResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  int? selectedVehicleId;
  int? selectedStationId;

  @override
  void initState() {
    malfunctionProvider = context.read<MalfunctionProvider>();
    vehicleProvider = context.read<VehicleProvider>();
    stationProvider = context.read<StationProvider>();

    super.initState();
    initForm();
  }

  Future initForm() async {
    malfunctionResult = await malfunctionProvider.get();
    vehicleResult = await vehicleProvider.get();
    stationResult = await stationProvider.get();
  }

  Future refreshTable() async {
    setState(() {
      isLoading = true;
    });
    try {
      var request = Map.from(_formKey.currentState?.value ?? {});
      malfunctionResult = await malfunctionProvider.get(filter: request);
      vehicleResult = await vehicleProvider.get();
      stationResult = await stationProvider.get();
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  List<DropdownMenuItem<String>> getVehicle() {
    var list = vehicleResult?.result
            .map((item) => DropdownMenuItem(
                value: item.manufacturerId.toString(),
                child: Text(item.registrationNumber ?? "")))
            .toList() ??
        [];
    return list;
  }

  List<DropdownMenuItem<String>> getStatione() {
    var list = stationResult?.result
            .map((item) => DropdownMenuItem(
                value: item.stationId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Kvarovi",
      Column(
        children: [
          const SizedBox(
            height: 5,
          ),
          const Align(
            alignment: Alignment.centerLeft,
            child: Text(
              "Za prikaz svih rezultata, neophodno je pritisnuti dugme "
              '"Pretraga"'
              ".",
              style: TextStyle(fontWeight: FontWeight.w400),
            ),
          ),
          const SizedBox(
            height: 20,
          ),
          _buildSearch(),
          isLoading
              ? const Center(child: CircularProgressIndicator())
              : _buildResultView(),
        ],
      ),
    );
  }

  Widget _buildSearch() {
    return Row(
      children: [
        Row(
          children: [
            IconButton(
              icon: Icon(
                Icons.arrow_back,
                color: Colors.green.shade800,
              ),
              onPressed: () {
                Navigator.pop(context);
              },
            ),
            Text(
              "back",
              style: TextStyle(
                  fontSize: 20,
                  fontWeight: FontWeight.bold,
                  color: Colors.green.shade800,
                  decoration: TextDecoration.underline),
            ),
          ],
        ),
        const SizedBox(
          width: 15,
        ),
        const Text(
          "Registracijska oznaka vozila:",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        ),
        const SizedBox(
          width: 15,
        ),
        Expanded(
          child: FormBuilderDropdown(
            name: "vehicleId",
            items: getVehicle(),
            initialValue: selectedVehicleId?.toString(),
            onChanged: (value) {
              setState(() {
                selectedVehicleId = int.parse(value as String);
              });
            },
            validator: FormBuilderValidators.compose([
              FormBuilderValidators.required(errorText: "Odaberite vozilo."),
            ]),
          ),
        ),
        const SizedBox(
          width: 15,
        ),
        ElevatedButton(
          onPressed: () async {
            setState(() {
              isLoading = true;
            });
            try {
              var filter = {
                'VehicleIdGTE': selectedVehicleId,
              };
              malfunctionResult = await malfunctionProvider.get(filter: filter);
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
    );
  }

  Widget _buildResultView() {
    return Expanded(
      child: SingleChildScrollView(
        child: FormBuilder(
          key: _formKey,
          child: Column(
            children: [
              const SizedBox(
                height: 40,
              ),
              Column(
                children: [
                  Container(
                    color: Colors.black,
                    width: double.infinity,
                    child: DataTable(
                      headingRowColor: MaterialStateColor.resolveWith(
                          (states) => const Color.fromRGBO(72, 156, 118, 100)),
                      columns: const <DataColumn>[
                        DataColumn(
                          label: Flexible(
                            child: Text(
                              'Opis',
                              softWrap: true,
                              overflow: TextOverflow.visible,
                              style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 18),
                            ),
                          ),
                        ),
                        DataColumn(
                          label: Flexible(
                            child: Text(
                              'Datum',
                              softWrap: true,
                              overflow: TextOverflow.visible,
                              style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 18),
                            ),
                          ),
                        ),
                        DataColumn(
                          label: Flexible(
                            child: Text(
                              'Popravljen',
                              softWrap: true,
                              overflow: TextOverflow.visible,
                              style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 18),
                            ),
                          ),
                        ),
                        DataColumn(
                          label: Flexible(
                            child: Text(
                              'Vozilo',
                              softWrap: true,
                              overflow: TextOverflow.visible,
                              style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 18),
                            ),
                          ),
                        ),
                        DataColumn(
                          label: Flexible(
                            child: Text(
                              'Najbliža stanica',
                              softWrap: true,
                              overflow: TextOverflow.visible,
                              style: TextStyle(
                                  color: Colors.white,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 18),
                            ),
                          ),
                        ),
                        DataColumn(
                          label: Expanded(
                            child: Text(
                              '',
                            ),
                          ),
                        ),
                        DataColumn(
                          label: Expanded(
                            child: Text(
                              '',
                            ),
                          ),
                        ),
                      ],
                      rows: malfunctionResult?.result
                              .map(
                                (e) => DataRow(
                                  cells: [
                                    DataCell(Text(
                                      '${e.description}',
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),
                                    DataCell(Text(
                                      formatDate(e.dateOfMalufunction),
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),
                                    DataCell(Text(
                                      '${e.fixed}',
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),
                                    DataCell(Text(
                                      vehicleResult?.result
                                              .where((element) =>
                                                  element.vehicleId ==
                                                  e.vehicleId)
                                              .firstOrNull
                                              ?.registrationNumber ??
                                          "",
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),
                                    //********** */
                                    DataCell(Text(
                                      stationResult?.result
                                              .firstWhere((element) =>
                                                  element.stationId ==
                                                  e.stationId)
                                              .name ??
                                          "",
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),

                                    // update
                                    DataCell(IconButton(
                                      onPressed: () {
                                        showDialog(
                                            context: context,
                                            builder: (BuildContext context) =>
                                                MalfunctionUpdateScreen(
                                                  malfunction: e,
                                                  onDone: () => refreshTable(),
                                                ));
                                      },
                                      icon: const Icon(
                                        Icons.tips_and_updates_rounded,
                                        color: Colors.white,
                                      ),
                                    )),

                                    // delete:
                                    DataCell(
                                      IconButton(
                                        onPressed: () async {
                                          await showDialog(
                                            context: context,
                                            builder: (dialogContext) {
                                              return AlertDialog(
                                                title: const Text(
                                                  "Delete",
                                                  style: TextStyle(
                                                      fontWeight:
                                                          FontWeight.bold),
                                                ),
                                                content: const Text(
                                                  "Da li želite obrisati zapis?",
                                                ),
                                                actions: [
                                                  TextButton(
                                                    child: const Text(
                                                      "OK",
                                                      style: TextStyle(
                                                          color: Colors.black),
                                                    ),
                                                    onPressed: () async {
                                                      Navigator.pop(
                                                          dialogContext);
                                                      try {
                                                        await malfunctionProvider
                                                            .delete(e
                                                                .malfunctionId!);
                                                        setState(() {});
                                                        await showDialog(
                                                          context: context,
                                                          builder:
                                                              (successDialogContext) =>
                                                                  AlertDialog(
                                                            title: const Text(
                                                              "Success",
                                                              style: TextStyle(
                                                                  color: Colors
                                                                      .green,
                                                                  fontWeight:
                                                                      FontWeight
                                                                          .bold),
                                                            ),
                                                            content: const Text(
                                                              "Zapis je uspješno obrisan.",
                                                            ),
                                                            actions: [
                                                              TextButton(
                                                                onPressed: () =>
                                                                    Navigator.pop(
                                                                        successDialogContext),
                                                                child:
                                                                    const Text(
                                                                  "OK",
                                                                  style: TextStyle(
                                                                      color: Colors
                                                                          .black),
                                                                ),
                                                              ),
                                                            ],
                                                          ),
                                                        );
                                                      } catch (error) {
                                                        String errorMessage =
                                                            "Greška prilikom brisanja zapisa.\n$error";

                                                        await showDialog(
                                                          context: context,
                                                          builder:
                                                              (errorDialogContext) =>
                                                                  AlertDialog(
                                                            title: const Text(
                                                              "Error",
                                                              style: TextStyle(
                                                                  color: Colors
                                                                      .red,
                                                                  fontWeight:
                                                                      FontWeight
                                                                          .bold),
                                                            ),
                                                            content: Text(
                                                              errorMessage,
                                                            ),
                                                            actions: [
                                                              TextButton(
                                                                onPressed: () =>
                                                                    Navigator.pop(
                                                                        errorDialogContext),
                                                                child:
                                                                    const Text(
                                                                  "OK",
                                                                  style: TextStyle(
                                                                      color: Colors
                                                                          .black),
                                                                ),
                                                              ),
                                                            ],
                                                          ),
                                                        );
                                                      }
                                                      refreshTable();
                                                    },
                                                  ),
                                                  TextButton(
                                                    child: const Text("Cancel",
                                                        style: TextStyle(
                                                            color: Colors.red)),
                                                    onPressed: () =>
                                                        Navigator.pop(
                                                            dialogContext,
                                                            false),
                                                  ),
                                                ],
                                              );
                                            },
                                          );
                                        },
                                        icon: const Icon(
                                            Icons.delete_forever_rounded,
                                            color: Colors.white),
                                      ),
                                    )
                                  ],
                                ),
                              )
                              .toList()
                              .cast<DataRow>() ??
                          [],
                    ),
                  ),
                  const SizedBox(
                    height: 15,
                  ),
                  ElevatedButton(
                      onPressed: () async {
                        showDialog(
                            context: context,
                            builder: (BuildContext context) =>
                                MalfunctionAddScreen(
                                  onDone: () => refreshTable(),
                                ));
                      },
                      style: ElevatedButton.styleFrom(
                        backgroundColor:
                            const Color.fromRGBO(72, 156, 118, 100),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(2.0),
                        ),
                        minimumSize: const Size(double.infinity, 65),
                      ),
                      child: const Text(
                        "Dodaj",
                        style: TextStyle(
                            fontSize: 18, fontWeight: FontWeight.bold),
                      )),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
