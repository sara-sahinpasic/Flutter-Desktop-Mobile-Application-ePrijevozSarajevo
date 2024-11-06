import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/request.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/status.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/request_provider.dart';
import 'package:eprijevoz_desktop/providers/status_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/screens/request_approve_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class RequestListScreen extends StatefulWidget {
  Status? status;
  Request? request;
  RequestListScreen({super.key, this.request, this.status});

  @override
  State<RequestListScreen> createState() => _RequestListScreenState();
}

class _RequestListScreenState extends State<RequestListScreen> {
  //Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  //late
  late RequestProvider requestProvider;
  late StatusProvider statusProvider;
  late UserProvider userProvider;
  //SearchResult
  SearchResult<Request>? requestResult;
  SearchResult<Status>? statusResult;
  SearchResult<Request>? routeResultForStatus;
  SearchResult<User>? userResult;

  int _selectedStatusId = 0;
  bool isLoading = true;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  @override
  void initState() {
    statusProvider = context.read<StatusProvider>();
    requestProvider = context.read<RequestProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();

    _initialValue = {
      'userStatusId': widget?.request?.userStatusId?.toString(),
      'statusId': widget?.status?.statusId?.toString(),
    };

    initForm();
  }

  Future initForm() async {
    statusResult = await statusProvider.get();
    requestResult = await requestProvider.get();
    userResult = await userProvider.get();

    if (requestResult?.result != null) {
      requestResult!.result = filterDuplicates(requestResult!.result);
    }

    print("statuskoo: ${statusResult?.result.length}");
    print("statuskoo1: ${statusResult?.result.map((e) => e.name)}");

    print("zahtjev: ${requestResult?.result.length}");
    print("zahtjev1: ${requestResult?.result.map((e) => e.userStatusId)}");

    setState(() {
      isLoading = false;
    });
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
            isLoading ? Container() : _buildSearch(),
            Expanded(child: _buildResultView())
          ],
        ));
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
              _selectedStatusId = status?.statusId ?? 0;
            },
          ),
        ),
        const SizedBox(
          width: 15,
        ),
        ElevatedButton(
          onPressed: () async {
            print("UserStatusIdGTE: ${_selectedStatusId}");

            //Search:
            var filter = {
              'UserStatusIdGTE': _selectedStatusId,
            };
            routeResultForStatus = await requestProvider.get(filter: filter);
            print(
                "tetsni routeResultForStatus : ${routeResultForStatus?.result.map((e) => e.userStatusId)}");

            setState(() {});
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
      ]),
    );
  }

  Widget _buildResultView() {
    return
        //Placeholder();
        Expanded(
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
                        .map(
                          (e) => DataRow(
                            cells: [
                              DataCell(Text(
                                '${userResult?.result.firstWhere((element) => element.userId == e.userId).userId.toString() ?? ""}',
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
                                      try {
                                        final result = await showDialog<bool>(
                                          context: context,
                                          builder: (successDialogContext) =>
                                              RequestApproveDialog(
                                            request: e,
                                          ),
                                        );

                                        if (result == true) {
                                          // refresh???
                                        }
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
                                      onPressed: () {},
                                      style: ElevatedButton.styleFrom(
                                        backgroundColor: Colors.black,
                                      ),
                                      child: const Text(
                                        "Odbaci",
                                        style: TextStyle(
                                            color: Colors.red,
                                            fontWeight: FontWeight.bold),
                                      )),
                                ],
                              )),
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
