import 'package:json_annotation/json_annotation.dart';
part 'vehicle.g.dart';

@JsonSerializable()
class Vehicle {
  int? vehicleId;
  int? number;
  String? registrationNumber;
  int? buildYear;
  int? manufacturerId;
  int? typeId;

  Vehicle({this.vehicleId, this.registrationNumber, this.buildYear});

  factory Vehicle.fromJson(Map<String, dynamic> json) =>
      _$VehicleFromJson(json);

  Map<String, dynamic> toJson() => _$VehicleToJson(this);
}
