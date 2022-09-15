import 'package:mobile/models/bad_request_response.dart';

class BadRequestException implements Exception {
  final BadRequestResponse badRequestResponse;

  BadRequestException(this.badRequestResponse);

  @override
  String toString() {
    return badRequestResponse.toString();
  }
}