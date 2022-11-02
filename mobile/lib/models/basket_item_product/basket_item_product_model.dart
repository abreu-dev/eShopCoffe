import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:intl/intl.dart';

part 'basket_item_product_model.freezed.dart';
part 'basket_item_product_model.g.dart';

@Freezed()
class BasketItemProductModel with _$BasketItemProductModel {
  const BasketItemProductModel._();

  factory BasketItemProductModel({
    required String id,
    required String name,
    required String imageUrl,
    required String currencyCode,
    required double currencyValue
  }) = _BasketItemProductModel;

  factory BasketItemProductModel.fromJson(Map<String, dynamic> json) =>
      _$BasketItemProductModelFromJson(json);

  String currencyText() {
    return NumberFormat.simpleCurrency(
      name: currencyCode, //currencyCode
    ).format(currencyValue);
  }
}