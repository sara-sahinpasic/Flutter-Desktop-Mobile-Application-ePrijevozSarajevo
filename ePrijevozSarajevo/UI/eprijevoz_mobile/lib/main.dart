import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';
import 'package:eprijevoz_mobile/providers/country_provider.dart';
import 'package:eprijevoz_mobile/providers/delay_provider.dart';
import 'package:eprijevoz_mobile/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_mobile/providers/recommendation_provider.dart';
import 'package:eprijevoz_mobile/providers/request_provider.dart';
import 'package:eprijevoz_mobile/providers/role_provider.dart';
import 'package:eprijevoz_mobile/providers/route_provider.dart';
import 'package:eprijevoz_mobile/providers/station_provider.dart';
import 'package:eprijevoz_mobile/providers/status_provider.dart';
import 'package:eprijevoz_mobile/providers/ticket_provider.dart';
import 'package:eprijevoz_mobile/providers/type_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:eprijevoz_mobile/providers/user_role_provider.dart';
import 'package:eprijevoz_mobile/screens/profile/profile_newUser_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';

void main() async {
  await dotenv.load(fileName: ".env");

  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider<UserProvider>(create: (_) => UserProvider()),
      ChangeNotifierProvider<RouteProvider>(create: (_) => RouteProvider()),
      ChangeNotifierProvider<StationProvider>(create: (_) => StationProvider()),
      ChangeNotifierProvider<StatusProvider>(create: (_) => StatusProvider()),
      ChangeNotifierProvider<RequestProvider>(create: (_) => RequestProvider()),
      ChangeNotifierProvider<TicketProvider>(create: (_) => TicketProvider()),
      ChangeNotifierProvider<IssuedTicketProvider>(
          create: (_) => IssuedTicketProvider()),
      ChangeNotifierProvider<CountryProvider>(create: (_) => CountryProvider()),
      ChangeNotifierProvider<RecommendationProvider>(
          create: (_) => RecommendationProvider()),
      ChangeNotifierProvider<RoleProvider>(create: (_) => RoleProvider()),
      ChangeNotifierProvider<UserRoleProvider>(
          create: (_) => UserRoleProvider()),
      //
      ChangeNotifierProvider<DelayProvider>(create: (_) => DelayProvider()),
      ChangeNotifierProvider<TypeProvider>(create: (_) => TypeProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(
            seedColor: Colors.white, primary: Colors.white),
        useMaterial3: true,
      ),
      home: const LoginPage(),
    );
  }
}

class LoginPage extends StatefulWidget {
  const LoginPage({super.key});

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
      backgroundColor: Colors.black,
      body: Center(
        child: SingleChildScrollView(
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
                padding:
                    const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
                child: FormBuilderTextField(
                  name: 'userName',
                  controller: _usernameController,
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                        errorText: "Ovo polje ne može bit prazno."),
                  ]),
                  style: const TextStyle(color: Colors.white, fontSize: 18),
                  decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: "Korisničko ime",
                    labelStyle: TextStyle(color: Colors.white),
                    hintText: 'Unesite korisničko ime',
                    hintStyle: TextStyle(color: Colors.white, fontSize: 13),
                    prefixIcon: Icon(Icons.person),
                    prefixIconColor: Colors.white,
                  ),
                ),
              ),
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 35, vertical: 0),
                child: FormBuilderTextField(
                  name: 'password',
                  validator: FormBuilderValidators.compose([
                    FormBuilderValidators.required(
                        errorText: "Ovo polje ne može bit prazno."),
                  ]),
                  controller: _passwordController,
                  style: const TextStyle(color: Colors.white, fontSize: 18),
                  obscureText: !_passwordVisible,
                  decoration: InputDecoration(
                    border: const OutlineInputBorder(),
                    labelText: "Lozinka",
                    labelStyle: const TextStyle(color: Colors.white),
                    hintText: 'Unesite lozinku',
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
                    UserProvider userProvider = UserProvider();
                    UserRoleProvider userRoleProvider = UserRoleProvider();
                    RoleProvider roleProvider = RoleProvider();

                    AuthProvider.username = _usernameController.text;
                    AuthProvider.password = _passwordController.text;
                    try {
                      var userResult = await userProvider.get();
                      var userRolesResult = await userRoleProvider.get();
                      var rolesResult = await roleProvider.get();

                      var currentUser = userResult.result.firstWhere(
                          (user) => user.userName == AuthProvider.username);
                      var currentUserRole = userRolesResult.result.firstWhere(
                          (userRole) => userRole.userId == currentUser.userId);
                      var role = rolesResult.result.firstWhere(
                          (role) => role.roleId == currentUserRole.roleId);

                      if (role.name != "User") {
                        throw UserException(
                            "Samo korisnički računi se mogu koristiti na mobilnoj aplikaciji");
                      }

                      Navigator.of(context).pushReplacement(MaterialPageRoute(
                          builder: (context) => const MasterScreen()));
                    } on Exception catch (e) {
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
                                      onPressed: () => (Navigator.pop(context)),
                                      child: const Text(
                                        "OK",
                                        style: TextStyle(color: Colors.black),
                                      ))
                                ],
                                content: Text(e.toString()),
                              ));
                    }
                  },
                  style: ElevatedButton.styleFrom(
                    backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(2.0),
                    ),
                  ),
                  child: const Text(
                    "Prijava",
                    style: TextStyle(color: Colors.white, fontSize: 20),
                  ),
                ),
              ),
              const SizedBox(height: 5),
              Column(
                mainAxisSize: MainAxisSize.min,
                crossAxisAlignment: CrossAxisAlignment.center,
                children: [
                  TextButton(
                    onPressed: () {
                      Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => const ProfileNewUserScreen()));
                    },
                    child: const Text(
                      "Kreiranje korisničkog naloga",
                      style: TextStyle(
                          color: Colors.white,
                          fontSize: 13,
                          fontWeight: FontWeight.normal,
                          decoration: TextDecoration.underline,
                          decorationColor: Colors.white,
                          decorationThickness: 0.5),
                    ),
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
