import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/status_provider.dart';
import 'package:eprijevoz_mobile/providers/ticket_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/route/route_ticket_info_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:provider/provider.dart';

class TicketChooseScreen extends StatefulWidget {
  final Route route;
  const TicketChooseScreen({required this.route, super.key});
  @override
  State<TicketChooseScreen> createState() => _TicketChooseScreenState();
}

class _TicketChooseScreenState extends State<TicketChooseScreen> {
  late StationProvider stationProvider;
  late StatusProvider statusProvider;
  late TicketProvider ticketProvider;
  late UserProvider userProvider;
  late RouteProvider routeProvider;
  SearchResult<Station>? stationResult;
  SearchResult<Status>? statusResult;
  SearchResult<Ticket>? ticketResult;
  SearchResult<User>? userResult;
  SearchResult<Route>? routeResult;
  double? selectedTicketPrice;
  int? userStatusId;
  User? loggedUser;
  Ticket? basicTicket;
  Status? extraStatusTicket;
  Route? currentRoute;
  bool isLoading = true;

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    statusProvider = context.read<StatusProvider>();
    ticketProvider = context.read<TicketProvider>();
    userProvider = context.read<UserProvider>();
    routeProvider = context.read<RouteProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    statusResult = await statusProvider.get();
    ticketResult = await ticketProvider.get();
    userResult = await userProvider.get();
    routeResult = await routeProvider.get();

    loggedUser = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    currentRoute = widget.route;

    setState(() {
      isLoading = false;
    });
  }

  String? getStartStationName() {
    return stationResult?.result
            .firstWhere(
                (element) => element.stationId == widget.route.startStationId)
            .name ??
        "";
  }

  String? getEndStationName() {
    return stationResult?.result
            .firstWhere(
                (element) => element.stationId == widget.route.endStationId)
            .name ??
        "";
  }

  bool disableTickets(Status userStatus) {
    if (loggedUser != null && loggedUser?.userStatusId != null) {
      userStatusId = loggedUser?.userStatusId!;
    }

    if (userStatusId == 1) // default == disable
    {
      return true;
    } else {
      return false;
    }
  }

  List<ListTile> generateTicketList() {
    if (ticketResult == null) {
      return List<ListTile>.empty();
    }
    Ticket? mjesecnaKarta;

    var currentUser = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    var basicTicketList = ticketResult!.result.map((ticket) {
      if (ticket.ticketId == 5) // 5 == mjesečna
      {
        mjesecnaKarta = ticket;
      }
      return ListTile(
        title: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text("${ticket.name} karta",
                style:
                    const TextStyle(fontSize: 16, fontWeight: FontWeight.w500)),
            Text(formatPrice(ticket.price!),
                style:
                    const TextStyle(fontSize: 16, fontWeight: FontWeight.w700)),
          ],
        ),
        leading: Radio<double>(
          value: ticket.price!,
          groupValue: selectedTicketPrice,
          activeColor: Colors.green,
          onChanged: (double? value) {
            setState(() {
              selectedTicketPrice = value;
              basicTicket = ticket;
            });
          },
        ),
      );
    }).toList();
    var extraTicketList = <ListTile>[];
    if (mjesecnaKarta != null) {
      extraTicketList = statusResult!.result
          .where((element) => !element.name!.contains("Default"))
          .map((status) {
        var reducedPrice =
            mjesecnaKarta!.price! - (mjesecnaKarta!.price! * status.discount!);
        var currentUserStatus = currentUser!.userStatusId;
        var enabled = currentUserStatus != null
            ? currentUserStatus == status.statusId!
            : false;
        return ListTile(
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text("${mjesecnaKarta?.name} karta - ${status.name}",
                  style: const TextStyle(
                      fontSize: 16, fontWeight: FontWeight.w500)),
              Text(formatPrice(reducedPrice),
                  style: const TextStyle(
                      fontSize: 16, fontWeight: FontWeight.w700)),
            ],
          ),
          leading: Radio<double>(
            value: reducedPrice,
            groupValue: selectedTicketPrice,
            activeColor: Colors.green,
            onChanged: enabled
                ? (double? value) {
                    setState(() {
                      selectedTicketPrice = value;
                      extraStatusTicket = status;
                      basicTicket = mjesecnaKarta;
                    });
                  }
                : null,
          ),
          enabled: enabled,
        );
      }).toList();
    }
    return basicTicketList + extraTicketList;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: isLoading
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
                        ),
                      ),
                    ],
                  ),
                ),
                const Row(
                  children: [
                    Padding(
                      padding: EdgeInsets.fromLTRB(150.0, 20.0, 0.0, 20.0),
                      child: Icon(
                        Icons.location_on,
                        size: 100,
                        color: Colors.black,
                      ),
                    ),
                  ],
                ),
                Padding(
                  padding: const EdgeInsets.fromLTRB(15.0, 10.0, 20.0, 10.0),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      Text(
                        "${getStartStationName()} - ${getEndStationName()}",
                        style: const TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          decoration: TextDecoration.underline,
                        ),
                      ),
                      const SizedBox(height: 5),
                      Text(
                        "${formatTime(widget.route.departure)} - ${formatTime(widget.route.arrival)}",
                        style: const TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          decoration: TextDecoration.underline,
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(height: 10),
                Expanded(
                  child: ListView(children: generateTicketList()),
                ),
                const SizedBox(
                  height: 20,
                ),
                SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: selectedTicketPrice != null
                        ? () {
                            Navigator.of(context)
                                .push(
                              MaterialPageRoute(
                                builder: (context) => TicketInfoScreen(
                                  selectedTicketPrice: selectedTicketPrice!,
                                  user: loggedUser,
                                  ticket: basicTicket,
                                  status: extraStatusTicket,
                                  route: currentRoute,
                                ),
                              ),
                            )
                                .then((_) {
                              setState(() {
                                // reset the state only after returning to this page
                                selectedTicketPrice = null;
                                basicTicket = null;
                                extraStatusTicket = null;
                              });
                            });
                          }
                        : null, // disable the button if no price is selected
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.black,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(10.0),
                      ),
                      padding: const EdgeInsets.symmetric(vertical: 10.0),
                    ),
                    child: const Text(
                      "Dodaj",
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                    ),
                  ),
                ),
                const SizedBox(
                  height: 25,
                ),
              ],
            ),

      // footer
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
