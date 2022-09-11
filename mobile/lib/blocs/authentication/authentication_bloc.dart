import 'dart:developer';

import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:mobile/repositories/user_repository.dart';

import '../../services/session_api.dart';

part 'authentication_event.dart';
part 'authentication_state.dart';

class AuthenticationBloc extends Bloc<AuthenticationEvent, AuthenticationState> {
  final UserRepository userRepository = UserRepository();
  final SessionApi sessionApi = SessionApi();

  AuthenticationBloc(): super(AuthenticationUnauthenticatedState()) {
    on<LoggedInEvent>(_loggedInEventHandler);
    on<LoggedOutEvent>(_loggedOutEventHandler);
  }

  void _loggedInEventHandler(LoggedInEvent event, Emitter<AuthenticationState> emit) async {
    try {
      final String token = await sessionApi.login(event.username, event.password);
      await userRepository.persistToken(token);
      emit(AuthenticationAuthenticatedState());
    } catch(error) {
      log(error.toString());
    }
  }

  void _loggedOutEventHandler(LoggedOutEvent event, Emitter<AuthenticationState> emit) {
    emit(AuthenticationUnauthenticatedState());
  }
}