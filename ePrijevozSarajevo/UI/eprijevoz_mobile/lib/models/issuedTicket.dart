// import 'package:json_annotation/json_annotation.dart';
// part 'issuedTicket.g.dart';

// @JsonSerializable()
// class IssuedTicket {
//   int? issuedTicketId;
//   int? userId;
//   int? ticketId;
//   DateTime? validFrom;
//   DateTime? validTo;
//   DateTime? issuedDate;

//   IssuedTicket({
//     this.issuedTicketId,
//     this.userId,
//     this.ticketId,
//     this.validFrom,
//     this.validTo,
//     this.issuedDate,
//   });

//   factory IssuedTicket.fromJson(Map<String, dynamic> json) =>
//       _$IssuedTicketFromJson(json);

//   Map<String, dynamic> toJson() => _$IssuedTicketToJson(this);
// }
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

  IssuedTicket({
    this.issuedTicketId,
    this.userId,
    this.ticketId,
    this.validFrom,
    this.validTo,
    this.issuedDate,
  });

  factory IssuedTicket.fromJson(Map<String, dynamic> json) =>
      _$IssuedTicketFromJson(json);

  Map<String, dynamic> toJson() => _$IssuedTicketToJson(this);
}
