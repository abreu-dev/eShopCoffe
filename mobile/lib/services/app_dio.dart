import 'dart:convert';
import 'dart:io';
import 'package:dio/dio.dart';
import 'package:dio/adapter.dart';
import 'package:flutter/foundation.dart';
import 'package:eshopcoffe/models/authenticated_user/authenticated_user_model.dart';
import 'package:eshopcoffe/utils/local_storage.dart';
import 'package:eshopcoffe/services/exceptions/bad_request_exception.dart';
import 'package:eshopcoffe/services/exceptions/models/bad_request_response_model.dart';
import 'package:eshopcoffe/services/exceptions/service_exception.dart';
import 'package:eshopcoffe/flavors.dart';

class AppDio with DioMixin implements Dio {
  AppDio._([BaseOptions? options]) {
    options = BaseOptions(
        baseUrl: F.apiUrl,
        contentType: 'application/json',
        connectTimeout: 5000,
        sendTimeout: 5000,
        receiveTimeout: 5000
    );

    this.options = options;

    if (kDebugMode) {
      // Local Log
      interceptors.add(LogInterceptor(responseBody: true, requestBody: true));
    }

    httpClientAdapter = DefaultHttpClientAdapter();
  }

  static Dio getInstance() => AppDio._();

  static Future<Options> getOptions() async {
    var value = await LocalStorage.getUser();
    if (value == null) return Options();

    var model = AuthenticatedUserModel.fromJson(json.decode(value));
    return Options(
        headers: {
          "Authorization": model.token
        }
    );
  }

  static Exception getTreatedDioError(DioError error) {
    if (error.response == null || error.response?.statusCode != 400) {
      return ServiceException(
          statusCode: error.response?.statusCode ?? HttpStatus.requestTimeout,
          message: error.message);
    }

    final BadRequestResponseModel model = BadRequestResponseModel.fromJson(error.response?.data);
    return BadRequestException(model);
  }
}