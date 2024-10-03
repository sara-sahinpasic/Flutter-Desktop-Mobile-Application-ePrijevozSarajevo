import 'package:json_annotation/json_annotation.dart';
part 'user.g.dart';

@JsonSerializable()
class User {
  int? userId;
  //public Role? Role { get; set; }
  String? firstName;
  String? lastName;
  String? email;
  DateTime? dateOfBirth;
  String? phoneNumber;
  String? address;
  DateTime? registrationDate;
  DateTime? modifiedDate;
  bool? active;
  String? userName;
  int? userStatusId;
  String? password;
  String? passwordConfirmation;
  //String? profileImagePath;
  //Status? UserStatus { get; set; }
  //DateTime? statusExpirationDate;
  //virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

  User(
      {this.userId,
      this.firstName,
      this.lastName,
      this.email,
      this.dateOfBirth,
      this.phoneNumber,
      this.address,
      this.registrationDate,
      this.modifiedDate,
      this.active,
      this.userName,
      this.userStatusId,
      this.password,
      this.passwordConfirmation});

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  Map<String, dynamic> toJson() => _$UserToJson(this);
}
