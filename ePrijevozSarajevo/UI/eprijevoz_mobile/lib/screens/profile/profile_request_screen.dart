import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:flutter/material.dart';

class RequestScreen extends StatelessWidget {
  const RequestScreen({super.key});

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
                  "Zahtjev",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 40,
                    color: Colors.white,
                  ),
                ),
                IconButton(
                  onPressed: () {
                    Navigator.of(context).push(MaterialPageRoute(
                        builder: (context) =>
                            const MasterScreen(initialIndex: 3)));
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
          Padding(
            padding: const EdgeInsets.fromLTRB(15.0, 135.0, 20.0, 135.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                RichText(
                  textAlign: TextAlign.justify,
                  text: const TextSpan(
                    style: TextStyle(
                      fontSize: 18,
                      fontWeight: FontWeight.w400,
                      color: Colors.black,
                    ),
                    children: [
                      TextSpan(
                        text:
                            '''Poštovani,\n\nza potrebe dokazivanja traženog statusa, molimo Vas da potrebne dokumente dostavite na e-mail adresu sekretarijata preduzeća: ''',
                      ),
                      TextSpan(
                        text: 'eprijevoztest@e-mail.de',
                        style: TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.bold,
                          color: Colors.black,
                        ),
                      ),
                      TextSpan(
                        text:
                            '''\n\nNakon prihvatanja Vašeg zahtjeva Vaš status na Vašem profilu će biti izmijenjen, te ćete moći kupiti kartu sa odgovarajućom povlasticom.''',
                      ),
                    ],
                  ),
                ),
              ],
            ),
          )
        ],
      ),
      bottomSheet: Container(
        color: Colors.green.shade800,
        height: 20,
      ),
    );
  }
}
