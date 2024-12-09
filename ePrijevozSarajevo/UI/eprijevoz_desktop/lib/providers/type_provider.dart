import 'package:eprijevoz_desktop/providers/base_provider.dart';
import 'package:eprijevoz_desktop/models/type.dart';

class TypeProvider extends BaseProvider<Type> {
  TypeProvider() : super("Type");

  @override
  Type fromJson(data) {
    return Type.fromJson(data);
  }
}
