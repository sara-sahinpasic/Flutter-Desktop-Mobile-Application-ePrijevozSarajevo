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
    setState(() {}); // Trigger a rebuild after fetching the data
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
                padding: EdgeInsets.fromLTRB(150.0, 50.0, 0.0, 20.0),
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
                const SizedBox(height: 10),
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
          Expanded(
            child: ListView(
              children: [
                if (ticketResult != null)
                  ...ticketResult!.result.map((ticket) {
                    return ListTile(
                      title: Text(
                        "${ticket.name} karta ------- ${ticket.price} KM",
                        style: const TextStyle(fontSize: 16),
                      ),
                      leading: Radio<int>(
                        value: ticket.ticketId!,
                        groupValue: _selectedTicketTypeId,
                        activeColor: Colors.green,
                        onChanged: (int? value) {
                          setState(() {
                            if (_selectedStatusDiscountTypeId == null) {
                              //  _selectedStatusDiscountTypeId = 0;

                              _selectedTicketTypeId = value;
                            }
                          });
                        },
                      ),
                    );
                  }).toList(),
                if (statusResult != null)
                  ...statusResult!.result
                      .where((status) => !status.name!.contains("Default"))
                      .map((status) {
                    bool disabled = disableTickets(status);

                    print("Disabled: $disabled");

                    return ListTile(
                      title: Text(
                        "Mjesečna karta - ${status.name}",
                        style: TextStyle(
                          fontSize: 16,
                          color: disabled ? Colors.grey : Colors.black,
                        ),
                      ),
                      leading: Radio<int>(
                        value: status.statusId!,
                        groupValue: _selectedStatusDiscountTypeId,
                        activeColor: Colors.green,
                        onChanged: disabled
                            ? null // Disable selection if necessary
                            : (int? value) {
                                setState(() {
                                  if (_selectedTicketTypeId == null) {
                                    //_selectedTicketTypeId = 0;

                                    _selectedStatusDiscountTypeId = value;
                                  }
                                });
                              },
                      ),
                    );
                  }).toList(),
                const SizedBox(height: 50),
              ],
            ),
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
