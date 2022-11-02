import 'package:eshopcoffe/models/basket_item_product/basket_item_product_model.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'basket_item_model.freezed.dart';
part 'basket_item_model.g.dart';

@Freezed()
class BasketItemModel with _$BasketItemModel {
  factory BasketItemModel({
    required String id,
    required BasketItemProductModel product,
    required int amount,
  }) = _BasketItemModel;

  factory BasketItemModel.fromJson(Map<String, dynamic> json) =>
      _$BasketItemModelFromJson(json);
}