// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_event_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_OrderEventModel _$$_OrderEventModelFromJson(Map<String, dynamic> json) =>
    _$_OrderEventModel(
      status: json['status'] as String,
      date: DateTime.parse(json['date'] as String),
    );

Map<String, dynamic> _$$_OrderEventModelToJson(_$_OrderEventModel instance) =>
    <String, dynamic>{
      'status': instance.status,
      'date': instance.date.toIso8601String(),
    };
