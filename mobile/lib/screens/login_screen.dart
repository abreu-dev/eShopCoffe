import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/services/authentication_service.dart';
import 'package:eshopcoffe/blocs/authentication_cubit.dart';
import 'package:eshopcoffe/models/authenticated_user_model.dart';
import 'package:eshopcoffe/services/snack_bar_service.dart';
import 'package:eshopcoffe/screens/home_screen.dart';

class LoginScreen extends StatelessWidget {
  const LoginScreen({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
            title: const Text('eShopCoffee')
        ),
        body: const LoginForm()
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

  final AuthenticationService authenticationService = AuthenticationService();

  @override
  Widget build(BuildContext context) {
    onLoginButtonPressed() async {
      await authenticationService.login(_usernameController.text, _passwordController.text).then((response) async {
        var model = AuthenticatedUserModel.fromJson(response.data);
        if (!mounted) return;
        BlocProvider.of<AuthenticationCubit>(context).login(model);
        Navigator.push(context, MaterialPageRoute(builder: (context) => HomeScreen()));
      },
      onError: (error) {
        SnackBarService.failure(context, error.toString());
      });
    }

    return Container(
      padding: const EdgeInsets.symmetric(vertical: 20.0, horizontal: 25.0),
      child: Form(
        key: _formKey,
        child: Column(
          mainAxisAlignment: MainAxisAlignment.start,
          children: <Widget>[
            const SizedBox(height: 70),
            const Text("Welcome!"),
            const SizedBox(height: 30),
            SizedBox(
              width: 400,
              child: TextFormField(
                controller: _usernameController,
                decoration: const InputDecoration(labelText: 'Username'),
              ),
            ),
            const SizedBox(height: 30),
            SizedBox(
              width: 400,
              child: TextFormField(
                obscureText: true,
                controller: _passwordController,
                decoration: const InputDecoration(labelText: 'Password'),
              ),
            ),
            const SizedBox(height: 25),
            SizedBox(
              width: 400,
              child: ElevatedButton(
                onPressed: () async => onLoginButtonPressed(),
                child: const Text('Login'),
              ),
            ),
          ],
        )
      )
    );

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