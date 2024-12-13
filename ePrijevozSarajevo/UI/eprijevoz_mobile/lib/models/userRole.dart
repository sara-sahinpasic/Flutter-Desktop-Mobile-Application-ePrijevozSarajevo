import 'package:json_annotation/json_annotation.dart';
part 'userRole.g.dart';

@JsonSerializable()
class UserRole {
  int? userRoleId;
  int? userId;
  int? roleId;

  UserRole({this.userRoleId, this.userId, this.roleId});

  factory UserRole.fromJson(Map<String, dynamic> json) =>
      _$UserRoleFromJson(json);

  Map<String, dynamic> toJson() => _$UserRoleToJson(this);
}
