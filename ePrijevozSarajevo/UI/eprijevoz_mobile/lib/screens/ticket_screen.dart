import 'package:eprijevoz_mobile/models/issuedTicket.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';

//IZLISTATI ISSUED TICKET IZ BAZE ZA TRENUTNO LOGIRANOG KORISNIKA
class TicketScreen extends StatefulWidget {
  final User? user;
  final Ticket? ticket;
  final Status? status;
  final DateTime? validFrom;
  final DateTime? validTo;
  const TicketScreen(
      {this.user,
      this.ticket,
      this.status,
      this.validFrom,
      this.validTo,
      super.key});

  @override
  State<TicketScreen> createState() => _TicketScreenState();
}

class _TicketScreenState extends State<TicketScreen> {
  // Form
  final _formKey = GlobalKey<FormBuilderState>();
  Map<String, dynamic> _initialValue = {};

  late UserProvider userProvider;
  late IssuedTicketProvider issuedTicketProvider;
  SearchResult<User>? userResult;
  SearchResult<IssuedTicket>? issuedTicketResult;
  int? userId;

  @override
  void initState() {
    super.initState();
    userProvider = context.read<UserProvider>();
    issuedTicketProvider = context.read<IssuedTicketProvider>();
    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
    issuedTicketResult = await issuedTicketProvider.get();

    var user = userResult?.result
        .firstWhere((user) => user.userName == AuthProvider.username);

    userId = user?.userId;

    print("User ima id: ${userId}");
  }

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
        child: Padding(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.center,
        children: [
          _buildResultView(),
          const SizedBox(height: 15),
        ],
      ),
    ));
  }

  Widget _buildResultView() {
    return FormBuilder(
      key: _formKey,
      initialValue: _initialValue,
      child: Padding(
        padding: const EdgeInsets.fromLTRB(30.0, 0.0, 0.0, 0.0),
        child: Column(children: [
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
    );
  }
}
