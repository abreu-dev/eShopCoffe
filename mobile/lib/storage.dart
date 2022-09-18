import 'package:flutter_secure_storage/flutter_secure_storage.dart';

class LocalStorage {
  static const String userKey = 'user';
  static const _storage = FlutterSecureStorage();

  static Future<void> writeUser(String user) async {
    await _storage.write(key: userKey, value: user);
  }

  static Future<void> deleteUser() async {
    await _storage.delete(key: userKey);
  }

  static Future<String?> getUser() async {
    return await _storage.read(key: userKey);
  }
}
