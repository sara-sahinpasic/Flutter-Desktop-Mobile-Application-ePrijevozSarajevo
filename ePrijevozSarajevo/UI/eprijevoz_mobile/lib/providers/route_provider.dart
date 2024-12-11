import 'dart:convert';

import 'package:eprijevoz_mobile/models/route.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class RouteProvider extends BaseProvider<Route> {
  RouteProvider() : super("Route");

  @override
  Route fromJson(data) {
    return Route.fromJson(data);
  }

  Future<List<Route>> getRecommendations(int userId,
      {int maxRecommendations = 5}) async {
    final url =
        ("${BaseProvider.baseUrl}$endpoint/recommendations/$userId?maxRecommendations=$maxRecommendations");
    var uri = Uri.parse(url);
    var headers = createHeaders();

    final response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      // Parse the response body and convert it to a list of Route objects
      final List<dynamic> data = jsonDecode(response.body);
      return data.map((json) => Route.fromJson(json)).toList();
    } else {
      throw Exception("Failed to get recommendations");
    }
  }
}
