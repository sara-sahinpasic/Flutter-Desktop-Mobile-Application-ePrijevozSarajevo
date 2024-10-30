import 'package:eprijevoz_desktop/main.dart';
import 'package:eprijevoz_desktop/providers/user_provider.dart';
import 'package:flutter/material.dart';
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
          _username,
          _newPassword,
          _passwordConfirmation,
        );

        if (success) {
          ScaffoldMessenger.of(context).showSnackBar(
            const SnackBar(content: Text('Lozinka uspješno promijenjena!')),
          );
          Navigator.of(context)
              .push(MaterialPageRoute(builder: (context) => LoginPage()));
        }
      } catch (e) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(
              content: Text('Greška u promijeni lozinke: ${e.toString()}!')),
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
      /*appBar: AppBar(
        iconTheme: const IconThemeData(
          color: Colors.white,
        ),
        title: const Text(
          'Promjena lozinke',
          style: TextStyle(color: Colors.white),
        ),
        backgroundColor: Colors.black,
      ),*/
      backgroundColor: Colors.white,
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
                    padding: const EdgeInsets.symmetric(
                        horizontal: 35, vertical: 68),
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
                            validator: (value) {
                              if (value == null || value.isEmpty) {
                                return 'Unesite korisničko ime';
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
                              labelText: 'Nova loznika',
                              labelStyle: const TextStyle(color: Colors.white),
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
                          _isLoading
                              ? const CircularProgressIndicator()
                              : Row(
                                  children: [
                                    SizedBox(
                                      width: 250,
                                      height: 45,
                                      child: ElevatedButton(
                                        onPressed: _resetPassword,
                                        style: ElevatedButton.styleFrom(
                                          backgroundColor: const Color.fromRGBO(
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
                                    SizedBox(
                                      width: 99,
                                    ),
                                    TextButton(
                                        onPressed: () =>
                                            Navigator.pop(context, false),
                                        child: Text(
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
