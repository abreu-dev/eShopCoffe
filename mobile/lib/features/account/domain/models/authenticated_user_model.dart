import 'dart:convert';

class AuthenticatedUserModel {
  final String token;
  final String id;
  final String username;

  AuthenticatedUserModel(this.token, this.id, this.username);

  AuthenticatedUserModel.fromJson(Map<String, dynamic> json):
    token = json['token'],
    id = json['user']['id'],
    username = json['user']['login'];

  static Map<String, dynamic> toJson(AuthenticatedUserModel model) => {
    'token': model.token,
    'user': {
      'id': model.id,
      'login': model.username
    }
  };

  static String serialize(AuthenticatedUserModel model) {
    return json.encode(AuthenticatedUserModel.toJson(model));
  }

  static AuthenticatedUserModel deserialize(String value) {
    return AuthenticatedUserModel.fromJson(json.decode(value));
  }
}