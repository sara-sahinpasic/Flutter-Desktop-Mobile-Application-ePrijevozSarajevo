import 'package:eprijevoz_desktop/models/delay.dart';
import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/delay_provider.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class DelayAddScreen extends StatefulWidget {
  final Function onDone;
  const DelayAddScreen({required this.onDone, super.key});

  @override
  State<DelayAddScreen> createState() => _DelayAddScreenState();
}

class _DelayAddScreenState extends State<DelayAddScreen> {
  late DelayProvider delayProvider;
  SearchResult<Delay>? delayResult;
  bool isLoading = false;
  final _formKey = GlobalKey<FormBuilderState>();
  String? typeName;
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late TypeProvider typeProvider;
  SearchResult<Type>? typeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  int? currentUserId;
  late UserProvider userProvider;
  SearchResult<User>? userResult;

  @override
  void initState() {
    delayProvider = context.read<DelayProvider>();
    routeProvider = context.read<RouteProvider>();
    typeProvider = context.read<TypeProvider>();
    stationProvider = context.read<StationProvider>();
    userProvider = context.read<UserProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    delayResult = await delayProvider.get();
    routeResult = await routeProvider.get();
    typeResult = await typeProvider.get();
    stationResult = await stationProvider.get();
    userResult = await userProvider.get();

    currentUserId = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username)
        .userId;

    setState(() {
      isLoading = false;
    });
  }

  int? selectedRouteId;
  int? selectedVehicleTypeId;
  List<DropdownMenuItem<String>> getVehicleType() {
    var list = typeResult?.result
            .map((item) => DropdownMenuItem(
                value: item.typeId.toString(), child: Text(item.name ?? "")))
            .toList() ??
        [];
    return list;
  }

  List<Route> filterDuplicates(List<Route> data) {
    final seen = <int>{};
    return data
        .where((dataModel) => seen.add(dataModel.startStationId!))
        .toList();
  }

  List<Route> getUniqueRoutes(List<Station> stations) {
    List<Route> result = [];
    if (routeResult != null) {
      result = filterDuplicates(routeResult!.result);

      result.sort((a, b) {
        final stationA = stations.firstWhere(
          (station) => station.stationId == a.startStationId,
        );
        final stationB = stations.firstWhere(
          (station) => station.stationId == b.startStationId,
        );
        return (stationA.name ?? '').compareTo(stationB.name ?? '');
      });
    }
    return result;
  }

  List<DropdownMenuItem<String>> getRoutes() {
    var list = getUniqueRoutes(stationResult?.result ?? [])
        .map((item) => DropdownMenuItem(
            value: item.routeId.toString(),
            child: Text(getRoutesName(item.routeId))))
        .toList();
    return list;
  }

  String getRoutesName(int? rutaId) {
    String result = "";

    if (rutaId != null) {
      var ruta = routeResult?.result
          .where((route) => route.routeId == rutaId)
          .firstOrNull;
      var startStation = stationResult?.result
          .where((station) => station.stationId == ruta?.startStationId)
          .firstOrNull;
      var endStation = stationResult?.result
          .where((station) => station.stationId == ruta?.endStationId)
          .firstOrNull;
      result = "${startStation?.name ?? ""} - ${endStation?.name ?? ""}";
    }

    return result;
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text(
        "Novi zapis",
        style: TextStyle(fontWeight: FontWeight.bold),
      ),
      content: SingleChildScrollView(
        child: SizedBox(
          width: 500,
          child: isLoading
              ? const Center(
                  child: CircularProgressIndicator(),
                )
              : FormBuilder(
                  key: _formKey,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(height: 15),
                      const Text(
                        "Razlog kašnjenja:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderTextField(
                          name: 'reason',
                          validator: FormBuilderValidators.compose([
                            FormBuilderValidators.required(
                              errorText: "Ovo polje ne može bit prazno.",
                            ),
                          ]),
                          maxLines: 2,
                          keyboardType: TextInputType.multiline,
                          cursorColor: Colors.green.shade800,
                          decoration: const InputDecoration(
                            enabledBorder: OutlineInputBorder(
                              borderSide: BorderSide(color: Colors.black),
                              borderRadius: BorderRadius.only(
                                topLeft: Radius.circular(10),
                                topRight: Radius.circular(10),
                                bottomLeft: Radius.circular(10),
                                bottomRight: Radius.circular(10),
                              ),
                            ),
                          )),
                      const Text(
                        "Ruta:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderDropdown(
                        name: "routeId",
                        items: getRoutes(),
                        initialValue: selectedRouteId?.toString(),
                        onChanged: (value) {
                          setState(() {
                            selectedRouteId = int.parse(value as String);
                          });
                        },
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Odaberite rutu.",
                          ),
                        ]),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(
                              Radius.circular(10),
                            ),
                          ),
                        ),
                      ),
                      const Text(
                        "Količina kašnjenja u minutama:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderTextField(
                        name: 'delayAmountMinutes',
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                              errorText: "Ovo polje ne može bit prazno."),
                          FormBuilderValidators.integer(
                              errorText: "Format broja: 1010"),
                        ]),
                        cursorColor: Colors.green.shade800,
                        decoration: const InputDecoration(
                          enabledBorder: OutlineInputBorder(
                            borderSide: BorderSide(color: Colors.black),
                            borderRadius: BorderRadius.all(
                              Radius.circular(10),
                            ),
                          ),
                        ),
                      ),
                      const Text(
                        "Tip vozila:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                          fontSize: 16,
                        ),
                      ),
                      const SizedBox(height: 10),
                      FormBuilderDropdown(
                        name: "typeId",
                        items: getVehicleType(),
                        initialValue: selectedVehicleTypeId?.toString(),
                        onChanged: (value) {
                          setState(() {
                            selectedVehicleTypeId = int.parse(value as String);
                          });
                        },
                        validator: FormBuilderValidators.compose([
                          FormBuilderValidators.required(
                            errorText: "Odaberite tip vozila.",
                          ),
                        ]),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(
                            borderRadius: BorderRadius.all(
                              Radius.circular(10),
                            ),
                          ),
                        ),
                      ),
                      const SizedBox(height: 25),
                      Row(
                        children: [
                          Expanded(
                            child: ElevatedButton(
                              onPressed: () async {
                                if (_formKey.currentState?.saveAndValidate() ??
                                    false) {
                                  var request =
                                      Map.from(_formKey.currentState!.value);
                                  request['modifiedDate'] =
                                      DateTime.now().toIso8601String();
                                  request['typeId'] = selectedVehicleTypeId;
                                  request['routeId'] = selectedRouteId;
                                  request['currentUserId'] = currentUserId;

                                  try {
                                    setState(() {
                                      isLoading = true;
                                    });

                                    await delayProvider.insert(request);

                                    showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                        title: const Text("Success"),
                                        content: const Text(
                                            "Zapis je uspješno dodan."),
                                        actions: [
                                          TextButton(
                                            child: const Text(
                                              "OK",
                                              style: TextStyle(
                                                  color: Colors.black),
                                            ),
                                            onPressed: () async {
                                              await widget.onDone();
                                              Navigator.pop(context);
                                              Navigator.pop(context, true);
                                            },
                                          )
                                        ],
                                      ),
                                    );
                                  } catch (error) {
                                    showDialog(
                                      context: context,
                                      builder: (context) => AlertDialog(
                                        title: const Text("Error"),
                                        content: Text(
                                          "Greška prilikom dodavanja zapisa: $error",
                                        ),
                                        actions: [
                                          TextButton(
                                            onPressed: () =>
                                                Navigator.pop(context),
                                            child: const Text("OK"),
                                          ),
                                        ],
                                      ),
                                    );
                                  } finally {
                                    setState(() {
                                      isLoading = false;
                                    });
                                  }
                                }
                              },
                              style: ElevatedButton.styleFrom(
                                backgroundColor:
                                    const Color.fromRGBO(72, 156, 118, 100),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(2.0),
                                ),
                                minimumSize: const Size(100, 65),
                              ),
                              child: const Text(
                                "Dodaj",
                                style: TextStyle(fontSize: 18),
                              ),
                            ),
                          ),
                        ],
                      ),
                    ],
                  ),
                ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () => Navigator.pop(context, false),
          child: const Text(
            "Cancel",
            style: TextStyle(color: Colors.red, fontSize: 18),
          ),
        ),
      ],
    );
  }
}
