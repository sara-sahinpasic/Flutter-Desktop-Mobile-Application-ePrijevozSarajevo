import 'package:eprijevoz_mobile/models/role.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class RoleProvider extends BaseProvider<Role> {
  RoleProvider() : super("Role");

  @override
  Role fromJson(data) {
    return Role.fromJson(data);
  }
}
