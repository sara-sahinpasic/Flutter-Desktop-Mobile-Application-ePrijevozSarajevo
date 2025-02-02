import 'dart:convert';

import 'package:eprijevoz_mobile/models/countRaspolozenja.dart';

import 'package:eprijevoz_mobile/models/moodTracker30012025.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class MoodTrackerProvider extends BaseProvider<MoodTracker30012025> {
  MoodTrackerProvider() : super("MoodTracker30012025");

  @override
  MoodTracker30012025 fromJson(data) {
    return MoodTracker30012025.fromJson(data);
  }

  Future<CountRaspolozenja> countRaspolozenja() async {
    var url = "${BaseProvider.baseUrl}$endpoint/count-raspolozenje";

    var headers = createHeaders();

    var uri = Uri.parse(url);
    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      final dynamic data = jsonDecode(response.body);
      CountRaspolozenja result = CountRaspolozenja.fromJson(
          data); //vracanje pojedinacnih zapisa (count1, count2, count3...)
      return result;

      //return data.map((json) => CountRaspolozenja.fromJson(json)); //vracanje skupa zapisa ([count1, count2, count3])
    } else {
      throw Exception("Failed to get count");
    }
  }
}
