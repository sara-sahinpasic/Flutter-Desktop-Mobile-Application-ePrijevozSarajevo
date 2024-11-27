// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

User _$UserFromJson(Map<String, dynamic> json) => User(
      userId: (json['userId'] as num?)?.toInt(),
      firstName: json['firstName'] as String?,
      lastName: json['lastName'] as String?,
      email: json['email'] as String?,
      dateOfBirth: json['dateOfBirth'] == null
          ? null
          : DateTime.parse(json['dateOfBirth'] as String),
      phoneNumber: json['phoneNumber'] as String?,
      address: json['address'] as String?,
      zipCode: json['zipCode'] as String?,
      city: json['city'] as String?,
      userCountryId: (json['userCountryId'] as num?)?.toInt(),
      registrationDate: json['registrationDate'] == null
          ? null
          : DateTime.parse(json['registrationDate'] as String),
      modifiedDate: json['modifiedDate'] == null
          ? null
          : DateTime.parse(json['modifiedDate'] as String),
      active: json['active'] as bool?,
      userName: json['userName'] as String?,
      userStatusId: (json['userStatusId'] as num?)?.toInt(),
      password: json['password'] as String?,
      passwordConfirmation: json['passwordConfirmation'] as String?,
      roleId: (json['roleId'] as num?)?.toInt(),
      profileImage: json['profileImage'] as String?,
    );

Map<String, dynamic> _$UserToJson(User instance) => <String, dynamic>{
      'userId': instance.userId,
      'firstName': instance.firstName,
      'lastName': instance.lastName,
      'email': instance.email,
      'dateOfBirth': instance.dateOfBirth?.toIso8601String(),
      'phoneNumber': instance.phoneNumber,
      'address': instance.address,
      'zipCode': instance.zipCode,
      'city': instance.city,
      'userCountryId': instance.userCountryId,
      'registrationDate': instance.registrationDate?.toIso8601String(),
      'modifiedDate': instance.modifiedDate?.toIso8601String(),
      'active': instance.active,
      'userName': instance.userName,
      'userStatusId': instance.userStatusId,
      'password': instance.password,
      'passwordConfirmation': instance.passwordConfirmation,
      'profileImage': instance.profileImage,
      'roleId': instance.roleId,
    };
