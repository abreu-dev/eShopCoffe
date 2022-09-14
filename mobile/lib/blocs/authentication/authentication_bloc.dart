import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';

import '../../repositories/user_repository.dart';
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
    emit(AuthenticationLoadingState());
    final String token = await sessionApi.login(event.username, event.password);
    await userRepository.persistToken(token);
    emit(AuthenticationAuthenticatedState());
  }

  void _loggedOutEventHandler(LoggedOutEvent event, Emitter<AuthenticationState> emit) async {
    emit(AuthenticationLoadingState());
    await userRepository.deleteToken();
    emit(AuthenticationUnauthenticatedState());
  }
}