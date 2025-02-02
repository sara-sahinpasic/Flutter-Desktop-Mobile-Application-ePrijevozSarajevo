// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'countRaspolozenja.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

CountRaspolozenja _$CountRaspolozenjaFromJson(Map<String, dynamic> json) =>
    CountRaspolozenja(
      sretanCount: (json['sretanCount'] as num?)?.toInt(),
      tuzanCount: (json['tuzanCount'] as num?)?.toInt(),
      uzbudenCount: (json['uzbudenCount'] as num?)?.toInt(),
      umoranCount: (json['umoranCount'] as num?)?.toInt(),
      podStresomCount: (json['podStresomCount'] as num?)?.toInt(),
    );

Map<String, dynamic> _$CountRaspolozenjaToJson(CountRaspolozenja instance) =>
    <String, dynamic>{
      'sretanCount': instance.sretanCount,
      'tuzanCount': instance.tuzanCount,
      'uzbudenCount': instance.uzbudenCount,
      'umoranCount': instance.umoranCount,
      'podStresomCount': instance.podStresomCount,
    };
