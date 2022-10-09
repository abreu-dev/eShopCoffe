import 'package:eshopcoffe/components/sign_in_page.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

import '../services/session_service.dart';
import '../utils/snack_bar_helper.dart';

class ConfirmPasswordResetPage extends StatefulWidget {
  final String username;

  const ConfirmPasswordResetPage(this.username, {super.key});

  @override
  ConfirmPasswordResetPageState createState() => ConfirmPasswordResetPageState();
}

class ConfirmPasswordResetPageState extends State<ConfirmPasswordResetPage> {
  final _newPasswordController = TextEditingController();
  final _passwordResetCodeController = TextEditingController();
  var _passwordVisible = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: buildView(),
    );
  }

  Widget buildView() {
    onConfirmPasswordResetButtonPressed() async {
      await SessionService().confirmPasswordReset(
          widget.username,
          _newPasswordController.text,
          _passwordResetCodeController.text)
      .then((response) async {
        SnackBarHelper.success(context, 'Password reset succeed! Please, try to sign in.');
        Navigator.push(context, MaterialPageRoute(builder: (context) => const SignInPage()));
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
                  maxLength: 6,
                  maxLengthEnforcement: MaxLengthEnforcement.enforced,
                  controller: _passwordResetCodeController,
                  showCursor: true,
                  keyboardType: TextInputType.number,
                  inputFormatters: <TextInputFormatter>[
                    FilteringTextInputFormatter.digitsOnly
                  ], // Only numb
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
                      FontAwesomeIcons.key,
                      color: const Color(0xFF666666),
                      size: defaultIconSize,
                    ),
                    fillColor: const Color(0xFFF2F3F5),
                    hintStyle: TextStyle(
                        color: const Color(0xFF666666),
                        fontFamily: defaultFontFamily,
                        fontSize: defaultFontSize),
                    hintText: "Password reset code",
                  ),
                ),
                const SizedBox(
                  height: 15,
                ),
                TextField(
                  controller: _newPasswordController,
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
                    hintText: "New password",
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
                    onPressed: () async => onConfirmPasswordResetButtonPressed(),
                    color: const Color(0xFF74AA50),
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(15.0),
                        side: const BorderSide(color: Color(0xFF74AA50))
                    ),
                    child: const Text(
                      "Confirm password reset",
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
                    "Remembered your account? ",
                    style: TextStyle(
                      color: const Color(0xFF666666),
                      fontFamily: defaultFontFamily,
                      fontSize: defaultFontSize,
                      fontStyle: FontStyle.normal,
                    ),
                  ),
                  InkWell(
                    onTap: () {
                      Navigator.push(
                        context,
                        MaterialPageRoute(builder: (context) => const SignInPage()),
                      );
                    },
                    child: Text(
                      "Sign In",
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
