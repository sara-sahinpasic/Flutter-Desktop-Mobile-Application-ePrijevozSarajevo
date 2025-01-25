import 'package:eprijevoz_mobile/layouts/master_screen.dart';
import 'package:eprijevoz_mobile/main.dart';
import 'package:eprijevoz_mobile/providers/auth_provider.dart';
import 'package:eprijevoz_mobile/providers/user_provider.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class ForgotPasswordScreen extends StatefulWidget {
  const ForgotPasswordScreen({super.key});

  @override
  State<ForgotPasswordScreen> createState() => _ForgotPasswordScreenState();
}

class _ForgotPasswordScreenState extends State<ForgotPasswordScreen> {
  final _formKey = GlobalKey<FormState>();
  final String? _username = AuthProvider.username;
  String _newPassword = '';
  String _oldPassword = '';
  String _passwordConfirmation = '';
  bool _isLoading = false;
  bool _passwordVisible = false;

  void _resetPassword() async {
    if (_formKey.currentState!.validate()) {
      setState(() {
        _isLoading = true;
      });

      try {
        var userProvider = Provider.of<UserProvider>(context, listen: false);
        bool success = await userProvider.resetPassword(
          _username ?? "",
          _newPassword,
          _passwordConfirmation,
          _oldPassword,
        );

        if (success) {
          showDialog(
            context: context,
            builder: (context) => AlertDialog(
              title: const Text(
                "Promjena lozinke",
                style:
                    TextStyle(fontWeight: FontWeight.bold, color: Colors.green),
              ),
              content: const Text("Lozinka uspješno promijenjena!"),
              actions: [
                TextButton(
                    child:
                        const Text("OK", style: TextStyle(color: Colors.black)),
                    onPressed: () =>
                        Navigator.of(context).push(MaterialPageRoute(
                          builder: (context) => const MasterScreen(
                            initialIndex: 3,
                          ),
                        )))
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
            content: Text('Greška u promijeni lozinke! \n$e'),
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
          _isLoading = false;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        iconTheme: const IconThemeData(
          color: Colors.white,
        ),
        title: const Text(
          'Promjena lozinke',
          style: TextStyle(color: Colors.white),
        ),
        backgroundColor: Colors.black,
      ),
      backgroundColor: Colors.black,
      body: Center(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Padding(
                padding:
                    const EdgeInsets.symmetric(horizontal: 35, vertical: 20),
                child: Form(
                  key: _formKey,
                  child: Column(
                    children: [
                      TextFormField(
                        style: const TextStyle(color: Colors.white),
                        obscureText: !_passwordVisible,
                        decoration: InputDecoration(
                          border: const OutlineInputBorder(),
                          labelText: 'Stara loznika',
                          labelStyle: const TextStyle(color: Colors.white),
                          hintText: 'Unesite staru lozinku',
                          hintStyle: const TextStyle(
                              color: Colors.white, fontSize: 13),
                          prefixIcon:
                              const Icon(Icons.password, color: Colors.white),
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
                            _oldPassword = value;
                          });
                        },
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Unesite staru lozinku';
                          }
                          return null;
                        },
                      ),
                      //
                      const SizedBox(
                        height: 20,
                      ),
                      TextFormField(
                        style: const TextStyle(color: Colors.white),
                        obscureText: !_passwordVisible,
                        decoration: InputDecoration(
                          border: const OutlineInputBorder(),
                          labelText: 'Nova loznika',
                          labelStyle: const TextStyle(color: Colors.white),
                          hintText: 'Unesite novu lozinku',
                          hintStyle: const TextStyle(
                              color: Colors.white, fontSize: 13),
                          prefixIcon:
                              const Icon(Icons.password, color: Colors.white),
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
                        validator: (value) {
                          if (value == null || value.isEmpty) {
                            return 'Unesite novu lozinku';
                          }
                          return null;
                        },
                      ),
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
                          prefixIcon:
                              const Icon(Icons.password, color: Colors.white),
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
                      _isLoading
                          ? const CircularProgressIndicator()
                          : ElevatedButton(
                              onPressed: _resetPassword,
                              style: ElevatedButton.styleFrom(
                                backgroundColor:
                                    const Color.fromRGBO(72, 156, 118, 100),
                                shape: RoundedRectangleBorder(
                                  borderRadius: BorderRadius.circular(2.0),
                                ),
                              ),
                              child: const Text(
                                'Promjena lozinke',
                                style: TextStyle(
                                  fontSize: 17,
                                  fontWeight: FontWeight.normal,
                                ),
                              ),
                            )
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
