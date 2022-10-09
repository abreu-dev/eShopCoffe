import 'package:eshopcoffe/components/request_password_reset.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:eshopcoffe/blocs/authentication/authentication_cubit.dart';
import 'package:eshopcoffe/main.dart';
import 'package:eshopcoffe/models/authenticated_user/authenticated_user_model.dart';
import 'package:eshopcoffe/services/session_service.dart';
import 'package:eshopcoffe/utils/snack_bar_helper.dart';
import 'package:eshopcoffe/components/sign_up_page.dart';

class SignInPage extends StatefulWidget {
  const SignInPage({super.key});

  @override
  SignInPageState createState() => SignInPageState();
}

class SignInPageState extends State<SignInPage> {
  final _usernameController = TextEditingController();
  final _passwordController = TextEditingController();
  var _passwordVisible = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: buildView(),
    );
  }

  Widget buildView() {
    onSignInButtonPressed() async {
      await SessionService().signIn(
          _usernameController.text,
          _passwordController.text)
      .then((response) async {
        var model = AuthenticatedUserModel.fromJson(response.data);
        context.read<AuthenticationCubit>().signIn(model);
        Navigator.push(context, MaterialPageRoute(builder: (context) => const MyHomePage()));
      },
      onError: (error) {
        SnackBarHelper.failure(context, error.toString());
      });
    }

    String defaultFontFamily = 'Roboto-Light.ttf';
    double defaultFontSize = 14;
    double defaultIconSize = 17;

    return Container(
      padding: const EdgeInsets.only(left: 20, right: 20, top: 35, bottom: 30),
      width: double.infinity,
      height: double.infinity,
      color: Colors.white70,
      child: Column(
        children: <Widget>[
          Flexible(
            flex: 1,
            child: InkWell(
              child: const Align(
                alignment: Alignment.topLeft,
                child: Icon(Icons.close),
              ),
              onTap: () {
                Navigator.pop(context);
              },
            ),
          ),
          Flexible(
            flex: 5,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: <Widget>[
                Container(
                  width: 130,
                  height: 130,
                  alignment: Alignment.center,
                  child: Image.asset("assets/images/app_icon_1.png"),
                ),
                const SizedBox(
                  height: 15,
                ),
                TextField(
                  controller: _usernameController,
                  showCursor: true,
                  decoration: InputDecoration(
                    border: const OutlineInputBorder(
                      borderRadius: BorderRadius.all(Radius.circular(10.0)),
                      borderSide: BorderSide(
                        width: 0,
                        style: BorderStyle.none,
                      ),
                    ),
                    filled: true,
                    prefixIcon: Icon(
                      FontAwesomeIcons.user,
                      color: const Color(0xFF666666),
                      size: defaultIconSize,
                    ),
                    fillColor: const Color(0xFFF2F3F5),
                    hintStyle: TextStyle(
                        color: const Color(0xFF666666),
                        fontFamily: defaultFontFamily,
                        fontSize: defaultFontSize),
                    hintText: "Username",
                  ),
                ),
                const SizedBox(
                  height: 15,
                ),
                TextField(
                  controller: _passwordController,
                  obscureText: !_passwordVisible,
                  showCursor: true,
                  decoration: InputDecoration(
                    border: const OutlineInputBorder(
                      borderRadius: BorderRadius.all(Radius.circular(10.0)),
                      borderSide: BorderSide(
                        width: 0,
                        style: BorderStyle.none,
                      ),
                    ),
                    filled: true,
                    prefixIcon: Icon(
                      Icons.lock_outline,
                      color: const Color(0xFF666666),
                      size: defaultIconSize,
                    ),
                    suffixIcon: IconButton(
                      icon: Icon(
                        _passwordVisible ? Icons.visibility : Icons.visibility_off,
                        color: const Color(0xFF666666),
                        size: defaultIconSize,
                      ),
                      onPressed: () {
                        setState(() {
                          _passwordVisible = !_passwordVisible;
                        });
                      }
                    ),
                    fillColor: const Color(0xFFF2F3F5),
                    hintStyle: TextStyle(
                      color: const Color(0xFF666666),
                      fontFamily: defaultFontFamily,
                      fontSize: defaultFontSize,
                    ),
                    hintText: "Password",
                  ),
                ),
                const SizedBox(
                  height: 15,
                ),
                SizedBox(
                  width: double.infinity,
                  child: InkWell(
                    onTap: () => {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => const RequestPassswordResetPage()),
                      )
                    },
                    child: Text(
                      "Forgot your password?",
                      style: TextStyle(
                        color: const Color(0xFF666666),
                        fontFamily: defaultFontFamily,
                        fontSize: defaultFontSize,
                        fontStyle: FontStyle.normal,
                      ),
                      textAlign: TextAlign.end,
                    ),
                  ),
                ),
                const SizedBox(
                  height: 15,
                ),
                Container(
                  width: double.infinity,
                  decoration: const BoxDecoration(
                      shape: BoxShape.circle, color: Color(0xFFF2F3F7)
                  ),
                  child: MaterialButton(
                    padding: const EdgeInsets.all(17.0),
                    onPressed: () async => onSignInButtonPressed(),
                    color: const Color(0xFF74AA50),
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(15.0),
                        side: const BorderSide(color: Color(0xFF74AA50))
                    ),
                    child: const Text(
                      "Sign In",
                      style: TextStyle(
                        color: Colors.white,
                        fontSize: 18,
                        fontFamily: 'Poppins-Medium.ttf',
                      ),
                      textAlign: TextAlign.center,
                    ),
                  ),
                ),
                const SizedBox(
                  height: 10,
                ),
              ],
            ),
          ),
          Flexible(
            flex: 1,
            child: Align(
              alignment: Alignment.bottomCenter,
              child: Row(
                crossAxisAlignment: CrossAxisAlignment.center,
                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[
                  Text(
                    "Don't have an account? ",
                    style: TextStyle(
                      color: const Color(0xFF666666),
                      fontFamily: defaultFontFamily,
                      fontSize: defaultFontSize,
                      fontStyle: FontStyle.normal,
                    ),
                  ),
                  InkWell(
                    onTap: () => {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => const SignUpPage()),
                      )
                    },
                    child: Text(
                      "Sign Up",
                      style: TextStyle(
                        color: const Color(0xFF74AA50),
                        fontFamily: defaultFontFamily,
                        fontSize: defaultFontSize,
                        fontStyle: FontStyle.normal,
                      ),
                    ),
                  ),
                ],
              ),
            ),
          )
        ],
      ),
    );
  }
}
