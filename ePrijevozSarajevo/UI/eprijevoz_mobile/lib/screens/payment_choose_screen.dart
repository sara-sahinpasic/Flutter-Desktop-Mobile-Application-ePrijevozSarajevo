import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/issuedTicket.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_svg/flutter_svg.dart';
import 'package:provider/provider.dart';
import 'package:flutter_paypal_payment/flutter_paypal_payment.dart';
import 'package:quickalert/quickalert.dart';

class PaymentChooseScreen extends StatefulWidget {
  final double? selectedTicketPrice;
  final User? user;
  final Ticket? ticket;
  final Status? status;
  //
  final DateTime? validFrom;
  final DateTime? validTo;
  int? countNumberOfTickets;

  PaymentChooseScreen(
      {this.selectedTicketPrice,
      this.user,
      this.ticket,
      this.status,
      this.validFrom,
      this.validTo,
      this.countNumberOfTickets,
      super.key});

  @override
  State<PaymentChooseScreen> createState() => _PaymentChooseScreenState();
}

enum PaymentMethods { paypal, stripe }

class _PaymentChooseScreenState extends State<PaymentChooseScreen> {
  late IssuedTicketProvider issuedTicketProvider;
  SearchResult<IssuedTicket>? issuedTicketResult;
  DateTime? _validFrom;
  DateTime? _validTo;
  User? _currentUser;
  Ticket? _choosenTicket;
  DateTime? _issuedDate;
  PaymentMethods? _selectedPaymentMethod;
  bool? _isPayPalSelected = false;
  bool? _isStripeSelected = false;
  int? _countNumberOfTickets;
  double? _selectedTicketPrice;

  @override
  void initState() {
    super.initState();
    issuedTicketProvider = context.read<IssuedTicketProvider>();

    _currentUser = widget?.user; //?.userId;
    _choosenTicket = widget?.ticket; //?.ticketId;
    _issuedDate = DateTime.now();
    _countNumberOfTickets = widget?.countNumberOfTickets;
    _selectedTicketPrice = widget?.selectedTicketPrice;
    print("Br karti: ${_countNumberOfTickets}");
    print("Karta: ${_choosenTicket?.name}");
    print("Cijena: ${_selectedTicketPrice}");

    //initForm();
  }

  // Future initForm() async {
  //   issuedTicketResult = await issuedTicketProvider.get();

  //   setState(() {});
  // }

  String? ValidFromTo() {
    String? finalDate;

    if (widget.ticket?.name != null &&
            widget.ticket!.name!.contains("Mjesečna") ||
        widget.status?.name != null) {
      _validFrom = DateTime.now();
      _validTo = _validFrom?.add(const Duration(days: 31));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Jednosmjerna")) {
      _validFrom = DateTime.now();
      _validTo = _validFrom?.add(const Duration(minutes: 60));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Povratna")) {
      _validFrom = DateTime.now();
      _validTo = _validFrom?.add(const Duration(minutes: 180));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Jednosmjerna dječija")) {
      _validFrom = DateTime.now();
      _validTo = _validFrom?.add(const Duration(minutes: 60));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Povratna dječija")) {
      _validFrom = DateTime.now();
      _validTo = _validFrom?.add(const Duration(minutes: 180));
    }

    return finalDate =
        "${formatDateTime(_validFrom!)}\n${formatDateTime(_validTo!)}";
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
                    "Plaćanje",
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
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Icon(
                  Icons.payment,
                  size: 100,
                  color: Colors.black,
                ),
                //),
              ],
            ),
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
                      style:
                          TextStyle(fontWeight: FontWeight.w500, fontSize: 17),
                    ),
                    Text(
                      "Datum rođenja: ${formatDate(widget?.user?.dateOfBirth)} ",
                      style:
                          TextStyle(fontWeight: FontWeight.w500, fontSize: 17),
                    ),
                    Text(
                      "Broj korisnika: 2024${widget.user?.userId} ",
                      style:
                          TextStyle(fontWeight: FontWeight.w500, fontSize: 17),
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
                      "Važenje karte:\n${ValidFromTo()}",
                      style: const TextStyle(
                        fontSize: 18,
                        fontWeight: FontWeight.w500,
                      ),
                    ),
                    Align(
                      alignment: Alignment.centerRight,
                      child: Text(
                        "Cijena: ${formatPrice(widget.selectedTicketPrice!)} ",
                        style: TextStyle(
                            fontWeight: FontWeight.w500, fontSize: 17),
                      ),
                    ),
                  ],
                ),
              ),
            ),
            SizedBox(
              height: 20,
            ),
            Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                // Payment Buttons
                Padding(
                  padding: const EdgeInsets.symmetric(
                      vertical: 10.0, horizontal: 30.0),
                  child: Column(
                    children: [
                      // PayPal Button
                      ElevatedButton(
                        onPressed: () async {
                          setState(() {
                            _selectedPaymentMethod = PaymentMethods.paypal;
                            _isPayPalSelected = true;
                          });
                          ScaffoldMessenger.of(context).showSnackBar(
                            SnackBar(
                                content:
                                    Text("Odabrani način plaćanja: PayPal!")),
                          );
                        },
                        style: ElevatedButton.styleFrom(
                          padding: EdgeInsets.symmetric(
                              vertical: 15.0, horizontal: 30.0),
                          backgroundColor:
                              _isPayPalSelected! ? Colors.yellow : Colors.white,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                          side: BorderSide(
                            color: _isPayPalSelected!
                                ? Colors.orange
                                : Colors.grey
                                    .shade300, // Change border color when selected
                          ),
                          elevation: 5,
                        ),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            SvgPicture.network(
                              'https://upload.wikimedia.org/wikipedia/commons/b/b5/PayPal.svg',
                              height: 30,
                            ),
                            SizedBox(width: 10),
                          ],
                        ),
                      ),
                      SizedBox(height: 20),
                      // Stripe Button
                      ElevatedButton(
                        onPressed: _isStripeSelected!
                            ? null
                            : () async {
                                setState(() {
                                  _selectedPaymentMethod =
                                      PaymentMethods.stripe;
                                  _isStripeSelected = true;
                                });
                                ScaffoldMessenger.of(context).showSnackBar(
                                  SnackBar(
                                      content: Text(
                                          "Odabrani način plaćanja: Stripe, još uvijek nije podržan!")),
                                );
                              },
                        style: ElevatedButton.styleFrom(
                          padding: EdgeInsets.symmetric(
                              vertical: 15.0, horizontal: 30.0),
                          backgroundColor: _isStripeSelected!
                              ? Colors.grey.shade300
                              : Colors.white,
                          shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(10.0),
                          ),
                          side: BorderSide(color: Colors.grey.shade300),
                          elevation: 5,
                        ),
                        child: Row(
                          mainAxisAlignment: MainAxisAlignment.center,
                          children: [
                            SvgPicture.network(
                              'https://www.vectorlogo.zone/logos/stripe/stripe-ar21.svg', // Stripe Logo SVG
                              height: 30,
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
            SizedBox(
              height: 20,
            ),
            SizedBox(
              width: double.infinity,
              child: ElevatedButton(
                onPressed: () {
                  if (_selectedPaymentMethod == PaymentMethods.paypal) {
                    processPayment();
                  } else {
                    showDialog(
                        context: context,
                        builder: (context) => AlertDialog(
                              title: Text("Error"),
                              content: Text(
                                  "Molimo prvo odaberite validan nacin placanja!"),
                              titleTextStyle: const TextStyle(
                                  color: Colors.red,
                                  fontWeight: FontWeight.bold,
                                  fontSize: 24),
                              actions: [
                                TextButton(
                                    onPressed: () => (Navigator.pop(context)),
                                    child: const Text(
                                      "OK",
                                      style: TextStyle(color: Colors.black),
                                    ))
                              ],
                            ));
                  }
                },
                style: ElevatedButton.styleFrom(
                  backgroundColor: Colors.black,
                  shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(10.0),
                  ),
                  padding: const EdgeInsets.symmetric(vertical: 10.0),
                ),
                child: const Text(
                  "Plati",
                  style: TextStyle(fontWeight: FontWeight.bold, fontSize: 22),
                ),
              ),
            ),
            const SizedBox(height: 50),
          ],
        ),
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }

  void processPayment() {
    Navigator.of(context).push(MaterialPageRoute(
      builder: (BuildContext context) => PaypalCheckoutView(
        sandboxMode: true,
        clientId:
            "AYTBslLKVvc0yWmL_p7xuYFsbHzUW0vwDNvY4mxFnsZb8YDe7BCM5TJul8X-y02HhmmMtp5pKKIgSFEf",
        secretKey:
            "EGQDCKtMnPdbK5EvQwwPDo280-2_Na_UMe5YT4MU1B6LXW45atXupuoP_Cr-G6iSyXGE07XeOr5Ua6dJ",
        transactions: /*const*/ [
          {
            "amount": {
              "total": _selectedTicketPrice?.toStringAsFixed(2),
              "currency": "EUR",
              "details": {
                "subtotal": _selectedTicketPrice?.toStringAsFixed(2),
                "shipping": '0',
                "shipping_discount": 0
              }
            },
            "description": "Kupovina karte za prijevoz.",
            "item_list": {
              "items": [
                {
                  "name": _choosenTicket?.name ?? "",
                  "quantity": _countNumberOfTickets?.toString() ?? '1',
                  "price": (_selectedTicketPrice! / _countNumberOfTickets!)
                      .toStringAsFixed(2),
                  "currency": "EUR",
                },
              ],
            }
          }
        ],
        note:
            "Za bilo kakva pitanja vezana uz Vašu kupovinu, kontaktirajte nas.",
        onSuccess: (Map params) async {
          print("onSuccess: $params");

          addIssuedTicketToDatabase();

          Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => MasterScreen(
                    initialIndex: 2,
                  )));

          showDialog(
              context: context,
              builder: (context) => AlertDialog(
                    title: Text("Success"),
                    content: Text("Karta je uspješno kupljena!"),
                    titleTextStyle: const TextStyle(
                        color: Colors.green,
                        fontWeight: FontWeight.bold,
                        fontSize: 24),
                    actions: [
                      TextButton(
                          onPressed: () => (Navigator.pop(context)),
                          child: const Text(
                            "OK",
                            style: TextStyle(color: Colors.black),
                          ))
                    ],
                  ));
        },
        onError: (error) {
          print("onError: $error");
          Navigator.pop(context);
        },
        onCancel: () {
          print('cancelled:');
          Navigator.pop(context);
        },
      ),
    ));
  }

  void addIssuedTicketToDatabase() {
    if (_currentUser != null &&
        _choosenTicket != null &&
        _issuedDate != null &&
        _validFrom != null &&
        _validTo != null) {
      // Creates an IssuedTicket object
      IssuedTicket newTicket = IssuedTicket(
        userId: _currentUser?.userId!,
        ticketId: _choosenTicket?.ticketId!,
        validFrom: _validFrom!,
        validTo: _validTo!,
        issuedDate: _issuedDate!,
      );

      // Serialize to JSON
      Map<String, dynamic> newRequest = newTicket.toJson();

      // Send the request to the server
      print("New request ticket: $newRequest");
      issuedTicketProvider.insert(newRequest);
    }
  }
}
