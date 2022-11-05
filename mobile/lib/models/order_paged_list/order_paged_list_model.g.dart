// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'order_paged_list_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_OrderPagedListModel _$$_OrderPagedListModelFromJson(
        Map<String, dynamic> json) =>
    _$_OrderPagedListModel(
      data: (json['data'] as List<dynamic>)
          .map((e) => OrderModel.fromJson(e as Map<String, dynamic>))
          .toList(),
      currentPage: json['currentPage'] as int,
      totalItems: json['totalItems'] as int,
      totalPages: json['totalPages'] as int,
    );

Map<String, dynamic> _$$_OrderPagedListModelToJson(
        _$_OrderPagedListModel instance) =>
    <String, dynamic>{
      'data': instance.data,
      'currentPage': instance.currentPage,
      'totalItems': instance.totalItems,
      'totalPages': instance.totalPages,
    };
