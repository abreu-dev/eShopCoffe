class ServiceException implements Exception {
  final int? statusCode;
  final String message;

  ServiceException({
    this.statusCode,
    required this.message
  });

  @override
  String toString() {
    return "Request to API failed with status code '$statusCode'";
  }
}