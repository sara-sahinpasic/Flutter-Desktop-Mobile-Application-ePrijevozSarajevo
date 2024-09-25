// import 'package:eprijevoz_mobile/models/route.dart';
// import 'package:eprijevoz_mobile/models/search_result.dart';
// import 'package:eprijevoz_mobile/models/station.dart';
// import 'package:eprijevoz_mobile/models/status.dart';
// import 'package:eprijevoz_mobile/models/ticket.dart';
// import 'package:eprijevoz_mobile/providers/station_provider.dart';
// import 'package:eprijevoz_mobile/providers/status_provider.dart';
// import 'package:eprijevoz_mobile/providers/ticket_provider.dart';
// import 'package:eprijevoz_mobile/providers/utils.dart';
// import 'package:flutter/material.dart' hide Route;
// import 'package:provider/provider.dart';

// class TicketChooseScreen extends StatefulWidget {
//   final Route route; // Accept only ONE route
//   TicketChooseScreen({required this.route, super.key});
//   @override
//   State<TicketChooseScreen> createState() => _TicketChooseScreenState();
// }

// class _TicketChooseScreenState extends State<TicketChooseScreen> {
//   late StationProvider stationProvider;
//   late StatusProvider statusProvider;
//   late TicketProvider ticketProvider;

//   SearchResult<Station>? stationResult;
//   SearchResult<Status>? statusResult;
//   SearchResult<Ticket>? ticketResult;

//   int? _selectedTicketTypeId;
//   int _userStatusId =
//       1; // Assuming this comes from the user's information (default set to 1 for example)

//   @override
//   void initState() {
//     stationProvider = context.read<StationProvider>();
//     statusProvider = context.read<StatusProvider>();
//     ticketProvider = context.read<TicketProvider>();
//     initForm();
//   }

//   Future initForm() async {
//     stationResult = await stationProvider.get();
//     statusResult = await statusProvider.get();
//     ticketResult = await ticketProvider.get();

//     // Assume we fetch the user's status here. For now, I'm assuming it's 1.
//     // You'd replace this with the actual user's status fetched from somewhere.
//     setState(() {}); // Trigger a rebuild after fetching the data
//   }

//   String? getStartStationName() {
//     return stationResult?.result
//             .firstWhere(
//                 (element) => element.stationId == widget.route.startStationId)
//             .name ??
//         "";
//   }

//   String? getEndStationName() {
//     return stationResult?.result
//             .firstWhere(
//                 (element) => element.stationId == widget.route.endStationId)
//             .name ??
//         "";
//   }

//   @override
//   Widget build(BuildContext context) {
//     return Scaffold(
//       body: Column(
//         children: [
//           Container(
//             padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
//             color: Colors.green.shade800,
//             child: Row(
//               mainAxisAlignment: MainAxisAlignment.spaceBetween,
//               children: [
//                 const Text(
//                   "Pretraga",
//                   style: TextStyle(
//                     fontWeight: FontWeight.bold,
//                     fontSize: 40,
//                     color: Colors.white,
//                   ),
//                 ),
//                 IconButton(
//                   onPressed: () {
//                     Navigator.of(context).pop();
//                   },
//                   icon: const Icon(
//                     Icons.cancel_outlined,
//                     color: Colors.white,
//                     size: 40,
//                   ),
//                 ),
//               ],
//             ),
//           ),
//           Row(
//             children: const [
//               Padding(
//                 padding: EdgeInsets.fromLTRB(150.0, 50.0, 0.0, 20.0),
//                 child: Icon(
//                   Icons.location_on,
//                   size: 100,
//                 ),
//               ),
//             ],
//           ),
//           Padding(
//             padding: const EdgeInsets.fromLTRB(15.0, 10.0, 20.0, 10.0),
//             child: Column(
//               mainAxisAlignment: MainAxisAlignment.center,
//               crossAxisAlignment: CrossAxisAlignment.center,
//               children: [
//                 Text(
//                   "${getStartStationName()} - ${getEndStationName()}",
//                   style: const TextStyle(
//                     fontSize: 18,
//                     fontWeight: FontWeight.bold,
//                     decoration: TextDecoration.underline,
//                   ),
//                 ),
//                 const SizedBox(height: 10),
//                 Text(
//                   "${formatTime(widget.route.departure)} - ${formatTime(widget.route.arrival)}",
//                   style: const TextStyle(
//                     fontSize: 18,
//                     fontWeight: FontWeight.bold,
//                     decoration: TextDecoration.underline,
//                   ),
//                 ),
//               ],
//             ),
//           ),
//           Expanded(
//             child: ListView(
//               children: [
//                 if (ticketResult != null)
//                   ...ticketResult!.result.map((ticket) {
//                     return ListTile(
//                       title: Text(
//                         "${ticket.name} karta ------- ${ticket.price} KM",
//                         style: const TextStyle(fontSize: 16),
//                       ),
//                       leading: Radio<int>(
//                         value: ticket.ticketId!,
//                         groupValue: _selectedTicketTypeId,
//                         activeColor: Colors.green,
//                         onChanged: (int? value) {
//                           setState(() {
//                             _selectedTicketTypeId = value;
//                           });
//                         },
//                       ),
//                     );
//                   }).toList(),

//                 // Conditional logic for "Mjesečna karta" based on userStatusId
//                 if (statusResult != null)
//                   ...statusResult!.result.map((status) {
//                     bool isMjesecnaKarta =
//                         status.name!.contains("Mjesečna karta");
//                     bool isDisabled = (_userStatusId == 1 && isMjesecnaKarta);

//                     return ListTile(
//                       title: Text(
//                         "Mjesečna karta - ${status.name}",
//                         style: TextStyle(
//                           fontSize: 16,
//                           color: isDisabled
//                               ? Colors.grey
//                               : Colors.black, // Grey out if disabled
//                         ),
//                       ),
//                       leading: Radio<int>(
//                         value: status.statusId!,
//                         groupValue: _selectedTicketTypeId,
//                         activeColor: Colors.green,
//                         onChanged: isDisabled
//                             ? null // Disable selection if userStatusId is 1 and it's "Mjesečna karta"
//                             : (int? value) {
//                                 setState(() {
//                                   _selectedTicketTypeId = value;
//                                 });
//                               },
//                       ),
//                     );
//                   }).toList(),

//                 const SizedBox(height: 50),
//               ],
//             ),
//           ),
//         ],
//       ),

//       // Footer
//       bottomSheet: Container(
//         color: Colors.green.shade800,
//         height: 20,
//       ),
//     );
//   }
// }
import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/status_provider.dart';
import 'package:eprijevoz_mobile/providers/ticket_provider.dart';
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

  SearchResult<Station>? stationResult;
  SearchResult<Status>? statusResult;
  SearchResult<Ticket>? ticketResult;

  int? _selectedTicketTypeId;
  int _userStatusId = 1;

  @override
  void initState() {
    stationProvider = context.read<StationProvider>();
    statusProvider = context.read<StatusProvider>();
    ticketProvider = context.read<TicketProvider>();
    initForm();
  }

  Future initForm() async {
    stationResult = await stationProvider.get();
    statusResult = await statusProvider.get();
    ticketResult = await ticketProvider.get();
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
                            _selectedTicketTypeId = value;
                          });
                        },
                      ),
                    );
                  }).toList(),
                //
                // Conditional logic for "Mjesečna karta" based on userStatusId
                if (statusResult != null)
                  ...statusResult!.result.map((status) {
                    bool isMjesecnaKarta =
                        status.name!.contains("Mjesečna karta");
                    bool isDisabled = (_userStatusId == 1 && isMjesecnaKarta);

                    //if ticketId==1 (default) than show that ticket, all other ticket with prefix "${Mjesečna karta} - " needs to be unclickable
                    // if user has userstatus which is not 1, show all tickets that have prefix "${Mjesečna karta} - "
                    // if (statusResult != null)
                    //   ...statusResult!.result.map((status) {
                    //     return ListTile(
                    //       title: Text(
                    //         "Mjesečna karta - ${status.name}",
                    //         style: const TextStyle(fontSize: 16),
                    //       ),
                    //       leading: Radio<int>(
                    //         value: status.statusId!,
                    //         groupValue: _selectedTicketTypeId,
                    //         activeColor: Colors.green,
                    //         onChanged: (int? value) {
                    //           setState(() {
                    //             _selectedTicketTypeId = value;
                    //           });
                    //         },
                    //       ),
                    //     );
                    //   }).toList(),

                    return ListTile(
                      title: Text(
                        "Mjesečna karta - ${status.name}",
                        style: TextStyle(
                          fontSize: 16,
                          color: isDisabled
                              ? Colors.grey
                              : Colors.black, // Grey out if disabled
                        ),
                      ),
                      leading: Radio<int>(
                        value: status.statusId!,
                        groupValue: _selectedTicketTypeId,
                        activeColor: Colors.green,
                        onChanged: isDisabled
                            ? null // Disable selection if userStatusId is 1 and it's "Mjesečna karta"
                            : (int? value) {
                                setState(() {
                                  _selectedTicketTypeId = value;
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
