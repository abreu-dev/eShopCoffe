import 'package:flutter/material.dart';
import 'flavors.dart';
import 'main.dart';

void main() {
  F.appFlavor = Flavor.DEVELOPMENT;
  runApp(const MyApp());
}
