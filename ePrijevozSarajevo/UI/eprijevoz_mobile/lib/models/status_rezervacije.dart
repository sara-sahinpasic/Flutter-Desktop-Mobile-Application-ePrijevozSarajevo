import 'package:json_annotation/json_annotation.dart';

part 'status_rezervacije.g.dart';

@JsonSerializable()
class StatusRezervacije {
  int? statusRezervacijeId;
  String? naziv;

  StatusRezervacije({this.statusRezervacijeId, this.naziv});

  factory StatusRezervacije.fromJson(Map<String, dynamic> json) =>
      _$StatusRezervacijeFromJson(json);

  Map<String, dynamic> toJson() => _$StatusRezervacijeToJson(this);
}
