import 'package:eprijevoz_desktop/main.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:form_builder_validators/form_builder_validators.dart';
import 'package:provider/provider.dart';

class ForgotPasswordScreen extends StatefulWidget {
  const ForgotPasswordScreen({super.key});

  @override
  State<ForgotPasswordScreen> createState() => _ForgotPasswordScreenState();
}

class _ForgotPasswordScreenState extends State<ForgotPasswordScreen> {
  final _formKey = GlobalKey<FormState>();
  String _username = '';
  String _newPassword = '';
  String _passwordConfirmation = '';
  bool _passwordVisible = false;
  bool isLoading = false;

  void _resetPassword() async {
    if (_formKey.currentState!.validate()) {
      setState(() {
        isLoading = true;
      });

      try {
        var userProvider = Provider.of<UserProvider>(context, listen: false);
        bool success = await userProvider.resetPassword(
          _username,
          _newPassword,
          _passwordConfirmation,
        );

        if (success) {
          showDialog(
            context: context,
            builder: (context) => AlertDialog(
              title: const Text(
                "Promjena lozinke",
                style:
                    TextStyle(color: Colors.green, fontWeight: FontWeight.bold),
              ),
              content: const Text("Lozinka uspješno promijenjena!"),
              actions: [
                TextButton(
                    child:
                        const Text("OK", style: TextStyle(color: Colors.black)),
                    onPressed: () => Navigator.of(context).push(
                        MaterialPageRoute(
                            builder: (context) => const LoginPage())))
              ],
            ),
          );
        }
      } catch (e) {
        showDialog(
          context: context,
          builder: (dialogContext) => AlertDialog(
            title: const Text(
              "Error",
              style: TextStyle(color: Colors.red, fontWeight: FontWeight.bold),
            ),
            content: Text('Greška u promijeni lozinke!->\n$e'),
            actions: [
              TextButton(
                child: const Text(
                  "OK",
                  style: TextStyle(color: Colors.black),
                ),
                onPressed: () {
                  Navigator.pop(dialogContext, false);
                },
              ),
            ],
          ),
        );
      } finally {
        setState(() {
          isLoading = false;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: SingleChildScrollView(
          child: Container(
            constraints: BoxConstraints(
              maxHeight: MediaQuery.of(context).size.height * 0.8,
              maxWidth: 500,
            ),
            child: Card(
              color: Colors.black,
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  Padding(
                    padding: const EdgeInsets.symmetric(
                        horizontal: 35, vertical: 50),
                    child: Form(
                      key: _formKey,
                      child: Column(
                        children: [
                          TextFormField(
                            style: const TextStyle(color: Colors.white),
                            decoration: const InputDecoration(
                              border: OutlineInputBorder(),
                              labelText: 'Korisničko ime',
                              labelStyle: TextStyle(color: Colors.white),
                              hintText: 'Unesite korisničko ime',
                              hintStyle:
                                  TextStyle(color: Colors.white, fontSize: 13),
                              prefixIcon:
                                  Icon(Icons.person, color: Colors.white),
                            ),
                            onChanged: (value) {
                              setState(() {
                                _username = value;
                              });
                            },
                            validator: FormBuilderValidators.compose([
                              FormBuilderValidators.required(
                                  errorText: "Unesite korisničko ime."),
                            ]),
                          ),
                          const SizedBox(
                            height: 20,
                          ),
                          TextFormField(
                              style: const TextStyle(color: Colors.white),
                              obscureText: !_passwordVisible,
                              decoration: InputDecoration(
                                border: const OutlineInputBorder(),
                                labelText: 'Nova loznika',
                                labelStyle:
                                    const TextStyle(color: Colors.white),
                                hintText: 'Unesite novu lozinku',
                                hintStyle: const TextStyle(
                                    color: Colors.white, fontSize: 13),
                                prefixIcon: const Icon(Icons.password,
                                    color: Colors.white),
                                suffixIcon: IconButton(
                                  icon: Icon(
                                    _passwordVisible
                                        ? Icons.visibility
                                        : Icons.visibility_off,
                                    color: Colors.white,
                                  ),
                                  onPressed: () {
                                    setState(() {
                                      _passwordVisible = !_passwordVisible;
                                    });
                                  },
                                ),
                              ),
                              onChanged: (value) {
                                setState(() {
                                  _newPassword = value;
                                });
                              },
                              validator: FormBuilderValidators.compose([
                                FormBuilderValidators.required(
                                    errorText: "Unesite novu lozinku."),
                              ])),
                          const SizedBox(
                            height: 20,
                          ),
                          TextFormField(
                            style: const TextStyle(color: Colors.white),
                            obscureText: !_passwordVisible,
                            decoration: InputDecoration(
                              border: const OutlineInputBorder(),
                              labelText: 'Potvrda lozinke',
                              labelStyle: const TextStyle(color: Colors.white),
                              hintText: 'Ponovite lozinku',
                              hintStyle: const TextStyle(
                                  color: Colors.white, fontSize: 13),
                              prefixIcon: const Icon(Icons.password,
                                  color: Colors.white),
                              suffixIcon: IconButton(
                                icon: Icon(
                                  _passwordVisible
                                      ? Icons.visibility
                                      : Icons.visibility_off,
                                  color: Colors.white,
                                ),
                                onPressed: () {
                                  setState(() {
                                    _passwordVisible = !_passwordVisible;
                                  });
                                },
                              ),
                            ),
                            onChanged: (value) {
                              setState(() {
                                _passwordConfirmation = value;
                              });
                            },
                            validator: (value) {
                              if (value == null || value.isEmpty) {
                                return 'Potvrdite lozinku';
                              } else if (value != _newPassword) {
                                return 'Lozinka se ne podudara';
                              }
                              return null;
                            },
                          ),
                          const SizedBox(height: 30),
                          isLoading
                              ? const CircularProgressIndicator()
                              : Row(
                                  mainAxisAlignment:
                                      MainAxisAlignment.spaceBetween,
                                  children: [
                                    Expanded(
                                      flex: 2,
                                      child: SizedBox(
                                        height: 45,
                                        child: ElevatedButton(
                                          onPressed: _resetPassword,
                                          style: ElevatedButton.styleFrom(
                                            backgroundColor:
                                                const Color.fromRGBO(
                                                    72, 156, 118, 100),
                                            shape: RoundedRectangleBorder(
                                              borderRadius:
                                                  BorderRadius.circular(2.0),
                                            ),
                                          ),
                                          child: const Text(
                                            'Promjena lozinke',
                                            style: TextStyle(
                                              fontSize: 17,
                                              fontWeight: FontWeight.bold,
                                            ),
                                          ),
                                        ),
                                      ),
                                    ),
                                    const SizedBox(
                                      width: 10,
                                    ),
                                    TextButton(
                                        onPressed: () =>
                                            Navigator.pop(context, false),
                                        child: const Text(
                                          "Cancel",
                                          style: TextStyle(
                                              color: Colors.red, fontSize: 16),
                                        )),
                                  ],
                                ),
                        ],
                      ),
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
