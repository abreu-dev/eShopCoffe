import 'package:dio/dio.dart';
import 'package:dio/adapter.dart';
import 'package:flutter/foundation.dart';
import 'package:eshopcoffe/models/authenticated_user_model.dart';
import 'package:eshopcoffe/storage.dart';

class AppDio with DioMixin implements Dio {
  AppDio._([BaseOptions? options]) {
    options = BaseOptions(
      baseUrl: 'http://10.0.2.2:5003',
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

    var model = AuthenticatedUserModel.deserialize(value);
    return Options(
      headers: {
        "Authorization": model.token
      }
    );
  }
}