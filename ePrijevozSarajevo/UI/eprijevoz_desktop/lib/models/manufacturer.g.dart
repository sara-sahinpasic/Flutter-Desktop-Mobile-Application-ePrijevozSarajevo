// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'manufacturer.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Manufacturer _$ManufacturerFromJson(Map<String, dynamic> json) => Manufacturer(
      manufacturerId: (json['manufacturerId'] as num?)?.toInt(),
      name: json['name'] as String?,
    );

Map<String, dynamic> _$ManufacturerToJson(Manufacturer instance) =>
    <String, dynamic>{
      'manufacturerId': instance.manufacturerId,
      'name': instance.name,
    };
