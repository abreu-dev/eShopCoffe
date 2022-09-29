import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:eshopcoffe/components/sign_in_page.dart';
import 'package:eshopcoffe/services/health_service.dart';
import 'package:eshopcoffe/utils/snack_bar_helper.dart';

AppBar appBarWidget(context) {
  final HealthService healthService = HealthService();

  onHealthButtonPressed() async {
    await healthService.health().then((response) async {
      SnackBarHelper.success(context, 'Health OK! ${response.statusCode}');
    },
    onError: (error) {
      SnackBarHelper.failure(context, 'Health NOK! ${error.toString()}');
    });
  }

  return AppBar(
    elevation: 0.0,
    centerTitle: true,
    backgroundColor: Colors.white,
    title: Image.asset(
      'assets/images/ic_app_icon.png',
      width: 80,
      height: 40,
    ),
    iconTheme: const IconThemeData(color: Color(0xFF323232)),
    actions: <Widget>[
      IconButton(
        onPressed: onHealthButtonPressed,
        icon: const Icon(FontAwesomeIcons.heartPulse),
        color: const Color(0xFF323232),
      )
    ],
  );
}
