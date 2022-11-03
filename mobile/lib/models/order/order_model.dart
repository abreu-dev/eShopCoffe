import 'package:eshopcoffe/models/address/address_model.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

import 'package:eshopcoffe/models/order_item/order_item_model.dart';
import 'package:eshopcoffe/models/order_event/order_event_model.dart';
import 'package:intl/intl.dart';

part 'order_model.freezed.dart';
part 'order_model.g.dart';

@Freezed()
class OrderModel with _$OrderModel {
  const OrderModel._();

  factory OrderModel({
    required String id,
    required AddressModel address,
    required String paymentMethod,
    required double currencyValue,
    required String currencyCode,
    required String status,
    required DateTime createdDate,
    required List<OrderEventModel> events,
    required List<OrderItemModel> items
  }) = _OrderModel;

  factory OrderModel.fromJson(Map<String, dynamic> json) =>
      _$OrderModelFromJson(json);

  String currencyText() {
    return NumberFormat.simpleCurrency(
      name: currencyCode, //currencyCode
    ).format(currencyValue);
  }
}