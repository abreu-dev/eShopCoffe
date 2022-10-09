// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product_paged_list_model.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_$_ProductPagedListModel _$$_ProductPagedListModelFromJson(
        Map<String, dynamic> json) =>
    _$_ProductPagedListModel(
      data: (json['data'] as List<dynamic>)
          .map((e) => ProductModel.fromJson(e as Map<String, dynamic>))
          .toList(),
      currentPage: json['currentPage'] as int,
      totalItems: json['totalItems'] as int,
      totalPages: json['totalPages'] as int,
    );

Map<String, dynamic> _$$_ProductPagedListModelToJson(
        _$_ProductPagedListModel instance) =>
    <String, dynamic>{
      'data': instance.data,
      'currentPage': instance.currentPage,
      'totalItems': instance.totalItems,
      'totalPages': instance.totalPages,
    };
