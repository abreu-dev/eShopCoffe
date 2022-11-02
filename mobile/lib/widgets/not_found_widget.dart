import 'package:flutter/material.dart';

class NotFoundWidget extends StatefulWidget {
  const NotFoundWidget({super.key});

  @override
  NotFoundWidgetState createState() => NotFoundWidgetState();
}

class NotFoundWidgetState extends State<NotFoundWidget> {
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
                "assets/images/404_not_found.png",
                height: 250,
                width: double.infinity,
              ),
            )
          ],
        ),
      ),
    );
  }
}
