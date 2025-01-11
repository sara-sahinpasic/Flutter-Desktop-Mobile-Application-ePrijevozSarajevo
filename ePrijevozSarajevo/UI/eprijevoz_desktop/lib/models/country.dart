import 'package:json_annotation/json_annotation.dart';
part 'country.g.dart';

@JsonSerializable()
class Country {
  int? countryId;
  String? name;
  DateTime? modifiedDate;
  int? currentUserId;

  Country({this.countryId, this.name});

  factory Country.fromJson(Map<String, dynamic> json) =>
      _$CountryFromJson(json);

  Map<String, dynamic> toJson() => _$CountryToJson(this);
}
