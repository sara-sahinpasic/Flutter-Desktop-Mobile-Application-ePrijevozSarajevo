import 'package:json_annotation/json_annotation.dart';

part 'total_dto.g.dart';

@JsonSerializable()
class TotalDto {
  int? countRaspolozenja;
  int? vrijednostRaspolozenjaId;

  TotalDto({this.countRaspolozenja, this.vrijednostRaspolozenjaId});
  factory TotalDto.fromJson(Map<String, dynamic> json) =>
      _$TotalDtoFromJson(json);

  Map<String, dynamic> toJson() => _$TotalDtoToJson(this);
}
