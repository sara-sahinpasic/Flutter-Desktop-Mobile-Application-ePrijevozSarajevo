// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'issuedTicket.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

IssuedTicket _$IssuedTicketFromJson(Map<String, dynamic> json) => IssuedTicket(
      issuedTicketId: (json['issuedTicketId'] as num?)?.toInt(),
      userId: (json['userId'] as num?)?.toInt(),
      ticketId: (json['ticketId'] as num?)?.toInt(),
      validFrom: json['validFrom'] == null
          ? null
          : DateTime.parse(json['validFrom'] as String),
      validTo: json['validTo'] == null
          ? null
          : DateTime.parse(json['validTo'] as String),
      issuedDate: json['issuedDate'] == null
          ? null
          : DateTime.parse(json['issuedDate'] as String),
      amount: (json['amount'] as num?)?.toInt(),
      routeId: (json['routeId'] as num?)?.toInt(),
    );

Map<String, dynamic> _$IssuedTicketToJson(IssuedTicket instance) =>
    <String, dynamic>{
      'issuedTicketId': instance.issuedTicketId,
      'userId': instance.userId,
      'ticketId': instance.ticketId,
      'validFrom': instance.validFrom?.toIso8601String(),
      'validTo': instance.validTo?.toIso8601String(),
      'issuedDate': instance.issuedDate?.toIso8601String(),
      'amount': instance.amount,
      'routeId': instance.routeId,
    };
