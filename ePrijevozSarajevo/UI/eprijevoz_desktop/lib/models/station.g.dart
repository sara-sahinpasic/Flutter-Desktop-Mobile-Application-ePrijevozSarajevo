// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'station.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Station _$StationFromJson(Map<String, dynamic> json) => Station(
      stationId: (json['stationId'] as num?)?.toInt(),
      name: json['name'] as String?,
      modifiedDate: json['modifiedDate'] == null
          ? null
          : DateTime.parse(json['modifiedDate'] as String),
      currentUserId: (json['currentUserId'] as num?)?.toInt(),
      dateCreated: json['dateCreated'] == null
          ? null
          : DateTime.parse(json['dateCreated'] as String),
    );

Map<String, dynamic> _$StationToJson(Station instance) => <String, dynamic>{
      'stationId': instance.stationId,
      'name': instance.name,
      'modifiedDate': instance.modifiedDate?.toIso8601String(),
      'currentUserId': instance.currentUserId,
      'dateCreated': instance.dateCreated?.toIso8601String(),
    };
