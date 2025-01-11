import 'package:json_annotation/json_annotation.dart';

part 'manufacturer.g.dart';

@JsonSerializable()
class Manufacturer {
  int? manufacturerId;
  String? name;
  DateTime? modifiedDate;
  int? manufacturerCountryId;

  Manufacturer({this.manufacturerId, this.name});

  factory Manufacturer.fromJson(Map<String, dynamic> json) =>
      _$ManufacturerFromJson(json);

  /// Connect the generated [_$PersonToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$ManufacturerToJson(this);
}
