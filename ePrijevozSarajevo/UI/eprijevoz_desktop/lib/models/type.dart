import 'package:json_annotation/json_annotation.dart';

part 'type.g.dart';

@JsonSerializable()
class Type {
  int? typeId;
  String? name;
  DateTime? modifiedDate;

  Type({this.typeId, this.name});

  factory Type.fromJson(Map<String, dynamic> json) => _$TypeFromJson(json);

  /// Connect the generated [_$PersonToJson] function to the `toJson` method.
  Map<String, dynamic> toJson() => _$TypeToJson(this);
}
