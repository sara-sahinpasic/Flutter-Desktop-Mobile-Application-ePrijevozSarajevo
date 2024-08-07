// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vehicle.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Vehicle _$VehicleFromJson(Map<String, dynamic> json) => Vehicle(
      vehicleId: (json['vehicleId'] as num?)?.toInt(),
      registrationNumber: json['registrationNumber'] as String?,
      buildYear: (json['buildYear'] as num?)?.toInt(),
    )
      ..number = (json['number'] as num?)?.toInt()
      ..manufacturerId = (json['manufacturerId'] as num?)?.toInt()
      ..typeId = (json['typeId'] as num?)?.toInt();

Map<String, dynamic> _$VehicleToJson(Vehicle instance) => <String, dynamic>{
      'vehicleId': instance.vehicleId,
      'number': instance.number,
      'registrationNumber': instance.registrationNumber,
      'buildYear': instance.buildYear,
      'manufacturerId': instance.manufacturerId,
      'typeId': instance.typeId,
    };
