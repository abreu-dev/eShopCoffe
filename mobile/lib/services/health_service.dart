import 'package:dio/dio.dart';
import 'package:eshopcoffe/services/app_dio.dart';

class HealthService {
  final Dio _dio = AppDio.getInstance();

  Future<Response> health() async {
    try {
      var options = await AppDio.getOptions();
      Response response = await _dio.get('/health', options: options);
      return response;
    }
    on DioError catch (error) {
      throw Exception(error.message);
    }
  }
}