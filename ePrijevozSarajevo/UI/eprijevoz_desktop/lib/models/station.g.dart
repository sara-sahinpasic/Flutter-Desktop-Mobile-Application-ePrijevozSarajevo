// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'station.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Station _$StationFromJson(Map<String, dynamic> json) => Station()
  ..stationId = (json['stationId'] as num?)?.toInt()
  ..name = json['name'] as String?;

Map<String, dynamic> _$StationToJson(Station instance) => <String, dynamic>{
      'stationId': instance.stationId,
      'name': instance.name,
    };
