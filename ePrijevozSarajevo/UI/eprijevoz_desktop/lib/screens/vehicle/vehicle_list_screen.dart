import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:eprijevoz_desktop/screens/manufacturer/manufacturer_lsit_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle/vehicle_add_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle/vehicle_update_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle_type/vehicle_type_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class VehicleListScreen extends StatefulWidget {
  const VehicleListScreen({super.key});

  @override
  State<VehicleListScreen> createState() => _VehicleListScreenState();
}

class _VehicleListScreenState extends State<VehicleListScreen> {
  late VehicleProvider vehicleProvider;
  late ManufacturerProvider manufacturerProvider;
  late TypeProvider typeProvider;
  final _formKey = GlobalKey<FormBuilderState>();
  SearchResult<Manufacturer>? manufacturerResult;
  SearchResult<Vehicle>? vehicleResult;
  SearchResult<Type>? typeResult;
  bool isLoading = false;
  Vehicle? vehicle;

  @override
  void initState() {
    vehicleProvider = context.read<VehicleProvider>();
    manufacturerProvider = context.read<ManufacturerProvider>();
    typeProvider = context.read<TypeProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    manufacturerResult = await manufacturerProvider.get();
    typeResult = await typeProvider.get();
  }

  Future refreshTable() async {
    setState(() {
      isLoading = true;
    });
    try {
      var request = Map.from(_formKey.currentState?.value ?? {});
      vehicleResult = await vehicleProvider.get(filter: request);
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
      "Vozila",
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
              : _buildResultView()
        ],
      ),
    );
  }

  final TextEditingController _ftsRegistrationMarkController =
      TextEditingController();

  Widget _buildSearch() {
    return Row(
      children: [
        const Text(
          "Registracijska oznaka:",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        ),
        const SizedBox(
          width: 15,
        ),
        Expanded(
            child: TextFormField(
          controller: _ftsRegistrationMarkController,
          cursorColor: Colors.green.shade800,
          decoration: InputDecoration(
            suffixText: "Pretraga po registracijskoj oznaci.",
            suffixStyle: TextStyle(color: Colors.green.shade800),
            labelStyle: TextStyle(
              color: Colors.green.shade800,
            ),
            enabledBorder: const OutlineInputBorder(
              borderSide: BorderSide(
                color: Colors.black,
              ),
              borderRadius: BorderRadius.only(
                topLeft: Radius.circular(10),
                topRight: Radius.circular(10),
                bottomLeft: Radius.circular(10),
                bottomRight: Radius.circular(10),
              ),
            ),
          ),
          inputFormatters: [
            LengthLimitingTextInputFormatter(9),
          ],
        )),
        const SizedBox(
          width: 15,
        ),
        ElevatedButton(
          onPressed: () async {
            setState(() {
              isLoading = true;
            });
            try {
              //Search:
              var filter = {
                'RegistrationNumberGTE': _ftsRegistrationMarkController.text,
              };
              vehicleResult = await vehicleProvider.get(filter: filter);
            } catch (e) {
              debugPrint('Error: $e');
            } finally {
              setState(() {
                isLoading = false;
              });
            }
            _ftsRegistrationMarkController.clear();
          },
          style: ElevatedButton.styleFrom(
            backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(2.0),
            ),
            minimumSize: const Size(100, 65),
          ),
          child: const Text("Pretraga", style: TextStyle(fontSize: 18)),
        )
      ],
    );
  }

  _buildResultView() {
    return Expanded(
      child: SingleChildScrollView(
        child: FormBuilder(
            key: _formKey,
            child: Column(
              children: [
                const SizedBox(
                  height: 20,
                ),
                Column(
                  children: [
                    Row(
                      children: [
                        // type
                        TextButton(
                          onPressed: () => Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) =>
                                  const VehicleTypeListScreen(),
                            ),
                          ),
                          child: Row(
                            children: [
                              Icon(
                                Icons.arrow_forward,
                                color: Colors.green.shade800,
                              ),
                              const SizedBox(width: 5),
                              Text(
                                "Sekcija tipovi vozila",
                                style: TextStyle(
                                  color: Colors.green.shade800,
                                  fontSize: 18,
                                  fontWeight: FontWeight.bold,
                                  decoration: TextDecoration.underline,
                                  decorationColor: Colors.green.shade800,
                                  decorationThickness: 1,
                                ),
                              ),
                            ],
                          ),
                        ),
                        // manufacturer
                        TextButton(
                          onPressed: () => Navigator.of(context).push(
                            MaterialPageRoute(
                              builder: (context) =>
                                  const ManufacturerListScreen(),
                            ),
                          ),
                          child: Row(
                            children: [
                              Icon(
                                Icons.arrow_forward,
                                color: Colors.green.shade800,
                              ),
                              const SizedBox(width: 5),
                              Text(
                                "Sekcija proizvođači",
                                style: TextStyle(
                                  color: Colors.green.shade800,
                                  fontSize: 18,
                                  fontWeight: FontWeight.bold,
                                  decoration: TextDecoration.underline,
                                  decorationColor: Colors.green.shade800,
                                  decorationThickness: 1,
                                ),
                              ),
                            ],
                          ),
                        ),
                      ],
                    ),
                    const SizedBox(
                      height: 20,
                    ),
                    //
                    Container(
                      color: Colors.black,
                      width: double.infinity,
                      child: DataTable(
                        headingRowColor: MaterialStateColor.resolveWith(
                            (states) =>
                                const Color.fromRGBO(72, 156, 118, 100)),
                        columns: const <DataColumn>[
                          DataColumn(
                            label: Flexible(
                              child: Text(
                                'Registracijska oznaka',
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
                                'Broj',
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
                                'Godina proizvodnje',
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
                                'Vrsta',
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
                                'Marka',
                                style: TextStyle(
                                    color: Colors.white,
                                    fontWeight: FontWeight.bold,
                                    fontSize: 18),
                              ),
                            ),
                          ),
                          // update
                          DataColumn(
                            label: Expanded(
                              child: Text(
                                '',
                              ),
                            ),
                          ),
                          // delete
                          DataColumn(
                            label: Expanded(
                              child: Text(
                                '',
                              ),
                            ),
                          ),
                        ],
                        rows: vehicleResult?.result
                                .map(
                                  (e) => DataRow(
                                    cells: [
                                      DataCell(Text(
                                        e.registrationNumber ?? "",
                                        style: const TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        e.number.toString(),
                                        style: const TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        e.buildYear.toString(),
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
                                      DataCell(Text(
                                        manufacturerResult?.result
                                                .firstWhere((element) =>
                                                    element.manufacturerId ==
                                                    e.manufacturerId)
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
                                                  VehicleUpdateDialog(
                                                    vehicle: e,
                                                    onDone: () =>
                                                        refreshTable(),
                                                  ));
                                        },
                                        icon: const Icon(
                                          Icons.tips_and_updates_rounded,
                                          color: Colors.white,
                                        ),
                                      )),
                                      // delete
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
                                                            color:
                                                                Colors.black),
                                                      ),
                                                      onPressed: () async {
                                                        Navigator.pop(
                                                            dialogContext);
                                                        try {
                                                          await vehicleProvider
                                                              .delete(
                                                                  e.vehicleId!);
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
                                                              content:
                                                                  const Text(
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
                                                      child: const Text(
                                                          "Cancel",
                                                          style: TextStyle(
                                                              color:
                                                                  Colors.red)),
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
                          final result = await showDialog(
                              context: context,
                              builder: (dialogAddContext) =>
                                  const VehicleAddDialog());

                          if (result == true) {
                            await refreshTable();
                          }
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
                        ))
                  ],
                ),
              ],
            )),
      ),
    );
  }
}
