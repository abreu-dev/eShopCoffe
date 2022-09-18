import 'package:auto_route/auto_route.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/routes/router.gr.dart';
import 'package:eshopcoffe/shared/widgets/circular_progress_widget.dart';
import 'package:eshopcoffe/features/account/domain/blocs/authentication_cubit.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  LoginScreenState createState() => LoginScreenState();
}

class LoginScreenState extends State<LoginScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            title: const Text('LoginScreen')
        ),
        body: BlocBuilder<AuthenticationCubit, AuthenticationState>(
          buildWhen: (previous, current) => previous != current,
          builder: (context, state) {
            if (state is AuthenticationAuthenticatedState) {
              context.navigateTo(const HomeRouteWrapper());
            }
            if (state is AuthenticationLoadingState) {
              return const CircularProgressWidget();
            }
            else {
              return const LoginForm();
            }
          }
        )
    );
  }
}

class LoginForm extends StatefulWidget {
  const LoginForm({Key? key}) : super(key: key);

  @override
  LoginFormState createState() => LoginFormState();
}

class LoginFormState extends State<LoginForm> {
  final _formKey = GlobalKey<FormState>();
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    onLoginButtonPressed() async {
      await BlocProvider.of<AuthenticationCubit>(context).login(_usernameController.text, _passwordController.text);
    }

    return Form(
      key: _formKey,
      child: Column(
        children: <Widget>[
          TextFormField(
            controller: _usernameController,
            decoration: const InputDecoration(labelText: 'Username'),
          ),
          const SizedBox(height: 10.0),
          TextFormField(
            controller: _passwordController,
            decoration: const InputDecoration(labelText: 'Password'),
          ),
          const SizedBox(height: 10.0),
          ElevatedButton(
            onPressed: () async => onLoginButtonPressed(),
            child: const Text('Login'),
          ),
          Container(
              child: null
          )
        ],
      ),
    );
  }
}