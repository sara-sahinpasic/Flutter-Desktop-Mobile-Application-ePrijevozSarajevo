// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'malfunction.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Malfunction _$MalfunctionFromJson(Map<String, dynamic> json) => Malfunction(
      malfunctionId: (json['malfunctionId'] as num?)?.toInt(),
      description: json['description'] as String?,
      dateOfMalufunction: json['dateOfMalufunction'] == null
          ? null
          : DateTime.parse(json['dateOfMalufunction'] as String),
      fixed: json['fixed'] as bool?,
      vehicleId: (json['vehicleId'] as num?)?.toInt(),
      stationId: (json['stationId'] as num?)?.toInt(),
    );

Map<String, dynamic> _$MalfunctionToJson(Malfunction instance) =>
    <String, dynamic>{
      'malfunctionId': instance.malfunctionId,
      'description': instance.description,
      'dateOfMalufunction': instance.dateOfMalufunction?.toIso8601String(),
      'fixed': instance.fixed,
      'vehicleId': instance.vehicleId,
      'stationId': instance.stationId,
    };
