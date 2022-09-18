import 'package:bloc/bloc.dart';

import 'package:eshopcoffe/features/account/domain/models/authenticated_user_model.dart';
import 'package:eshopcoffe/features/account/domain/services/authentication_service.dart';
import 'package:eshopcoffe/shared/storage.dart';
import 'package:eshopcoffe/shared/services/snack_bar_service.dart';

part 'authentication_state.dart';

class AuthenticationCubit extends Cubit<AuthenticationState> {
  final AuthenticationService authenticationService;
  final SnackBarService snackBarService;

  AuthenticationCubit(this.authenticationService, this.snackBarService) : super(const AuthenticationUnauthenticatedState()) {
    initFromLocalStorage();
  }

  Future<void> initFromLocalStorage() async {
    try {
      final storageValue = await LocalStorage.getUser();
      if (storageValue != null) {
        final model = AuthenticatedUserModel.deserialize(storageValue);
        emit(AuthenticationAuthenticatedState(model));
      }
    }
    catch (error) {
      snackBarService.failure(error.toString());
    }
  }

  Future<void> logout() async {
    await LocalStorage.deleteUser();
    emit(const AuthenticationUnauthenticatedState());
  }

  Future<void> login(String username, String password) async {
    emit(const AuthenticationLoadingState());

    await authenticationService.login(username, password).then((response) async {
      var model = AuthenticatedUserModel.fromJson(response.data);
      await LocalStorage.writeUser(AuthenticatedUserModel.serialize(model));
      emit(AuthenticationAuthenticatedState(model));
    },
    onError: (error) {
      snackBarService.failure(error.toString());
      emit(const AuthenticationUnauthenticatedState());
    });
  }
}
