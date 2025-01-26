import 'package:eprijevoz_desktop/models/malfunction.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class MalfunctionProvider extends BaseProvider<Malfunction> {
  MalfunctionProvider() : super("Malfunction");
  @override
  Malfunction fromJson(data) {
    return Malfunction.fromJson(data);
  }
}
