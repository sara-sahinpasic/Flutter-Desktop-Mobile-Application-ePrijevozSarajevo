import 'package:eprijevoz_desktop/providers/base_provider.dart';
import '../models/request.dart';

class RequestProvider extends BaseProvider<Request> {
  RequestProvider() : super("Request");

  @override
  Request fromJson(data) {
    return Request.fromJson(data);
  }
}
