import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:eshopcoffe/models/basket_item/basket_item_model.dart';

part 'basket_model.freezed.dart';
part 'basket_model.g.dart';

@Freezed()
class BasketModel with _$BasketModel {
  factory BasketModel({
    required String id,
    required List<BasketItemModel> items
  }) = _BasketModel;

  factory BasketModel.fromJson(Map<String, dynamic> json) =>
      _$BasketModelFromJson(json);
}