import 'package:eshopcoffe/shared/models/bad_request_response_model.dart';

class BadRequestException implements Exception {
  final BadRequestResponseModel badRequestResponseModel;

  BadRequestException(this.badRequestResponseModel);

  @override
  String toString() {
    return badRequestResponseModel.toString();
  }
}