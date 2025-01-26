import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/delay.dart';
import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/providers/delay_provider.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/screens/delay/delay_add_screen.dart';
import 'package:eprijevoz_desktop/screens/delay/delay_update_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class DelaylistScreen extends StatefulWidget {
  const DelaylistScreen({super.key});

  @override
  State<DelaylistScreen> createState() => _DelaylistScreenState();
}

class _DelaylistScreenState extends State<DelaylistScreen> {
  late DelayProvider delayProvider;
  SearchResult<Delay>? delayResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Delay? delay;
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late TypeProvider typeProvider;
  SearchResult<Type>? typeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  @override
  void initState() {
    delayProvider = context.read<DelayProvider>();
    routeProvider = context.read<RouteProvider>();
    typeProvider = context.read<TypeProvider>();
    stationProvider = context.read<StationProvider>();

    super.initState();
    initForm();
  }

  dynamic stationName;
  Future initForm() async {
    delayResult = await delayProvider.get();
    routeResult = await routeProvider.get();
    typeResult = await typeProvider.get();
    stationResult = await stationProvider.get();
  }

  String getRoutesName(int? id) {
    String result = "";

    if (id != null) {
      var ruta =
          routeResult?.result.where((route) => route.routeId == id).firstOrNull;
      var startStation = stationResult?.result
          .where((station) => station.stationId == ruta?.startStationId)
          .firstOrNull;
      var endStation = stationResult?.result
          .where((station) => station.stationId == ruta?.endStationId)
          .firstOrNull;
      result = "${startStation?.name ?? ""} - ${endStation?.name ?? ""}";
    }

    return result;
  }

  List<DropdownMenuItem<String>> getVehicleType() {
    var list = typeResult?.result
            .map((item) => DropdownMenuItem(
                value: item.typeId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  Future refreshTable() async {
    setState(() {
      isLoading = true;
    });
    try {
      var request = Map.from(_formKey.currentState?.value ?? {});
      delayResult = await delayProvider.get(filter: request);
      routeResult = await routeProvider.get();
      typeResult = await typeProvider.get();
      stationResult = await stationProvider.get();
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Kašnjenja",
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

  int? selectedVehicleTypeId;
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
          "Tip vozila:",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        ),
        const SizedBox(
          width: 15,
        ),
        Expanded(
          child: FormBuilderDropdown(
            name: "typeId",
            items: getVehicleType(),
            initialValue: selectedVehicleTypeId?.toString(),
            onChanged: (value) {
              setState(() {
                selectedVehicleTypeId = int.parse(value as String);
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
              var filter = {'TypeIdGTE': selectedVehicleTypeId};
              delayResult = await delayProvider.get(filter: filter);
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
                              'Razlog kašnjenja',
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
                              'Ruta',
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
                              'Kašnjenje u minutama',
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
                              'Tip vozila',
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
                      rows: delayResult?.result
                              .map(
                                (e) => DataRow(
                                  cells: [
                                    DataCell(Text(
                                      '${e.reason}',
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),

                                    DataCell(Text(
                                      '${getRoutesName(e.routeId)}',
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),

                                    DataCell(Text(
                                      '${e.delayAmountMinutes}',
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),

                                    DataCell(Text(
                                      typeResult?.result
                                              .firstWhere((element) =>
                                                  element.typeId == e.typeId)
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
                                                DelayUpdateScreen(
                                                  delay: e,
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
                                                        await delayProvider
                                                            .delete(e.delayId!);
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
                            builder: (BuildContext context) => DelayAddScreen(
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
