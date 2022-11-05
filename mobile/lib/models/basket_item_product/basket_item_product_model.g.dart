// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'basket_item_product_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_BasketItemProductModel _$$_BasketItemProductModelFromJson(
        Map<String, dynamic> json) =>
    _$_BasketItemProductModel(
      id: json['id'] as String,
      name: json['name'] as String,
      imageUrl: json['imageUrl'] as String,
      currencyCode: json['currencyCode'] as String,
      currencyValue: (json['currencyValue'] as num).toDouble(),
    );

Map<String, dynamic> _$$_BasketItemProductModelToJson(
        _$_BasketItemProductModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'imageUrl': instance.imageUrl,
      'currencyCode': instance.currencyCode,
      'currencyValue': instance.currencyValue,
    };
