import 'package:freezed_annotation/freezed_annotation.dart';

part 'address_model.freezed.dart';
part 'address_model.g.dart';

@Freezed()
class AddressModel with _$AddressModel {
  const AddressModel._();

  factory AddressModel({
    required String cep,
    required String number
  }) = _AddressModel;

  factory AddressModel.fromJson(Map<String, dynamic> json) =>
      _$AddressModelFromJson(json);

  String get() {
    return "$cep, n. $number";
  }
}