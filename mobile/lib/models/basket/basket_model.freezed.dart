// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'basket_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

BasketModel _$BasketModelFromJson(Map<String, dynamic> json) {
  return _BasketModel.fromJson(json);
}

/// @nodoc
mixin _$BasketModel {
  String get id => throw _privateConstructorUsedError;
  List<BasketItemModel> get items => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $BasketModelCopyWith<BasketModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $BasketModelCopyWith<$Res> {
  factory $BasketModelCopyWith(
          BasketModel value, $Res Function(BasketModel) then) =
      _$BasketModelCopyWithImpl<$Res, BasketModel>;
  @useResult
  $Res call({String id, List<BasketItemModel> items});
}

/// @nodoc
class _$BasketModelCopyWithImpl<$Res, $Val extends BasketModel>
    implements $BasketModelCopyWith<$Res> {
  _$BasketModelCopyWithImpl(this._value, this._then);

  // ignore: unused_field
  final $Val _value;
  // ignore: unused_field
  final $Res Function($Val) _then;

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? items = null,
  }) {
    return _then(_value.copyWith(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      items: null == items
          ? _value.items
          : items // ignore: cast_nullable_to_non_nullable
              as List<BasketItemModel>,
    ) as $Val);
  }
}

/// @nodoc
abstract class _$$_BasketModelCopyWith<$Res>
    implements $BasketModelCopyWith<$Res> {
  factory _$$_BasketModelCopyWith(
          _$_BasketModel value, $Res Function(_$_BasketModel) then) =
      __$$_BasketModelCopyWithImpl<$Res>;
  @override
  @useResult
  $Res call({String id, List<BasketItemModel> items});
}

/// @nodoc
class __$$_BasketModelCopyWithImpl<$Res>
    extends _$BasketModelCopyWithImpl<$Res, _$_BasketModel>
    implements _$$_BasketModelCopyWith<$Res> {
  __$$_BasketModelCopyWithImpl(
      _$_BasketModel _value, $Res Function(_$_BasketModel) _then)
      : super(_value, _then);

  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? items = null,
  }) {
    return _then(_$_BasketModel(
      id: null == id
          ? _value.id
          : id // ignore: cast_nullable_to_non_nullable
              as String,
      items: null == items
          ? _value._items
          : items // ignore: cast_nullable_to_non_nullable
              as List<BasketItemModel>,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_BasketModel extends _BasketModel {
  _$_BasketModel({required this.id, required final List<BasketItemModel> items})
      : _items = items,
        super._();

  factory _$_BasketModel.fromJson(Map<String, dynamic> json) =>
      _$$_BasketModelFromJson(json);

  @override
  final String id;
  final List<BasketItemModel> _items;
  @override
  List<BasketItemModel> get items {
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_items);
  }

  @override
  String toString() {
    return 'BasketModel(id: $id, items: $items)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_BasketModel &&
            (identical(other.id, id) || other.id == id) &&
            const DeepCollectionEquality().equals(other._items, _items));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode =>
      Object.hash(runtimeType, id, const DeepCollectionEquality().hash(_items));

  @JsonKey(ignore: true)
  @override
  @pragma('vm:prefer-inline')
  _$$_BasketModelCopyWith<_$_BasketModel> get copyWith =>
      __$$_BasketModelCopyWithImpl<_$_BasketModel>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_BasketModelToJson(
      this,
    );
  }
}

abstract class _BasketModel extends BasketModel {
  factory _BasketModel(
      {required final String id,
      required final List<BasketItemModel> items}) = _$_BasketModel;
  _BasketModel._() : super._();

  factory _BasketModel.fromJson(Map<String, dynamic> json) =
      _$_BasketModel.fromJson;

  @override
  String get id;
  @override
  List<BasketItemModel> get items;
  @override
  @JsonKey(ignore: true)
  _$$_BasketModelCopyWith<_$_BasketModel> get copyWith =>
      throw _privateConstructorUsedError;
}
