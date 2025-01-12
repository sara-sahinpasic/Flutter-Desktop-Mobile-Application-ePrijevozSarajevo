import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/request.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/status.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/request_provider.dart';
import 'package:eprijevoz_desktop/providers/status_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/screens/request/request_approve_screen.dart';
import 'package:eprijevoz_desktop/screens/request/request_reject_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class RequestListScreen extends StatefulWidget {
  const RequestListScreen({super.key});

  @override
  State<RequestListScreen> createState() => _RequestListScreenState();
}

class _RequestListScreenState extends State<RequestListScreen> {
  final _formKey = GlobalKey<FormBuilderState>();
  final Map<String, dynamic> _initialValue = {};
  late RequestProvider requestProvider;
  late StatusProvider statusProvider;
  late UserProvider userProvider;
  SearchResult<Request>? requestResult;
  SearchResult<Status>? statusResult;
  SearchResult<Request>? routeResultForStatus;
  SearchResult<User>? userResult;
  int selectedStatusId = 0;
  bool isLoading = false;

  @override
  void initState() {
    statusProvider = context.read<StatusProvider>();
    requestProvider = context.read<RequestProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    setState(() {
      isLoading = true;
    });

    try {
      statusResult = await statusProvider.get();
      requestResult = await requestProvider.get();
      userResult = await userProvider.get();
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false;
      });
    }

    if (requestResult?.result != null) {
      requestResult!.result = filterDuplicates(requestResult!.result);
    }
  }

  List<Request> filterDuplicates(List<Request> data) {
    final seen = <int>{};
    return data
        .where((dataModel) => seen.add(dataModel.userStatusId!))
        .toList();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
        "Zahtjevi",
        Column(
          children: [
            const SizedBox(
              height: 5,
            ),
            const Align(
              alignment: Alignment.centerLeft,
              child: Text(
                "Za prikaz svih rezultata, neophodno je odbrati traženi status, te pritisnuti dugme "
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
        ));
  }

  void _refreshData({bool byUser = false}) async {
    setState(() {
      isLoading = false;
    });
    try {
      // search:
      var filter = {
        'UserStatusIdGTE': selectedStatusId,
      };
      routeResultForStatus = await requestProvider.get(filter: filter);
      requestResult = await requestProvider.get();
      if (requestResult != null) {
        requestResult!.result = filterDuplicates(requestResult!.result);
      }
      if (routeResultForStatus?.count == 0 && byUser) {
        await showDialog(
          context: context,
          builder: (context) => AlertDialog(
            title: const Text(
              "Warning",
              style:
                  TextStyle(color: Colors.orange, fontWeight: FontWeight.bold),
            ),
            content: const Text(
              "Nema pronađenih zahtjeva za odabranu kategoriju.",
            ),
            actions: [
              TextButton(
                child: const Text("OK", style: TextStyle(color: Colors.black)),
                onPressed: () {
                  Navigator.pop(context);
                },
              ),
            ],
          ),
        );
      }
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  Widget _buildSearch() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Row(children: [
        const Text(
          "Status: ",
          style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
        ),
        const SizedBox(
          width: 15,
        ),
        Expanded(
          child: FormBuilderDropdown(
            name: "userStatusId",
            items: requestResult?.result
                    .map((e) => DropdownMenuItem<String>(
                        value: e.userStatusId.toString(),
                        child: Text(
                          statusResult?.result
                                  .firstWhere((element) =>
                                      element.statusId == e.userStatusId)
                                  .name ??
                              "",
                        )))
                    .toList() ??
                [],
            onChanged: (value) {
              var status = statusResult?.result.firstWhere(((statusElement) =>
                  statusElement.statusId.toString() == value));
              selectedStatusId = status?.statusId ?? 0;
            },
          ),
        ),
        const SizedBox(
          width: 15,
        ),
        ElevatedButton(
          onPressed: () => _refreshData(byUser: true),
          style: ElevatedButton.styleFrom(
            backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(2.0),
            ),
            minimumSize: const Size(100, 65),
          ),
          child: const Text("Pretraga", style: TextStyle(fontSize: 18)),
        ),
      ]),
    );
  }

  Widget _buildResultView() {
    return Expanded(
      child: SingleChildScrollView(
        child: FormBuilder(
            child: Column(
          children: [
            const SizedBox(
              height: 40,
            ),
            Container(
              color: Colors.black,
              width: double.infinity,
              child: DataTable(
                headingRowColor: MaterialStateColor.resolveWith(
                    (states) => const Color.fromRGBO(72, 156, 118, 100)),
                columns: const <DataColumn>[
                  DataColumn(
                    label: Expanded(
                      child: Text(
                        'Id',
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
                        'Ime prezime',
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
                        'Kategorija',
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
                ],
                rows: routeResultForStatus?.result
                        .where((element) => element.active == true)
                        .map(
                          (e) => DataRow(
                            cells: [
                              DataCell(Text(
                                userResult?.result
                                        .firstWhere((element) =>
                                            element.userId == e.userId)
                                        .userId
                                        .toString() ??
                                    "",
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(Text(
                                '${userResult?.result.firstWhere((element) => element.userId == e.userId).firstName ?? ""}'
                                " "
                                '${userResult?.result.firstWhere((element) => element.userId == e.userId).lastName ?? ""}',
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(Text(
                                "Mjesečna karta - "
                                '${statusResult?.result.firstWhere((element) => element.statusId == e.userStatusId).name ?? ""}',
                                style: const TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(Row(
                                children: [
                                  ElevatedButton(
                                    onPressed: () async {
                                      //accept
                                      try {
                                        showDialog(
                                          context: context,
                                          builder: (successDialogContext) =>
                                              RequestApproveDialog(
                                            request: e,
                                            onDone: () => _refreshData(),
                                          ),
                                        );
                                      } catch (error) {
                                        String errorMessage =
                                            "Greška prilikom odobrenja zahtjeva.";
                                        await showDialog(
                                          context: context,
                                          builder: (errorDialogContext) =>
                                              AlertDialog(
                                            title: const Text(
                                              "Error",
                                              style: TextStyle(
                                                  color: Colors.red,
                                                  fontWeight: FontWeight.bold),
                                            ),
                                            content: Text(errorMessage),
                                            actions: [
                                              TextButton(
                                                onPressed: () => Navigator.pop(
                                                    errorDialogContext),
                                                child: const Text(
                                                  "OK",
                                                  style: TextStyle(
                                                      color: Colors.black),
                                                ),
                                              ),
                                            ],
                                          ),
                                        );
                                      }
                                    },
                                    style: ElevatedButton.styleFrom(
                                      backgroundColor: Colors.black,
                                    ),
                                    child: const Text(
                                      "Prihvati",
                                      style: TextStyle(
                                          color: Colors.green,
                                          fontWeight: FontWeight.bold),
                                    ),
                                  ),
                                  const Text(
                                    "|",
                                    style: TextStyle(
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  ElevatedButton(
                                      onPressed: () async {
                                        //reject
                                        try {
                                          showDialog(
                                            context: context,
                                            builder: (successDialogContext) =>
                                                RequestRejectDialog(
                                              request: e,
                                              onDone: () => _refreshData(),
                                            ),
                                          );
                                        } catch (error) {
                                          String errorMessage =
                                              "Greška prilikom odobrenja zahtjeva.";
                                          showDialog(
                                            context: context,
                                            builder: (errorDialogContext) =>
                                                AlertDialog(
                                              title: const Text(
                                                "Error",
                                                style: TextStyle(
                                                    color: Colors.red,
                                                    fontWeight:
                                                        FontWeight.bold),
                                              ),
                                              content: Text(errorMessage),
                                              actions: [
                                                TextButton(
                                                  onPressed: () =>
                                                      Navigator.pop(
                                                          errorDialogContext),
                                                  child: const Text(
                                                    "OK",
                                                    style: TextStyle(
                                                        color: Colors.black),
                                                  ),
                                                ),
                                              ],
                                            ),
                                          );
                                        }
                                      },
                                      style: ElevatedButton.styleFrom(
                                        backgroundColor: Colors.black,
                                      ),
                                      child: const Text(
                                        "Odbaci",
                                        style: TextStyle(
                                            color: Colors.red,
                                            fontWeight: FontWeight.bold),
                                      )),
                                  const Text(
                                    "|",
                                    style: TextStyle(
                                        color: Colors.white,
                                        fontWeight: FontWeight.bold),
                                  ),
                                  // delete
                                  const SizedBox(
                                    width: 15,
                                  ),
                                  IconButton(
                                    onPressed: () async {
                                      await showDialog(
                                        context: context,
                                        builder: (dialogContext) {
                                          return AlertDialog(
                                            title: const Text(
                                              "Delete",
                                              style: TextStyle(
                                                  fontWeight: FontWeight.bold),
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
                                                  Navigator.pop(dialogContext);
                                                  try {
                                                    await requestProvider
                                                        .delete(e.requestId!);
                                                    setState(() {});
                                                    await showDialog(
                                                      context: context,
                                                      builder:
                                                          (successDialogContext) =>
                                                              AlertDialog(
                                                        title: const Text(
                                                          "Success",
                                                          style: TextStyle(
                                                              color:
                                                                  Colors.green,
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
                                                            child: const Text(
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
                                                              color: Colors.red,
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
                                                            child: const Text(
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
                                                  _refreshData();
                                                },
                                              ),
                                              TextButton(
                                                child: const Text("Cancel",
                                                    style: TextStyle(
                                                        color: Colors.red)),
                                                onPressed: () => Navigator.pop(
                                                    dialogContext, false),
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
                                ],
                              )),
                              //--------------------
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
          ],
        )),
      ),
    );
  }
}
