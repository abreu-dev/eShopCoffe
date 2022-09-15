import 'package:bloc/bloc.dart';
import 'package:dio/dio.dart';
import 'package:equatable/equatable.dart';

import '../../repositories/user_repository.dart';
import '../../services/session_api.dart';
import '../../services/snackbar_service.dart';

part 'authentication_event.dart';
part 'authentication_state.dart';

class AuthenticationBloc extends Bloc<AuthenticationEvent, AuthenticationState> {
  final UserRepository userRepository = UserRepository();
  final SessionApi sessionApi = SessionApi();

  final SnackBarService snackBarService;

  AuthenticationBloc({required this.snackBarService}): super(AuthenticationUnauthenticatedState()) {
    on<LoggedInEvent>(_loggedInEventHandler);
    on<LoggedOutEvent>(_loggedOutEventHandler);
  }

  void _loggedInEventHandler(LoggedInEvent event, Emitter<AuthenticationState> emit) async {
    emit(AuthenticationLoadingState());

    await sessionApi.login(event.username, event.password).then((response)
    {
        userRepository.persistToken(response.token);
        emit(AuthenticationAuthenticatedState());
    },
    onError: (error) {
      emit(AuthenticationUnauthenticatedState());
      snackBarService.failure(error.toString());
    });
  }

  void _loggedOutEventHandler(LoggedOutEvent event, Emitter<AuthenticationState> emit) async {
    emit(AuthenticationLoadingState());
    await userRepository.deleteToken();
    emit(AuthenticationUnauthenticatedState());
  }
}