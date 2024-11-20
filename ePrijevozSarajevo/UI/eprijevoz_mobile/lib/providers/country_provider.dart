import 'package:eprijevoz_mobile/models/country.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class CountryProvider extends BaseProvider<Country> {
  CountryProvider() : super("Country");

  @override
  Country fromJson(data) {
    // TODO: implement fromJson
    return Country.fromJson(data);
  }
}
