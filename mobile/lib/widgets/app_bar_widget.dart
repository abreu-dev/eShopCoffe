import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:eshopcoffe/screens/basket_screen.dart';

AppBar appBarWidget(context, {showBasket = true}) {

  print(showBasket);
  onHealthButtonPressed() async {
    Navigator.push(
        context,
        MaterialPageRoute(
            builder: (context) => const BasketScreen()
        )
    );
  }

  var actions = <Widget>[];

  if (showBasket) {
    actions.add(
      IconButton(
        onPressed: onHealthButtonPressed,
        icon: const Icon(FontAwesomeIcons.basketShopping),
        color: const Color(0xFF323232),
      )
    );
  }

  return AppBar(
    elevation: 0.0,
    centerTitle: true,
    backgroundColor: Colors.white,
    title: Image.asset(
      'assets/images/app_icon_1.png',
      height: 50,
    ),
    iconTheme: const IconThemeData(color: Color(0xFF323232)),
    actions: actions
  );
}
