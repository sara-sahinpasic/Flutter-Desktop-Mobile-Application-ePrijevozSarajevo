import 'package:json_annotation/json_annotation.dart';
part 'request.g.dart';

@JsonSerializable()
class Request {
  int? requestId;
  int? userStatusId;
  int? userId;
  DateTime? dateCreated;
  bool? approved;
  String? rejectionReason;
  bool? active;

  Request(
      {this.requestId,
      this.userStatusId,
      this.userId,
      this.dateCreated,
      this.approved,
      this.rejectionReason,
      this.active});

  factory Request.fromJson(Map<String, dynamic> json) =>
      _$RequestFromJson(json);

  Map<String, dynamic> toJson() => _$RequestToJson(this);
}
