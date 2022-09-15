import 'login_response_user.dart';

class LoginResponse {
  final String token;
  final LoginResponseUser user;

  LoginResponse(this.token, this.user);

  LoginResponse.fromJson(Map<String, dynamic> json):
      token = json['token'],
      user = LoginResponseUser.fromJson(json['user']);
}
