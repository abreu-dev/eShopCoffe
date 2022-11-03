// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_OrderModel _$$_OrderModelFromJson(Map<String, dynamic> json) =>
    _$_OrderModel(
      id: json['id'] as String,
      address: AddressModel.fromJson(json['address'] as Map<String, dynamic>),
      paymentMethod: json['paymentMethod'] as String,
      currencyValue: (json['currencyValue'] as num).toDouble(),
      currencyCode: json['currencyCode'] as String,
      status: json['status'] as String,
      createdDate: DateTime.parse(json['createdDate'] as String),
      events: (json['events'] as List<dynamic>)
          .map((e) => OrderEventModel.fromJson(e as Map<String, dynamic>))
          .toList(),
      items: (json['items'] as List<dynamic>)
          .map((e) => OrderItemModel.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$$_OrderModelToJson(_$_OrderModel instance) =>
    <String, dynamic>{
      'id': instance.id,
      'address': instance.address,
      'paymentMethod': instance.paymentMethod,
      'currencyValue': instance.currencyValue,
      'currencyCode': instance.currencyCode,
      'status': instance.status,
      'createdDate': instance.createdDate.toIso8601String(),
      'events': instance.events,
      'items': instance.items,
    };
