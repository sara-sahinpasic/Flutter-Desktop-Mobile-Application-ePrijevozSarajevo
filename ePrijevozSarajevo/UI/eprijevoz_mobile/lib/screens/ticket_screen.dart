import 'package:eprijevoz_mobile/models/issuedTicket.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status.dart';
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
  //final int? amount;
  const TicketScreen(
      {
      //this.amount,
      super.key});

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
  User? _user;
  int? _amount;

  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    issuedTicketProvider = context.read<IssuedTicketProvider>();
    ticketProvider = context.read<TicketProvider>();

    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    issuedTicketResult = await issuedTicketProvider.get();
    ticketResult = await ticketProvider.get();

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);
    _user = user;

    var issuedTicket = issuedTicketResult?.result
        .firstWhere((ticketUser) => ticketUser.userId == _user?.userId);
    if (issuedTicket != null) {
      _amount = issuedTicket.amount;
    }

    setState(() {});
  }

  final List<String>? _ticketsName = [];
  List<String>? ticketName() {
    var issuedTickets = issuedTicketResult?.result
        .where((issuedTicket) => issuedTicket.userId == _user?.userId)
        .toList();

    if (issuedTickets != null && issuedTickets.isNotEmpty) {
      for (var issuedTicket in issuedTickets) {
        var ticket = ticketResult?.result.firstWhere(
          (ticket) => ticket.ticketId == issuedTicket.ticketId,
        );

        if (ticket != null) {
          _ticketsName?.add(ticket.name ?? "");
        }
      }
    } else {
      print("Korisnik nema izdatih karti.");
    }
    return _ticketsName;
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
        .where((issuedTicket) => issuedTicket.userId == _user?.userId)
        .toList();

    if (issuedTickets == null || issuedTickets.isEmpty) {
      return Text("Korisnik nema izdatih karti.");
    }

    return Column(
      children: issuedTickets.map((issuedTicket) {
        var ticket = ticketResult?.result.firstWhere(
          (ticket) => ticket.ticketId == issuedTicket.ticketId,
        );

        if (ticket == null) {
          return Text("Karta nije pronađena.");
        }

        Color cardColor = DateTime.now().isAfter(issuedTicket.validTo!)
            ? Colors.red.shade300
            : Colors.green.shade300;

        return Container(
          margin: EdgeInsets.symmetric(vertical: 10),
          width: 400,
          padding: EdgeInsets.all(16),
          decoration: BoxDecoration(
            color: cardColor,
            borderRadius: BorderRadius.circular(10),
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.5),
                spreadRadius: 2,
                blurRadius: 5,
                offset: Offset(0, 3),
              ),
            ],
          ),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                "${ticket.name} karta - ${issuedTicket.amount}X" ?? "",
                style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
              SizedBox(height: 5),
              Text("Broj korisnika: ${_user?.userId}"),
              Text("Korisnik: ${_user?.firstName} ${_user?.lastName}"),
              Text(
                "Datum rođenja: ${formatDate(_user?.dateOfBirth)}",
              ),
              Divider(
                color: Colors.black,
              ),
              Text("Datum važenja:"),
              Text(
                "${formatDateTime(issuedTicket.validFrom!)} <lll> ${formatDateTime(issuedTicket.validTo!)}",
              ),
            ],
          ),
        );
      }).toList(),
    );
  }
}
