// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Ticket _$TicketFromJson(Map<String, dynamic> json) => Ticket()
  ..ticketId = (json['ticketId'] as num?)?.toInt()
  ..name = json['name'] as String?
  ..price = (json['price'] as num?)?.toDouble();

Map<String, dynamic> _$TicketToJson(Ticket instance) => <String, dynamic>{
      'ticketId': instance.ticketId,
      'name': instance.name,
      'price': instance.price,
    };
