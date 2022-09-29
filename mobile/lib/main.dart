import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/screens/home_screen.dart';
import 'package:eshopcoffe/blocs/authentication_cubit.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers:  [
        BlocProvider<AuthenticationCubit>(
            create: (BuildContext context) => AuthenticationCubit()
        ),
      ],
      child: MaterialApp(
          title: "eShopCof",
          theme: ThemeData(
          splashColor: Colors.orange,
            primarySwatch: Colors.orange,
            appBarTheme: const AppBarTheme(elevation: 16.0),
          ),
          home: HomeScreen(),
      ),
    );
  }
}