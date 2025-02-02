import 'package:json_annotation/json_annotation.dart';

part 'countRaspolozenja.g.dart';

@JsonSerializable()
class CountRaspolozenja {
  int? sretanCount;
  int? tuzanCount;
  int? uzbudenCount;
  int? umoranCount;
  int? podStresomCount;

  CountRaspolozenja(
      {this.sretanCount,
      this.tuzanCount,
      this.uzbudenCount,
      this.umoranCount,
      this.podStresomCount});

  factory CountRaspolozenja.fromJson(Map<String, dynamic> json) =>
      _$CountRaspolozenjaFromJson(json);

  Map<String, dynamic> toJson() => _$CountRaspolozenjaToJson(this);
}
