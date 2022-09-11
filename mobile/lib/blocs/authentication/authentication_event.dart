part of 'authentication_bloc.dart';

abstract class AuthenticationEvent extends Equatable {
  const AuthenticationEvent();

  @override
  List<Object> get props => [];
}

class LoggedInEvent extends AuthenticationEvent {
  final String username;
  final String password;

  const LoggedInEvent({required this.username, required this.password});
}

class LoggedOutEvent extends AuthenticationEvent {}
