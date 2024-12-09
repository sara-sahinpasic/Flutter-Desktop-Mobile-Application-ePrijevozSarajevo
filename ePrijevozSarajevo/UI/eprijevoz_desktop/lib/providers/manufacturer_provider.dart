import 'package:eprijevoz_desktop/models/manufacturer.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class ManufacturerProvider extends BaseProvider<Manufacturer> {
  ManufacturerProvider() : super("Manufacturer");

  @override
  Manufacturer fromJson(data) {
    return Manufacturer.fromJson(data);
  }
}
