import 'package:json_annotation/json_annotation.dart';
part 'moodTracker30012025.g.dart';

@JsonSerializable()
class MoodTracker30012025 {
  int? moodTracker30012025Id;
  int? userId;
  int? vrijednostRaspolozenjaId;
  String? opis;
  DateTime? datumEvidencije;

  MoodTracker30012025(
      {this.moodTracker30012025Id,
      this.userId,
      this.vrijednostRaspolozenjaId,
      this.opis,
      this.datumEvidencije});
  factory MoodTracker30012025.fromJson(Map<String, dynamic> json) =>
      _$MoodTracker30012025FromJson(json);

  Map<String, dynamic> toJson() => _$MoodTracker30012025ToJson(this);
}
