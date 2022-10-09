import 'package:dio/dio.dart';
import 'package:eshopcoffe/services/app_dio.dart';

class HealthService {
  final Dio _dio = AppDio.getInstance();

  Future<Response> health() async {
    try {
      Response response = await _dio.get('/health', options: await AppDio.getOptions());
      return response;
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}