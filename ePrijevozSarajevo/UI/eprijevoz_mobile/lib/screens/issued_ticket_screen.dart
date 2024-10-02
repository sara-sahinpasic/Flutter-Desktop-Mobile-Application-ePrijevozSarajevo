import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class IssuedTicketScreen extends StatefulWidget {
  final User? user;
  final Ticket? ticket;
  final Status? status;
  final DateTime? validFrom;
  final DateTime? validTo;

  const IssuedTicketScreen(
      {this.user,
      this.ticket,
      this.status,
      this.validFrom,
      this.validTo,
      super.key});

  @override
  State<IssuedTicketScreen> createState() => _IssuedTicketScreenState();
}

class _IssuedTicketScreenState extends State<IssuedTicketScreen> {
  late IssuedTicketProvider issuedTicketProvider;

  @override
  void initState() {
    super.initState();
    issuedTicketProvider = context.read<IssuedTicketProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(children: [
          Container(
            padding: const EdgeInsets.fromLTRB(50.0, 35.0, 30.0, 20.0),
            color: Colors.green.shade800,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Text(
                  "Moje karte",
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
          // const Row(
          //   mainAxisAlignment: MainAxisAlignment.center,
          //   children: [
          //     Icon(
          //       Icons.payment,
          //       size: 100,
          //       color: Colors.black,
          //     ),
          //     //),
          //   ],
          // ),
          Container(
            decoration: BoxDecoration(
                color: Colors.grey.shade300,
                border: Border(
                    top: BorderSide(color: Colors.black, width: 2),
                    bottom: BorderSide(color: Colors.black, width: 2))),
            child: Padding(
              padding: EdgeInsets.fromLTRB(30.0, 30.0, 30.0, 30.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  (widget.ticket?.name != null)
                      ? Text(
                          "${widget.ticket?.name} karta",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 21),
                        )
                      : Text(
                          "Mjesečna karta - ${widget.status?.name}",
                          style: TextStyle(
                              fontWeight: FontWeight.bold, fontSize: 21),
                        ),
                  SizedBox(
                    height: 15,
                  ),
                  //
                  Text(
                    "Korisnik: ${widget.user?.firstName} ${widget?.user?.lastName} ",
                    style: TextStyle(fontWeight: FontWeight.w500, fontSize: 17),
                  ),
                  Text(
                    "Datum rođenja: ${formatDate(widget?.user?.dateOfBirth)} ",
                    style: TextStyle(fontWeight: FontWeight.w500, fontSize: 17),
                  ),
                  Text(
                    "Broj korisnika: 2024${widget.user?.userId} ",
                    style: TextStyle(fontWeight: FontWeight.w500, fontSize: 17),
                  ),

                  SizedBox(
                    height: 30.0,
                    child: Center(
                      child: Container(
                        margin:
                            EdgeInsetsDirectional.only(start: 1.0, end: 1.0),
                        height: 2.0,
                        color: Colors.black,
                      ),
                    ),
                  ),

                  Text(
                    "Važenje karte:\n${widget.validFrom}-${widget.validTo}",
                    style: const TextStyle(
                      fontSize: 18,
                      fontWeight: FontWeight.w500,
                    ),
                  ),
                ],
              ),
            ),
          ),
        ]),
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
