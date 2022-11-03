import 'package:dio/dio.dart';
import 'package:eshopcoffe/models/order_paged_list/order_paged_list_model.dart';
import 'package:eshopcoffe/services/app_dio.dart';
import 'package:eshopcoffe/models/order/order_model.dart';

class OrdersService {
  final Dio _dio = AppDio.getInstance();

  Future<OrderPagedListModel> getPaged(int page) async {
    try {
      var queryParameters = {
        "page": page.toString(),
        "size": 15
      };
      Response response = await _dio.get('/orders', queryParameters: queryParameters, options: await AppDio.getOptions());
      return OrderPagedListModel.fromJson(response.data);
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<OrderModel> getDetails(String orderId) async {
    try {
      Response response = await _dio.get('/orders/$orderId', options: await AppDio.getOptions());
      return OrderModel.fromJson(response.data);
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}