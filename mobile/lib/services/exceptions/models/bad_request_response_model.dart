class BadRequestResponseModel {
  final String instance;
  final String traceId;
  final List<BadRequestResponseErrorModel> errors;

  BadRequestResponseModel(this.instance, this.traceId, this.errors);

  BadRequestResponseModel.fromJson(Map<String, dynamic> json):
    instance = json['instance'],
    traceId = json['traceId'],
    errors = json['errors'] != '[]' ?
      List<BadRequestResponseErrorModel>.from(json['errors'].map((error) =>
          BadRequestResponseErrorModel.fromJson(error))) : <BadRequestResponseErrorModel>[];

  @override
  String toString() {
    return errors.map((error) => error.toString()).join(",");
  }
}

class BadRequestResponseErrorModel {
  final String type;
  final String error;

  BadRequestResponseErrorModel(this.type, this.error);

  BadRequestResponseErrorModel.fromJson(Map<String, dynamic> json):
    type = json['type'],
    error = json['error'];

  @override
  String toString() {
    return "$type: $error";
  }
}