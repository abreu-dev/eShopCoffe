// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_ProductModel _$$_ProductModelFromJson(Map<String, dynamic> json) =>
    _$_ProductModel(
      id: json['id'] as String,
      name: json['name'] as String,
      description: json['description'] as String,
      imageUrl: json['imageUrl'] as String,
      quantityAvailable: json['quantityAvailable'] as int,
      currencyCode: json['currencyCode'] as String,
      currencyValue: (json['currencyValue'] as num).toDouble(),
    );

Map<String, dynamic> _$$_ProductModelToJson(_$_ProductModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'imageUrl': instance.imageUrl,
      'quantityAvailable': instance.quantityAvailable,
      'currencyCode': instance.currencyCode,
      'currencyValue': instance.currencyValue,
    };
