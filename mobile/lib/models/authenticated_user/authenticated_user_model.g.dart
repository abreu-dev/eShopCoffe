// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'authenticated_user_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_AuthenticatedUserModel _$$_AuthenticatedUserModelFromJson(
        Map<String, dynamic> json) =>
    _$_AuthenticatedUserModel(
      token: json['token'] as String,
      user: UserModel.fromJson(json['user'] as Map<String, dynamic>),
    );

Map<String, dynamic> _$$_AuthenticatedUserModelToJson(
        _$_AuthenticatedUserModel instance) =>
    <String, dynamic>{
      'token': instance.token,
      'user': instance.user,
    };
