class Vehicle {
  final int vehicleId;
  final String number;
  final String registrationNumber;
  final String buildYear;
  //final int vehicleTypeId;
  final String vehicleType;
  //final int manufacturerId;
  final String manufacturer;

  Vehicle({
    required this.vehicleId,
    required this.number,
    required this.registrationNumber,
    required this.buildYear,
    required this.vehicleType,
    required this.manufacturer,
  });

  factory Vehicle.fromJson(Map<String, dynamic> json) {
    return Vehicle(
      vehicleId: json['vehicleId'],
      number: json['number'],
      registrationNumber: json['registrationNumber'],
      buildYear: json['buildYear'],
      vehicleType: json['vehicleType'],
      manufacturer: json['manufacturer'],
    );
  }
}
