import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/status_provider.dart';
import 'package:eprijevoz_mobile/providers/ticket_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/ticket_info_screen.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:provider/provider.dart';

class TicketChooseScreen extends StatefulWidget {
  final Route route; // Accept only ONE route
  TicketChooseScreen({required this.route, super.key});
  @override
  State<TicketChooseScreen> createState() => _TicketChooseScreenState();
}

class _TicketChooseScreenState extends State<TicketChooseScreen> {
  late StationProvider stationProvider;
  late StatusProvider statusProvider;
  late TicketProvider ticketProvider;
  late UserProvider userProvider;

  SearchResult<Station>? stationResult;
  SearchResult<Status>? statusResult;
  SearchResult<Ticket>? ticketResult;
  SearchResult<User>? userResult;

  int? _selectedTicketTypeId;
  double? _selectedTicketPrice;
  int? _selectedStatusDiscountTypeId;
  int? _userStatusId;

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    statusProvider = context.read<StatusProvider>();
    ticketProvider = context.read<TicketProvider>();
    userProvider = context.read<UserProvider>();
    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    statusResult = await statusProvider.get();
    ticketResult = await ticketProvider.get();
    userResult = await userProvider.get();

    setState(() {});
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
    var trenutniUser = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);
    if (trenutniUser != null) print("Fetched user: ${trenutniUser?.toJson()}");

    if (trenutniUser != null) {
      _userStatusId = trenutniUser.userStatusId!;
    }

    print("poslije if userStatus je:: ${_userStatusId}");
    if (_userStatusId == 1) //default = disable
    {
      print("true uslov / disabled...");
      return true;
    } else {
      print("false uslov / enabled...");
      return false;
    }
  }

/*
  List<ListTile> generateTicketList() {
    if (ticketResult == null) {
      return List<ListTile>.empty();
    }
    Ticket? mjesecnaKarta;

    var currentUser = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    var basicTicketList = ticketResult!.result.map((ticket) {
      //magic number 5 means mjesecna
      if (ticket.ticketId == 5) {
        mjesecnaKarta = ticket;
      }
      return ListTile(
        title: Text("${ticket.name} karta - ${formatPrice(ticket.price!)}",
            style: const TextStyle(fontSize: 16)),
        leading: Radio<double>(
            value: ticket.price!,
            groupValue: _selectedTicketPrice,
            activeColor: Colors.green,
            onChanged: (double? value) {
              setState(() {
                _selectedTicketPrice = value;
              });
            }),
      );
    }).toList();

    var extraTicketList = statusResult!.result
        .where((element) => !element.name!.contains("Default"))
        .map((status) {
      var reducedPrice =
          mjesecnaKarta!.price! - (mjesecnaKarta!.price! * status.discount!);
      var enabled = currentUser!.userStatusId! == status.statusId!;
      return ListTile(
        title: Text(
            "${mjesecnaKarta?.name} karta - ${status.name} - ${formatPrice(reducedPrice)}",
            style: const TextStyle(fontSize: 16)),
        leading: Radio<double>(
            value: reducedPrice,
            groupValue: _selectedTicketPrice,
            activeColor: Colors.green,
            onChanged: enabled
                ? (double? value) {
                    setState(() {
                      _selectedTicketPrice = value;
                    });
                  }
                : null),
        enabled: enabled,
      );
    }).toList();

    return basicTicketList + extraTicketList;
  }

  */

  List<ListTile> generateTicketList() {
    if (ticketResult == null) {
      return List<ListTile>.empty();
    }
    Ticket? mjesecnaKarta;

    var currentUser = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    var basicTicketList = ticketResult!.result.map((ticket) {
      //magic number 5 means mjesecna
      if (ticket.ticketId == 5) {
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
          groupValue: _selectedTicketPrice,
          activeColor: Colors.green,
          onChanged: (double? value) {
            setState(() {
              _selectedTicketPrice = value;
            });
          },
        ),
      );
    }).toList();

    var extraTicketList = statusResult!.result
        .where((element) => !element.name!.contains("Default"))
        .map((status) {
      var reducedPrice =
          mjesecnaKarta!.price! - (mjesecnaKarta!.price! * status.discount!);
      var enabled = currentUser!.userStatusId! == status.statusId!;
      return ListTile(
        title: Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Text("${mjesecnaKarta?.name} karta - ${status.name}",
                style:
                    const TextStyle(fontSize: 16, fontWeight: FontWeight.w500)),
            Text(formatPrice(reducedPrice),
                style:
                    const TextStyle(fontSize: 16, fontWeight: FontWeight.w700)),
          ],
        ),
        leading: Radio<double>(
          value: reducedPrice,
          groupValue: _selectedTicketPrice,
          activeColor: Colors.green,
          onChanged: enabled
              ? (double? value) {
                  setState(() {
                    _selectedTicketPrice = value;
                  });
                }
              : null,
        ),
        enabled: enabled,
      );
    }).toList();

    return basicTicketList + extraTicketList;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Column(
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
          Row(
            children: const [
              Padding(
                padding: EdgeInsets.fromLTRB(150.0, 20.0, 0.0, 20.0),
                child: Icon(
                  Icons.location_on,
                  size: 100,
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
          SizedBox(
            height: 20,
          ),
          SizedBox(
            width: double.infinity,
            child: ElevatedButton(
              onPressed: () {
                Navigator.of(context).push(MaterialPageRoute(
                    builder: (context) => TicketInfoScreen()));
              },
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.black,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(10.0),
                ),
                padding: const EdgeInsets.symmetric(vertical: 10.0),
              ),
              child: const Text(
                "Dodaj",
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
              ),
            ),
          ),
          SizedBox(
            height: 25,
          ),
        ],
      ),

      // Footer
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
