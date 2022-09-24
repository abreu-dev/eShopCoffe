// coverage:ignore-file
// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target

part of 'authenticated_user_model.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

T _$identity<T>(T value) => value;

final _privateConstructorUsedError = UnsupportedError(
    'It seems like you constructed your class using `MyClass._()`. This constructor is only meant to be used by freezed and you are not supposed to need it nor use it.\nPlease check the documentation here for more information: https://github.com/rrousselGit/freezed#custom-getters-and-methods');

AuthenticatedUserModel _$AuthenticatedUserModelFromJson(
    Map<String, dynamic> json) {
  return _AuthenticatedUserModel.fromJson(json);
}

/// @nodoc
mixin _$AuthenticatedUserModel {
  String get token => throw _privateConstructorUsedError;
  UserModel get user => throw _privateConstructorUsedError;

  Map<String, dynamic> toJson() => throw _privateConstructorUsedError;
  @JsonKey(ignore: true)
  $AuthenticatedUserModelCopyWith<AuthenticatedUserModel> get copyWith =>
      throw _privateConstructorUsedError;
}

/// @nodoc
abstract class $AuthenticatedUserModelCopyWith<$Res> {
  factory $AuthenticatedUserModelCopyWith(AuthenticatedUserModel value,
          $Res Function(AuthenticatedUserModel) then) =
      _$AuthenticatedUserModelCopyWithImpl<$Res>;
  $Res call({String token, UserModel user});

  $UserModelCopyWith<$Res> get user;
}

/// @nodoc
class _$AuthenticatedUserModelCopyWithImpl<$Res>
    implements $AuthenticatedUserModelCopyWith<$Res> {
  _$AuthenticatedUserModelCopyWithImpl(this._value, this._then);

  final AuthenticatedUserModel _value;
  // ignore: unused_field
  final $Res Function(AuthenticatedUserModel) _then;

  @override
  $Res call({
    Object? token = freezed,
    Object? user = freezed,
  }) {
    return _then(_value.copyWith(
      token: token == freezed
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
      user: user == freezed
          ? _value.user
          : user // ignore: cast_nullable_to_non_nullable
              as UserModel,
    ));
  }

  @override
  $UserModelCopyWith<$Res> get user {
    return $UserModelCopyWith<$Res>(_value.user, (value) {
      return _then(_value.copyWith(user: value));
    });
  }
}

/// @nodoc
abstract class _$$_AuthenticatedUserModelCopyWith<$Res>
    implements $AuthenticatedUserModelCopyWith<$Res> {
  factory _$$_AuthenticatedUserModelCopyWith(_$_AuthenticatedUserModel value,
          $Res Function(_$_AuthenticatedUserModel) then) =
      __$$_AuthenticatedUserModelCopyWithImpl<$Res>;
  @override
  $Res call({String token, UserModel user});

  @override
  $UserModelCopyWith<$Res> get user;
}

/// @nodoc
class __$$_AuthenticatedUserModelCopyWithImpl<$Res>
    extends _$AuthenticatedUserModelCopyWithImpl<$Res>
    implements _$$_AuthenticatedUserModelCopyWith<$Res> {
  __$$_AuthenticatedUserModelCopyWithImpl(_$_AuthenticatedUserModel _value,
      $Res Function(_$_AuthenticatedUserModel) _then)
      : super(_value, (v) => _then(v as _$_AuthenticatedUserModel));

  @override
  _$_AuthenticatedUserModel get _value =>
      super._value as _$_AuthenticatedUserModel;

  @override
  $Res call({
    Object? token = freezed,
    Object? user = freezed,
  }) {
    return _then(_$_AuthenticatedUserModel(
      token: token == freezed
          ? _value.token
          : token // ignore: cast_nullable_to_non_nullable
              as String,
      user: user == freezed
          ? _value.user
          : user // ignore: cast_nullable_to_non_nullable
              as UserModel,
    ));
  }
}

/// @nodoc
@JsonSerializable()
class _$_AuthenticatedUserModel implements _AuthenticatedUserModel {
  _$_AuthenticatedUserModel({required this.token, required this.user});

  factory _$_AuthenticatedUserModel.fromJson(Map<String, dynamic> json) =>
      _$$_AuthenticatedUserModelFromJson(json);

  @override
  final String token;
  @override
  final UserModel user;

  @override
  String toString() {
    return 'AuthenticatedUserModel(token: $token, user: $user)';
  }

  @override
  bool operator ==(dynamic other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _$_AuthenticatedUserModel &&
            const DeepCollectionEquality().equals(other.token, token) &&
            const DeepCollectionEquality().equals(other.user, user));
  }

  @JsonKey(ignore: true)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      const DeepCollectionEquality().hash(token),
      const DeepCollectionEquality().hash(user));

  @JsonKey(ignore: true)
  @override
  _$$_AuthenticatedUserModelCopyWith<_$_AuthenticatedUserModel> get copyWith =>
      __$$_AuthenticatedUserModelCopyWithImpl<_$_AuthenticatedUserModel>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$$_AuthenticatedUserModelToJson(
      this,
    );
  }
}

abstract class _AuthenticatedUserModel implements AuthenticatedUserModel {
  factory _AuthenticatedUserModel(
      {required final String token,
      required final UserModel user}) = _$_AuthenticatedUserModel;

  factory _AuthenticatedUserModel.fromJson(Map<String, dynamic> json) =
      _$_AuthenticatedUserModel.fromJson;

  @override
  String get token;
  @override
  UserModel get user;
  @override
  @JsonKey(ignore: true)
  _$$_AuthenticatedUserModelCopyWith<_$_AuthenticatedUserModel> get copyWith =>
      throw _privateConstructorUsedError;
}
