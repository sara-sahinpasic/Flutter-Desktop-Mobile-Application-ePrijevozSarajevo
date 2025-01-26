// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'type.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Type _$TypeFromJson(Map<String, dynamic> json) => Type(
      typeId: (json['typeId'] as num?)?.toInt(),
      name: json['name'] as String?,
    )
      ..modifiedDate = json['modifiedDate'] == null
          ? null
          : DateTime.parse(json['modifiedDate'] as String)
      ..currentUserId = (json['currentUserId'] as num?)?.toInt();

Map<String, dynamic> _$TypeToJson(Type instance) => <String, dynamic>{
      'typeId': instance.typeId,
      'name': instance.name,
      'modifiedDate': instance.modifiedDate?.toIso8601String(),
      'currentUserId': instance.currentUserId,
    };
