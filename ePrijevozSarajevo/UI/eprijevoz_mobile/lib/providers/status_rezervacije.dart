import 'package:eprijevoz_mobile/models/status_rezervacije.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class StatusRezervacijeProvider extends BaseProvider<StatusRezervacije> {
  StatusRezervacijeProvider() : super("StatusRezervacije");

  @override
  StatusRezervacije fromJson(data) {
    // TODO: implement fromJson
    return StatusRezervacije.fromJson(data);
  }
}
