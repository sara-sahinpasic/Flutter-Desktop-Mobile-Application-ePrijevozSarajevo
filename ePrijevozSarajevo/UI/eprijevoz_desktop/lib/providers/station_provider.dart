import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class StationProvider extends BaseProvider<Station> {
  StationProvider() : super("Station");

  @override
  Station fromJson(data) {
    return Station.fromJson(data);
  }
}
