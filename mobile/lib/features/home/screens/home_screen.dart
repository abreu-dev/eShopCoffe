import 'dart:developer';

import 'package:auto_route/auto_route.dart';
import 'package:eshopcoffe/features/home/domain/services/health_service.dart';
import 'package:eshopcoffe/shared/services/snack_bar_service.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/features/account/domain/blocs/authentication_cubit.dart';
import 'package:eshopcoffe/routes/router.gr.dart';

class HomeScreen extends StatefulWidget  {
  final SnackBarService snackBarService;

  const HomeScreen(this.snackBarService, {super.key});

  @override
  HomeScreenState createState() => HomeScreenState(snackBarService);
}

class HomeScreenState extends State<HomeScreen> {
  final SnackBarService snackBarService;
  final HealthService healthService = HealthService();

  HomeScreenState(this.snackBarService);

  @override
  Widget build(BuildContext context) {
    onLogoutButtonPressed() {
      BlocProvider.of<AuthenticationCubit>(context).logout();
      context.navigateTo(const LoginRoute());
    }

    onHealthCheckButtonPressed() async {
      await healthService.health().then((response) {
        snackBarService.success(response.data);
      },
      onError: (error) {
        snackBarService.failure(error.toString());
      });
    }

    return Scaffold(
        appBar: AppBar(
            title: const Text('HomeScreen')
        ),
        body: Center(
          child: Column(
            children: <Widget>[
              ElevatedButton(
                onPressed: onHealthCheckButtonPressed,
                child: const Text('Health')
              ),
              ElevatedButton(
                onPressed: onLogoutButtonPressed,
                child: const Text('Logout')
              ),
            ]
          )
        )
    );
  }
}