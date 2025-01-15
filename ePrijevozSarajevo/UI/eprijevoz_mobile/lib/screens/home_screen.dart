import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/models/search_result.dart';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});
  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  late UserProvider userProvider;
  SearchResult<User>? userResult;
  User? currentUser;
  bool isLoading = false;

  @override
  void initState() {
    userProvider = context.read<UserProvider>();
    super.initState();
    initForm();
  }

  Future initForm() async {
    setState(() {
      isLoading = true;
    });

    try {
      userResult = await userProvider.get();
      currentUser = userResult?.result
          .firstWhere((user) => user.userName == AuthProvider.username);
    } catch (e) {
      debugPrint("Error loading user data: $e");
    } finally {
      setState(() {
        isLoading = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: LayoutBuilder(
        builder: (context, constraints) {
          constraints.maxWidth;
          return Padding(
            padding: const EdgeInsets.fromLTRB(15.0, 70.0, 15.0, 0.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Padding(
                  padding: const EdgeInsets.fromLTRB(110.0, 0.0, 0.0, 0.0),
                  child: Row(
                    children: [
                      Icon(
                        Icons.tram,
                        size: 80,
                        color: Colors.green.shade800,
                      ),
                      Icon(
                        Icons.bus_alert,
                        size: 80,
                        color: Colors.green.shade800,
                      ),
                    ],
                  ),
                ),
                const SizedBox(
                  height: 40,
                ),
                Center(
                  child: Text(
                    "ePrijevozSarajevo\nDobrodošli, ${currentUser?.firstName ?? ''}!",
                    textAlign: TextAlign.center,
                    style: TextStyle(
                      fontSize: 40,
                      fontWeight: FontWeight.bold,
                      color: Colors.green.shade700,
                    ),
                    maxLines: 2,
                    overflow: TextOverflow.ellipsis,
                  ),
                ),
                const SizedBox(
                  height: 55,
                ),
                Text(
                  "ZAJEDNO ZAŠTITIMO NAŠU PLANETU ZEMLJU!",
                  textAlign: TextAlign.center,
                  style: TextStyle(
                    fontSize: 20,
                    color: Colors.green.shade800,
                  ),
                ),
                const SizedBox(height: 30),
                SizedBox(
                  width: double.infinity,
                  child: ElevatedButton(
                    onPressed: () {
                      Navigator.of(context).push(
                        MaterialPageRoute(
                          builder: (context) => const MasterScreen(
                            initialIndex: 1,
                          ),
                        ),
                      );
                    },
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Colors.black,
                      shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(10.0),
                      ),
                      padding: const EdgeInsets.symmetric(vertical: 10.0),
                    ),
                    child: const Text(
                      "Krenimo odmah!",
                      style:
                          TextStyle(fontWeight: FontWeight.bold, fontSize: 23),
                    ),
                  ),
                ),
              ],
            ),
          );
        },
      ),
    );
  }
}
