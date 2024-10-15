import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/request_provider.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/status_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:eprijevoz_desktop/screens/home_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider<VehicleProvider>(create: (_) => VehicleProvider()),
      ChangeNotifierProvider<ManufacturerProvider>(
          create: (_) => ManufacturerProvider()),
      ChangeNotifierProvider<TypeProvider>(create: (_) => TypeProvider()),
      ChangeNotifierProvider<UserProvider>(create: (_) => UserProvider()),
      ChangeNotifierProvider<RouteProvider>(create: (_) => RouteProvider()),
      ChangeNotifierProvider<StationProvider>(create: (_) => StationProvider()),
      ChangeNotifierProvider<RequestProvider>(create: (_) => RequestProvider()),
      ChangeNotifierProvider<StatusProvider>(create: (_) => StatusProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.white, primary: Colors.white),
        useMaterial3: true,
      ),
      home: LoginPage(),
    );
  }
}

class LoginPage extends StatefulWidget {
  LoginPage({super.key});

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  final TextEditingController _usernameController = TextEditingController();

  final TextEditingController _passwordController = TextEditingController();

  bool _passwordVisible = false;

  @override
  void initState() {
    _passwordVisible = false;
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Center(
        child: SingleChildScrollView(
          child: Container(
            constraints: const BoxConstraints(
              maxHeight: 500,
              maxWidth: 500,
            ),
            child: Card(
              color: Colors.black,
              child: Column(
                children: [
                  Padding(
                    padding: const EdgeInsets.only(top: 40, bottom: 25),
                    child: Center(
                      child: SizedBox(
                          width: 200,
                          height: 140,
                          child: Image.asset("assets/images/logo.png",
                              height: 100, width: 100)),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.symmetric(
                        horizontal: 35, vertical: 20),
                    child: TextField(
                        controller: _usernameController,
                        style: const TextStyle(color: Colors.white),
                        decoration: const InputDecoration(
                          border: OutlineInputBorder(),
                          labelText: "Username",
                          labelStyle: TextStyle(color: Colors.white),
                          hintText: "Unesite svoje korisničko ime (username)",
                          hintStyle:
                              TextStyle(color: Colors.white, fontSize: 13),
                          prefixIcon: Icon(Icons.person),
                          prefixIconColor: Colors.white,
                        )),
                  ),
                  Padding(
                    padding:
                        const EdgeInsets.symmetric(horizontal: 35, vertical: 0),
                    child: TextField(
                      controller: _passwordController,
                      style: const TextStyle(color: Colors.white, fontSize: 18),
                      obscureText: !_passwordVisible,
                      decoration: InputDecoration(
                        border: const OutlineInputBorder(),
                        labelText: "Password",
                        labelStyle: const TextStyle(color: Colors.white),
                        hintText: 'Unesite svoj password',
                        hintStyle:
                            const TextStyle(color: Colors.white, fontSize: 13),
                        prefixIcon: const Icon(Icons.password),
                        prefixIconColor: Colors.white,
                        suffixIcon: IconButton(
                          icon: Icon(
                              _passwordVisible
                                  ? Icons.visibility
                                  : Icons.visibility_off,
                              color: Colors.white),
                          onPressed: () {
                            setState(() {
                              _passwordVisible = !_passwordVisible;
                            });
                          },
                        ),
                      ),
                    ),
                  ),
                  const SizedBox(
                    height: 25,
                  ),
                  SizedBox(
                    height: 40,
                    width: 250,
                    child: ElevatedButton(
                      onPressed: () async {
                        UserProvider provider = UserProvider();
                        print(
                            "credentials: ${_usernameController.text} : ${_passwordController.text}");
                        AuthProvider.username = _usernameController.text;
                        AuthProvider.password = _passwordController.text;
                        try {
                          var data = await provider.get();
                          print("Authorized");
                          Navigator.of(context).push(MaterialPageRoute(
                              builder: (context) => (const HomePage())));
                        } on Exception catch (e) {
                          print("Not authorized!");
                          showDialog(
                              context: context,
                              builder: (context) => AlertDialog(
                                    title: const Text("Error"),
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
                                    content: Text(e.toString()),
                                  ));
                        }
                      },
                      style: ElevatedButton.styleFrom(
                        backgroundColor:
                            const Color.fromRGBO(72, 156, 118, 100),
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(2.0),
                        ),
                      ),
                      child: const Text(
                        "Login",
                        style: TextStyle(color: Colors.white, fontSize: 20),
                      ),
                    ),
                  ),
                  const SizedBox(height: 5),
                  TextButton(
                    onPressed: () {},
                    child: const Text(
                      "Forgot Password",
                      style: TextStyle(
                          color: Colors.red,
                          fontSize: 15,
                          fontWeight: FontWeight.normal,
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.red,
                          decorationThickness: 1),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
