import 'package:flutter/material.dart';

class CircularProgressWidget extends StatefulWidget {
  const CircularProgressWidget({super.key});

  @override
  CircularProgressWidgetState createState() => CircularProgressWidgetState();
}

class CircularProgressWidgetState extends State<CircularProgressWidget> {
  @override
  Widget build(BuildContext context) {
    return const Center(
      child: CircularProgressIndicator(
      ),
    );
  }
}