import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:eshopcoffe/models/basket_item/basket_item_model.dart';
import 'package:intl/intl.dart';

part 'basket_model.freezed.dart';
part 'basket_model.g.dart';

@Freezed()
class BasketModel with _$BasketModel {
  const BasketModel._();

  factory BasketModel({
    required String id,
    required List<BasketItemModel> items
  }) = _BasketModel;

  factory BasketModel.fromJson(Map<String, dynamic> json) =>
      _$BasketModelFromJson(json);

  String totalValue() {
    double total = 0;

    for (var item in items) {
      total += item.product.currencyValue * item.amount;
    }

    return NumberFormat.simpleCurrency(
      name: items[0].product.currencyCode, //currencyCode
    ).format(total);
  }
}