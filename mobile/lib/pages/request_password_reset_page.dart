import 'package:eshopcoffe/pages/sign_in_page.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';

import '../services/session_service.dart';
import '../utils/snack_bar_helper.dart';
import 'confirm_password_reset_page.dart';

class RequestPassswordResetPage extends StatefulWidget {
  const RequestPassswordResetPage({super.key});

  @override
  RequestPassswordResetPageState createState() => RequestPassswordResetPageState();
}

class RequestPassswordResetPageState extends State<RequestPassswordResetPage> {
  final _usernameController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: buildView(),
    );
  }

  Widget buildView() {
    onRequestPasswordResetButtonPressed() async {
      final String username = _usernameController.text;
      await SessionService().requestPasswordReset(
          username)
          .then((response) async {
        SnackBarHelper.success(context, 'Por favor, verifique o email com o código de confirmação.');
        Navigator.push(context, MaterialPageRoute(builder: (context) => ConfirmPasswordResetPage(username)));
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
                    hintText: "Nome de usuário",
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
                    onPressed: () async => onRequestPasswordResetButtonPressed(),
                    color: const Color(0xFF74AA50),
                    shape: RoundedRectangleBorder(
                        borderRadius: BorderRadius.circular(15.0),
                        side: const BorderSide(color: Color(0xFF74AA50))
                    ),
                    child: const Text(
                      "Recuperar minha senha",
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
                    "Lembrou sua conta? ",
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
                      "Login",
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
