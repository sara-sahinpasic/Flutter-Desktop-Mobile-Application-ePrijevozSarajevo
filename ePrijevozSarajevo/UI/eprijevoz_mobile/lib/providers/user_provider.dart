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

  Future<bool> resetPassword(
      String username, String newPassword, String passwordConfirmation) async {
    var url =
        "${BaseProvider.baseUrl}$endpoint/reset-password"; // use the getter

    var body = {
      'username': username,
      'newPassword': newPassword,
      'passwordConfirmation': passwordConfirmation,
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
}
