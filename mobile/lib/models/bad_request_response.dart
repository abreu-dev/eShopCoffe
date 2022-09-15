class BadRequestResponse {
  final String instance;
  final String traceId;
  final List<BadRequestResponseError> errors;

  BadRequestResponse(this.instance, this.traceId, this.errors);

  BadRequestResponse.fromJson(Map<String, dynamic> json):
      instance = json['instance'],
      traceId = json['traceId'],
      errors = List<BadRequestResponseError>.from(json['errors'].map((error) => BadRequestResponseError.fromJson(error)));

  @override
  String toString() {
    return errors.map((error) => error.toString()).join(",");
  }
}

class BadRequestResponseError {
  final String type;
  final String error;

  BadRequestResponseError(this.type, this.error);

  BadRequestResponseError.fromJson(Map<String, dynamic> json):
        type = json['type'],
        error = json['error'];

  @override
  String toString() {
    return "$type: $error";
  }
}