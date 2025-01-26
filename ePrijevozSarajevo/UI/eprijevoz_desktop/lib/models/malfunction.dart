import 'package:json_annotation/json_annotation.dart';
part 'malfunction.g.dart';

@JsonSerializable()
class Malfunction {
  int? malfunctionId;
  String? description;
  DateTime? dateOfMalufunction;
  bool? fixed;
  int? vehicleId;
  int? stationId;

  Malfunction(
      {this.malfunctionId,
      this.description,
      this.dateOfMalufunction,
      this.fixed,
      this.vehicleId,
      this.stationId});

  factory Malfunction.fromJson(Map<String, dynamic> json) =>
      _$MalfunctionFromJson(json);

  Map<String, dynamic> toJson() => _$MalfunctionToJson(this);
}
