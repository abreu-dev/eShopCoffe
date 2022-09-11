import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../blocs/authentication/authentication_bloc.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    onLogoutButtonPressed() {
      context.read<AuthenticationBloc>().add(LoggedOutEvent());
    }

    return Scaffold(
      appBar: AppBar(
        title: const Text('Login Page')
      ),
      body: Center(
        child: ElevatedButton(
          onPressed: onLogoutButtonPressed,
          child: const Text('Logout')
        )
      )
    );
  }
}