import 'package:eprijevoz_desktop/models/country.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class CountryProvider extends BaseProvider<Country> {
  CountryProvider() : super("Country");

  @override
  Country fromJson(data) {
    return Country.fromJson(data);
  }
}
