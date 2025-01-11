// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'country.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Country _$CountryFromJson(Map<String, dynamic> json) => Country(
      countryId: (json['countryId'] as num?)?.toInt(),
      name: json['name'] as String?,
    )..modifiedDate = json['modifiedDate'] == null
        ? null
        : DateTime.parse(json['modifiedDate'] as String);

Map<String, dynamic> _$CountryToJson(Country instance) => <String, dynamic>{
      'countryId': instance.countryId,
      'name': instance.name,
      'modifiedDate': instance.modifiedDate?.toIso8601String(),
    };
