// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'total_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

TotalDto _$TotalDtoFromJson(Map<String, dynamic> json) => TotalDto(
      countRaspolozenja: (json['countRaspolozenja'] as num?)?.toInt(),
      vrijednostRaspolozenjaId:
          (json['vrijednostRaspolozenjaId'] as num?)?.toInt(),
    );

Map<String, dynamic> _$TotalDtoToJson(TotalDto instance) => <String, dynamic>{
      'countRaspolozenja': instance.countRaspolozenja,
      'vrijednostRaspolozenjaId': instance.vrijednostRaspolozenjaId,
    };
