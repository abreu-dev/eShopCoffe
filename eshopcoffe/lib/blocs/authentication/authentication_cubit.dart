import 'dart:convert';
import 'dart:developer';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/models/authenticated_user/authenticated_user_model.dart';
import 'package:eshopcoffe/utils/local_storage.dart';

class AuthenticationCubit extends Cubit<AuthenticatedUserModel?> {
  AuthenticationCubit(): super(null) {
    tryLoadFromLocalStorage();
  }

  Future<void> tryLoadFromLocalStorage() async {
    try {
      final storageValue = await LocalStorage.getUser();
      if (storageValue != null) {
        emit(AuthenticatedUserModel.fromJson(json.decode(storageValue)));
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
    await LocalStorage.writeUser(json.encode(model.toJson()));
    emit(model);
  }
}