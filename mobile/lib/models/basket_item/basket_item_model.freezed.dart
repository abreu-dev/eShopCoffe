// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'basket_item_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

BasketItemModel _$BasketItemModelFromJson(Map<String, dynamic> json) {
  return _BasketItemModel.fromJson(json);
}

/// @nodoc
mixin _$BasketItemModel {
  String get id => throw _privateConstructorUsedError;
  BasketItemProductModel get product => throw _privateConstructorUsedError;
  int get amount => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $BasketItemModelCopyWith<BasketItemModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $BasketItemModelCopyWith<$Res> {
  factory $BasketItemModelCopyWith(
          BasketItemModel value, $Res Function(BasketItemModel) then) =
      _$BasketItemModelCopyWithImpl<$Res, BasketItemModel>;
  @useResult
  $Res call({String id, BasketItemProductModel product, int amount});

  $BasketItemProductModelCopyWith<$Res> get product;
}

/// @nodoc
class _$BasketItemModelCopyWithImpl<$Res, $Val extends BasketItemModel>
    implements $BasketItemModelCopyWith<$Res> {
  _$BasketItemModelCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? product = null,
    Object? amount = null,
  }) {
    return _then(_value.copyWith(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      product: null == product
          ? _value.product
          : product // ignore: cast_nullable_to_non_nullable
              as BasketItemProductModel,
      amount: null == amount
          ? _value.amount
          : amount // ignore: cast_nullable_to_non_nullable
              as int,
    ) as $Val);
  }

  @override
  @pragma('vm:prefer-inline')
  $BasketItemProductModelCopyWith<$Res> get product {
    return $BasketItemProductModelCopyWith<$Res>(_value.product, (value) {
      return _then(_value.copyWith(product: value) as $Val);
    });
  }
}

/// @nodoc
abstract class _$$_BasketItemModelCopyWith<$Res>
    implements $BasketItemModelCopyWith<$Res> {
  factory _$$_BasketItemModelCopyWith(
          _$_BasketItemModel value, $Res Function(_$_BasketItemModel) then) =
      __$$_BasketItemModelCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String id, BasketItemProductModel product, int amount});

  @override
  $BasketItemProductModelCopyWith<$Res> get product;
}

/// @nodoc
class __$$_BasketItemModelCopyWithImpl<$Res>
    extends _$BasketItemModelCopyWithImpl<$Res, _$_BasketItemModel>
    implements _$$_BasketItemModelCopyWith<$Res> {
  __$$_BasketItemModelCopyWithImpl(
      _$_BasketItemModel _value, $Res Function(_$_BasketItemModel) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? product = null,
    Object? amount = null,
  }) {
    return _then(_$_BasketItemModel(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      product: null == product
          ? _value.product
          : product // ignore: cast_nullable_to_non_nullable
              as BasketItemProductModel,
      amount: null == amount
          ? _value.amount
          : amount // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_BasketItemModel implements _BasketItemModel {
  _$_BasketItemModel(
      {required this.id, required this.product, required this.amount});

  factory _$_BasketItemModel.fromJson(Map<String, dynamic> json) =>
      _$$_BasketItemModelFromJson(json);

  @override
  final String id;
  @override
  final BasketItemProductModel product;
  @override
  final int amount;

  @override
  String toString() {
    return 'BasketItemModel(id: $id, product: $product, amount: $amount)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_BasketItemModel &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.product, product) || other.product == product) &&
            (identical(other.amount, amount) || other.amount == amount));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, id, product, amount);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_BasketItemModelCopyWith<_$_BasketItemModel> get copyWith =>
      __$$_BasketItemModelCopyWithImpl<_$_BasketItemModel>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_BasketItemModelToJson(
      this,
    );
  }
}

abstract class _BasketItemModel implements BasketItemModel {
  factory _BasketItemModel(
      {required final String id,
      required final BasketItemProductModel product,
      required final int amount}) = _$_BasketItemModel;

  factory _BasketItemModel.fromJson(Map<String, dynamic> json) =
      _$_BasketItemModel.fromJson;

  @override
  String get id;
  @override
  BasketItemProductModel get product;
  @override
  int get amount;
  @override
  @JsonKey(ignore: true)
  _$$_BasketItemModelCopyWith<_$_BasketItemModel> get copyWith =>
      throw _privateConstructorUsedError;
}
