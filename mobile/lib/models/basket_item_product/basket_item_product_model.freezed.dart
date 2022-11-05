// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'basket_item_product_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

BasketItemProductModel _$BasketItemProductModelFromJson(
    Map<String, dynamic> json) {
  return _BasketItemProductModel.fromJson(json);
}

/// @nodoc
mixin _$BasketItemProductModel {
  String get id => throw _privateConstructorUsedError;
  String get name => throw _privateConstructorUsedError;
  String get imageUrl => throw _privateConstructorUsedError;
  String get currencyCode => throw _privateConstructorUsedError;
  double get currencyValue => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $BasketItemProductModelCopyWith<BasketItemProductModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $BasketItemProductModelCopyWith<$Res> {
  factory $BasketItemProductModelCopyWith(BasketItemProductModel value,
          $Res Function(BasketItemProductModel) then) =
      _$BasketItemProductModelCopyWithImpl<$Res, BasketItemProductModel>;
  @useResult
  $Res call(
      {String id,
      String name,
      String imageUrl,
      String currencyCode,
      double currencyValue});
}

/// @nodoc
class _$BasketItemProductModelCopyWithImpl<$Res,
        $Val extends BasketItemProductModel>
    implements $BasketItemProductModelCopyWith<$Res> {
  _$BasketItemProductModelCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? name = null,
    Object? imageUrl = null,
    Object? currencyCode = null,
    Object? currencyValue = null,
  }) {
    return _then(_value.copyWith(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      imageUrl: null == imageUrl
          ? _value.imageUrl
          : imageUrl // ignore: cast_nullable_to_non_nullable
              as String,
      currencyCode: null == currencyCode
          ? _value.currencyCode
          : currencyCode // ignore: cast_nullable_to_non_nullable
              as String,
      currencyValue: null == currencyValue
          ? _value.currencyValue
          : currencyValue // ignore: cast_nullable_to_non_nullable
              as double,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$_BasketItemProductModelCopyWith<$Res>
    implements $BasketItemProductModelCopyWith<$Res> {
  factory _$$_BasketItemProductModelCopyWith(_$_BasketItemProductModel value,
          $Res Function(_$_BasketItemProductModel) then) =
      __$$_BasketItemProductModelCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call(
      {String id,
      String name,
      String imageUrl,
      String currencyCode,
      double currencyValue});
}

/// @nodoc
class __$$_BasketItemProductModelCopyWithImpl<$Res>
    extends _$BasketItemProductModelCopyWithImpl<$Res,
        _$_BasketItemProductModel>
    implements _$$_BasketItemProductModelCopyWith<$Res> {
  __$$_BasketItemProductModelCopyWithImpl(_$_BasketItemProductModel _value,
      $Res Function(_$_BasketItemProductModel) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? name = null,
    Object? imageUrl = null,
    Object? currencyCode = null,
    Object? currencyValue = null,
  }) {
    return _then(_$_BasketItemProductModel(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      name: null == name
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      imageUrl: null == imageUrl
          ? _value.imageUrl
          : imageUrl // ignore: cast_nullable_to_non_nullable
              as String,
      currencyCode: null == currencyCode
          ? _value.currencyCode
          : currencyCode // ignore: cast_nullable_to_non_nullable
              as String,
      currencyValue: null == currencyValue
          ? _value.currencyValue
          : currencyValue // ignore: cast_nullable_to_non_nullable
              as double,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_BasketItemProductModel extends _BasketItemProductModel {
  _$_BasketItemProductModel(
      {required this.id,
      required this.name,
      required this.imageUrl,
      required this.currencyCode,
      required this.currencyValue})
      : super._();

  factory _$_BasketItemProductModel.fromJson(Map<String, dynamic> json) =>
      _$$_BasketItemProductModelFromJson(json);

  @override
  final String id;
  @override
  final String name;
  @override
  final String imageUrl;
  @override
  final String currencyCode;
  @override
  final double currencyValue;

  @override
  String toString() {
    return 'BasketItemProductModel(id: $id, name: $name, imageUrl: $imageUrl, currencyCode: $currencyCode, currencyValue: $currencyValue)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_BasketItemProductModel &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.imageUrl, imageUrl) ||
                other.imageUrl == imageUrl) &&
            (identical(other.currencyCode, currencyCode) ||
                other.currencyCode == currencyCode) &&
            (identical(other.currencyValue, currencyValue) ||
                other.currencyValue == currencyValue));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode =>
      Object.hash(runtimeType, id, name, imageUrl, currencyCode, currencyValue);

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_BasketItemProductModelCopyWith<_$_BasketItemProductModel> get copyWith =>
      __$$_BasketItemProductModelCopyWithImpl<_$_BasketItemProductModel>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_BasketItemProductModelToJson(
      this,
    );
  }
}

abstract class _BasketItemProductModel extends BasketItemProductModel {
  factory _BasketItemProductModel(
      {required final String id,
      required final String name,
      required final String imageUrl,
      required final String currencyCode,
      required final double currencyValue}) = _$_BasketItemProductModel;
  _BasketItemProductModel._() : super._();

  factory _BasketItemProductModel.fromJson(Map<String, dynamic> json) =
      _$_BasketItemProductModel.fromJson;

  @override
  String get id;
  @override
  String get name;
  @override
  String get imageUrl;
  @override
  String get currencyCode;
  @override
  double get currencyValue;
  @override
  @JsonKey(ignore: true)
  _$$_BasketItemProductModelCopyWith<_$_BasketItemProductModel> get copyWith =>
      throw _privateConstructorUsedError;
}
