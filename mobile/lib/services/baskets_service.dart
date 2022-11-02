import 'package:dio/dio.dart';
import 'package:eshopcoffe/services/app_dio.dart';

class BasketsService {
  final Dio _dio = AppDio.getInstance();

  Future<void> addToCart(String productId, int amount) async {
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
}