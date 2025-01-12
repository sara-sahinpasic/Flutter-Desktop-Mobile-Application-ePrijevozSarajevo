// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'manufacturer.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Manufacturer _$ManufacturerFromJson(Map<String, dynamic> json) => Manufacturer(
      manufacturerId: (json['manufacturerId'] as num?)?.toInt(),
      name: json['name'] as String?,
    )
      ..modifiedDate = json['modifiedDate'] == null
          ? null
          : DateTime.parse(json['modifiedDate'] as String)
      ..manufacturerCountryId = (json['manufacturerCountryId'] as num?)?.toInt()
      ..currentUserId = (json['currentUserId'] as num?)?.toInt();

Map<String, dynamic> _$ManufacturerToJson(Manufacturer instance) =>
    <String, dynamic>{
      'manufacturerId': instance.manufacturerId,
      'name': instance.name,
      'modifiedDate': instance.modifiedDate?.toIso8601String(),
      'manufacturerCountryId': instance.manufacturerCountryId,
      'currentUserId': instance.currentUserId,
    };
