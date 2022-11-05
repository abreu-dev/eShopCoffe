import 'package:freezed_annotation/freezed_annotation.dart';

part 'create_order_item_model.freezed.dart';
part 'create_order_item_model.g.dart';

@Freezed()
class CreateOrderItemModel with _$CreateOrderItemModel {
  factory CreateOrderItemModel({
    required String productId,
    required int amount
  }) = _CreateOrderItemModel;

  factory CreateOrderItemModel.fromJson(Map<String, dynamic> json) =>
      _$CreateOrderItemModelFromJson(json);
}