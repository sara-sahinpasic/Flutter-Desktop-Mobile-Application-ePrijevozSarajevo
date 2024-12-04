import 'package:eprijevoz_mobile/models/issuedTicket.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_mobile/providers/ticket_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart';
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

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    issuedTicketProvider = context.read<IssuedTicketProvider>();
    ticketProvider = context.read<TicketProvider>();

    super.initState();

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    issuedTicketResult = await issuedTicketProvider.get();
    ticketResult = await ticketProvider.get();

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

  List<String>? ticketName() {
    var issuedTickets = issuedTicketResult?.result
        .where((issuedTicket) => issuedTicket.userId == user?.userId)
        .toList();

    if (issuedTickets != null && issuedTickets.isNotEmpty) {
      for (var issuedTicket in issuedTickets) {
        var ticket = ticketResult?.result.firstWhere(
          (ticket) => ticket.ticketId == issuedTicket.ticketId,
        );

        if (ticket != null) {
          ticketsName?.add(ticket.name ?? "");
        }
      }
    } else {
      debugPrint("Korisnik nema izdatih karti.");
    }
    return ticketsName;
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
              var ticket = ticketResult?.result.firstWhere(
                (ticket) => ticket.ticketId == issuedTicket.ticketId,
              );

              if (ticket == null) {
                return const Text("Karta nije pronađena.");
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
                      "${ticket.name} karta  (${issuedTicket.amount})",
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
                  ],
                ),
              );
            }).toList(),
          );
  }
}
