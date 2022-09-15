import 'dart:developer';

import 'package:dio/dio.dart';
import 'package:mobile/models/bad_request_exception.dart';
import 'package:mobile/models/login_response.dart';

import '../config/app_config.dart';
import '../models/bad_request_response.dart';

class SessionApi {
  static BaseOptions baseOptions = BaseOptions(
    baseUrl: AppConfig.apiUrlIdentity,
    connectTimeout: 5000,
    receiveTimeout: 5000
  );
  final Dio _dio = Dio(baseOptions);

  Future<LoginResponse> login(String username, String password) async {
    final Map<String, String> data = {
      'login': username,
      'password': password
    };

    try {
      Response response = await _dio.post('/login', data: data);
      final LoginResponse loginResponse = LoginResponse.fromJson(response.data);
      return loginResponse;
    }
    on DioError catch (e) {
      if (e.response?.statusCode == 400) {
        final BadRequestResponse badRequestResponse = BadRequestResponse.fromJson(e.response?.data);
        throw BadRequestException(badRequestResponse);
      }

      throw Exception(e.message);
    }
  }
}