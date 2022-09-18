import 'package:auto_route/auto_route.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/shared/services/snack_bar_service.dart';
import 'package:eshopcoffe/features/account/domain/blocs/authentication_cubit.dart';
import 'package:eshopcoffe/features/account/domain/services/authentication_service.dart';

class ScreenWrapper extends StatelessWidget implements AutoRouteWrapper {
  const ScreenWrapper({super.key});

  @override
  Widget build(BuildContext context) {
    return const Scaffold(body: AutoRouter());
  }

  @override
  Widget wrappedRoute(BuildContext context) {
    final authenticationService = AuthenticationService();
    final snackBarService = SnackBarService(context: context);
    var authenticationCubit = AuthenticationCubit(authenticationService, snackBarService);

    return MultiBlocProvider(
        providers: [
          BlocProvider<AuthenticationCubit>(create: (BuildContext context) => authenticationCubit)
        ],
        child: BlocProvider<AuthenticationCubit>(
            create: (context) => authenticationCubit,
            child: this
        )
    );
  }
}