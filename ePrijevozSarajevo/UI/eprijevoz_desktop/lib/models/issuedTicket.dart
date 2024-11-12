import 'package:json_annotation/json_annotation.dart';

part 'issuedTicket.g.dart';

@JsonSerializable()
class IssuedTicket {
  int? issuedTicketId;
  int? userId;
  int? ticketId;
  DateTime? validFrom;
  DateTime? validTo;
  DateTime? issuedDate;
  int? amount;
  int? routeId;

  IssuedTicket(
      {this.issuedTicketId,
      this.userId,
      this.ticketId,
      this.validFrom,
      this.validTo,
      this.issuedDate,
      this.amount,
      this.routeId});

  factory IssuedTicket.fromJson(Map<String, dynamic> json) =>
      _$IssuedTicketFromJson(json);

  Map<String, dynamic> toJson() => _$IssuedTicketToJson(this);
}
