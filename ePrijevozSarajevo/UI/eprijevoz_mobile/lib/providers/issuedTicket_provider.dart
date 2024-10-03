import 'package:eprijevoz_mobile/models/issuedTicket.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class IssuedTicketProvider extends BaseProvider<IssuedTicket> {
  IssuedTicketProvider() : super("IssuedTicket");

  @override
  IssuedTicket fromJson(data) {
    // TODO: implement fromJson
    return IssuedTicket.fromJson(data);
  }
}
