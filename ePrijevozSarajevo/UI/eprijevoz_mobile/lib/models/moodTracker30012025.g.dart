// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'moodTracker30012025.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

MoodTracker30012025 _$MoodTracker30012025FromJson(Map<String, dynamic> json) =>
    MoodTracker30012025(
      moodTracker30012025Id: (json['moodTracker30012025Id'] as num?)?.toInt(),
      userId: (json['userId'] as num?)?.toInt(),
      vrijednostRaspolozenjaId:
          (json['vrijednostRaspolozenjaId'] as num?)?.toInt(),
      opis: json['opis'] as String?,
      datumEvidencije: json['datumEvidencije'] == null
          ? null
          : DateTime.parse(json['datumEvidencije'] as String),
    );

Map<String, dynamic> _$MoodTracker30012025ToJson(
        MoodTracker30012025 instance) =>
    <String, dynamic>{
      'moodTracker30012025Id': instance.moodTracker30012025Id,
      'userId': instance.userId,
      'vrijednostRaspolozenjaId': instance.vrijednostRaspolozenjaId,
      'opis': instance.opis,
      'datumEvidencije': instance.datumEvidencije?.toIso8601String(),
    };
