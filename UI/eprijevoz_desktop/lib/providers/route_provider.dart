import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class RouteProvider extends BaseProvider<Route> {
  RouteProvider() : super("Route");

  @override
  Route fromJson(data) {
    // TODO: implement fromJson
    return Route.fromJson(data);
  }
}
