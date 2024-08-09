/*import 'package:eprijevoz_desktop/models/user.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';*/

import 'package:eprijevoz_mobile/models/user.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("User");

  @override
  User fromJson(data) {
    // TODO: implement fromJson
    return User.fromJson(data);
  }
}
