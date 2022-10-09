import 'package:eshopcoffe/models/product/product_model.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'product_paged_list_model.freezed.dart';
part 'product_paged_list_model.g.dart';

@Freezed()
class ProductPagedListModel with _$ProductPagedListModel {
  factory ProductPagedListModel({
    required List<ProductModel> data,
    required int currentPage,
    required int totalItems,
    required int totalPages
  }) = _ProductPagedListModel;

  factory ProductPagedListModel.fromJson(Map<String, dynamic> json) =>
      _$ProductPagedListModelFromJson(json);
}