import 'package:dio/dio.dart';
import 'package:eshopcoffe/models/order_paged_list/order_paged_list_model.dart';
import 'package:eshopcoffe/services/app_dio.dart';
import 'package:eshopcoffe/models/order/order_model.dart';

import '../models/create_order_item/create_order_item_model.dart';
import '../models/payment_method/payment_method_enum.dart';

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

  Future<void> post(
      String cep,
      String number,
      PaymentMethodEnum? paymentMethod,
      List<CreateOrderItemModel> items) async {

    var itemsDto = [];
    for (final i in items) {
      itemsDto.add(
        {
          'productId': i.productId,
          'amount': i.amount.toString()
        }
      );
    }

    final Map<String, dynamic> body = {
      'address': {
        'cep': cep,
        'number': number
      },
      'paymentMethod': getEnumDesc(paymentMethod ?? PaymentMethodEnum.none),
      'items': itemsDto,
      'clearBasket': 'true'
    };

    try {
      await _dio.post('/orders', data: body, options: await AppDio.getOptions());
    }
    on DioError catch (error) {
      throw AppDio.getTreatedDioError(error);
    }
  }
}