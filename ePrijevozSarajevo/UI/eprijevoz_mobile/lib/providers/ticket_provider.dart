import 'package:eprijevoz_mobile/models/ticket.dart';
import 'package:eprijevoz_mobile/providers/base_provider.dart';

class TicketProvider extends BaseProvider<Ticket> {
  TicketProvider() : super("Ticket");

  @override
  Ticket fromJson(data) {
    return Ticket.fromJson(data);
  }
}
