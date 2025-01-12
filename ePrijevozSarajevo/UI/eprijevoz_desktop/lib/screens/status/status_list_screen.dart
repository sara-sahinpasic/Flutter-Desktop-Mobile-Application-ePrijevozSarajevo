import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/status.dart';
import 'package:eprijevoz_desktop/providers/status_provider.dart';
import 'package:eprijevoz_desktop/screens/status/status_add_screen.dart';
import 'package:eprijevoz_desktop/screens/status/status_update_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class StatusListScreen extends StatefulWidget {
  const StatusListScreen({super.key});

  @override
  State<StatusListScreen> createState() => _StatusListScreenState();
}

class _StatusListScreenState extends State<StatusListScreen> {
  late StatusProvider statusProvider;
  SearchResult<Status>? statusResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Status? status;

  @override
  void initState() {
    statusProvider = context.read<StatusProvider>();
    super.initState();
    initForm();
  }

  Future initForm() async {
    statusResult = await statusProvider.get();
  }

  Future refreshTable() async {
    setState(() {
      isLoading = true;
    });
    try {
      var request = Map.from(_formKey.currentState?.value ?? {});
      statusResult = await statusProvider.get(filter: request);
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
      "Statusi",
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

  final TextEditingController _ftsStatusNameController =
      TextEditingController();

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
          "Naziv statusa:",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        ),
        const SizedBox(
          width: 15,
        ),
        Expanded(
          child: TextFormField(
            controller: _ftsStatusNameController,
            cursorColor: Colors.green.shade800,
            decoration: InputDecoration(
              suffixText: 'Pretraga po nazivu statusa.',
              suffixStyle: TextStyle(color: Colors.green.shade800),
              enabledBorder: const OutlineInputBorder(
                borderSide: BorderSide(color: Colors.black),
                borderRadius: BorderRadius.only(
                  topLeft: Radius.circular(10),
                  topRight: Radius.circular(10),
                  bottomLeft: Radius.circular(10),
                  bottomRight: Radius.circular(10),
                ),
              ),
            ),
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
                'NameGTE': _ftsStatusNameController.text,
              };
              statusResult = await statusProvider.get(filter: filter);
            } catch (e) {
              debugPrint('Error: $e');
            } finally {
              setState(() {
                isLoading = false;
              });
            }
            _ftsStatusNameController.clear();
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
                              'Naziv',
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
                              'Povlastica',
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
                      rows: statusResult?.result
                              .map(
                                (e) => DataRow(
                                  cells: [
                                    DataCell(Text(
                                      '${e.name}',
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),
                                    DataCell(Text(
                                      '${e.discount?.toStringAsFixed(2)}',
                                      style: const TextStyle(
                                          color: Colors.white, fontSize: 17),
                                    )),

                                    // update
                                    DataCell(IconButton(
                                      onPressed: () {
                                        showDialog(
                                            context: context,
                                            builder: (BuildContext context) =>
                                                StatusUpdateDialog(
                                                  status: e,
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
                                                        await statusProvider
                                                            .delete(
                                                                e.statusId!);
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
                            builder: (BuildContext context) => StatusAddDialog(
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
