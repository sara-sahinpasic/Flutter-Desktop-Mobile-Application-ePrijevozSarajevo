import 'dart:convert';

import 'package:eprijevoz_mobile/models/rezervacija_prostora20022025.dart';
import 'package:eprijevoz_mobile/models/total_dto.dart';

import 'package:eprijevoz_mobile/providers/base_provider.dart';
import 'package:http/http.dart' as http;

class RezervacijaProstora20022025Provider
    extends BaseProvider<RezervacijaProstora20022025> {
  RezervacijaProstora20022025Provider() : super("RezervacijaProstora20022025");

  @override
  RezervacijaProstora20022025 fromJson(data) {
    // TODO: implement fromJson
    return RezervacijaProstora20022025.fromJson(data);
  }

  Future<List<TotalDto>> totalList({dynamic filter}) async {
    var url = ("${BaseProvider.baseUrl}$endpoint");

    if (filter != null) {
      var queryString = getQueryString(filter);
      url = "$url/total-list?$queryString";
    } else {
      url = "$url/total-list";
    }

    var uri = Uri.parse(url);
    var headers = createHeaders();

    final response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      final List<dynamic> data = jsonDecode(response.body);
      return data.map((json) => TotalDto.fromJson(json)).toList();
    } else {
      throw Exception("Failed to get data");
    }
  }
}
