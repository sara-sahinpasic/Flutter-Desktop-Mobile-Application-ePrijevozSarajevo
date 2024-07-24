import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/screens/update_user_screen.dart';
import 'package:eprijevoz_desktop/screens/user_add_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UserListScreen extends StatefulWidget {
  User? user;
  UserListScreen({
    super.key,
    this.user,
  });

  @override
  State<UserListScreen> createState() => _UserListScreenState();
}

class _UserListScreenState extends State<UserListScreen> {
//late
  late UserProvider userProvider;
//SearchResult
  SearchResult<User>? userResult;

  bool isLoading = true;

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

    _initialValue = {
      'firstName': widget?.user?.firstName,
      'lastName': widget?.user?.lastName,
      'userName': widget?.user?.userId,
      'dateOfBirth': widget?.user?.dateOfBirth?.toString(),
    };
  }

  Future refreshTable() async {
    var request = Map.from(_formKey.currentState?.value ?? {});
    userResult = await userProvider.get(filter: request);
    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Korisnici",
      Column(
        children: [
          SizedBox(
            height: 5,
          ),
          Align(
            alignment: Alignment.centerLeft,
            child: Text(
              "Za prikaz svih rezultata, neophodno je pritisnuti dugme "
              '"Pretraga"'
              ".",
              style: TextStyle(fontWeight: FontWeight.w400),
            ),
          ),
          SizedBox(
            height: 20,
          ),
          _buildSearch(),
          _buildResultView()
        ],
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
                        headingRowColor: MaterialStateColor.resolveWith(
                            (states) => Color.fromRGBO(72, 156, 118, 100)),
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
                                      //update
                                      DataCell(IconButton(
                                        onPressed: () {
                                          final result = showDialog(
                                              context: context,
                                              builder: (BuildContext context) =>
                                                  UpdateUserDialog(
                                                    user: e,
                                                    onUserUpdated:
                                                        refreshTable, //refresh table with new data
                                                  ));

                                          if (result == true)
                                            refreshTable(); //refresh table with new data
                                        },
                                        icon: const Icon(
                                          Icons.tips_and_updates_rounded,
                                          color: Colors.white,
                                        ),
                                      )),
                                      //delete:
                                      DataCell(IconButton(
                                        onPressed: () {
                                          showDialog(
                                              context: context,
                                              builder: (context) => AlertDialog(
                                                    title: Text("Delete"),
                                                    content: Text(
                                                        "Da li želite obrisati korisnika ${e.firstName} ${e.lastName}?"),
                                                    actions: [
                                                      TextButton(
                                                          child: Text(
                                                            "OK",
                                                            style: TextStyle(
                                                                color: Colors
                                                                    .green),
                                                          ),
                                                          onPressed: () async {
                                                            Navigator.pop(
                                                                context);
                                                            bool success =
                                                                await userProvider
                                                                    .delete(e
                                                                        .userId!);
                                                            showDialog(
                                                                context:
                                                                    context,
                                                                builder:
                                                                    (dialogDeleteContext) =>
                                                                        AlertDialog(
                                                                          title: Text(success
                                                                              ? "Success"
                                                                              : "Error"),
                                                                          content: Text(success
                                                                              ? "Korisnik: ${e.firstName} ${e.lastName}, uspješno obrisan."
                                                                              : "Korisnik: ${e.firstName} ${e.lastName}, nije obrisan."),
                                                                          actions: [
                                                                            TextButton(
                                                                              child: Text(
                                                                                "OK",
                                                                                style: TextStyle(color: Colors.green),
                                                                              ),
                                                                              onPressed: () {
                                                                                refreshTable(); //refresh table with new data
                                                                                Navigator.pop(dialogDeleteContext);
                                                                              },
                                                                            )
                                                                          ],
                                                                        ));
                                                          }),
                                                      TextButton(
                                                          child: Text(
                                                            "Cancel",
                                                            style: TextStyle(
                                                                color:
                                                                    Colors.red),
                                                          ),
                                                          onPressed: () =>
                                                              Navigator.pop(
                                                                  context))
                                                    ],
                                                  ));
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
                        onPressed: () {
                          showDialog(
                            context: context,
                            builder: (dialogAddContext) => UserAddDialog(),

                            /*
                            
                             final result = showDialog(
                                              context: context,
                                              builder: (BuildContext context) =>
                                                  UpdateUserDialog(
                                                    user: e,
                                                    onUserUpdated:
                                                        refreshTable, //refresh table with new data
                                                  ));

                                          if (result == true)
                                            refreshTable(); //refresh table with new data
                            
                            */
                          );
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
