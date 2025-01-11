import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/issuedTicket.dart';
import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/station.dart';
import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:provider/provider.dart';
import 'package:flutter_paypal_payment/flutter_paypal_payment.dart';

class PaymentChooseScreen extends StatefulWidget {
  final double? selectedTicketPrice;
  final User? user;
  final Ticket? ticket;
  final Status? status;
  final DateTime? validFrom;
  final DateTime? validTo;
  final int? amount;
  final Route? route;

  const PaymentChooseScreen(
      {this.selectedTicketPrice,
      this.user,
      this.ticket,
      this.status,
      this.validFrom,
      this.validTo,
      this.amount,
      this.route,
      super.key});

  @override
  State<PaymentChooseScreen> createState() => _PaymentChooseScreenState();
}

enum PaymentMethods { paypal, stripe }

class _PaymentChooseScreenState extends State<PaymentChooseScreen> {
  late IssuedTicketProvider issuedTicketProvider;
  SearchResult<IssuedTicket>? issuedTicketResult;
  DateTime? validFrom;
  DateTime? validTo;
  User? currentUser;
  Ticket? choosenTicket;
  DateTime? issuedDate;
  PaymentMethods? _selectedPaymentMethod;
  bool? _isPayPalSelected = false;
  bool? _isStripeSelected = false;
  double? selectedTicketPrice;
  int? amount;
  Route? currentRoute;
  bool isLoading = true;
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  String? startStationName;
  String? endStationName;
  String paypalClientId = String.fromEnvironment("PAYPAL_CLIENT_ID",
      defaultValue: dotenv.get("PAYPAL_CLIENT_ID"));
  String paypalSecretKey = String.fromEnvironment("PAYPAL_SECRET_KEY",
      defaultValue: dotenv.get("PAYPAL_SECRET_KEY"));

  @override
  void initState() {
    super.initState();
    issuedTicketProvider = context.read<IssuedTicketProvider>();
    routeProvider = context.read<RouteProvider>();
    stationProvider = context.read<StationProvider>();

    super.initState();

    currentUser = widget.user;
    choosenTicket = widget.ticket;
    issuedDate = DateTime.now();
    amount = widget.amount;
    selectedTicketPrice = widget.selectedTicketPrice;
    currentRoute = widget.route;

    initForm();
  }

  Future initForm() async {
    routeResult = await routeProvider.get();
    stationResult = await stationProvider.get();

    startStationName = stationResult!.result
        .firstWhere(
          (start) => start.stationId == widget.route?.startStationId,
        )
        .name;

    endStationName = stationResult!.result
        .firstWhere(
          (end) => end.stationId == widget.route?.endStationId,
        )
        .name;

    setState(() {
      isLoading = false;
    });
  }

  String? validFromTo() {
    if (widget.ticket?.name != null &&
            widget.ticket!.name!.contains("Mjesečna") ||
        widget.status?.name != null) {
      validFrom = DateTime.now();
      validTo = validFrom?.add(const Duration(days: 31));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Jednosmjerna")) {
      validFrom = DateTime.now();
      validTo = validFrom?.add(const Duration(minutes: 60));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Povratna")) {
      validFrom = DateTime.now();
      validTo = validFrom?.add(const Duration(minutes: 180));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Jednosmjerna dječija")) {
      validFrom = DateTime.now();
      validTo = validFrom?.add(const Duration(minutes: 60));
    } else if (widget.ticket?.name != null &&
        widget.ticket!.name!.contains("Povratna dječija")) {
      validFrom = DateTime.now();
      validTo = validFrom?.add(const Duration(minutes: 180));
    }

    return "${formatDateTime(validFrom!)}\n${formatDateTime(validTo!)}";
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: isLoading
            ? const Center(
                child: CircularProgressIndicator(),
              )
            : Column(
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
                    ],
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Container(
                    decoration: BoxDecoration(
                        color: Colors.grey.shade300,
                        border: const Border(
                            top: BorderSide(color: Colors.black, width: 2),
                            bottom: BorderSide(color: Colors.black, width: 2))),
                    child: Padding(
                      padding:
                          const EdgeInsets.fromLTRB(30.0, 30.0, 30.0, 30.0),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          if (widget.ticket?.name != null)
                            Text(
                              "${widget.ticket?.name} karta ($amount)",
                              style: const TextStyle(
                                  fontWeight: FontWeight.bold, fontSize: 20),
                            ),
                          const SizedBox(
                            height: 10,
                          ),
                          Row(
                            children: [
                              Text(
                                '$startStationName - $endStationName',
                                style: const TextStyle(
                                    fontWeight: FontWeight.bold, fontSize: 18),
                              ),
                            ],
                          ),
                          SizedBox(
                            height: 20.0,
                            child: Center(
                              child: Container(
                                margin: const EdgeInsetsDirectional.only(
                                    start: 1.0, end: 1.0),
                                height: 2.0,
                                color: Colors.black,
                              ),
                            ),
                          ),
                          Text(
                            "Važenje karte:\n${validFromTo()}",
                            style: const TextStyle(
                              fontSize: 17,
                              fontWeight: FontWeight.w500,
                            ),
                          ),
                          Align(
                            alignment: Alignment.centerRight,
                            child: Text(
                              "Cijena: ${formatPrice(widget.selectedTicketPrice!)} ",
                              style: const TextStyle(
                                  fontWeight: FontWeight.bold, fontSize: 17),
                            ),
                          ),
                        ],
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 10,
                  ),
                  Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    crossAxisAlignment: CrossAxisAlignment.center,
                    children: [
                      // payment Buttons
                      Padding(
                        padding: const EdgeInsets.symmetric(
                            vertical: 10.0, horizontal: 30.0),
                        child: Column(
                          children: [
                            // PayPal Button
                            ElevatedButton(
                              onPressed: () async {
                                setState(() {
                                  _selectedPaymentMethod =
                                      PaymentMethods.paypal;
                                  _isPayPalSelected = true;
                                });
                                ScaffoldMessenger.of(context).showSnackBar(
                                  const SnackBar(
                                      content: Text(
                                          "Odabrani način plaćanja: PayPal!")),
                                );
                              },
                              style: ElevatedButton.styleFrom(
                                padding: const EdgeInsets.symmetric(
                                    vertical: 15.0, horizontal: 30.0),
                                backgroundColor: _isPayPalSelected!
                                    ? Colors.yellow
                                    : Colors.white,
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(10.0),
                                ),
                                side: BorderSide(
                                  color: _isPayPalSelected!
                                      ? Colors.orange
                                      : Colors.grey.shade300,
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
                                  const SizedBox(width: 10),
                                ],
                              ),
                            ),
                            const SizedBox(height: 20),
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
                                      ScaffoldMessenger.of(context)
                                          .showSnackBar(
                                        const SnackBar(
                                            content: Text(
                                                "Odabrani način plaćanja: Stripe, još uvijek nije podržan!")),
                                      );
                                    },
                              style: ElevatedButton.styleFrom(
                                padding: const EdgeInsets.symmetric(
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
                                    'https://www.vectorlogo.zone/logos/stripe/stripe-ar21.svg',
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
                  const SizedBox(
                    height: 10,
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
                                    title: const Text("Error"),
                                    content: const Text(
                                        "Molimo prvo odaberite validan nacin plaćanja!"),
                                    titleTextStyle: const TextStyle(
                                        color: Colors.red,
                                        fontWeight: FontWeight.bold,
                                        fontSize: 24),
                                    actions: [
                                      TextButton(
                                          onPressed: () =>
                                              (Navigator.pop(context)),
                                          child: const Text(
                                            "OK",
                                            style:
                                                TextStyle(color: Colors.black),
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
                        style: TextStyle(
                            fontWeight: FontWeight.bold, fontSize: 22),
                      ),
                    ),
                  ),
                  const SizedBox(height: 25),
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
        clientId: paypalClientId,
        secretKey: paypalSecretKey,
        transactions: [
          {
            "amount": {
              "total": selectedTicketPrice?.toStringAsFixed(2),
              "currency": "EUR",
              "details": {
                "subtotal": selectedTicketPrice?.toStringAsFixed(2),
                "shipping": '0',
                "shipping_discount": 0
              }
            },
            "description": "Kupovina karte za prijevoz.",
            "item_list": {
              "items": [
                {
                  "name": "${choosenTicket?.name} - ${amount}X",
                  "quantity": amount?.toString() ?? '1',
                  "price": (selectedTicketPrice! / amount!).toStringAsFixed(2),
                  "currency": "EUR",
                },
              ],
            }
          }
        ],
        note:
            "Za bilo kakva pitanja vezana uz Vašu kupovinu, kontaktirajte nas.",
        onSuccess: (Map params) async {
          debugPrint('Paypal reponse: $params');
          await addIssuedTicketToDatabase();

          await showDialog(
              context: context,
              builder: (context) => AlertDialog(
                    title: const Text("Success"),
                    content: const Text("Karta je uspješno kupljena!"),
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

          await Navigator.of(context).pushReplacement(MaterialPageRoute(
              builder: (context) => MasterScreen(
                    amount: amount,
                    initialIndex: 2,
                  )));
        },
        onError: (error) {
          debugPrint("onError: $error");
          Navigator.pop(context);
        },
        onCancel: () {
          debugPrint('cancelled:');
          Navigator.pop(context);
        },
      ),
    ));
  }

  Future addIssuedTicketToDatabase() async {
    if (currentUser != null &&
        choosenTicket != null &&
        issuedDate != null &&
        validFrom != null &&
        validTo != null) {
      IssuedTicket newTicket = IssuedTicket(
          userId: currentUser?.userId!,
          ticketId: choosenTicket?.ticketId!,
          validFrom: validFrom!,
          validTo: validTo!,
          issuedDate: issuedDate!,
          amount: amount!,
          routeId: currentRoute?.routeId!);

      Map<String, dynamic> newRequest = newTicket.toJson();

      await issuedTicketProvider.insert(newRequest);
    }
  }
}
