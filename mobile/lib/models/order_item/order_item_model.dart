import 'package:freezed_annotation/freezed_annotation.dart';

part 'order_item_model.freezed.dart';
part 'order_item_model.g.dart';

@Freezed()
class OrderItemModel with _$OrderItemModel {
  const OrderItemModel._();

  factory OrderItemModel({
    required String name,
    required String imageUrl,
    required int amount,
    required double currencyValue,
    required String currencyCode,
  }) = _OrderItemModel;

  factory OrderItemModel.fromJson(Map<String, dynamic> json) =>
      _$OrderItemModelFromJson(json);
}