import 'package:dio/dio.dart';
import 'package:eshopcoffe/models/basket/basket_model.dart';
import 'package:eshopcoffe/services/app_dio.dart';

class BasketsService {
  final Dio _dio = AppDio.getInstance();

  Future<BasketModel> get() async {
    try {
      Response response = await _dio.get('/baskets', options: await AppDio.getOptions());
      return BasketModel.fromJson(response.data);
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<void> addToBasket(String productId, int amount) async {
    final Map<String, String> body = {
      'productId': productId,
      'amount': amount.toString(),
      'increase': 'true'
    };

    try {
      await _dio.post('/baskets', data: body, options: await AppDio.getOptions());
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }

  Future<void> removeFromBasket(String productId) async {
    try {
      await _dio.delete('/baskets/$productId', options: await AppDio.getOptions());
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}