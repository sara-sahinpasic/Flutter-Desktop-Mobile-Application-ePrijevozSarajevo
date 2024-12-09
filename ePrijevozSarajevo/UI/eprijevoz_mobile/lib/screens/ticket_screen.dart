import 'package:eprijevoz_mobile/models/issuedTicket.dart';
import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/ticket_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:provider/provider.dart';

class TicketScreen extends StatefulWidget {
  const TicketScreen({super.key});

  @override
  State<TicketScreen> createState() => _TicketScreenState();
}

class _TicketScreenState extends State<TicketScreen> {
  late UserProvider userProvider;
  late IssuedTicketProvider issuedTicketProvider;
  late TicketProvider ticketProvider;
  SearchResult<User>? userResult;
  SearchResult<IssuedTicket>? issuedTicketResult;
  SearchResult<Ticket>? ticketResult;
  User? user;
  int? amount;
  bool isLoading = true;
  final List<String>? ticketsName = [];
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  String? startStationName;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    issuedTicketProvider = context.read<IssuedTicketProvider>();
    ticketProvider = context.read<TicketProvider>();
    routeProvider = context.read<RouteProvider>();
    stationProvider = context.read<StationProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    issuedTicketResult = await issuedTicketProvider.get();
    ticketResult = await ticketProvider.get();
    routeResult = await routeProvider.get();
    stationResult = await stationProvider.get();

    user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    var issuedTicket = issuedTicketResult?.result
        .firstWhere((ticketUser) => ticketUser.userId == user?.userId);
    if (issuedTicket != null) {
      amount = issuedTicket.amount;
    }

    setState(() {
      isLoading = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildResultView(),
              const SizedBox(height: 15),
            ],
          ),
        ),
      ),
    );
  }

  Widget _buildResultView() {
    var issuedTickets = issuedTicketResult?.result
        .where((issuedTicket) => issuedTicket.userId == user?.userId)
        .toList();

    if (issuedTickets == null || issuedTickets.isEmpty) {
      return const Text("Korisnik nema izdatih karti.");
    }

    return isLoading
        ? const Center(
            child: CircularProgressIndicator(),
          )
        : Column(
            children: issuedTickets.map((issuedTicket) {
              Route? route = routeResult?.result.firstWhere(
                (route) => route.routeId == issuedTicket.routeId,
              );

              if (route == null) {
                return const Text("Ruta nije pronađena.");
              }

              String? startStation = stationResult!.result
                  .firstWhere(
                    (station) => station.stationId == route.startStationId,
                  )
                  .name;

              if (startStation == null) {
                return const Text("Početna stanica nije pronađena.");
              }

              Color cardColor = DateTime.now().isAfter(issuedTicket.validTo!)
                  ? Colors.red.shade300
                  : Colors.green.shade300;

              return Container(
                margin: const EdgeInsets.symmetric(vertical: 10),
                width: 400,
                padding: const EdgeInsets.all(16),
                decoration: BoxDecoration(
                  color: cardColor,
                  borderRadius: BorderRadius.circular(10),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.grey.withOpacity(0.5),
                      spreadRadius: 2,
                      blurRadius: 5,
                      offset: const Offset(0, 3),
                    ),
                  ],
                ),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      "${ticketResult?.result.firstWhere((ticket) => ticket.ticketId == issuedTicket.ticketId).name ?? 'Karta'} karta (${issuedTicket.amount})",
                      style: const TextStyle(
                          fontSize: 18, fontWeight: FontWeight.bold),
                    ),
                    const SizedBox(height: 5),
                    Text(
                      "Kupac: Nr.${user?.userId} | ${user?.firstName} ${user?.lastName} | ${formatDate(user?.dateOfBirth)}",
                    ),
                    const Divider(
                      color: Colors.black,
                    ),
                    const Text(
                      "Valjanost:",
                      style: TextStyle(fontWeight: FontWeight.w500),
                    ),
                    Text(
                      "${formatDateTime(issuedTicket.validFrom!)} - ${formatDateTime(issuedTicket.validTo!)}",
                      style: const TextStyle(fontWeight: FontWeight.w500),
                    ),
                    const SizedBox(height: 5),
                    const Text(
                      "Startna stanica:",
                      style: TextStyle(fontWeight: FontWeight.w500),
                    ),
                    Text(
                      startStation,
                      style: const TextStyle(fontWeight: FontWeight.w500),
                    ),
                  ],
                ),
              );
            }).toList(),
          );
  }
}
