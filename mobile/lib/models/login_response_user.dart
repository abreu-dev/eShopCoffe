class LoginResponseUser {
  final String id;
  final String login;
  final bool isAdmin;

  LoginResponseUser(this.id, this.login, this.isAdmin);

  LoginResponseUser.fromJson(Map<String, dynamic> json):
        id = json['id'],
        login = json['login'],
        isAdmin = json['isAdmin'];
}