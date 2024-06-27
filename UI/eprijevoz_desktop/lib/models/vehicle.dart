import 'package:json_annotation/json_annotation.dart';
part 'vehicle.g.dart';

@JsonSerializable()
class Vehicle {
  int? vehicleId;
  String? registrationNumber;
  int? buildYear;

  Vehicle(
      {this.vehicleId,
      this.registrationNumber,
      this.buildYear}); //kontruktor - moramo ga imati jer imamo factory metodu

  factory Vehicle.fromJson(Map<String, dynamic> json) =>
      _$VehicleFromJson(json);

  Map<String, dynamic> toJson() => _$VehicleToJson(this);
}
