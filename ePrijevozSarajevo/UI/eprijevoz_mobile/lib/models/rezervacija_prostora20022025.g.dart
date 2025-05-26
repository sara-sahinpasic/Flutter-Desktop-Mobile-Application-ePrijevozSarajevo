// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'rezervacija_prostora20022025.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

RezervacijaProstora20022025 _$RezervacijaProstora20022025FromJson(
        Map<String, dynamic> json) =>
    RezervacijaProstora20022025(
      rezervacijaProstora20022025Id:
          (json['rezervacijaProstora20022025Id'] as num?)?.toInt(),
      userId: (json['userId'] as num?)?.toInt(),
      pocetakRezervacije: json['pocetakRezervacije'] == null
          ? null
          : DateTime.parse(json['pocetakRezervacije'] as String),
      trajanjeRezervacije: json['trajanjeRezervacije'] == null
          ? null
          : DateTime.parse(json['trajanjeRezervacije'] as String),
      napomena: json['napomena'] as String?,
      radniProstorId: (json['radniProstorId'] as num?)?.toInt(),
      statusRezervacijeId: (json['statusRezervacijeId'] as num?)?.toInt(),
    );

Map<String, dynamic> _$RezervacijaProstora20022025ToJson(
        RezervacijaProstora20022025 instance) =>
    <String, dynamic>{
      'rezervacijaProstora20022025Id': instance.rezervacijaProstora20022025Id,
      'userId': instance.userId,
      'pocetakRezervacije': instance.pocetakRezervacije?.toIso8601String(),
      'trajanjeRezervacije': instance.trajanjeRezervacije?.toIso8601String(),
      'napomena': instance.napomena,
      'radniProstorId': instance.radniProstorId,
      'statusRezervacijeId': instance.statusRezervacijeId,
    };
