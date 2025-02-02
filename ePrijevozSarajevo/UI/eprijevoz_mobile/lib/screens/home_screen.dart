import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/delay.dart';
import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/delay_provider.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/type_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/screens/moodTracker/frmMoodTracker30012025.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:provider/provider.dart';
import 'package:eprijevoz_mobile/models/type.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});
  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  User? currentUser;
  bool isLoading = false;
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late TypeProvider typeProvider;
  SearchResult<Type>? typeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  late DelayProvider delayProvider;
  SearchResult<Delay>? delayResult;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    delayProvider = context.read<DelayProvider>();
    routeProvider = context.read<RouteProvider>();
    typeProvider = context.read<TypeProvider>();
    stationProvider = context.read<StationProvider>();
    super.initState();
    initForm();
  }

  Future initForm() async {
    setState(() {
      isLoading = true;
    });

    try {
      userResult = await userProvider.get();
      delayResult = await delayProvider.get();
      routeResult = await routeProvider.get();
      typeResult = await typeProvider.get();
      stationResult = await stationProvider.get();

      currentUser = userResult?.result
          .firstWhere((user) => user.userName == AuthProvider.username);
    } catch (e) {
      debugPrint("Error loading user data: $e");
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  String getRoutesName(int? id) {
    String result = "";

    if (id != null) {
      var ruta =
          routeResult?.result.where((route) => route.routeId == id).firstOrNull;
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

  Widget _buildDelaysTable() {
    return Container(
      child: SingleChildScrollView(
        scrollDirection: Axis.horizontal,
        child: DataTable(
          columns: const <DataColumn>[
            DataColumn(
              label: Flexible(
                child: Text(
                  'Ruta',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
            DataColumn(
              label: Flexible(
                child: Text(
                  'Kašnjenje',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
            DataColumn(
              label: Flexible(
                child: Text(
                  'Tip vozila',
                  softWrap: true,
                  overflow: TextOverflow.visible,
                  style: TextStyle(
                      color: Colors.black,
                      fontWeight: FontWeight.bold,
                      fontSize: 18),
                ),
              ),
            ),
          ],
          rows: delayResult?.result
                  .map(
                    (e) => DataRow(
                      cells: [
                        DataCell(Text(
                          getRoutesName(e.routeId),
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                        DataCell(Text(
                          "${e.delayAmountMinutes} min",
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                        DataCell(Text(
                          typeResult?.result
                                  .firstWhere(
                                      (element) => element.typeId == e.typeId)
                                  .name ??
                              "",
                          style: const TextStyle(
                              color: Colors.black, fontSize: 17),
                        )),
                      ],
                    ),
                  )
                  .toList()
                  .cast<DataRow>() ??
              [],
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: LayoutBuilder(
          builder: (context, constraints) {
            constraints.maxWidth;
            return Padding(
              padding: const EdgeInsets.fromLTRB(15.0, 20.0, 15.0, 0.0),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  Padding(
                    padding: const EdgeInsets.fromLTRB(110.0, 0.0, 0.0, 0.0),
                    child: Row(
                      children: [
                        Icon(
                          Icons.tram,
                          size: 80,
                          color: Colors.green.shade800,
                        ),
                        Icon(
                          Icons.bus_alert,
                          size: 80,
                          color: Colors.green.shade800,
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(
                    height: 30,
                  ),
                  Center(
                    child: Text(
                      "ePrijevozSarajevo\nDobrodošli, ${currentUser?.firstName ?? ''}!",
                      textAlign: TextAlign.center,
                      style: TextStyle(
                        fontSize: 40,
                        fontWeight: FontWeight.bold,
                        color: Colors.green.shade700,
                      ),
                      maxLines: 2,
                      overflow: TextOverflow.ellipsis,
                    ),
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  TextButton(
                    onPressed: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) =>
                              const frmMoodTracker30012025()));
                    },
                    child: const Text(
                      "frmMoodTracker",
                      style: TextStyle(
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.red,
                          color: Color.fromARGB(255, 212, 16, 2),
                          fontWeight: FontWeight.bold,
                          fontSize: 15),
                    ),
                  ),
                  const Text(
                    "Aktualna kašnjenja:",
                    textAlign: TextAlign.left,
                    style: TextStyle(
                      fontSize: 20,
                      fontWeight: FontWeight.bold,
                      color: Colors.red,
                    ),
                    maxLines: 2,
                    overflow: TextOverflow.ellipsis,
                  ),
                  _buildDelaysTable(),
                  const SizedBox(
                    height: 25,
                  ),
                  Text(
                    "ZAJEDNO ZAŠTITIMO NAŠU PLANETU ZEMLJU!",
                    textAlign: TextAlign.center,
                    style: TextStyle(
                      fontSize: 20,
                      color: Colors.green.shade800,
                    ),
                  ),
                  const SizedBox(height: 30),
                  SizedBox(
                    width: double.infinity,
                    child: ElevatedButton(
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (context) => const MasterScreen(
                              initialIndex: 1,
                            ),
                          ),
                        );
                      },
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.black,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0),
                        ),
                        padding: const EdgeInsets.symmetric(vertical: 10.0),
                      ),
                      child: const Text(
                        "Krenimo odmah!",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 23),
                      ),
                    ),
                  ),
                ],
              ),
            );
          },
        ),
      ),
    );
  }
}
