import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UserListScreen extends StatefulWidget {
  User? user;
  UserListScreen({super.key, this.user});

  @override
  State<UserListScreen> createState() => _UserListScreenState();
}

class _UserListScreenState extends State<UserListScreen> {
//late
  late UserProvider userProvider;
//SearchResult
  SearchResult<User>? userResult;
//Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  @override
  void initState() {
    userProvider = context.read<UserProvider>();

    super.initState();

    _initialValue = {
      'firstName': widget?.user?.firstName,
      'lastName': widget?.user?.lastName,
      'userName': widget?.user?.userId,
      'dateOfBirth': widget?.user?.dateOfBirth?.toString(),
    };

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Korisnici",
      Column(
        children: [_buildSearch(), _buildResultView()],
      ),
    );
  }

  TextEditingController _ftsFirstLastNameController = TextEditingController();
  Widget _buildSearch() {
    return Container(
      //color: Colors.red,
      child: Row(
        children: [
          const Text(
            "Ime prezime:",
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
          ),
          const SizedBox(
            width: 15,
          ),
          Expanded(
            child: TextFormField(
              controller: _ftsFirstLastNameController,
              cursorColor: Colors.green.shade800,
              decoration: InputDecoration(
                suffixText: 'Pretraga po imenu ili prezimenu.',
                suffixStyle: TextStyle(color: Colors.green.shade800),
                enabledBorder: OutlineInputBorder(
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
          const SizedBox(
            width: 15,
          ),
          ElevatedButton(
            onPressed: () async {
              //Search:
              var filter = {
                'FirstNameGTE': _ftsFirstLastNameController.text,
                'LastNameGTE': _ftsFirstLastNameController.text,
              };
              userResult = await userProvider.get(filter: filter);
              setState(() {});

              _ftsFirstLastNameController.clear();
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
      ),
    );
  }

  Widget _buildResultView() {
    return Expanded(
      child: SingleChildScrollView(
        child: FormBuilder(
            key: _formKey,
            initialValue: _initialValue,
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
                        columns: const <DataColumn>[
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
                                'Korisničko ime',
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
                                'Datum rođenja',
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
                        rows: userResult?.result
                                .map(
                                  (e) => DataRow(
                                    cells: [
                                      DataCell(Text(
                                        '${e.firstName} ${e.lastName}' ?? "",
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        e.userName.toString() ?? "",
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        formatDate(e.dateOfBirth) ?? "",
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(IconButton(
                                        onPressed: () {
                                          //code
                                        },
                                        icon: const Icon(
                                          Icons.tips_and_updates_rounded,
                                          color: Colors.white,
                                        ),
                                      )),
                                      DataCell(IconButton(
                                        onPressed: () {
                                          //code
                                        },
                                        icon: const Icon(
                                          Icons.delete_forever_rounded,
                                          color: Colors.white,
                                        ),
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
                    ElevatedButton(
                        onPressed: () {},
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
                  //),
                ),
                //),
              ],
            )),
      ),
    );
  }
}
