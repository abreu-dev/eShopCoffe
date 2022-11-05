// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'order_paged_list_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

OrderPagedListModel _$OrderPagedListModelFromJson(Map<String, dynamic> json) {
  return _OrderPagedListModel.fromJson(json);
}

/// @nodoc
mixin _$OrderPagedListModel {
  List<OrderModel> get data => throw _privateConstructorUsedError;
  int get currentPage => throw _privateConstructorUsedError;
  int get totalItems => throw _privateConstructorUsedError;
  int get totalPages => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $OrderPagedListModelCopyWith<OrderPagedListModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $OrderPagedListModelCopyWith<$Res> {
  factory $OrderPagedListModelCopyWith(
          OrderPagedListModel value, $Res Function(OrderPagedListModel) then) =
      _$OrderPagedListModelCopyWithImpl<$Res, OrderPagedListModel>;
  @useResult
  $Res call(
      {List<OrderModel> data, int currentPage, int totalItems, int totalPages});
}

/// @nodoc
class _$OrderPagedListModelCopyWithImpl<$Res, $Val extends OrderPagedListModel>
    implements $OrderPagedListModelCopyWith<$Res> {
  _$OrderPagedListModelCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? data = null,
    Object? currentPage = null,
    Object? totalItems = null,
    Object? totalPages = null,
  }) {
    return _then(_value.copyWith(
      data: null == data
          ? _value.data
          : data // ignore: cast_nullable_to_non_nullable
              as List<OrderModel>,
      currentPage: null == currentPage
          ? _value.currentPage
          : currentPage // ignore: cast_nullable_to_non_nullable
              as int,
      totalItems: null == totalItems
          ? _value.totalItems
          : totalItems // ignore: cast_nullable_to_non_nullable
              as int,
      totalPages: null == totalPages
          ? _value.totalPages
          : totalPages // ignore: cast_nullable_to_non_nullable
              as int,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$_OrderPagedListModelCopyWith<$Res>
    implements $OrderPagedListModelCopyWith<$Res> {
  factory _$$_OrderPagedListModelCopyWith(_$_OrderPagedListModel value,
          $Res Function(_$_OrderPagedListModel) then) =
      __$$_OrderPagedListModelCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {List<OrderModel> data, int currentPage, int totalItems, int totalPages});
}

/// @nodoc
class __$$_OrderPagedListModelCopyWithImpl<$Res>
    extends _$OrderPagedListModelCopyWithImpl<$Res, _$_OrderPagedListModel>
    implements _$$_OrderPagedListModelCopyWith<$Res> {
  __$$_OrderPagedListModelCopyWithImpl(_$_OrderPagedListModel _value,
      $Res Function(_$_OrderPagedListModel) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? data = null,
    Object? currentPage = null,
    Object? totalItems = null,
    Object? totalPages = null,
  }) {
    return _then(_$_OrderPagedListModel(
      data: null == data
          ? _value._data
          : data // ignore: cast_nullable_to_non_nullable
              as List<OrderModel>,
      currentPage: null == currentPage
          ? _value.currentPage
          : currentPage // ignore: cast_nullable_to_non_nullable
              as int,
      totalItems: null == totalItems
          ? _value.totalItems
          : totalItems // ignore: cast_nullable_to_non_nullable
              as int,
      totalPages: null == totalPages
          ? _value.totalPages
          : totalPages // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_OrderPagedListModel implements _OrderPagedListModel {
  _$_OrderPagedListModel(
      {required final List<OrderModel> data,
      required this.currentPage,
      required this.totalItems,
      required this.totalPages})
      : _data = data;

  factory _$_OrderPagedListModel.fromJson(Map<String, dynamic> json) =>
      _$$_OrderPagedListModelFromJson(json);

  final List<OrderModel> _data;
  @override
  List<OrderModel> get data {
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_data);
  }

  @override
  final int currentPage;
  @override
  final int totalItems;
  @override
  final int totalPages;

  @override
  String toString() {
    return 'OrderPagedListModel(data: $data, currentPage: $currentPage, totalItems: $totalItems, totalPages: $totalPages)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_OrderPagedListModel &&
            const DeepCollectionEquality().equals(other._data, _data) &&
            (identical(other.currentPage, currentPage) ||
                other.currentPage == currentPage) &&
            (identical(other.totalItems, totalItems) ||
                other.totalItems == totalItems) &&
            (identical(other.totalPages, totalPages) ||
                other.totalPages == totalPages));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      const DeepCollectionEquality().hash(_data),
      currentPage,
      totalItems,
      totalPages);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_OrderPagedListModelCopyWith<_$_OrderPagedListModel> get copyWith =>
      __$$_OrderPagedListModelCopyWithImpl<_$_OrderPagedListModel>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_OrderPagedListModelToJson(
      this,
    );
  }
}

abstract class _OrderPagedListModel implements OrderPagedListModel {
  factory _OrderPagedListModel(
      {required final List<OrderModel> data,
      required final int currentPage,
      required final int totalItems,
      required final int totalPages}) = _$_OrderPagedListModel;

  factory _OrderPagedListModel.fromJson(Map<String, dynamic> json) =
      _$_OrderPagedListModel.fromJson;

  @override
  List<OrderModel> get data;
  @override
  int get currentPage;
  @override
  int get totalItems;
  @override
  int get totalPages;
  @override
  @JsonKey(ignore: true)
  _$$_OrderPagedListModelCopyWith<_$_OrderPagedListModel> get copyWith =>
      throw _privateConstructorUsedError;
}
