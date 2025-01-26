import 'package:eprijevoz_desktop/providers/auth_provider.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';
import 'package:eprijevoz_desktop/providers/country_provider.dart';
import 'package:eprijevoz_desktop/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_desktop/providers/malfunction_provider.dart';
import 'package:eprijevoz_desktop/providers/manufacturer_provider.dart';
import 'package:eprijevoz_desktop/providers/request_provider.dart';
import 'package:eprijevoz_desktop/providers/role_provider.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/status_provider.dart';
import 'package:eprijevoz_desktop/providers/ticket_provider.dart';
import 'package:eprijevoz_desktop/providers/type_provider.dart';
import 'package:eprijevoz_desktop/providers/userRole_provider.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:eprijevoz_desktop/providers/vehicle_provider.dart';
import 'package:eprijevoz_desktop/screens/forgot_password_screen.dart';
import 'package:eprijevoz_desktop/screens/home_screen.dart';
import 'package:flutter/material.dart';
import 'package:flutter_form_builder/flutter_form_builder.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';
import 'package:window_manager/window_manager.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await windowManager.ensureInitialized();

  WindowOptions windowOptions = const WindowOptions(
    size: Size(1536, 864),
    center: true,
    backgroundColor: Colors.transparent,
    skipTaskbar: false,
    titleBarStyle: TitleBarStyle.normal,
    windowButtonVisibility: true,
  );
  windowManager.waitUntilReadyToShow(windowOptions, () async {
    await windowManager.show();
    await windowManager.focus();
  });
  await dotenv.load(fileName: ".env");

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
      ChangeNotifierProvider<IssuedTicketProvider>(
          create: (_) => IssuedTicketProvider()),
      ChangeNotifierProvider<CountryProvider>(create: (_) => CountryProvider()),
      ChangeNotifierProvider<UserRoleProvider>(
          create: (_) => UserRoleProvider()),
      ChangeNotifierProvider<RoleProvider>(create: (_) => RoleProvider()),
      ChangeNotifierProvider<TicketProvider>(create: (_) => TicketProvider()),
      //
      ChangeNotifierProvider<MalfunctionProvider>(
          create: (_) => MalfunctionProvider()),
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
  final _formKey = GlobalKey<FormBuilderState>();

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
          child: FormBuilder(
            key: _formKey,
            child: Container(
              constraints: BoxConstraints(
                maxHeight: MediaQuery.of(context).size.height * 0.8,
                maxWidth: 500,
              ),
              child: Card(
                color: Colors.black,
                child: SingleChildScrollView(
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      Padding(
                        padding: const EdgeInsets.only(top: 25, bottom: 25),
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
                        child: FormBuilderTextField(
                            name: 'userName',
                            controller: _usernameController,
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Ovo polje ne može bit prazno."),
                            ]),
                            style: const TextStyle(color: Colors.white),
                            decoration: const InputDecoration(
                              border: OutlineInputBorder(),
                              labelText: "Korisničko ime",
                              labelStyle: TextStyle(color: Colors.white),
                              hintText: "Unesite korisničko ime",
                              hintStyle:
                                  TextStyle(color: Colors.white, fontSize: 13),
                              prefixIcon: Icon(Icons.person),
                              prefixIconColor: Colors.white,
                            )),
                      ),
                      Padding(
                        padding: const EdgeInsets.symmetric(
                            horizontal: 35, vertical: 0),
                        child: FormBuilderTextField(
                          name: 'password',
                          validator: FormBuilderValidators.compose([
                            FormBuilderValidators.required(
                                errorText: "Ovo polje ne može bit prazno."),
                          ]),
                          controller: _passwordController,
                          style: const TextStyle(
                              color: Colors.white, fontSize: 18),
                          obscureText: !_passwordVisible,
                          decoration: InputDecoration(
                            border: const OutlineInputBorder(),
                            labelText: "Lozinka",
                            labelStyle: const TextStyle(color: Colors.white),
                            hintText: 'Unesite lozinku',
                            hintStyle: const TextStyle(
                                color: Colors.white, fontSize: 13),
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
                            UserRoleProvider userRoleProvider =
                                UserRoleProvider();
                            RoleProvider roleProvider = RoleProvider();
                            AuthProvider.username =
                                _usernameController.text.toLowerCase();
                            AuthProvider.password = _passwordController.text;
                            try {
                              _formKey.currentState?.saveAndValidate();
                              var userResult = await userProvider.get();
                              var userRolesResult =
                                  await userRoleProvider.get();
                              var rolesResult = await roleProvider.get();

                              var currentUser = userResult.result.firstWhere(
                                  (user) =>
                                      user.userName == AuthProvider.username);
                              var currentUserRole = userRolesResult.result
                                  .firstWhere((userRole) =>
                                      userRole.userId == currentUser.userId);
                              var role = rolesResult.result.firstWhere((role) =>
                                  role.roleId == currentUserRole.roleId);

                              if (role.name != "Admin") {
                                throw UserException(
                                    "Samo Admin računi se mogu koristiti na desktop aplikaciji");
                              }

                              Navigator.of(context).push(MaterialPageRoute(
                                  builder: (context) => (const HomePage())));
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
                                              onPressed: () =>
                                                  (Navigator.pop(context)),
                                              child: const Text(
                                                "OK",
                                                style: TextStyle(
                                                    color: Colors.black),
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
                            "Prijava",
                            style: TextStyle(color: Colors.white, fontSize: 20),
                          ),
                        ),
                      ),
                      const SizedBox(
                        height: 45,
                      )
                    ],
                  ),
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
