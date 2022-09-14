import 'package:dio/dio.dart';

import '../config/app_config.dart';

class SessionApi {
  final Dio _dio = Dio();

  Future<String> login(String username, String password) async {
    const String url = '${AppConfig.apiUrlIdentity}/login';
    final Map<String, String> data = {
      'login': username,
      'password': password
    };
    Response response = await _dio.post(url, data: data);
    return response.data['token'];
  }
}