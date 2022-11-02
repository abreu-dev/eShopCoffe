import 'package:dio/dio.dart';
import 'package:eshopcoffe/models/product_paged_list/product_paged_list_model.dart';
import 'package:eshopcoffe/services/app_dio.dart';
import 'package:eshopcoffe/models/product/product_model.dart';

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
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<ProductModel> getById(String productId) async {
    try {
      Response response = await _dio.get('/catalog/products/$productId');
      return ProductModel.fromJson(response.data);
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}