import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
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
  //Provider:
  late VehicleProvider vehicleProvider;
  //
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};
  late ManufacturerProvider manufacturerProvider;
  SearchResult<Manufacturer>? manufacturerResult;

  late TypeProvider typeProvider;
  SearchResult<Type>? typeResult;

  @override
  void didChangeDependencies() {
    super.didChangeDependencies();

/*
    vehicleProvider = context.read<
        VehicleProvider>(); //iz DI providera da dobijem klasu koja me interesuje (vehicle provider)
        */
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

  //dynamic result; //omogućava da rez sa API snimimo unutar varijable, te da bi se forma mogla re-reandering
  //List<Vehicle> result = []; //tokom seriazable više ne vraćamo dynamic nego listu proizvoda
  SearchResult<Vehicle>? result;
  //= null; // pošto nemamo rezultata inicijalno stavljamo null

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
        Container(
          child: Column(
            children: [_buildSearch(), _buildResultView()],
          ),
        ));
  }

//Search
  TextEditingController _ftsEditingController = TextEditingController();

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
          //Search
          controller: _ftsEditingController,
          decoration: InputDecoration(
            suffixText: "Unos registracijske oznake",
            suffixStyle: TextStyle(color: Colors.green.shade800),
            labelStyle: TextStyle(
              color: Colors.green.shade800,
            ),
            enabledBorder: const OutlineInputBorder(
              borderSide: BorderSide(
                color: Colors.black,
              ),
            ),
          ),
          inputFormatters: [
            LengthLimitingTextInputFormatter(9),
            //FilteringTextInputFormatter.allow(
            // RegExp('[A-Za-z]\d\d-[A-Za-z]-\d\d\d'))
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
              'RegistrationNumberGTE': _ftsEditingController.text,
            };
            //result = await provider.get();
            result = await vehicleProvider.get(filter: filter);

            //print(result[0].registrationNumber); //ovo smo dobili serijalizacijom i mijenjenjem dynamic tipa u List<Vehicle> u get() metodi
            setState(() {}); //omogućava dohvatanje podataka bez hot relading

            /*
            Prijašnje print varijacije prije urađenog JonSeriazable:
            print(result);
            Ispis:
             {count: 1, resultList: 
            
            print(result["resultList"]);
             Ispis:
             [{vehicleId: 1, number: 10, registrationNumber: 123, buildYear: 2000, vehicleType: null, manufacturer: null}]
             [{vehicleId: 1, number: 10, registrationNumber: 123, buildYear: 2000, vehicleType: null, manufacturer: null}]}
            
            print(result["resultList"]);
            Ispis:
            [{vehicleId: 1, number: 10, registrationNumber: 123, buildYear: 2000, vehicleType: null, manufacturer: null}]
            
            print(result["resultList"][0]["registrationNumber"]);
            print(result["resultList"][0]);

            if (result != null) {
              var first = result["resultList"][0];
              print("First element is: $first");
            } else {
              print("List is null");
            }
            */
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
    /* return SingleChildScrollView(
      child: Column(
        children: [
          const SizedBox(
            height: 40,
          ),
          Container(
            color: Colors.black,
            width: double.infinity,
            child: SingleChildScrollView(
              scrollDirection: Axis.horizontal,
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
                      child: Text(''),
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
                                'ToDo :: vehicleType',
                                style: TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(Text(
                                'ToDo :: manufacturer',
                                style: TextStyle(
                                    color: Colors.white, fontSize: 17),
                              )),
                              DataCell(IconButton(
                                onPressed: () {
                                  // code
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
          ),
          const SizedBox(
            height: 15,
          ),
          ElevatedButton(
            onPressed: () {},
            style: ElevatedButton.styleFrom(
              backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(2.0),
              ),
              minimumSize: const Size(double.infinity, 65),
            ),
            child: const Text(
              "Dodaj",
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
          ),
        ],
      ),
    );
*/

    return FormBuilder(
        key: _formKey,
        initialValue: _initialValue,
        child: Column(
          children: [
            const SizedBox(
              height: 40,
            ),
            SingleChildScrollView(
                //bez ovoga ako nemamo dovoljno prostora za prikaz podataka, ne bi imali scroll
                child: Column(
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
                    rows:
                        //[]
                        //result["resultList"]
                        //result.map(
                        //ako je ovaj dio code-a null, ce se preskociti i necemo dobiti nista iscrtano:
                        result?.result
                                .map(
                                  (e) => DataRow(
                                    cells: [
                                      DataCell(Text(
                                        e.registrationNumber ?? "",
                                        //e['registrationNumber'],
                                        style: TextStyle(
                                            color: Colors.white, fontSize: 17),
                                      )),
                                      DataCell(Text(
                                        e.buildYear.toString(),
                                        //e['buildYear'].toString(),
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
                                      //Jasko dodao
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
                      backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(2.0),
                      ),
                      minimumSize: const Size(double.infinity, 65),
                    ),
                    child: const Text(
                      "Dodaj",
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                    ))
              ],
            )),
          ],
        ));
  }
}
