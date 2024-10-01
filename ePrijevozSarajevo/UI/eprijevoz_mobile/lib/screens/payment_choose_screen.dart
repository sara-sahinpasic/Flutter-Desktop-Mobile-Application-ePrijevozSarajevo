import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class PaymentChooseScreen extends StatefulWidget {
  final double? selectedTicketPrice;
  final User? user;
  final Ticket? ticket;
  final Status? status;
  const PaymentChooseScreen(
      {this.selectedTicketPrice,
      this.user,
      this.ticket,
      this.status,
      super.key});

  @override
  State<PaymentChooseScreen> createState() => _PaymentChooseScreenState();
}

class _PaymentChooseScreenState extends State<PaymentChooseScreen> {
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
              children: [
                Padding(
                  padding: EdgeInsets.fromLTRB(150.0, 20.0, 0.0, 20.0),
                  child: Icon(
                    Icons.payment,
                    size: 100,
                    color: Colors.black,
                  ),
                ),
              ],
            ),
            //DATABASE Table: IssuedTicket
            /*
              public int IssuedTicketId { get; set; }
              public int UserId { get; set; }
              public User User { get; set; } = null!;
              public int TicketId { get; set; }
              public Ticket Ticket { get; set; } = null!;
              public DateTime ValidFrom { get; set; }
              public DateTime ValidTo { get; set; }
              public DateTime IssuedDate { get; set; }
              [NotMapped]
              public int Amount { get; set; }
              public int RouteId { get; set; }
              public Route Route { get; set; } = null!;
              */

            Container(
              decoration: BoxDecoration(
                  color: Colors.grey.shade300,
                  border: Border(
                      top: BorderSide(color: Colors.black, width: 2),
                      bottom: BorderSide(color: Colors.black, width: 2))),
              width: 500,
              height: 260,
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
                      "Datum važenja: ", //Datum važenja OD-DO
                      style:
                          TextStyle(fontWeight: FontWeight.w500, fontSize: 17),
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
                // Card or summary content goes here, I will leave it blank for now
                // Payment Buttons
                Padding(
                  padding: const EdgeInsets.symmetric(
                      vertical: 10.0, horizontal: 30.0),
                  child: Column(
                    children: [
                      // PayPal Button
                      ElevatedButton(
                        onPressed: () {
                          // Add PayPal payment logic here
                        },
                        style: ElevatedButton.styleFrom(
                          padding: EdgeInsets.symmetric(
                              vertical: 15.0, horizontal: 30.0),
                          backgroundColor: Colors.white,
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
                              'https://upload.wikimedia.org/wikipedia/commons/b/b5/PayPal.svg', // PayPal Logo SVG
                              height: 30,
                            ),
                            SizedBox(width: 10),
                          ],
                        ),
                      ),
                      SizedBox(height: 20),
                      // Stripe Button
                      ElevatedButton(
                        onPressed: () {
                          // Add Stripe payment logic here
                        },
                        style: ElevatedButton.styleFrom(
                          padding: EdgeInsets.symmetric(
                              vertical: 15.0, horizontal: 30.0),
                          backgroundColor: Colors.white,
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
                            SizedBox(width: 10),
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
                onPressed: () {},
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
}
