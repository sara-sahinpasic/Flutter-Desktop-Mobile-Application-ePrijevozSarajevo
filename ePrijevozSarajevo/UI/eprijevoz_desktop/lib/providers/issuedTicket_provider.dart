import 'package:eprijevoz_desktop/models/issuedTicket.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class IssuedTicketProvider extends BaseProvider<IssuedTicket> {
  IssuedTicketProvider() : super("IssuedTicket");

  @override
  IssuedTicket fromJson(data) {
    // TODO: implement fromJson
    return IssuedTicket.fromJson(data);
  }
}
