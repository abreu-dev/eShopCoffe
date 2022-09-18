part of 'authentication_cubit.dart';

abstract class AuthenticationState {
  const AuthenticationState();
}

class AuthenticationUnauthenticatedState extends AuthenticationState {
  const AuthenticationUnauthenticatedState();
}

class AuthenticationLoadingState extends AuthenticationState {
  const AuthenticationLoadingState();
}

class AuthenticationAuthenticatedState extends AuthenticationState {
  final AuthenticatedUserModel authenticatedUser;

  const AuthenticationAuthenticatedState(this.authenticatedUser);
}