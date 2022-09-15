import 'package:auto_route/auto_route.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../blocs/authentication/authentication_bloc.dart';
import '../routes/router.gr.dart';

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
    return MultiBlocProvider(
      providers: [
        BlocProvider<AuthenticationBloc>(create: (_) => AuthenticationBloc())
      ],
      child: BlocProvider<AuthenticationBloc>(
        create: (context) => AuthenticationBloc(),
        child: this
      )
    );
  }
}