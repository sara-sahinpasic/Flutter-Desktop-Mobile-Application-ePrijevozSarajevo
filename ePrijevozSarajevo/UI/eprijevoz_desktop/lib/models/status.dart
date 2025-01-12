import 'package:json_annotation/json_annotation.dart';
part 'status.g.dart';

@JsonSerializable()
class Status {
  int? statusId;
  String? name;
  double? discount;
  DateTime? modifiedDate;
  int? currentUserId;

  Status({this.statusId, this.name, this.discount});

  factory Status.fromJson(Map<String, dynamic> json) => _$StatusFromJson(json);

  Map<String, dynamic> toJson() => _$StatusToJson(this);
}
