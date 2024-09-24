import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/ticket_choose.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:provider/provider.dart';

class RouteOptionsScreen extends StatefulWidget {
  final List<Route> routes;

  RouteOptionsScreen({required this.routes, super.key});
  @override
  State<RouteOptionsScreen> createState() => _RouteOptionsScreenState();
}

class _RouteOptionsScreenState extends State<RouteOptionsScreen> {
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;

  @override
  void initState() {
    // TODO: implement initState
    stationProvider = context.read<StationProvider>();
    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(children: [
        Container(
          padding: EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
          color: Colors.green.shade800,
          child: Row(
            mainAxisAlignment:
                MainAxisAlignment.spaceBetween, // space between text and icon
            children: [
              Text(
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
                  icon: Icon(
                    Icons.cancel_outlined,
                    color: Colors.white,
                    size: 40,
                  ))
            ],
          ),
        ),
        Row(
          children: [
            //Text("data"),
            Padding(
              padding: const EdgeInsets.fromLTRB(150.0, 50.0, 20.0, 0.0),
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
                  final route = widget.routes[index];
                  final timeDeparture = route.departure;
                  final timeArrival = route.arrival;

                  final startStationName = stationResult?.result
                          .firstWhere((element) =>
                              element.stationId == route.startStationId)
                          .name ??
                      "";

                  final endStationName = stationResult?.result
                          .firstWhere((element) =>
                              element.stationId == route.endStationId)
                          .name ??
                      "";

                  return ListTile(
                    title: Container(
                        height: 40,
                        decoration: const BoxDecoration(
                          color: Color.fromRGBO(158, 158, 158, 0.279),
                          //color: Colors.red,
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
                            style: TextStyle(
                                fontSize: 18, fontWeight: FontWeight.bold),
                          ),
                        )),
                    subtitle: Container(
                      height: 40,
                      decoration: const BoxDecoration(
                        color: Color.fromRGBO(158, 158, 158, 0.279),
                        //color: Colors.red,
                        borderRadius: BorderRadius.only(
                          topLeft: Radius.circular(0),
                          topRight: Radius.circular(0),
                          bottomLeft: Radius.circular(10),
                          bottomRight: Radius.circular(10),
                        ),
                        // boxShadow: [
                        //   BoxShadow(
                        //     color: Colors.grey,
                        //     spreadRadius: 0.1,
                        //     blurRadius: 40,
                        //     offset: Offset(0, 30), // changes position of shadow
                        //   ),
                        // ],
                      ),
                      child: Align(
                        alignment: Alignment.center,
                        child: Text(
                          '${formatTime(timeDeparture)} - ${formatTime(timeArrival)}',
                          style: TextStyle(
                              fontSize: 18, fontWeight: FontWeight.bold),
                        ),
                      ),
                    ),
                    onTap: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => TicketChooseScreen()));
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
