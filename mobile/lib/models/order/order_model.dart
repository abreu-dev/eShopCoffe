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

  String formattedDate() {
    return DateFormat('dd/MM/yyyy HH:mm').format(createdDate.toLocal());
  }

  String statusText() {
    if (status == 'Pending') return 'Pendente';
    if (status == 'Confirmed') return 'Confirmado';
    if (status == 'In Production') return 'Em produção';
    if (status == 'In DeliveryRoute') return 'Em rota de entrega';
    if (status == 'Delivered') return 'Entregue';
    else return status;
  }

  String paymentMethodText() {
    if (paymentMethod == 'Cash') return 'Dinheiro';
    if (paymentMethod == 'Credit Card') return 'Cartão de crédito';
    if (paymentMethod == 'Debit Card') return 'Cartão de débito';
    if (paymentMethod == 'Pix') return 'Pix';
    else return paymentMethod;
  }
}