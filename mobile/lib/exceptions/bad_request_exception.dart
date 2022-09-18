import 'package:eshopcoffe/models/bad_request_response_model.dart';

class BadRequestException implements Exception {
  final BadRequestResponseModel model;

  BadRequestException(this.model);

  @override
  String toString() {
    return model.toString();
  }
}