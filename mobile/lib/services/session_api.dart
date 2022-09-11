import 'dart:developer';

import 'package:dio/dio.dart';

class SessionApi {
  final Dio _dio = Dio();

  Future<String> login(String username, String password) async {
    const String url = 'http://10.0.2.2:5003/identity/login';
    final Map<String, String> data = {
      'login': username,
      'password': password
    };
    Response response = await _dio.post(url, data: data);
    return response.data['token'];
  }
}