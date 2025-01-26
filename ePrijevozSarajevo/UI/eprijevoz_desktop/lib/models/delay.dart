import 'package:json_annotation/json_annotation.dart';

part 'delay.g.dart';

@JsonSerializable()
class Delay {
  int? delayId;
  String? reason;
  int? routeId;
  int? delayAmountMinutes;
  int? typeId;

  Delay(
      {this.delayId,
      this.reason,
      this.routeId,
      this.delayAmountMinutes,
      this.typeId});

  factory Delay.fromJson(Map<String, dynamic> json) => _$DelayFromJson(json);

  Map<String, dynamic> toJson() => _$DelayToJson(this);
}
