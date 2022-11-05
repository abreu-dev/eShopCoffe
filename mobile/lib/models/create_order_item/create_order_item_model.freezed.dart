// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'create_order_item_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

CreateOrderItemModel _$CreateOrderItemModelFromJson(Map<String, dynamic> json) {
  return _CreateOrderItemModel.fromJson(json);
}

/// @nodoc
mixin _$CreateOrderItemModel {
  String get productId => throw _privateConstructorUsedError;
  int get amount => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $CreateOrderItemModelCopyWith<CreateOrderItemModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $CreateOrderItemModelCopyWith<$Res> {
  factory $CreateOrderItemModelCopyWith(CreateOrderItemModel value,
          $Res Function(CreateOrderItemModel) then) =
      _$CreateOrderItemModelCopyWithImpl<$Res, CreateOrderItemModel>;
  @useResult
  $Res call({String productId, int amount});
}

/// @nodoc
class _$CreateOrderItemModelCopyWithImpl<$Res,
        $Val extends CreateOrderItemModel>
    implements $CreateOrderItemModelCopyWith<$Res> {
  _$CreateOrderItemModelCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? productId = null,
    Object? amount = null,
  }) {
    return _then(_value.copyWith(
      productId: null == productId
          ? _value.productId
          : productId // ignore: cast_nullable_to_non_nullable
              as String,
      amount: null == amount
          ? _value.amount
          : amount // ignore: cast_nullable_to_non_nullable
              as int,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$_CreateOrderItemModelCopyWith<$Res>
    implements $CreateOrderItemModelCopyWith<$Res> {
  factory _$$_CreateOrderItemModelCopyWith(_$_CreateOrderItemModel value,
          $Res Function(_$_CreateOrderItemModel) then) =
      __$$_CreateOrderItemModelCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String productId, int amount});
}

/// @nodoc
class __$$_CreateOrderItemModelCopyWithImpl<$Res>
    extends _$CreateOrderItemModelCopyWithImpl<$Res, _$_CreateOrderItemModel>
    implements _$$_CreateOrderItemModelCopyWith<$Res> {
  __$$_CreateOrderItemModelCopyWithImpl(_$_CreateOrderItemModel _value,
      $Res Function(_$_CreateOrderItemModel) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? productId = null,
    Object? amount = null,
  }) {
    return _then(_$_CreateOrderItemModel(
      productId: null == productId
          ? _value.productId
          : productId // ignore: cast_nullable_to_non_nullable
              as String,
      amount: null == amount
          ? _value.amount
          : amount // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_CreateOrderItemModel implements _CreateOrderItemModel {
  _$_CreateOrderItemModel({required this.productId, required this.amount});

  factory _$_CreateOrderItemModel.fromJson(Map<String, dynamic> json) =>
      _$$_CreateOrderItemModelFromJson(json);

  @override
  final String productId;
  @override
  final int amount;

  @override
  String toString() {
    return 'CreateOrderItemModel(productId: $productId, amount: $amount)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_CreateOrderItemModel &&
            (identical(other.productId, productId) ||
                other.productId == productId) &&
            (identical(other.amount, amount) || other.amount == amount));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(runtimeType, productId, amount);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_CreateOrderItemModelCopyWith<_$_CreateOrderItemModel> get copyWith =>
      __$$_CreateOrderItemModelCopyWithImpl<_$_CreateOrderItemModel>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_CreateOrderItemModelToJson(
      this,
    );
  }
}

abstract class _CreateOrderItemModel implements CreateOrderItemModel {
  factory _CreateOrderItemModel(
      {required final String productId,
      required final int amount}) = _$_CreateOrderItemModel;

  factory _CreateOrderItemModel.fromJson(Map<String, dynamic> json) =
      _$_CreateOrderItemModel.fromJson;

  @override
  String get productId;
  @override
  int get amount;
  @override
  @JsonKey(ignore: true)
  _$$_CreateOrderItemModelCopyWith<_$_CreateOrderItemModel> get copyWith =>
      throw _privateConstructorUsedError;
}
