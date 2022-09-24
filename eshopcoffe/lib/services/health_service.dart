import 'dart:io';

import 'package:dio/dio.dart';
import 'package:eshopcoffe/services/app_dio.dart';
import 'package:eshopcoffe/services/exceptions/service_exception.dart';

class HealthService {
  final Dio _dio = AppDio.getInstance();

  Future<Response> health() async {
    try {
      Response response = await _dio.get('/health');
      return response;
    }
    on DioError catch (error) {
      throw ServiceException(
          statusCode: error.response?.statusCode ?? HttpStatus.requestTimeout,
          message: error.message);
    }
  }
}