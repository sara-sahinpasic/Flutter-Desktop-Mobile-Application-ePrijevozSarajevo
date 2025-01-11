import 'package:json_annotation/json_annotation.dart';

part 'ticket.g.dart';

@JsonSerializable()
class Ticket {
  int? ticketId;
  String? name;
  double? price;
  String? stateMachine;
  List<String>? allowedActions = [];
  DateTime? modifiedDate;

  Ticket({this.ticketId, this.name, this.price, this.stateMachine});

  factory Ticket.fromJson(Map<String, dynamic> json) => _$TicketFromJson(json);

  Map<String, dynamic> toJson() => _$TicketToJson(this);
}
