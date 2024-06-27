import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

class VehicleListScreen extends StatefulWidget {
  VehicleListScreen({super.key});

  @override
  State<VehicleListScreen> createState() => _VehicleListScreenState();
}

class _VehicleListScreenState extends State<VehicleListScreen> {
  VehicleProvider provider =
      VehicleProvider(); //ovako se instancira samo jednom, umjesto svaki put kada je unutar dijela : ElevatedButton(onPressed: () async {

  //dynamic result; //omogućava da rez sa API snimimo unutar varijable, te da bi se forma mogla re-reandering
  List<Vehicle> result =
      []; //tokom seriazable više ne vraćamo dynamic nego listu proizvoda

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

  TextEditingController inputController = TextEditingController();

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
            //TODO: add call to API

            result = await provider.get();
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
    return Column(
      children: [
        const SizedBox(
          height: 40,
        ),
        SingleChildScrollView(
          child: Container(
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
                  result
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
            ))
      ],
    );
  }
}
