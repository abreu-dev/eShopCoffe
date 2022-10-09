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
      Response response = await _dio.post('/identity/sign-in', data: body);
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
      Response response = await _dio.post('/identity/sign-up', data: body);
      return response;
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}