import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/blocs/authentication_cubit.dart';
import 'package:eshopcoffe/models/authenticated_user_model.dart';
import 'package:eshopcoffe/services/snack_bar_service.dart';
import 'package:eshopcoffe/screens/login_screen.dart';
import 'package:eshopcoffe/services/health_service.dart';

class HomeScreen extends StatelessWidget {
  HomeScreen({Key? key}) : super(key: key);

  final HealthService healthService = HealthService();

  @override
  Widget build(BuildContext context) {
    onLogoutButtonPressed() {
      BlocProvider.of<AuthenticationCubit>(context).logout();
      Navigator.push(context, MaterialPageRoute(builder: (context) => const LoginScreen()));
    }

    onHealthButtonPressed() async {
      await healthService.health().then((response) async {
        SnackBarService.success(context, "Health OK!");
      },
      onError: (error) {
        SnackBarService.failure(context, "Health NOK!");
      });
    }

    return BlocBuilder<AuthenticationCubit, AuthenticatedUserModel?>(
      buildWhen: (previous, current) => previous != current && current != null,
      builder: (BuildContext context, AuthenticatedUserModel? user) {
        return Scaffold(
          appBar: AppBar(
            title: const Text('eShopCoffee')
          ),
          body: Container(
            padding: const EdgeInsets.symmetric(vertical: 20.0, horizontal: 25.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                const SizedBox(height: 70),
                Text("Welcome ${user?.username}!"),
                const SizedBox(height: 30),
                SizedBox(
                  width: 400,
                  child: ElevatedButton(
                    onPressed: () async => onHealthButtonPressed(),
                    child: const Text('Health'),
                  ),
                ),
                const SizedBox(height: 30),
                SizedBox(
                  width: 400,
                  child: ElevatedButton(
                    onPressed: () async => onLogoutButtonPressed(),
                    child: const Text('Logout'),
                  ),
                ),
              ],
            ),
          )
        );
      }
    );

  }
}