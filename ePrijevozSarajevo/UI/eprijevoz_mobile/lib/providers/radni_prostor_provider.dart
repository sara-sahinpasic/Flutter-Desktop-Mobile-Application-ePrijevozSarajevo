import 'package:eprijevoz_mobile/models/radni_prostor.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class RadniProstorProvider extends BaseProvider<RadniProstor> {
  RadniProstorProvider() : super("RadniProstor");

  @override
  RadniProstor fromJson(data) {
    // TODO: implement fromJson
    return RadniProstor.fromJson(data);
  }
}
