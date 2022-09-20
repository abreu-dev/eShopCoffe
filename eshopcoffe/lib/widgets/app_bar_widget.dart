import 'package:eshopcoffe/components/sign_in_page.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

AppBar appBarWidget(context) {
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
        onPressed: () {
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => const SignInPage()),
          );
        },
        icon: const Icon(FontAwesomeIcons.user),
        color: const Color(0xFF323232),
      ),
    ],
  );
}
