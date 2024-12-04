import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/route/route_payment_choose_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:provider/provider.dart';
import 'package:input_quantity/input_quantity.dart';

class TicketInfoScreen extends StatefulWidget {
  final double? selectedTicketPrice;
  final User? user;
  final Ticket? ticket;
  final Status? status;
  final Route? route;

  const TicketInfoScreen(
      {required this.selectedTicketPrice,
      this.user,
      this.ticket,
      this.status,
      this.route,
      super.key});

  @override
  State<TicketInfoScreen> createState() => _TicketInfoScreenState();
}

class _TicketInfoScreenState extends State<TicketInfoScreen> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  bool isLoading = true;

  DateTime? dateOfBirth;
  int? countNumberOfTickets = 1;
  double? finalTicketPrice;
  Ticket? choosenTicket;
  Status? userTicketStatus;
  User? currentUser;
  Route? currentRoute;

  String? startStationName;
  String? endStationName;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    routeProvider = context.read<RouteProvider>();
    stationProvider = context.read<StationProvider>();

    super.initState();

    choosenTicket = widget.ticket;
    userTicketStatus = widget.status;
    currentUser = widget.user;
    currentRoute = widget.route;

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    routeResult = await routeProvider.get();
    stationResult = await stationProvider.get();

    startStationName = stationResult!.result
        .firstWhere(
          (start) => start.stationId == widget.route?.startStationId,
        )
        .name;

    endStationName = stationResult!.result
        .firstWhere(
          (end) => end.stationId == widget.route?.endStationId,
        )
        .name;

    setState(() {
      isLoading = false;
    });
  }

  double? makefinalTicketPrice(int? countNumberOfTickets) {
    finalTicketPrice = (widget.selectedTicketPrice! * countNumberOfTickets!);

    return finalTicketPrice;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: isLoading
            ? const Center(
                child: CircularProgressIndicator(),
              )
            : Column(
                children: [
                  Container(
                    padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
                    color: Colors.green.shade800,
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        const Text(
                          "Podaci",
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
                          ),
                        ),
                      ],
                    ),
                  ),
                  const Padding(
                    padding: EdgeInsets.fromLTRB(110.0, 20.0, 0.0, 20.0),
                    child: Row(
                      children: [
                        Icon(
                          Icons.tram,
                          size: 100,
                        ),
                        Icon(
                          Icons.bus_alert,
                          size: 100,
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 10),
                  const Padding(
                    padding: EdgeInsets.fromLTRB(0.0, 0.0, 330.0, 0.0),
                    child: Text("Račun:"),
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(15.0, 0.0, 15.0, 10.0),
                    child: Row(
                      children: [
                        Expanded(
                          child: Container(
                            padding: const EdgeInsets.symmetric(
                                vertical: 15.0, horizontal: 12.0),
                            decoration: BoxDecoration(
                              border: Border.all(color: Colors.black),
                              borderRadius: BorderRadius.circular(5.0),
                            ),
                            child: Text(
                              "Nr. ${widget.user?.userId} | ${widget.user?.firstName} ${widget.user?.lastName} | ${formatDate(widget.user?.dateOfBirth)}",
                              style: const TextStyle(
                                  fontWeight: FontWeight.bold,
                                  color: Colors.grey,
                                  fontSize: 20),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 10),
                  const Padding(
                    padding: EdgeInsets.fromLTRB(0.0, 0.0, 310.0, 0.0),
                    child: Text("Start - Cilj "),
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(15.0, 0.0, 15.0, 10.0),
                    child: Row(
                      children: [
                        Expanded(
                          child: Container(
                            padding: const EdgeInsets.symmetric(
                                vertical: 15.0, horizontal: 12.0),
                            decoration: BoxDecoration(
                              border: Border.all(color: Colors.black),
                              borderRadius: BorderRadius.circular(5.0),
                            ),
                            child: Text(
                              "$startStationName - $endStationName",
                              style: const TextStyle(
                                  fontWeight: FontWeight.bold,
                                  color: Colors.grey,
                                  fontSize: 20),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 10),
                  const Padding(
                    padding: EdgeInsets.fromLTRB(0.0, 0.0, 340.0, 0.0),
                    child: Text("Karta:"),
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(15.0, 0.0, 15.0, 10.0),
                    child: Row(
                      children: [
                        Expanded(
                          child: Container(
                            padding: const EdgeInsets.symmetric(
                                vertical: 15.0, horizontal: 12.0),
                            decoration: BoxDecoration(
                              border: Border.all(color: Colors.black),
                              borderRadius: BorderRadius.circular(5.0),
                            ),
                            child: Text(
                              "${widget.ticket?.name} karta",
                              style: const TextStyle(
                                  fontWeight: FontWeight.bold,
                                  color: Colors.grey,
                                  fontSize: 20),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 10),
                  const Padding(
                    padding: EdgeInsets.fromLTRB(0.0, 0.0, 310.0, 0.0),
                    child: Text("Vrijedi od:"),
                  ),
                  Padding(
                    padding: const EdgeInsets.fromLTRB(15.0, 0.0, 15.0, 10.0),
                    child: Row(
                      children: [
                        Expanded(
                          child: Container(
                            padding: const EdgeInsets.symmetric(
                                vertical: 15.0, horizontal: 12.0),
                            decoration: BoxDecoration(
                              border: Border.all(color: Colors.black),
                              borderRadius: BorderRadius.circular(5.0),
                            ),
                            child: const Text(
                              "ODMAH",
                              style: TextStyle(
                                fontSize: 20,
                                fontWeight: FontWeight.bold,
                                color: Colors.grey,
                              ),
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  const SizedBox(height: 10),
                  Row(
                    children: [
                      const SizedBox(width: 16),
                      InputQty(
                        maxVal: 10,
                        initVal: 1,
                        minVal: 1,
                        steps: 1,
                        onQtyChanged: (val) {
                          countNumberOfTickets = val.round();
                          setState(() {
                            makefinalTicketPrice(countNumberOfTickets);
                          });
                        },
                      ),
                      const SizedBox(width: 190),
                      Text(
                        formatPrice(
                            makefinalTicketPrice(countNumberOfTickets)!),
                        style: const TextStyle(
                            fontSize: 20, fontWeight: FontWeight.bold),
                      ),
                    ],
                  ),
                  const SizedBox(height: 20),
                  SizedBox(
                    width: double.infinity,
                    child: ElevatedButton(
                      onPressed: () async {
                        Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => PaymentChooseScreen(
                                  ticket: choosenTicket,
                                  status: userTicketStatus,
                                  selectedTicketPrice: finalTicketPrice,
                                  user: currentUser,
                                  amount: countNumberOfTickets,
                                  route: currentRoute,
                                )));
                      },
                      style: ElevatedButton.styleFrom(
                        backgroundColor: Colors.black,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(10.0),
                        ),
                        padding: const EdgeInsets.symmetric(vertical: 10.0),
                      ),
                      child: const Text(
                        "Kupi",
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 18),
                      ),
                    ),
                  ),
                  const SizedBox(height: 20),
                ],
              ),
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
