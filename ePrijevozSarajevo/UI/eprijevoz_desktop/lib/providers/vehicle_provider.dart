import 'package:eprijevoz_desktop/models/vehicle.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class VehicleProvider extends BaseProvider<Vehicle> {
  VehicleProvider() : super("Vehicle");

  @override
  Vehicle fromJson(data) {
    return Vehicle.fromJson(data);
  }
}
