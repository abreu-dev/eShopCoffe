import 'package:flutter/material.dart';

class SnackBarHelper {
  static void success(BuildContext context, String message) {
    var snackBar = SnackBar(
      content: Text(message),
      backgroundColor: const Color(0xFF74AA50),
    );
    ScaffoldMessenger.of(context).showSnackBar(snackBar);
  }

  static void failure(BuildContext context, String message) {
    var snackBar = SnackBar(
      content: Text(message),
      backgroundColor: Colors.red,
    );
    ScaffoldMessenger.of(context).showSnackBar(snackBar);
  }
}