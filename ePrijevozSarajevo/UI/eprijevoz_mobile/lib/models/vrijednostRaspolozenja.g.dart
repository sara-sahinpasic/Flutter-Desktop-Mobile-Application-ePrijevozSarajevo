// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'vrijednostRaspolozenja.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

VrijednostRaspolozenja _$VrijednostRaspolozenjaFromJson(
        Map<String, dynamic> json) =>
    VrijednostRaspolozenja(
      vrijednostRaspolozenjaId:
          (json['vrijednostRaspolozenjaId'] as num?)?.toInt(),
      naziv: json['naziv'] as String?,
    );

Map<String, dynamic> _$VrijednostRaspolozenjaToJson(
        VrijednostRaspolozenja instance) =>
    <String, dynamic>{
      'vrijednostRaspolozenjaId': instance.vrijednostRaspolozenjaId,
      'naziv': instance.naziv,
    };
