import 'package:dio/dio.dart';
import 'package:eshopcoffe/services/app_dio.dart';

class SessionService {
  final Dio _dio = AppDio.getInstance();

  Future<Response> signIn(String username, String password) async {
    final Map<String, String> body = {
      'username': username,
      'password': password
    };

    try {
      Response response = await _dio.post('/session/sign-in', data: body);
      return response;
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<Response> signUp(String username, String email, String password) async {
    final Map<String, String> body = {
      'username': username,
      'email': email,
      'password': password
    };

    try {
      Response response = await _dio.post('/session/sign-up', data: body);
      return response;
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<Response> requestPasswordReset(String username) async {
    final Map<String, String> body = {
      'username': username
    };

    try {
      Response response = await _dio.post('/session/password-reset.request', data: body);
      return response;
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<Response> confirmPasswordReset(String username, String newPassword, String passwordResetCode) async {
    final Map<String, String> body = {
      'username': username,
      'newPassword': newPassword,
      'passwordResetCode': passwordResetCode
    };

    try {
      Response response = await _dio.post('/session/password-reset.confirm', data: body);
      return response;
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}