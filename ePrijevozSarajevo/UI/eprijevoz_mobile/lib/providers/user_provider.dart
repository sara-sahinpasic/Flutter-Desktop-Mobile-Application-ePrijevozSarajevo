import 'dart:convert';
import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    return User.fromJson(data);
  }

  Future<bool> resetPassword(String username, String newPassword,
      String passwordConfirmation, String oldPassword) async {
    var url =
        "${BaseProvider.baseUrl}$endpoint/reset-password"; // use the getter

    var body = {
      'username': username,
      'newPassword': newPassword,
      'passwordConfirmation': passwordConfirmation,
      'oldPassword': oldPassword
    };

    var headers = createHeaders();
    var jsonRequest = jsonEncode(body);

    var uri = Uri.parse(url);
    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      return true; // password reset successful
    } else {
      throw Exception("Failed to reset password");
    }
  }

  @override
  Future<User> insert(dynamic request) async {
    var url = ("${BaseProvider.baseUrl}$endpoint");

    var headers = createHeaders();
    var jsonRequest = jsonEncode(request);

    var uri = Uri.parse(url);
    var response = await http.post(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      var data = jsonDecode(response.body);
      return fromJson(data);
    } else {
      throw Exception("Unknown error");
    }
  }
}
