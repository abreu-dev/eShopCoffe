import 'package:dio/dio.dart';
import 'package:eshopcoffe/models/product_paged_list/product_paged_list_model.dart';
import 'package:eshopcoffe/services/app_dio.dart';
import 'package:eshopcoffe/models/product/product_model.dart';

class CatalogService {
  final Dio _dio = AppDio.getInstance();

  Future<ProductPagedListModel> getPaged(int page) async {
    try {
      var queryParameters = {
        "page": page.toString(),
        "size": 6
      };
      Response response = await _dio.get('/catalog', queryParameters: queryParameters);
      return ProductPagedListModel.fromJson(response.data);
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<ProductModel> getDetails(String productId) async {
    try {
      Response response = await _dio.get('/catalog/$productId');
      return ProductModel.fromJson(response.data);
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}