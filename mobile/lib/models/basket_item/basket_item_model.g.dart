// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'basket_item_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_BasketItemModel _$$_BasketItemModelFromJson(Map<String, dynamic> json) =>
    _$_BasketItemModel(
      id: json['id'] as String,
      product: BasketItemProductModel.fromJson(
          json['product'] as Map<String, dynamic>),
      amount: json['amount'] as int,
    );

Map<String, dynamic> _$$_BasketItemModelToJson(_$_BasketItemModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'product': instance.product,
      'amount': instance.amount,
    };
