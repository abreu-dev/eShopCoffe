import 'package:flutter/material.dart';

class SnackBarService {

  final BuildContext context;

  SnackBarService({required this.context});

  void success(String message) {
    var snackBar = SnackBar(
        content: Text(message),
        backgroundColor: Colors.green,
    );
    ScaffoldMessenger.of(context).showSnackBar(snackBar);
  }

  void failure(String message) {
    var snackBar = SnackBar(
      content: Text(message),
      backgroundColor: Colors.red,
    );
    ScaffoldMessenger.of(context).showSnackBar(snackBar);
  }
}