import 'package:eprijevoz_desktop/models/delay.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class DelayProvider extends BaseProvider<Delay> {
  DelayProvider() : super("Delay");

  @override
  Delay fromJson(data) {
    return Delay.fromJson(data);
  }
}
