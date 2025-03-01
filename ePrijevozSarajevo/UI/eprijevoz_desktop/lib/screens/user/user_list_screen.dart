import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/utils.dart';
import 'package:eprijevoz_desktop/screens/country/country_list_screen.dart';
import 'package:eprijevoz_desktop/screens/status/status_list_screen.dart';
import 'package:eprijevoz_desktop/screens/user/user_add_screen.dart';
import 'package:eprijevoz_desktop/screens/user/user_update_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

class UserListScreen extends StatefulWidget {
  const UserListScreen({
    super.key,
  });
  @override
  State<UserListScreen> createState() => _UserListScreenState();
}

class _UserListScreenState extends State<UserListScreen> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  User? user;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    super.initState();
    _initialValue = {
      'firstName': user?.firstName,
      'lastName': user?.lastName,
      'userName': user?.userId,
      'dateOfBirth': user?.dateOfBirth?.toString(),
    };
  }

  Future refreshTable() async {
    setState(() {
      isLoading = true;
    });
    try {
      var request = Map.from(_formKey.currentState?.value ?? {});
      userResult = await userProvider.get(filter: request);
    } catch (e) {
      debugPrint('Error: $e');
    } finally {
      setState(() {
        isLoading = false; // hide the loading indicator after completion
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Korisnici",
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
              ? const Center(child: CircularProgressIndicator()) // show loader
              : _buildResultView(), // show results when not loading
        ],
      ),
    );
  }

  final TextEditingController _ftsFirstLastNameController =
      TextEditingController();

  Widget _buildSearch() {
    return Row(
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
            // search:
            try {
              var filter = {
                'FirstNameGTE': _ftsFirstLastNameController.text,
                'LastNameGTE': _ftsFirstLastNameController.text,
              };
              userResult = await userProvider.get(filter: filter);
            } catch (e) {
              debugPrint('Error: $e');
            } finally {
              setState(() {
                isLoading = false;
              });
            }
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
                  height: 20,
                ),
                Row(
                  children: [
                    // country
                    TextButton(
                      onPressed: () async {
                        await Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => const CountryListScreen(),
                          ),
                        );
                        refreshTable();
                      },
                      child: Row(
                        children: [
                          Icon(
                            Icons.arrow_forward,
                            color: Colors.green.shade800,
                          ),
                          const SizedBox(width: 5),
                          Text(
                            "Sekcija države",
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
                    // status
                    TextButton(
                      onPressed: () async {
                        await Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => const StatusListScreen(),
                          ),
                        );
                        refreshTable();
                      },
                      child: Row(
                        children: [
                          Icon(
                            Icons.arrow_forward,
                            color: Colors.green.shade800,
                          ),
                          const SizedBox(width: 5),
                          Text(
                            "Sekcija statusi",
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
                Column(
                  children: [
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
                                'Ime prezime',
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
                                'Korisničko ime',
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
                                'Datum rođenja',
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
                        rows: userResult?.result
                                .map(
                                  (e) => DataRow(
                                    cells: [
                                      DataCell(Text(
                                        '${e.firstName} ${e.lastName}',
                                        style: const TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        e.userName.toString(),
                                        style: const TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        formatDate(e.dateOfBirth),
                                        style: const TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),

                                      // update
                                      DataCell(IconButton(
                                        onPressed: () {
                                          showDialog(
                                              context: context,
                                              builder: (BuildContext context) =>
                                                  UpdateUserDialog(
                                                    user: e,
                                                    onUserUpdated:
                                                        refreshTable, //refresh table with new data
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
                                                            color:
                                                                Colors.black),
                                                      ),
                                                      onPressed: () async {
                                                        Navigator.pop(
                                                            dialogContext);
                                                        try {
                                                          await userProvider
                                                              .delete(
                                                                  e.userId!);
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
                                const UserAddDialog(),
                          );
                          if (result == true) {
                            await refreshTable(); // refresh table after a new user is added
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
                        )),
                  ],
                ),
              ],
            )),
      ),
    );
  }
}
