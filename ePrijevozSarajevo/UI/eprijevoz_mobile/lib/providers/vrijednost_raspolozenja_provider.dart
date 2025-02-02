import 'package:eprijevoz_mobile/models/vrijednostRaspolozenja.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class VrijednostRaspolozenjaProvider
    extends BaseProvider<VrijednostRaspolozenja> {
  VrijednostRaspolozenjaProvider() : super("VrijednostRaspolozenja");

  @override
  VrijednostRaspolozenja fromJson(data) {
    return VrijednostRaspolozenja.fromJson(data);
  }
}
