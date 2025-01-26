// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'delay.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Delay _$DelayFromJson(Map<String, dynamic> json) => Delay(
      delayId: (json['delayId'] as num?)?.toInt(),
      reason: json['reason'] as String?,
      routeId: (json['routeId'] as num?)?.toInt(),
      delayAmountMinutes: (json['delayAmountMinutes'] as num?)?.toInt(),
      typeId: (json['typeId'] as num?)?.toInt(),
    );

Map<String, dynamic> _$DelayToJson(Delay instance) => <String, dynamic>{
      'delayId': instance.delayId,
      'reason': instance.reason,
      'routeId': instance.routeId,
      'delayAmountMinutes': instance.delayAmountMinutes,
      'typeId': instance.typeId,
    };
