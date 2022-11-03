import 'package:freezed_annotation/freezed_annotation.dart';

part 'order_event_model.freezed.dart';
part 'order_event_model.g.dart';

@Freezed()
class OrderEventModel with _$OrderEventModel {
  const OrderEventModel._();

  factory OrderEventModel({
    required String status,
    required DateTime date
  }) = _OrderEventModel;

  factory OrderEventModel.fromJson(Map<String, dynamic> json) =>
      _$OrderEventModelFromJson(json);
}