// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'request.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Request _$RequestFromJson(Map<String, dynamic> json) => Request(
      requestId: (json['requestId'] as num?)?.toInt(),
      userStatusId: (json['userStatusId'] as num?)?.toInt(),
      userId: (json['userId'] as num?)?.toInt(),
      dateCreated: json['dateCreated'] == null
          ? null
          : DateTime.parse(json['dateCreated'] as String),
      approved: json['approved'] as bool?,
      rejectionReason: json['rejectionReason'] as String?,
      active: json['active'] as bool?,
    );

Map<String, dynamic> _$RequestToJson(Request instance) => <String, dynamic>{
      'requestId': instance.requestId,
      'userStatusId': instance.userStatusId,
      'userId': instance.userId,
      'dateCreated': instance.dateCreated?.toIso8601String(),
      'approved': instance.approved,
      'rejectionReason': instance.rejectionReason,
      'active': instance.active,
    };
