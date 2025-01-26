import 'package:eprijevoz_mobile/models/delay.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class DelayProvider extends BaseProvider<Delay> {
  DelayProvider() : super("Delay");

  @override
  Delay fromJson(data) {
    return Delay.fromJson(data);
  }
}
