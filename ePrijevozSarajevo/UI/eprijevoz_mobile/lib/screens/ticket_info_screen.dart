import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:eprijevoz_mobile/screens/payment_choose_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:provider/provider.dart';
import 'package:input_quantity/input_quantity.dart';

class TicketInfoScreen extends StatefulWidget {
  final double? selectedTicketPrice;
  final User? user;
  final Ticket? ticket;
  final Status? status;

  const TicketInfoScreen(
      {required this.selectedTicketPrice,
      this.user,
      this.ticket,
      this.status,
      super.key});

  @override
  State<TicketInfoScreen> createState() => _TicketInfoScreenState();
}

class _TicketInfoScreenState extends State<TicketInfoScreen> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;

  final TextEditingController _ftsFirstNameController = TextEditingController();
  final TextEditingController _ftsLastNameController = TextEditingController();
  final TextEditingController _ftsDateOfBirthController =
      TextEditingController();

  DateTime? _dateOfBirth;
  int? _countNumberOfTickets = 1;
  double? _finalTicketPrice;
  Ticket? _choosenTicket;
  Status? _userTicketStatus;
  User? _currentUser;

  @override
  void initState() {
    super.initState();

    userProvider = context.read<UserProvider>();

    _ftsFirstNameController.text = widget.user?.firstName ?? '';
    _ftsLastNameController.text = widget.user?.lastName ?? '';

    if (widget.user?.dateOfBirth != null) {
      _ftsDateOfBirthController.text = formatDate(widget.user!.dateOfBirth!);
      _dateOfBirth = widget.user?.dateOfBirth;
    }

    _choosenTicket = widget?.ticket;
    _userTicketStatus = widget?.status;
    _currentUser = widget?.user;
    initForm();
  }

  Future initForm() async {
    userResult = await userProvider.get();
  }

  Future<void> _selectDate(BuildContext context) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: _dateOfBirth ?? DateTime.now(),
      firstDate: DateTime(1900),
      lastDate: DateTime(2100),
    );

    if (picked != null && picked != _dateOfBirth) {
      setState(() {
        _dateOfBirth = picked;
        _ftsDateOfBirthController.text = formatDate(picked);
      });
    }
  }

  double? finalTicketPrice(int? countNumberOfTickets) {
    _finalTicketPrice = (widget.selectedTicketPrice! * countNumberOfTickets!);

    return _finalTicketPrice;
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Column(
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
            const Row(
              children: [
                Padding(
                  padding: EdgeInsets.fromLTRB(150.0, 40.0, 0.0, 20.0),
                  child: Icon(
                    Icons.person,
                    size: 100,
                  ),
                ),
              ],
            ),
            Padding(
              padding: const EdgeInsets.fromLTRB(15.0, 15.0, 15.0, 10.0),
              child: Row(
                children: [
                  Expanded(
                      child: FormBuilderTextField(
                    name: 'firstName',
                    controller: _ftsFirstNameController,
                    cursorColor: Colors.green.shade800,
                    decoration: const InputDecoration(
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(color: Colors.black),
                      ),
                    ),
                  )),
                ],
              ),
            ),
            const SizedBox(height: 10),
            Padding(
              padding: const EdgeInsets.fromLTRB(15.0, 0.0, 15.0, 10.0),
              child: Row(
                children: [
                  Expanded(
                      child: FormBuilderTextField(
                    name: 'lastName',
                    controller: _ftsLastNameController,
                    cursorColor: Colors.green.shade800,
                    decoration: const InputDecoration(
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(color: Colors.black),
                      ),
                    ),
                  )),
                ],
              ),
            ),
            const SizedBox(height: 10),
            Padding(
              padding: const EdgeInsets.fromLTRB(15.0, 0.0, 15.0, 10.0),
              child: Row(
                children: [
                  Expanded(
                      child: FormBuilderTextField(
                    name: 'dateOfBirth',
                    controller: _ftsDateOfBirthController,
                    cursorColor: Colors.green.shade800,
                    readOnly: true, // Make it readonly, since it's a date
                    decoration: const InputDecoration(
                      enabledBorder: OutlineInputBorder(
                        borderSide: BorderSide(color: Colors.black),
                      ),
                    ),
                    onTap: () => _selectDate(context),
                  )),
                ],
              ),
            ),
            //Text("Karta: ${widget.ticket?.name}"),
            //Text("StatusnaKarta: ${widget.status?.name}"),
            const SizedBox(height: 10),
            Row(
              children: [
                const SizedBox(width: 16),
                InputQty(
                  maxVal: 10,
                  initVal: 1,
                  minVal: 0,
                  steps: 1,
                  onQtyChanged: (val) {
                    _countNumberOfTickets = val.round();
                    setState(() {
                      finalTicketPrice(_countNumberOfTickets);
                    });
                  },
                ),
                const SizedBox(width: 210),
                Text(
                  formatPrice(finalTicketPrice(_countNumberOfTickets)!),
                  style: const TextStyle(
                      fontSize: 19, fontWeight: FontWeight.bold),
                ),
              ],
            ),
            const SizedBox(height: 40),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () async {
                  Navigator.of(context).push(MaterialPageRoute(
                      builder: (context) => PaymentChooseScreen(
                            ticket: _choosenTicket,
                            status: _userTicketStatus,
                            selectedTicketPrice: _finalTicketPrice,
                            user: _currentUser,
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
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
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
