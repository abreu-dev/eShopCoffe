// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'product_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

ProductModel _$ProductModelFromJson(Map<String, dynamic> json) {
  return _ProductModel.fromJson(json);
}

/// @nodoc
mixin _$ProductModel {
  String get id => throw _privateConstructorUsedError;
  String get name => throw _privateConstructorUsedError;
  String get description => throw _privateConstructorUsedError;
  String get imageUrl => throw _privateConstructorUsedError;
  int get quantityAvailable => throw _privateConstructorUsedError;
  String get currencyCode => throw _privateConstructorUsedError;
  double get currencyValue => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $ProductModelCopyWith<ProductModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $ProductModelCopyWith<$Res> {
  factory $ProductModelCopyWith(
          ProductModel value, $Res Function(ProductModel) then) =
      _$ProductModelCopyWithImpl<$Res>;
  $Res call(
      {String id,
      String name,
      String description,
      String imageUrl,
      int quantityAvailable,
      String currencyCode,
      double currencyValue});
}

/// @nodoc
class _$ProductModelCopyWithImpl<$Res> implements $ProductModelCopyWith<$Res> {
  _$ProductModelCopyWithImpl(this._value, this._then);

  final ProductModel _value;
  // ignore: unused_field
  final $Res Function(ProductModel) _then;

  @override
  $Res call({
    Object? id = freezed,
    Object? name = freezed,
    Object? description = freezed,
    Object? imageUrl = freezed,
    Object? quantityAvailable = freezed,
    Object? currencyCode = freezed,
    Object? currencyValue = freezed,
  }) {
    return _then(_value.copyWith(
      id: id == freezed
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      name: name == freezed
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      description: description == freezed
          ? _value.description
          : description // ignore: cast_nullable_to_non_nullable
              as String,
      imageUrl: imageUrl == freezed
          ? _value.imageUrl
          : imageUrl // ignore: cast_nullable_to_non_nullable
              as String,
      quantityAvailable: quantityAvailable == freezed
          ? _value.quantityAvailable
          : quantityAvailable // ignore: cast_nullable_to_non_nullable
              as int,
      currencyCode: currencyCode == freezed
          ? _value.currencyCode
          : currencyCode // ignore: cast_nullable_to_non_nullable
              as String,
      currencyValue: currencyValue == freezed
          ? _value.currencyValue
          : currencyValue // ignore: cast_nullable_to_non_nullable
              as double,
    ));
  }
}

/// @nodoc
abstract class _$$_ProductModelCopyWith<$Res>
    implements $ProductModelCopyWith<$Res> {
  factory _$$_ProductModelCopyWith(
          _$_ProductModel value, $Res Function(_$_ProductModel) then) =
      __$$_ProductModelCopyWithImpl<$Res>;
  @override
  $Res call(
      {String id,
      String name,
      String description,
      String imageUrl,
      int quantityAvailable,
      String currencyCode,
      double currencyValue});
}

/// @nodoc
class __$$_ProductModelCopyWithImpl<$Res>
    extends _$ProductModelCopyWithImpl<$Res>
    implements _$$_ProductModelCopyWith<$Res> {
  __$$_ProductModelCopyWithImpl(
      _$_ProductModel _value, $Res Function(_$_ProductModel) _then)
      : super(_value, (v) => _then(v as _$_ProductModel));

  @override
  _$_ProductModel get _value => super._value as _$_ProductModel;

  @override
  $Res call({
    Object? id = freezed,
    Object? name = freezed,
    Object? description = freezed,
    Object? imageUrl = freezed,
    Object? quantityAvailable = freezed,
    Object? currencyCode = freezed,
    Object? currencyValue = freezed,
  }) {
    return _then(_$_ProductModel(
      id: id == freezed
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      name: name == freezed
          ? _value.name
          : name // ignore: cast_nullable_to_non_nullable
              as String,
      description: description == freezed
          ? _value.description
          : description // ignore: cast_nullable_to_non_nullable
              as String,
      imageUrl: imageUrl == freezed
          ? _value.imageUrl
          : imageUrl // ignore: cast_nullable_to_non_nullable
              as String,
      quantityAvailable: quantityAvailable == freezed
          ? _value.quantityAvailable
          : quantityAvailable // ignore: cast_nullable_to_non_nullable
              as int,
      currencyCode: currencyCode == freezed
          ? _value.currencyCode
          : currencyCode // ignore: cast_nullable_to_non_nullable
              as String,
      currencyValue: currencyValue == freezed
          ? _value.currencyValue
          : currencyValue // ignore: cast_nullable_to_non_nullable
              as double,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_ProductModel extends _ProductModel {
  _$_ProductModel(
      {required this.id,
      required this.name,
      required this.description,
      required this.imageUrl,
      required this.quantityAvailable,
      required this.currencyCode,
      required this.currencyValue})
      : super._();

  factory _$_ProductModel.fromJson(Map<String, dynamic> json) =>
      _$$_ProductModelFromJson(json);

  @override
  final String id;
  @override
  final String name;
  @override
  final String description;
  @override
  final String imageUrl;
  @override
  final int quantityAvailable;
  @override
  final String currencyCode;
  @override
  final double currencyValue;

  @override
  String toString() {
    return 'ProductModel(id: $id, name: $name, description: $description, imageUrl: $imageUrl, quantityAvailable: $quantityAvailable, currencyCode: $currencyCode, currencyValue: $currencyValue)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_ProductModel &&
            const DeepCollectionEquality().equals(other.id, id) &&
            const DeepCollectionEquality().equals(other.name, name) &&
            const DeepCollectionEquality()
                .equals(other.description, description) &&
            const DeepCollectionEquality().equals(other.imageUrl, imageUrl) &&
            const DeepCollectionEquality()
                .equals(other.quantityAvailable, quantityAvailable) &&
            const DeepCollectionEquality()
                .equals(other.currencyCode, currencyCode) &&
            const DeepCollectionEquality()
                .equals(other.currencyValue, currencyValue));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      const DeepCollectionEquality().hash(id),
      const DeepCollectionEquality().hash(name),
      const DeepCollectionEquality().hash(description),
      const DeepCollectionEquality().hash(imageUrl),
      const DeepCollectionEquality().hash(quantityAvailable),
      const DeepCollectionEquality().hash(currencyCode),
      const DeepCollectionEquality().hash(currencyValue));

  @JsonKey(ignore: true)
  @override
  _$$_ProductModelCopyWith<_$_ProductModel> get copyWith =>
      __$$_ProductModelCopyWithImpl<_$_ProductModel>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_ProductModelToJson(
      this,
    );
  }
}

abstract class _ProductModel extends ProductModel {
  factory _ProductModel(
      {required final String id,
      required final String name,
      required final String description,
      required final String imageUrl,
      required final int quantityAvailable,
      required final String currencyCode,
      required final double currencyValue}) = _$_ProductModel;
  _ProductModel._() : super._();

  factory _ProductModel.fromJson(Map<String, dynamic> json) =
      _$_ProductModel.fromJson;

  @override
  String get id;
  @override
  String get name;
  @override
  String get description;
  @override
  String get imageUrl;
  @override
  int get quantityAvailable;
  @override
  String get currencyCode;
  @override
  double get currencyValue;
  @override
  @JsonKey(ignore: true)
  _$$_ProductModelCopyWith<_$_ProductModel> get copyWith =>
      throw _privateConstructorUsedError;
}
