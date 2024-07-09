import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class VehicleListScreen extends StatefulWidget {
  Vehicle? vehicle;
  VehicleListScreen({super.key, this.vehicle});

  @override
  State<VehicleListScreen> createState() => _VehicleListScreenState();
}

class _VehicleListScreenState extends State<VehicleListScreen> {
  //VehicleProvider provider =  VehicleProvider(); //ovako se instancira samo jednom, umjesto svaki put kada je unutar dijela : ElevatedButton(onPressed: () async {
//late Provider:
  late VehicleProvider vehicleProvider;
  late ManufacturerProvider manufacturerProvider;
  late TypeProvider typeProvider;
//Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
//SearchResult
  SearchResult<Manufacturer>? manufacturerResult;
  SearchResult<Vehicle>? result;
  SearchResult<Type>? typeResult;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();
  }

  @override
  void initState() {
    vehicleProvider = context.read<VehicleProvider>();
    manufacturerProvider = context.read<ManufacturerProvider>();
    typeProvider = context.read<TypeProvider>();

    super.initState();

    _initialValue = {
      'number': widget?.vehicle?.number,
      'registrationNumber': widget?.vehicle?.registrationNumber,
      'buildYear': widget?.vehicle?.buildYear,
      'manufacturerId': widget?.vehicle?.manufacturerId?.toString(),
      'typeId': widget?.vehicle?.typeId?.toString()
    };

    initForm();
  }

  Future initForm() async {
    manufacturerResult = await manufacturerProvider.get();
    typeResult = await typeProvider.get();
    print("vr ${manufacturerResult?.result}");
    print("vrle ${manufacturerResult?.result.length}");
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Vozila",
      Column(
        children: [_buildSearch(), _buildResultView()],
      ),
    );
  }

//Search
  TextEditingController _ftsRegistrationMarkController =
      TextEditingController();

  Widget _buildSearch() {
    return Container(
      //color: Colors.blue,
      child: Row(
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
            //Search
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
              //Search:
              var filter = {
                //RegistrationNumberGTE -  naziv property-ja sa API
                'RegistrationNumberGTE': _ftsRegistrationMarkController.text,
              };
              //result = await provider.get();
              result = await vehicleProvider.get(filter: filter);

              setState(() {}); //omogućava dohvatanje podataka bez hot relading

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
      ),
    );
  }

  _buildResultView() {
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
                                'Registracijska oznaka',
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
                                'Godina proizvodnje',
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
                          DataColumn(
                            label: Expanded(
                              child: Text(
                                '',
                              ),
                            ),
                          ),
                        ],
                        rows: result?.result
                                .map(
                                  (e) => DataRow(
                                    cells: [
                                      DataCell(Text(
                                        e.registrationNumber ?? "",
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        e.buildYear.toString(),
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        typeResult?.result
                                                .firstWhere((element) =>
                                                    element.typeId == e.typeId)
                                                .name ??
                                            "",
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        manufacturerResult?.result
                                                .firstWhere((element) =>
                                                    element.manufacturerId ==
                                                    e.manufacturerId)
                                                .name ??
                                            "",
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
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
                ),
              ],
            )),
      ),
    );
  }
}
