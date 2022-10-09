import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:eshopcoffe/models/user/user_model.dart';

part 'authenticated_user_model.freezed.dart';
part 'authenticated_user_model.g.dart';

@Freezed()
class AuthenticatedUserModel with _$AuthenticatedUserModel {
  factory AuthenticatedUserModel({
    required String token,
    required UserModel user
  }) = _AuthenticatedUserModel;

  factory AuthenticatedUserModel.fromJson(Map<String, dynamic> json) =>
      _$AuthenticatedUserModelFromJson(json);
}