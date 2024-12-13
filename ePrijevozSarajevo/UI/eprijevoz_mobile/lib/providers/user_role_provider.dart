import 'package:eprijevoz_mobile/models/userRole.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class UserRoleProvider extends BaseProvider<UserRole> {
  UserRoleProvider() : super("UserRole");

  @override
  UserRole fromJson(data) {
    return UserRole.fromJson(data);
  }
}
