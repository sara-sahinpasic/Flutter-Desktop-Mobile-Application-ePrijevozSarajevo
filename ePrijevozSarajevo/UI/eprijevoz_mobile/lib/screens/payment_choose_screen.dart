import 'package:eprijevoz_mobile/models/status.dart';
import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/utils.dart';
import 'package:flutter/material.dart';

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
                  padding: EdgeInsets.fromLTRB(150.0, 40.0, 0.0, 20.0),
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
            /*
              if(widget.status?!=null)
                //show widget.status?
              else
                //show widget.ticket?                
            */
            Text("Karta: ${widget.ticket?.name} karta "),
            Text("StatusnaKarta: ${widget.status?.name} karta "), //toDo
            Text("cijena: ${widget.selectedTicketPrice} "),
            Text(
                "korisnik: ${widget.user?.firstName}-${widget?.user?.lastName} "),
            Text("korisnik: ${widget.user?.userId} "),
            Text("korisnik: ${formatDate(widget?.user?.dateOfBirth)} "),
            //Datum važenja OD-DO

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
