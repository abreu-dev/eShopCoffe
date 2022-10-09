import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:intl/intl.dart';

part 'product_model.freezed.dart';
part 'product_model.g.dart';

@Freezed()
class ProductModel with _$ProductModel {
  const ProductModel._();

  factory ProductModel({
    required String id,
    required String name,
    required String description,
    required String imageUrl,
    required int quantityAvailable,
    required String currencyCode,
    required double currencyValue
  }) = _ProductModel;

  factory ProductModel.fromJson(Map<String, dynamic> json) =>
      _$ProductModelFromJson(json);

  bool isAvailable() {
    return quantityAvailable > 0;
  }

  String currencyText() {
    return NumberFormat.simpleCurrency(
      name: currencyCode, //currencyCode
    ).format(currencyValue);
  }
}