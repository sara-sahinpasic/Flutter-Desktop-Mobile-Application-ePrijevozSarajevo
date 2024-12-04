import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/route/route_ticket_choose_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:provider/provider.dart';

class RouteOptionsScreen extends StatefulWidget {
  final List<Route> routes;

  const RouteOptionsScreen({required this.routes, super.key});
  @override
  State<RouteOptionsScreen> createState() => _RouteOptionsScreenState();
}

class _RouteOptionsScreenState extends State<RouteOptionsScreen> {
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  bool isLoading = true;

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    routeProvider = context.read<RouteProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    routeResult = await routeProvider.get();

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: isLoading
          ? const Center(
              child: CircularProgressIndicator(),
            )
          : Column(children: [
              Container(
                padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
                color: Colors.green.shade800,
                child: Row(
                  mainAxisAlignment: MainAxisAlignment
                      .spaceBetween, // space between text and icon
                  children: [
                    const Text(
                      "Pretraga",
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 40,
                        color: Colors.white,
                      ),
                    ),
                    IconButton(
                        onPressed: () {
                          Navigator.of(context).pop();
                        },
                        icon: const Icon(
                          Icons.cancel_outlined,
                          color: Colors.white,
                          size: 40,
                        ))
                  ],
                ),
              ),
              const Row(
                children: [
                  Padding(
                    padding: EdgeInsets.fromLTRB(150.0, 50.0, 20.0, 0.0),
                    child: Icon(
                      Icons.location_on,
                      size: 100,
                    ),
                  ),
                ],
              ),
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.fromLTRB(15.0, 10.0, 20.0, 135.0),
                  child: ListView.builder(
                      itemCount: widget.routes.length,
                      itemBuilder: (context, index) {
                        final routeFromList = widget.routes[index];
                        final timeDeparture = routeFromList.departure;
                        final timeArrival = routeFromList.arrival;

                        final startStationName = stationResult?.result
                                .firstWhere((element) =>
                                    element.stationId ==
                                    routeFromList.startStationId)
                                .name ??
                            "";

                        final endStationName = stationResult?.result
                                .firstWhere((element) =>
                                    element.stationId ==
                                    routeFromList.endStationId)
                                .name ??
                            "";

                        return ListTile(
                          title: Container(
                              height: 40,
                              decoration: const BoxDecoration(
                                color: Color.fromRGBO(158, 158, 158, 0.279),
                                borderRadius: BorderRadius.only(
                                  topLeft: Radius.circular(10),
                                  topRight: Radius.circular(10),
                                  bottomLeft: Radius.circular(0),
                                  bottomRight: Radius.circular(0),
                                ),
                              ),
                              child: Align(
                                alignment: Alignment.center,
                                child: Text(
                                  "$startStationName - $endStationName",
                                  style: const TextStyle(
                                      fontSize: 18,
                                      fontWeight: FontWeight.bold),
                                ),
                              )),
                          subtitle: Container(
                            height: 40,
                            decoration: const BoxDecoration(
                              color: Color.fromRGBO(158, 158, 158, 0.279),
                              borderRadius: BorderRadius.only(
                                topLeft: Radius.circular(0),
                                topRight: Radius.circular(0),
                                bottomLeft: Radius.circular(10),
                                bottomRight: Radius.circular(10),
                              ),
                            ),
                            child: Align(
                              alignment: Alignment.center,
                              child: Text(
                                '${formatTime(timeDeparture)} - ${formatTime(timeArrival)}',
                                style: const TextStyle(
                                    fontSize: 18, fontWeight: FontWeight.bold),
                              ),
                            ),
                          ),
                          onTap: () async {
                            // pass only the selected route to the next screen
                            Navigator.of(context).push(MaterialPageRoute(
                              builder: (context) =>
                                  TicketChooseScreen(route: routeFromList),
                            ));
                          },
                        );
                      }),
                ),
              )
            ]),

      //footer
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
