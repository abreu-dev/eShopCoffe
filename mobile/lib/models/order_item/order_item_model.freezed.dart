// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'order_item_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

OrderItemModel _$OrderItemModelFromJson(Map<String, dynamic> json) {
  return _OrderItemModel.fromJson(json);
}

/// @nodoc
mixin _$OrderItemModel {
  String get name => throw _privateConstructorUsedError;
  String get imageUrl => throw _privateConstructorUsedError;
  int get amount => throw _privateConstructorUsedError;
  double get currencyValue => throw _privateConstructorUsedError;
  String get currencyCode => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $OrderItemModelCopyWith<OrderItemModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $OrderItemModelCopyWith<$Res> {
  factory $OrderItemModelCopyWith(
          OrderItemModel value, $Res Function(OrderItemModel) then) =
      _$OrderItemModelCopyWithImpl<$Res, OrderItemModel>;
  @useResult
  $Res call(
      {String name,
      String imageUrl,
      int amount,
      double currencyValue,
      String currencyCode});
}

/// @nodoc
class _$OrderItemModelCopyWithImpl<$Res, $Val extends OrderItemModel>
    implements $OrderItemModelCopyWith<$Res> {
  _$OrderItemModelCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? name = null,
    Object? imageUrl = null,
    Object? amount = null,
    Object? currencyValue = null,
    Object? currencyCode = null,
  }) {
    return _then(_value.copyWith(
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      imageUrl: null == imageUrl
          ? _value.imageUrl
          : imageUrl // ignore: cast_nullable_to_non_nullable
              as String,
      amount: null == amount
          ? _value.amount
          : amount // ignore: cast_nullable_to_non_nullable
              as int,
      currencyValue: null == currencyValue
          ? _value.currencyValue
          : currencyValue // ignore: cast_nullable_to_non_nullable
              as double,
      currencyCode: null == currencyCode
          ? _value.currencyCode
          : currencyCode // ignore: cast_nullable_to_non_nullable
              as String,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$_OrderItemModelCopyWith<$Res>
    implements $OrderItemModelCopyWith<$Res> {
  factory _$$_OrderItemModelCopyWith(
          _$_OrderItemModel value, $Res Function(_$_OrderItemModel) then) =
      __$$_OrderItemModelCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String name,
      String imageUrl,
      int amount,
      double currencyValue,
      String currencyCode});
}

/// @nodoc
class __$$_OrderItemModelCopyWithImpl<$Res>
    extends _$OrderItemModelCopyWithImpl<$Res, _$_OrderItemModel>
    implements _$$_OrderItemModelCopyWith<$Res> {
  __$$_OrderItemModelCopyWithImpl(
      _$_OrderItemModel _value, $Res Function(_$_OrderItemModel) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? name = null,
    Object? imageUrl = null,
    Object? amount = null,
    Object? currencyValue = null,
    Object? currencyCode = null,
  }) {
    return _then(_$_OrderItemModel(
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      imageUrl: null == imageUrl
          ? _value.imageUrl
          : imageUrl // ignore: cast_nullable_to_non_nullable
              as String,
      amount: null == amount
          ? _value.amount
          : amount // ignore: cast_nullable_to_non_nullable
              as int,
      currencyValue: null == currencyValue
          ? _value.currencyValue
          : currencyValue // ignore: cast_nullable_to_non_nullable
              as double,
      currencyCode: null == currencyCode
          ? _value.currencyCode
          : currencyCode // ignore: cast_nullable_to_non_nullable
              as String,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_OrderItemModel extends _OrderItemModel {
  _$_OrderItemModel(
      {required this.name,
      required this.imageUrl,
      required this.amount,
      required this.currencyValue,
      required this.currencyCode})
      : super._();

  factory _$_OrderItemModel.fromJson(Map<String, dynamic> json) =>
      _$$_OrderItemModelFromJson(json);

  @override
  final String name;
  @override
  final String imageUrl;
  @override
  final int amount;
  @override
  final double currencyValue;
  @override
  final String currencyCode;

  @override
  String toString() {
    return 'OrderItemModel(name: $name, imageUrl: $imageUrl, amount: $amount, currencyValue: $currencyValue, currencyCode: $currencyCode)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_OrderItemModel &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.imageUrl, imageUrl) ||
                other.imageUrl == imageUrl) &&
            (identical(other.amount, amount) || other.amount == amount) &&
            (identical(other.currencyValue, currencyValue) ||
                other.currencyValue == currencyValue) &&
            (identical(other.currencyCode, currencyCode) ||
                other.currencyCode == currencyCode));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType, name, imageUrl, amount, currencyValue, currencyCode);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_OrderItemModelCopyWith<_$_OrderItemModel> get copyWith =>
      __$$_OrderItemModelCopyWithImpl<_$_OrderItemModel>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_OrderItemModelToJson(
      this,
    );
  }
}

abstract class _OrderItemModel extends OrderItemModel {
  factory _OrderItemModel(
      {required final String name,
      required final String imageUrl,
      required final int amount,
      required final double currencyValue,
      required final String currencyCode}) = _$_OrderItemModel;
  _OrderItemModel._() : super._();

  factory _OrderItemModel.fromJson(Map<String, dynamic> json) =
      _$_OrderItemModel.fromJson;

  @override
  String get name;
  @override
  String get imageUrl;
  @override
  int get amount;
  @override
  double get currencyValue;
  @override
  String get currencyCode;
  @override
  @JsonKey(ignore: true)
  _$$_OrderItemModelCopyWith<_$_OrderItemModel> get copyWith =>
      throw _privateConstructorUsedError;
}
