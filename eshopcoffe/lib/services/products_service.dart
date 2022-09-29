import 'dart:io';
import 'package:dio/dio.dart';
import 'package:eshopcoffe/models/product_paged_list/product_paged_list_model.dart';
import 'package:eshopcoffe/services/app_dio.dart';
import 'package:eshopcoffe/services/exceptions/service_exception.dart';

class ProductsService {
  final Dio _dio = AppDio.getInstance();

  Future<ProductPagedListModel> get(int page) async {
    try {
      var queryParameters = {
        "page": page.toString(),
        "size": 4
      };
      Response response = await _dio.get('/catalog/products', queryParameters: queryParameters);
      return ProductPagedListModel.fromJson(response.data);
    }
    on DioError catch (error) {
      throw ServiceException(
          statusCode: error.response?.statusCode ?? HttpStatus.requestTimeout,
          message: error.message);
    }
  }
}