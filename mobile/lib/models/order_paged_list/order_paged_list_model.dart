import 'package:eshopcoffe/models/order/order_model.dart';
import 'package:freezed_annotation/freezed_annotation.dart';

part 'order_paged_list_model.freezed.dart';
part 'order_paged_list_model.g.dart';

@Freezed()
class OrderPagedListModel with _$OrderPagedListModel {
  factory OrderPagedListModel({
    required List<OrderModel> data,
    required int currentPage,
    required int totalItems,
    required int totalPages
  }) = _OrderPagedListModel;

  factory OrderPagedListModel.fromJson(Map<String, dynamic> json) =>
      _$OrderPagedListModelFromJson(json);
}