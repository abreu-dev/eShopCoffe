import 'package:eshopcoffe/flavors.dart';

class ServiceException implements Exception {
  final int? statusCode;
  final String message;

  ServiceException({
    this.statusCode,
    required this.message
  });

  @override
  String toString() {
    return "Request to API ${F.apiUrl} failed with status code '$statusCode'";
  }
}