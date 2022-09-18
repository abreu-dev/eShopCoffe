import 'dart:developer';
import 'package:bloc/bloc.dart';
import 'package:eshopcoffe/storage.dart';
import 'package:eshopcoffe/models/authenticated_user_model.dart';

class AuthenticationCubit extends Cubit<AuthenticatedUserModel?> {
  AuthenticationCubit() : super(null) {
    initFromLocalStorage();
  }

  Future<void> initFromLocalStorage() async {
    try {
      final storageValue = await LocalStorage.getUser();
      if (storageValue != null) {
        emit(AuthenticatedUserModel.deserialize(storageValue));
      }
    }
    catch (error) {
      log(error.toString());
    }
  }

  Future<void> logout() async {
    await LocalStorage.deleteUser();
    emit(null);
  }

  Future<void> login(AuthenticatedUserModel model) async {
    await LocalStorage.writeUser(AuthenticatedUserModel.serialize(model));
    emit(model);
  }
}
