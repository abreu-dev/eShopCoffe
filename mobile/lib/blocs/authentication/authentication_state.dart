part of 'authentication_bloc.dart';

abstract class AuthenticationState extends Equatable {
  @override
  List<Object> get props => [];
}

class AuthenticationAuthenticatedState extends AuthenticationState {}

class AuthenticationUnauthenticatedState extends AuthenticationState {}

class AuthenticationLoadingState extends AuthenticationState {}
