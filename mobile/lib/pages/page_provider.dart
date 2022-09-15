import 'package:auto_route/auto_route.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../blocs/authentication/authentication_bloc.dart';
import '../config/app_config.dart';
import '../routes/router.gr.dart';
import '../services/snackbar_service.dart';

class PageProvider extends StatelessWidget implements AutoRouteWrapper {
  const PageProvider({super.key});

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<AuthenticationBloc, AuthenticationState>(
      builder: (context, state) {
        return WillPopScope(
          onWillPop: () async => false,
          child: AutoRouter.declarative(
            routes: (context) => [
              if (state is AuthenticationUnauthenticatedState)
                const LoginRoute()
              else if (state is AuthenticationLoadingState)
                const LoadingRoute()
              else
                const HomeRoute()
            ]
          )
        );
      }
    );
  }

  @override
  Widget wrappedRoute(BuildContext context) {
    final snackBarService = SnackBarService(context: context);
    return MultiBlocProvider(
      providers: [
        BlocProvider<AuthenticationBloc>(create: (_) => AuthenticationBloc(snackBarService: snackBarService))
      ],
      child: BlocProvider<AuthenticationBloc>(
        create: (context) => AuthenticationBloc(snackBarService: snackBarService),
        child: this
      )
    );
  }
}