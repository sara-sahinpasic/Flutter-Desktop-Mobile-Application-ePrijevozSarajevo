// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'status_rezervacije.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

StatusRezervacije _$StatusRezervacijeFromJson(Map<String, dynamic> json) =>
    StatusRezervacije(
      statusRezervacijeId: (json['statusRezervacijeId'] as num?)?.toInt(),
      naziv: json['naziv'] as String?,
    );

Map<String, dynamic> _$StatusRezervacijeToJson(StatusRezervacije instance) =>
    <String, dynamic>{
      'statusRezervacijeId': instance.statusRezervacijeId,
      'naziv': instance.naziv,
    };
