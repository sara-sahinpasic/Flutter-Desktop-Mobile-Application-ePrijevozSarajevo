import 'package:eprijevoz_desktop/models/manufacturer.dart';
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

  Vehicle(
      {this.vehicleId,
      this.registrationNumber,
      this.buildYear}); //kontruktor - moramo ga imati jer imamo factory metodu

  factory Vehicle.fromJson(Map<String, dynamic> json) =>
      _$VehicleFromJson(json);

  Map<String, dynamic> toJson() => _$VehicleToJson(this);
}
