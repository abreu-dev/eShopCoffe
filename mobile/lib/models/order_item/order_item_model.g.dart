// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_item_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_OrderItemModel _$$_OrderItemModelFromJson(Map<String, dynamic> json) =>
    _$_OrderItemModel(
      name: json['name'] as String,
      imageUrl: json['imageUrl'] as String,
      amount: json['amount'] as int,
      currencyValue: (json['currencyValue'] as num).toDouble(),
      currencyCode: json['currencyCode'] as String,
    );

Map<String, dynamic> _$$_OrderItemModelToJson(_$_OrderItemModel instance) =>
    <String, dynamic>{
      'name': instance.name,
      'imageUrl': instance.imageUrl,
      'amount': instance.amount,
      'currencyValue': instance.currencyValue,
      'currencyCode': instance.currencyCode,
    };
