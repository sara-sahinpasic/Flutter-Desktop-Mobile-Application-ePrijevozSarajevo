import 'dart:convert';

import 'package:eprijevoz_desktop/providers/base_provider.dart';
import '../models/request.dart';

import 'package:http/http.dart' as http;

final _httpClient = http.Client();

//get http => _httpClient;

class RequestProvider extends BaseProvider<Request> {
  RequestProvider() : super("Request");

  get http => _httpClient;

  @override
  Request fromJson(data) {
    return Request.fromJson(data);
  }

  Future<bool> approveRequest(int id, DateTime expirationDate,
      [String? rejectionReason]) async {
    var url = "${BaseProvider.baseUrl}$endpoint/Approve/$id";

    var formattedExpirationDate = expirationDate.toIso8601String();

    var body = {
      'expirationDate': formattedExpirationDate,
      if (rejectionReason != null)
        'rejectionReason': rejectionReason, // Optional parameter
    };

    var headers = createHeaders();
    var jsonRequest = jsonEncode(body);

    var uri = Uri.parse(url);
    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      return true;
    } else {
      throw Exception("Failed to approve request: ${response.body}");
    }
  }

  Future<bool> rejectRequest(
    int id,
    String? rejectionReason,
  ) async {
    var url = "${BaseProvider.baseUrl}$endpoint/Reject/$id";

    var body = {
      'rejectionReason': rejectionReason,
    };

    var headers = createHeaders();
    var jsonRequest = jsonEncode(body);

    var uri = Uri.parse(url);
    var response = await http.put(uri, headers: headers, body: jsonRequest);

    if (isValidResponse(response)) {
      return true;
    } else {
      throw Exception("Failed to approve request: ${response.body}");
    }
  }
}
