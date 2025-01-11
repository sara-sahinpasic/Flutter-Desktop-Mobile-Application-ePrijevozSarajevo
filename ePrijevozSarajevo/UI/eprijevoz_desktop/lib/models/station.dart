import 'package:json_annotation/json_annotation.dart';

part 'station.g.dart';

@JsonSerializable()
class Station {
  int? stationId;
  String? name;
  DateTime? modifiedDate;

  Station({this.stationId, this.name});

  factory Station.fromJson(Map<String, dynamic> json) =>
      _$StationFromJson(json);

  Map<String, dynamic> toJson() => _$StationToJson(this);
}
