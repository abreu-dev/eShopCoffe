// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'product_paged_list_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

ProductPagedListModel _$ProductPagedListModelFromJson(
    Map<String, dynamic> json) {
  return _ProductPagedListModel.fromJson(json);
}

/// @nodoc
mixin _$ProductPagedListModel {
  List<ProductModel> get data => throw _privateConstructorUsedError;
  int get currentPage => throw _privateConstructorUsedError;
  int get totalItems => throw _privateConstructorUsedError;
  int get totalPages => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $ProductPagedListModelCopyWith<ProductPagedListModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ProductPagedListModelCopyWith<$Res> {
  factory $ProductPagedListModelCopyWith(ProductPagedListModel value,
          $Res Function(ProductPagedListModel) then) =
      _$ProductPagedListModelCopyWithImpl<$Res>;
  $Res call(
      {List<ProductModel> data,
      int currentPage,
      int totalItems,
      int totalPages});
}

/// @nodoc
class _$ProductPagedListModelCopyWithImpl<$Res>
    implements $ProductPagedListModelCopyWith<$Res> {
  _$ProductPagedListModelCopyWithImpl(this._value, this._then);

  final ProductPagedListModel _value;
  // ignore: unused_field
  final $Res Function(ProductPagedListModel) _then;

  @override
  $Res call({
    Object? data = freezed,
    Object? currentPage = freezed,
    Object? totalItems = freezed,
    Object? totalPages = freezed,
  }) {
    return _then(_value.copyWith(
      data: data == freezed
          ? _value.data
          : data // ignore: cast_nullable_to_non_nullable
              as List<ProductModel>,
      currentPage: currentPage == freezed
          ? _value.currentPage
          : currentPage // ignore: cast_nullable_to_non_nullable
              as int,
      totalItems: totalItems == freezed
          ? _value.totalItems
          : totalItems // ignore: cast_nullable_to_non_nullable
              as int,
      totalPages: totalPages == freezed
          ? _value.totalPages
          : totalPages // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc
abstract class _$$_ProductPagedListModelCopyWith<$Res>
    implements $ProductPagedListModelCopyWith<$Res> {
  factory _$$_ProductPagedListModelCopyWith(_$_ProductPagedListModel value,
          $Res Function(_$_ProductPagedListModel) then) =
      __$$_ProductPagedListModelCopyWithImpl<$Res>;
  @override
  $Res call(
      {List<ProductModel> data,
      int currentPage,
      int totalItems,
      int totalPages});
}

/// @nodoc
class __$$_ProductPagedListModelCopyWithImpl<$Res>
    extends _$ProductPagedListModelCopyWithImpl<$Res>
    implements _$$_ProductPagedListModelCopyWith<$Res> {
  __$$_ProductPagedListModelCopyWithImpl(_$_ProductPagedListModel _value,
      $Res Function(_$_ProductPagedListModel) _then)
      : super(_value, (v) => _then(v as _$_ProductPagedListModel));

  @override
  _$_ProductPagedListModel get _value =>
      super._value as _$_ProductPagedListModel;

  @override
  $Res call({
    Object? data = freezed,
    Object? currentPage = freezed,
    Object? totalItems = freezed,
    Object? totalPages = freezed,
  }) {
    return _then(_$_ProductPagedListModel(
      data: data == freezed
          ? _value._data
          : data // ignore: cast_nullable_to_non_nullable
              as List<ProductModel>,
      currentPage: currentPage == freezed
          ? _value.currentPage
          : currentPage // ignore: cast_nullable_to_non_nullable
              as int,
      totalItems: totalItems == freezed
          ? _value.totalItems
          : totalItems // ignore: cast_nullable_to_non_nullable
              as int,
      totalPages: totalPages == freezed
          ? _value.totalPages
          : totalPages // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_ProductPagedListModel implements _ProductPagedListModel {
  _$_ProductPagedListModel(
      {required final List<ProductModel> data,
      required this.currentPage,
      required this.totalItems,
      required this.totalPages})
      : _data = data;

  factory _$_ProductPagedListModel.fromJson(Map<String, dynamic> json) =>
      _$$_ProductPagedListModelFromJson(json);

  final List<ProductModel> _data;
  @override
  List<ProductModel> get data {
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
    return 'ProductPagedListModel(data: $data, currentPage: $currentPage, totalItems: $totalItems, totalPages: $totalPages)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_ProductPagedListModel &&
            const DeepCollectionEquality().equals(other._data, _data) &&
            const DeepCollectionEquality()
                .equals(other.currentPage, currentPage) &&
            const DeepCollectionEquality()
                .equals(other.totalItems, totalItems) &&
            const DeepCollectionEquality()
                .equals(other.totalPages, totalPages));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      const DeepCollectionEquality().hash(_data),
      const DeepCollectionEquality().hash(currentPage),
      const DeepCollectionEquality().hash(totalItems),
      const DeepCollectionEquality().hash(totalPages));

  @JsonKey(ignore: true)
  @override
  _$$_ProductPagedListModelCopyWith<_$_ProductPagedListModel> get copyWith =>
      __$$_ProductPagedListModelCopyWithImpl<_$_ProductPagedListModel>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_ProductPagedListModelToJson(
      this,
    );
  }
}

abstract class _ProductPagedListModel implements ProductPagedListModel {
  factory _ProductPagedListModel(
      {required final List<ProductModel> data,
      required final int currentPage,
      required final int totalItems,
      required final int totalPages}) = _$_ProductPagedListModel;

  factory _ProductPagedListModel.fromJson(Map<String, dynamic> json) =
      _$_ProductPagedListModel.fromJson;

  @override
  List<ProductModel> get data;
  @override
  int get currentPage;
  @override
  int get totalItems;
  @override
  int get totalPages;
  @override
  @JsonKey(ignore: true)
  _$$_ProductPagedListModelCopyWith<_$_ProductPagedListModel> get copyWith =>
      throw _privateConstructorUsedError;
}
