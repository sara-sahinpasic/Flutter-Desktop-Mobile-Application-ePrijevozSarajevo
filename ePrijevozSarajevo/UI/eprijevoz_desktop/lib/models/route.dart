import 'package:json_annotation/json_annotation.dart';

part 'route.g.dart';

@JsonSerializable()
class Route {
  int? routeId;
  int? startStationId;
  int? endStationId;
  int? vehicleId;
  DateTime? arrival;
  DateTime? departure;
  //bool? active;
  //bool? activeOnHolidays;
  //bool? activeOnWeekend;

  Route(
      {this.routeId,
      this.startStationId,
      this.endStationId,
      this.vehicleId,
      this.arrival,
      this.departure});

  factory Route.fromJson(Map<String, dynamic> json) => _$RouteFromJson(json);

  Map<String, dynamic> toJson() => _$RouteToJson(this);
}
