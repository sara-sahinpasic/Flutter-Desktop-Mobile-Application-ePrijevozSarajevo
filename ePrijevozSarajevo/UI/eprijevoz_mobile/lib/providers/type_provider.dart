import 'package:eprijevoz_mobile/providers/base_provider.dart';
import 'package:eprijevoz_mobile/models/type.dart';

class TypeProvider extends BaseProvider<Type> {
  TypeProvider() : super("Type");

  @override
  Type fromJson(data) {
    // TODO: implement fromJson
    return Type.fromJson(data);
  }
}
