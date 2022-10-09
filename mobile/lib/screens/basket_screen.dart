import 'package:flutter/material.dart';

class BasketScreen extends StatefulWidget {
  const BasketScreen({super.key});

  @override
  BasketScreenState createState() => BasketScreenState();
}

class BasketScreenState extends State<BasketScreen> {
  @override
  Widget build(BuildContext context) {
    return const EmptyBasketScreen();
  }
}

class EmptyBasketScreen extends StatefulWidget {
  const EmptyBasketScreen({super.key});

  @override
  EmptyBasketScreenState createState() => EmptyBasketScreenState();
}

class EmptyBasketScreenState extends State<EmptyBasketScreen> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Container(
        decoration: const BoxDecoration(color: Colors.white),
        child: Column(
          children: <Widget>[
            SizedBox(
              height: 70,
              child: Container(
                color: const Color(0xFFFFFFFF),
              ),
            ),
            SizedBox(
              width: double.infinity,
              height: 250,
              child: Image.asset(
                "assets/images/empty_shopping_cart.png",
                height: 250,
                width: double.infinity,
              ),
            ),
            SizedBox(
              height: 40,
              child: Container(
                color: const Color(0xFFFFFFFF),
              ),
            ),
            const SizedBox(
              width: double.infinity,
              child: Text(
                "You haven't anything to cart",
                style: TextStyle(
                  color: Color(0xFF67778E),
                  fontFamily: 'Roboto-Light.ttf',
                  fontSize: 20,
                  fontStyle: FontStyle.normal,
                ),
                textAlign: TextAlign.center,
              ),
            )
          ],
        ),
      ),
    );
  }
}