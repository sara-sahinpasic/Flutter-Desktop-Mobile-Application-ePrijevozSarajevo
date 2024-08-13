// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'route.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Route _$RouteFromJson(Map<String, dynamic> json) => Route(
      routeId: (json['routeId'] as num?)?.toInt(),
      startStationId: (json['startStationId'] as num?)?.toInt(),
      endStationId: (json['endStationId'] as num?)?.toInt(),
      vehicleId: (json['vehicleId'] as num?)?.toInt(),
      arrival: json['arrival'] == null
          ? null
          : DateTime.parse(json['arrival'] as String),
      departure: json['departure'] == null
          ? null
          : DateTime.parse(json['departure'] as String),
    );

Map<String, dynamic> _$RouteToJson(Route instance) => <String, dynamic>{
      'routeId': instance.routeId,
      'startStationId': instance.startStationId,
      'endStationId': instance.endStationId,
      'vehicleId': instance.vehicleId,
      'arrival': instance.arrival?.toIso8601String(),
      'departure': instance.departure?.toIso8601String(),
    };
