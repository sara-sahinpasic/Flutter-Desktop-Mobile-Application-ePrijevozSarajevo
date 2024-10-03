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

  /// A necessary factory constructor for creating a new User instance
  /// from a map. Pass the map to the generated `_$UserFromJson()` constructor.
  /// The constructor is named after the source class, in this case, User.
  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  /// `toJson` is the convention for a class to declare support for serialization
  /// to JSON. The implementation simply calls the private, generated
  /// helper method `_$UserToJson`.
  Map<String, dynamic> toJson() => _$UserToJson(this);
}
