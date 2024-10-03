import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class RouteProvider extends BaseProvider<Route> {
  RouteProvider() : super("Route");

  @override
  Route fromJson(data) {
    // TODO: implement fromJson
    return Route.fromJson(data);
  }
}
