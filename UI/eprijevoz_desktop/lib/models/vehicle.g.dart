// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vehicle.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Vehicle _$VehicleFromJson(Map<String, dynamic> json) => Vehicle()
  ..vehicleId = (json['vehicleId'] as num?)?.toInt()
  ..registrationNumber = json['registrationNumber'] as String?
  ..buildYear = (json['buildYear'] as num?)?.toInt();

Map<String, dynamic> _$VehicleToJson(Vehicle instance) => <String, dynamic>{
      'vehicleId': instance.vehicleId,
      'registrationNumber': instance.registrationNumber,
      'buildYear': instance.buildYear,
    };
