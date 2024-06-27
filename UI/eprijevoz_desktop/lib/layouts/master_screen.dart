import 'package:eprijevoz_desktop/screens/user_list_screen.dart';
import 'package:eprijevoz_desktop/screens/vehicle_list_screen.dart';
import 'package:flutter/material.dart';

class MasterScreen extends StatefulWidget {
  MasterScreen(this.title, this.child, {super.key});
  String title;
  Widget child;

  @override
  State<MasterScreen> createState() => _MasterScreenState();
}

class _MasterScreenState extends State<MasterScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      /* appBar: PreferredSize(
        preferredSize: Size.fromHeight(150.0),
        child: AppBar(
          automaticallyImplyLeading: false,
          //titleSpacing: 0,
          //backgroundColor: Colors.black,
          /*title: Row(
            children: [
              Text(
                widget.title,
                style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 40,
                    color: Colors.green.shade800),
              ),
            ],
          ),*/
        ),
      ),
*/
      body: Row(
        children: [
          Expanded(
              flex: 3,
              child: Container(
                color: Colors.black,
                child: ListView(
                  children: [
                    const SizedBox(
                      height: 80,
                    ),
                    Icon(Icons.person, color: Colors.green.shade800, size: 50),
                    const SizedBox(
                      height: 20,
                    ),
                    Center(
                      child: Text(
                        "Zdravo, -Username-",
                        style: TextStyle(
                          color: Colors.green.shade800,
                          fontWeight: FontWeight.bold,
                          fontSize: 20,
                        ),
                      ),
                    ),
                    const SizedBox(
                      height: 45,
                    ),
                    ListTile(
                      leading: const Icon(
                        Icons.home,
                        color: Colors.white,
                        size: 30,
                      ),
                      title: const Text("Početna",
                          style: TextStyle(
                              color: Colors.white,
                              fontWeight: FontWeight.w400,
                              fontSize: 25)),
                      onTap: () {
                        Navigator.pop(context);
                        Navigator.pop(context);
                        // Navigator.pushAndRemoveUntil(
                        //   context,
                        //   MaterialPageRoute(builder: (context) => UserListScreen()),
                        //   (Route<dynamic> route) => false,
                        // );
                      },
                    ),
                    const SizedBox(
                      height: 25,
                    ),
                    ListTile(
                      leading: const Icon(
                        Icons.people,
                        color: Colors.white,
                        size: 30,
                      ),
                      title: const Text(
                        "Zaposlenici",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w400,
                            fontSize: 25),
                      ),
                      onTap: () {
                        Navigator.of(context).push(MaterialPageRoute(
                            builder: (context) => const UserListScreen()));
                      },
                    ),
                    const SizedBox(
                      height: 25,
                    ),
                    ListTile(
                      leading: const Icon(
                        Icons.directions_car,
                        color: Colors.white,
                        size: 30,
                      ),
                      title: const Text(
                        "Vozila",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w400,
                            fontSize: 25),
                      ),
                      onTap: () {
                        Navigator.of(context).pushReplacement(MaterialPageRoute(
                            builder: (context) => VehicleListScreen()));
                      },
                    ),
                    const SizedBox(
                      height: 25,
                    ),
                    ListTile(
                      leading: const Icon(
                        Icons.directions,
                        color: Colors.white,
                        size: 30,
                      ),
                      title: const Text(
                        "Plan vožnje",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w400,
                            fontSize: 25),
                      ),
                      onTap: () {
                        Navigator.pop(context);
                      },
                    ),
                    const SizedBox(
                      height: 25,
                    ),
                    ListTile(
                      leading: const Icon(
                        Icons.request_page,
                        color: Colors.white,
                        size: 30,
                      ),
                      title: const Text(
                        "Zahtjevi",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w400,
                            fontSize: 25),
                      ),
                      onTap: () {
                        Navigator.pop(context);
                      },
                    ),
                    const SizedBox(
                      height: 25,
                    ),
                    ListTile(
                      leading: const Icon(
                        Icons.bar_chart,
                        color: Colors.white,
                        size: 30,
                      ),
                      title: const Text(
                        "Statistika",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w400,
                            fontSize: 25),
                      ),
                      onTap: () {
                        Navigator.pop(context);
                      },
                    )
                  ],
                ),
              )),
          Expanded(
              flex: 7,
              child: SizedBox(
                  width: double.infinity,
                  //color: Colors.red,
                  child: Column(
                    children: [
                      Column(
                        children: [
                          Padding(
                            padding: const EdgeInsets.fromLTRB(35, 130, 0, 20),
                            child: Row(
                              children: [
                                Text(
                                  widget.title,
                                  style: TextStyle(
                                      fontWeight: FontWeight.bold,
                                      fontSize: 40,
                                      color: Colors.green.shade800),
                                ),
                              ],
                            ),
                          )
                        ],
                      ),
                      Column(
                        children: [
                          Padding(
                            padding: const EdgeInsets.fromLTRB(35, 10, 35, 0),
                            child: widget.child,
                          )
                        ],
                      ),
                    ],
                  )))
        ],
      ),

      /*Row(
        children: [
          Expanded(
            flex: 3,
            child: Container(
              color: Colors.black,
              width: 300,
              height: double.infinity,
              child: ListView(
                children: [
                  Column(
                    children: [
                      SizedBox(
                        height: 80,
                      ),
                      Icon(Icons.person,
                          color: Colors.green.shade700, size: 50),
                      Text(
                        "Zdravo, -Username-",
                        style: TextStyle(
                            color: Colors.green.shade700,
                            fontWeight: FontWeight.bold,
                            fontSize: 20),
                      )
                    ],
                  ),
                  SizedBox(
                    height: 45,
                  ),
                  ListTile(
                    leading: const Icon(
                      Icons.home,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text("Početna",
                        style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w400,
                            fontSize: 25)),
                    onTap: () {
                      Navigator.pop(context);
                      Navigator.pop(context);
                      // Navigator.pushAndRemoveUntil(
                      //   context,
                      //   MaterialPageRoute(builder: (context) => UserListScreen()),
                      //   (Route<dynamic> route) => false,
                      // );
                    },
                  ),
                  SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: Icon(
                      Icons.people,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Zaposlenici",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => const UserListScreen()));
                    },
                  ),
                  SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: Icon(
                      Icons.directions_car,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Vozila",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) => VehicleListScreen()));
                    },
                  ),
                  SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: Icon(
                      Icons.directions,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Plan vožnje",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.pop(context);
                    },
                  ),
                  SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: Icon(
                      Icons.request_page,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Zahtjevi",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.pop(context);
                    },
                  ),
                  SizedBox(
                    height: 25,
                  ),
                  ListTile(
                    leading: Icon(
                      Icons.bar_chart,
                      color: Colors.white,
                      size: 30,
                    ),
                    title: const Text(
                      "Statistika",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25),
                    ),
                    onTap: () {
                      Navigator.pop(context);
                    },
                  )
                ],
              ),
            ),
          ),
          Expanded(
            flex: 7,
            child: Row(
              children: [
                Text(
                  widget.title,
                  style: TextStyle(
                      fontWeight: FontWeight.bold,
                      fontSize: 40,
                      color: Colors.green.shade800),
                ),
                widget.child
              ],
            ),
          ),
        ],
      ),*/
      ////////////////////////////////////////////////////////////////////////////////////////
      /*        Container(
            color: Colors.black,
            width: 300,
            height: double.infinity,
            child: ListView(
              children: [
                Column(
                  children: [
                    SizedBox(
                      height: 80,
                    ),
                    Icon(Icons.person, color: Colors.green.shade700, size: 50),
                    Text(
                      "Zdravo, -Username-",
                      style: TextStyle(
                          color: Colors.green.shade700,
                          fontWeight: FontWeight.bold,
                          fontSize: 20),
                    )
                  ],
                ),
                SizedBox(
                  height: 45,
                ),
                ListTile(
                  leading: const Icon(
                    Icons.home,
                    color: Colors.white,
                    size: 30,
                  ),
                  title: const Text("Početna",
                      style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.w400,
                          fontSize: 25)),
                  onTap: () {
                    Navigator.pop(context);
                    Navigator.pop(context);
                    // Navigator.pushAndRemoveUntil(
                    //   context,
                    //   MaterialPageRoute(builder: (context) => UserListScreen()),
                    //   (Route<dynamic> route) => false,
                    // );
                  },
                ),
                SizedBox(
                  height: 25,
                ),
                ListTile(
                  leading: Icon(
                    Icons.people,
                    color: Colors.white,
                    size: 30,
                  ),
                  title: const Text(
                    "Zaposlenici",
                    style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.w400,
                        fontSize: 25),
                  ),
                  onTap: () {
                    Navigator.of(context).push(MaterialPageRoute(
                        builder: (context) => const UserListScreen()));
                  },
                ),
                SizedBox(
                  height: 25,
                ),
                ListTile(
                  leading: Icon(
                    Icons.directions_car,
                    color: Colors.white,
                    size: 30,
                  ),
                  title: const Text(
                    "Vozila",
                    style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.w400,
                        fontSize: 25),
                  ),
                  onTap: () {
                    Navigator.of(context).pushReplacement(MaterialPageRoute(
                        builder: (context) => VehicleListScreen()));
                  },
                ),
                SizedBox(
                  height: 25,
                ),
                ListTile(
                  leading: Icon(
                    Icons.directions,
                    color: Colors.white,
                    size: 30,
                  ),
                  title: const Text(
                    "Plan vožnje",
                    style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.w400,
                        fontSize: 25),
                  ),
                  onTap: () {
                    Navigator.pop(context);
                  },
                ),
                SizedBox(
                  height: 25,
                ),
                ListTile(
                  leading: Icon(
                    Icons.request_page,
                    color: Colors.white,
                    size: 30,
                  ),
                  title: const Text(
                    "Zahtjevi",
                    style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.w400,
                        fontSize: 25),
                  ),
                  onTap: () {
                    Navigator.pop(context);
                  },
                ),
                SizedBox(
                  height: 25,
                ),
                ListTile(
                  leading: Icon(
                    Icons.bar_chart,
                    color: Colors.white,
                    size: 30,
                  ),
                  title: const Text(
                    "Statistika",
                    style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.w400,
                        fontSize: 25),
                  ),
                  onTap: () {
                    Navigator.pop(context);
                  },
                )
              ],
            ),
          ),
          
          */
      ////////////////////////////////////////////////////////////////////////////////////////
      /*     SizedBox(
            width: 30,
          ),
   ////////////////////////////////////////////////////////////////////////////////////////       
          SizedBox(
            width: 10,
          ),
   ////////////////////////////////////////////////////////////////////////////////////////       
          */
      //  Expanded(child: widget.child),

      // widget.child,
      ////////////////////////////////////////////////////////////////////////////////////////
      bottomNavigationBar: Stack(
        children: [
          Container(
              height: 40,
              width: double.infinity,
              color: Colors.black,
              child: Center(
                child: Text(
                  "© 2023/2024 RSII::FIT",
                  style: TextStyle(
                      color: Colors.green.shade800,
                      fontWeight: FontWeight.bold),
                ),
              ))
        ],
      ),
    );
  }
}
