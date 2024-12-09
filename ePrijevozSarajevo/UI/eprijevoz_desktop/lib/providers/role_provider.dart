import 'package:eprijevoz_desktop/models/role.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class RoleProvider extends BaseProvider<Role> {
  RoleProvider() : super("Role");

  @override
  Role fromJson(data) {
    return Role.fromJson(data);
  }
}
