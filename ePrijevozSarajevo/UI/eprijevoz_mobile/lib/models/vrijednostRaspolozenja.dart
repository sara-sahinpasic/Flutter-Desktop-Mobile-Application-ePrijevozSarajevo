import 'package:json_annotation/json_annotation.dart';

part 'vrijednostRaspolozenja.g.dart';

@JsonSerializable()
class VrijednostRaspolozenja {
  int? vrijednostRaspolozenjaId;
  String? naziv;

  VrijednostRaspolozenja({this.vrijednostRaspolozenjaId, this.naziv});

  factory VrijednostRaspolozenja.fromJson(Map<String, dynamic> json) =>
      _$VrijednostRaspolozenjaFromJson(json);

  Map<String, dynamic> toJson() => _$VrijednostRaspolozenjaToJson(this);
}
