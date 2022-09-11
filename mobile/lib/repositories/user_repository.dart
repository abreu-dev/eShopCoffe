import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class UserRepository {
  static String tokenKey = 'token';

  final FlutterSecureStorage storage = const FlutterSecureStorage();

  Future<void> persistToken(String token) async{
    storage.write(key: tokenKey, value: token);
  }

  Future<bool> hasToken() async {
    String? token = await storage.read(key: tokenKey);
    return token != null;
  }

  Future<void> deleteToken() async{
    await storage.delete(key: tokenKey);
  }
}