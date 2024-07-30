import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class VehicleAddDialog extends StatefulWidget {
  Vehicle? vehicle;
  VehicleAddDialog({super.key, this.vehicle});

  @override
  State<VehicleAddDialog> createState() => _VehicleAddDialogState();
}

class _VehicleAddDialogState extends State<VehicleAddDialog> {
  //Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  SearchResult<Vehicle>? vehicleResult;
  late VehicleProvider vehicleProvider;
  SearchResult<Manufacturer>? manufacturerResult;
  late ManufacturerProvider manufacturerProvider;
  SearchResult<Type>? typeResult;
  late TypeProvider typeProvider;

  @override
  void initState() {
    super.initState();
    vehicleProvider = context.read<VehicleProvider>();
    manufacturerProvider = context.read<ManufacturerProvider>();
    typeProvider = context.read<TypeProvider>();

    initForm();

    /*  _initialValue = {
      'number': widget?.vehicle?.number,
      'registrationNumber': widget?.vehicle?.registrationNumber,
      'buildYear': widget?.vehicle?.buildYear,
      //'manufacturerId': widget?.vehicle?.manufacturerId,
       'manufacturerId':_selectedManufacturerId,
      'typeId': widget?.vehicle?.typeId
    };*/
  }

  /* Future initForm() async {
    //vehicleResult = await vehicleProvider.get();
    manufacturerResult = await manufacturerProvider.get();
    typeResult = await typeProvider.get();

    setState(() {
      // _selectedStartStationId = widget?.user?.userStatusId ?? 0;
    });
  }*/

  Future initForm() async {
    manufacturerResult = await manufacturerProvider.get();
    typeResult = await typeProvider.get();

    setState(() {
      _selectedManufacturerId = widget?.vehicle?.manufacturerId ??
          (manufacturerResult?.result.isNotEmpty ?? false
              ? manufacturerResult!.result.first.manufacturerId
              : null);
      _selectedTypeId = widget?.vehicle?.typeId ??
          (typeResult?.result.isNotEmpty ?? false
              ? typeResult!.result.first.typeId
              : null);

      // Update _initialValue to reflect the fetched data
      _initialValue = {
        'number': widget?.vehicle?.number,
        'registrationNumber': widget?.vehicle?.registrationNumber,
        'buildYear': widget?.vehicle?.buildYear,
        'manufacturerId': _selectedManufacturerId,
        'typeId': _selectedTypeId
      };
    });
  }

  TextEditingController _ftsNumberController = TextEditingController();
  TextEditingController _ftsRegistrationNumberController =
      TextEditingController();
  TextEditingController _ftsBuildYearController = TextEditingController();
  int? _selectedManufacturerId;
  int? _selectedTypeId;

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Novo vozilo"),
      content: Container(
        width: 500,
        height: 450,
        child: FormBuilder(
          key: _formKey,
          initialValue: _initialValue,
          child: Column(
            children: [
              SizedBox(
                height: 15,
              ),
              Row(
                children: [
                  Text(
                    "Broj vozila:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 130,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsNumberController,
                      decoration: InputDecoration(
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
                ],
              ),
              SizedBox(
                height: 15,
              ),
              Row(
                children: [
                  Text(
                    "Registracijska oznaka:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 50,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsRegistrationNumberController,
                      decoration: InputDecoration(
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
                ],
              ),
              SizedBox(
                height: 15,
              ),
              Row(
                children: [
                  Text(
                    "Godina proizvodnje:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  SizedBox(
                    width: 63,
                  ),
                  Expanded(
                    child: TextFormField(
                      controller: _ftsBuildYearController,
                      decoration: InputDecoration(
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
                ],
              ),
              SizedBox(
                height: 15,
              ),
              Row(
                children: [
                  const Text(
                    "Proizvođač:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  const SizedBox(
                    width: 125,
                  ),
                  Expanded(
                    child: FormBuilderDropdown(
                      name: "manufacturerId",
                      items: getManufacturer(),
                      //initialValue: 1,
                      initialValue: _selectedManufacturerId?.toString(),
                      onChanged: (value) {
                        setState(() {
                          _selectedManufacturerId = int.parse(value as String);
                        });
                      },
                    ),
                  ),
                ],
              ),
              SizedBox(
                height: 15,
              ),
              Row(
                children: [
                  const Text(
                    "Tip vozila:",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 15),
                  ),
                  const SizedBox(
                    width: 135,
                  ),
                  Expanded(
                    child: FormBuilderDropdown(
                      name: "typeId",
                      items: getType(),
                      initialValue: _selectedTypeId?.toString(),
                      onChanged: (value) {
                        setState(() {
                          _selectedTypeId = int.parse(value as String);
                        });
                      },
                    ),
                  ),
                ],
              ),
              //
              SizedBox(
                height: 25,
              ),
              Row(
                children: [
                  Expanded(
                      child: ElevatedButton(
                    onPressed: () async {
                      _formKey.currentState?.saveAndValidate();
                      var request = Map.from(_formKey.currentState!.value);

                      showDialog(
                          context: context,
                          builder: (context) => AlertDialog(
                                title: Text("Novo vozilo"),
                                content: Text("Vozilo je dodano!"),
                                actions: [
                                  TextButton(
                                    child: Text(
                                      "OK",
                                      style: TextStyle(color: Colors.green),
                                    ),
                                    onPressed: () {
                                      Navigator.pop(context);
                                    },
                                  )
                                ],
                              ));
                    },
                    style: ElevatedButton.styleFrom(
                      backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(2.0),
                      ),
                      minimumSize: const Size(100, 65),
                    ),
                    child: const Text("Dodaj", style: TextStyle(fontSize: 18)),
                  )),
                ],
              ),
            ],
          ),
        ),
      ),
      //
      actions: [
        TextButton(
            onPressed: () => Navigator.pop(context),
            child: Text(
              "Cancel",
              style: TextStyle(color: Colors.red, fontSize: 18),
            )),
      ],
    );
  }

  List<DropdownMenuItem<String>> getManufacturer() {
    var list = manufacturerResult?.result
            .map((item) => DropdownMenuItem(
                value: item.manufacturerId.toString(),
                child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  List<DropdownMenuItem<String>> getType() {
    var list = typeResult?.result
            .map((item) => DropdownMenuItem(
                value: item.typeId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }
}
