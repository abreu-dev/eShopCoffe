import 'dart:io';
import 'package:dio/dio.dart';
import 'package:eshopcoffe/services/app_dio.dart';
import 'exceptions/service_exception.dart';

class SessionService {
  final Dio _dio = AppDio.getInstance();

  Future<Response> login(String username, String password) async {
    final Map<String, String> body = {
      'login': username,
      'password': password
    };

    try {
      Response response = await _dio.post('/identity/login', data: body);
      return response;
    }
    on DioError catch (error) {
      throw ServiceException(
          statusCode: error.response?.statusCode ?? HttpStatus.requestTimeout,
          message: error.message);
    }
  }
}