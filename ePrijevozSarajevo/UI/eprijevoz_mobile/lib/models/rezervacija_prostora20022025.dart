import 'package:json_annotation/json_annotation.dart';

part 'rezervacija_prostora20022025.g.dart';

@JsonSerializable()
class RezervacijaProstora20022025 {
  int? rezervacijaProstora20022025Id;
  int? userId;
  DateTime? pocetakRezervacije;
  DateTime? trajanjeRezervacije;
  String? napomena;
  int? radniProstorId;
  int? statusRezervacijeId;

  RezervacijaProstora20022025(
      {this.rezervacijaProstora20022025Id,
      this.userId,
      this.pocetakRezervacije,
      this.trajanjeRezervacije,
      this.napomena,
      this.radniProstorId,
      this.statusRezervacijeId});

  factory RezervacijaProstora20022025.fromJson(Map<String, dynamic> json) =>
      _$RezervacijaProstora20022025FromJson(json);

  Map<String, dynamic> toJson() => _$RezervacijaProstora20022025ToJson(this);
}
