// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'status.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Status _$StatusFromJson(Map<String, dynamic> json) => Status(
      statusId: (json['statusId'] as num?)?.toInt(),
      name: json['name'] as String?,
      discount: (json['discount'] as num?)?.toDouble(),
    )
      ..modifiedDate = json['modifiedDate'] == null
          ? null
          : DateTime.parse(json['modifiedDate'] as String)
      ..currentUserId = (json['currentUserId'] as num?)?.toInt();

Map<String, dynamic> _$StatusToJson(Status instance) => <String, dynamic>{
      'statusId': instance.statusId,
      'name': instance.name,
      'discount': instance.discount,
      'modifiedDate': instance.modifiedDate?.toIso8601String(),
      'currentUserId': instance.currentUserId,
    };
