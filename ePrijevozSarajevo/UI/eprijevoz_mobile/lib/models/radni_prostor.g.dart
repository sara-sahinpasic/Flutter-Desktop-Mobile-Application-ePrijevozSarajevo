// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'radni_prostor.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RadniProstor _$RadniProstorFromJson(Map<String, dynamic> json) => RadniProstor(
      radniProstorId: (json['radniProstorId'] as num?)?.toInt(),
      oznaka: json['oznaka'] as String?,
      kapacitet: (json['kapacitet'] as num?)?.toInt(),
      aktivna: json['aktivna'] as bool?,
    );

Map<String, dynamic> _$RadniProstorToJson(RadniProstor instance) =>
    <String, dynamic>{
      'radniProstorId': instance.radniProstorId,
      'oznaka': instance.oznaka,
      'kapacitet': instance.kapacitet,
      'aktivna': instance.aktivna,
    };
