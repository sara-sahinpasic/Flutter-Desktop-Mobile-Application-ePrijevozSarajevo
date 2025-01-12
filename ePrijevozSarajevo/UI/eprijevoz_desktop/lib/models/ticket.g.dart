// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Ticket _$TicketFromJson(Map<String, dynamic> json) => Ticket(
      ticketId: (json['ticketId'] as num?)?.toInt(),
      name: json['name'] as String?,
      price: (json['price'] as num?)?.toDouble(),
      stateMachine: json['stateMachine'] as String?,
    )
      ..allowedActions = (json['allowedActions'] as List<dynamic>?)
          ?.map((e) => e as String)
          .toList()
      ..modifiedDate = json['modifiedDate'] == null
          ? null
          : DateTime.parse(json['modifiedDate'] as String)
      ..currentUserId = (json['currentUserId'] as num?)?.toInt();

Map<String, dynamic> _$TicketToJson(Ticket instance) => <String, dynamic>{
      'ticketId': instance.ticketId,
      'name': instance.name,
      'price': instance.price,
      'stateMachine': instance.stateMachine,
      'allowedActions': instance.allowedActions,
      'modifiedDate': instance.modifiedDate?.toIso8601String(),
      'currentUserId': instance.currentUserId,
    };
