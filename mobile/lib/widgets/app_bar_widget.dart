import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

import '../screens/login_screen.dart';

AppBar appBarWidget(context) {
  return AppBar(
    elevation: 0.0,
    centerTitle: true,
    title: Image.asset(
      "assets/images/ic_app_icon.png",
      width: 80,
      height: 40
    ),
    actions: <Widget>[
      IconButton(
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder : (context) => const LoginScreen())
          );
        },
        icon: const Icon(FontAwesomeIcons.user),
        color: const Color(0xFF323232)
      )
    ]
  );
}