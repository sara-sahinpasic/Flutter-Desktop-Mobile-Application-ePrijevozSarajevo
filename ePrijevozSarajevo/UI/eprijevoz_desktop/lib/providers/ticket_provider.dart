import 'dart:convert';
import 'package:eprijevoz_desktop/models/ticket.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';
import 'package:http/http.dart' as http;

final _httpClient = http.Client();

class TicketProvider extends BaseProvider<Ticket> {
  TicketProvider() : super("Ticket");

  get http => _httpClient;

  @override
  Ticket fromJson(data) {
    return Ticket.fromJson(data);
  }

  Future<bool> activate(int ticketId) async {
    var url = "${BaseProvider.baseUrl}$endpoint/Activate/$ticketId";

    var headers = createHeaders();

    var uri = Uri.parse(url);
    var response = await http.put(uri, headers: headers);

    if (isValidResponse(response)) {
      return true;
    } else {
      throw Exception("Failed to activate ticket: ${response.body}");
    }
  }

  Future<bool> hide(int ticketId) async {
    var url = "${BaseProvider.baseUrl}$endpoint/Hide/$ticketId";

    var headers = createHeaders();

    var uri = Uri.parse(url);
    var response = await http.put(uri, headers: headers);

    if (isValidResponse(response)) {
      return true;
    } else {
      throw Exception("Failed to hide ticket: ${response.body}");
    }
  }

  Future<List<String>> getAllowedActions(int ticketId) async {
    var url = "${BaseProvider.baseUrl}$endpoint/Allowed-Actions/$ticketId";

    var headers = createHeaders();

    var uri = Uri.parse(url);
    var response = await http.get(uri, headers: headers);

    if (isValidResponse(response)) {
      return (jsonDecode(response.body) as List<dynamic>)
          .map((action) => action.toString())
          .toList();
    } else {
      throw Exception("Failed to get allowed actions: ${response.body}");
    }
  }
}
