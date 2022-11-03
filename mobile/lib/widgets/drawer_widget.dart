import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:eshopcoffe/blocs/authentication/authentication_cubit.dart';
import 'package:eshopcoffe/components/sign_in_page.dart';
import 'package:eshopcoffe/main.dart';
import 'package:eshopcoffe/models/authenticated_user/authenticated_user_model.dart';

class DrawerWidget extends StatefulWidget {
  const DrawerWidget({super.key});

  @override
  DrawerWidgetState createState() => DrawerWidgetState();
}

class DrawerWidgetState extends State<DrawerWidget> {
  @override
  Widget build(BuildContext context) {
    return BlocBuilder<AuthenticationCubit, AuthenticatedUserModel?>(
      builder: (BuildContext context, AuthenticatedUserModel? user) {
        return buildView(context, user);
      }
    );
  }

  Widget buildView(BuildContext context, AuthenticatedUserModel? user) {
    var isLoggedIn = user != null;

    var widgets = <Widget>[];

    var homeWidget = _createDrawerItem(
        icon: Icons.home,
        text: 'Home',
        onTap: () =>
            Navigator.push(context, MaterialPageRoute(builder: (context) => const MyHomePage()))
    );

    if (isLoggedIn) {
      widgets.add(_createDrawerHeaderForAuthenticated(user));
      widgets.add(homeWidget);
      widgets.add(_createDrawerItem(
        icon: FontAwesomeIcons.user,
        text: 'Sign Out',
        onTap: () => {
          context.read<AuthenticationCubit>().signOut(),
          Navigator.push(context, MaterialPageRoute(builder: (context) => const MyHomePage()))
        }));
    } else {
      widgets.add(_createDrawerHeaderForUnauthenticated());
      widgets.add(homeWidget);
      widgets.add(_createDrawerItem(
        icon: FontAwesomeIcons.user,
        text: 'Sign In',
        onTap: () =>
          Navigator.push(context, MaterialPageRoute(builder: (context) => const SignInPage()))));
    }

    return SizedBox(
        width: MediaQuery.of(context).size.width * 0.65,
        child: Drawer(
          child: Column(
            children: <Widget>[
              Expanded(
                child: Column(
                  children: widgets,
                )
              ),
              _createDrawerFooter()
            ]
          ),
        )
    );
  }
}

Widget _createDrawerHeaderForAuthenticated(AuthenticatedUserModel authenticatedUserModel) {
  var user = authenticatedUserModel.user;
  return UserAccountsDrawerHeader(
    decoration: const BoxDecoration(
      color: Color(0xFF5D8640),
    ),
    accountName: Text(
      user.username,
      style: const TextStyle(
        color: Color(0xFFFFFFFF)
      ),
    ),
    accountEmail: Text(
      user.email,
      style: const TextStyle(
        color: Color(0xFFFFFFFF)
      ),
    ),
    currentAccountPicture: const CircleAvatar(
      backgroundColor: Color(0xFFFFFFFF),
      child: Icon(
        FontAwesomeIcons.solidUser,
        color: Color(0xFF5D8640),
        size: 50,
      ),
    ),
  );
}

Widget _createDrawerFooter() {
  return Align(
    alignment: FractionalOffset.bottomCenter,
    child: Image.asset('assets/images/app_thumb_1.png')
  );
}

Widget _createDrawerHeaderForUnauthenticated() {
  return Align(
      alignment: FractionalOffset.bottomCenter,
      child: Image.asset(
          'assets/images/app_icon_1.png',
          width: 130,
          height: 130,
      )
  );
}

Widget _createDrawerItem({required IconData icon, required String text, required GestureTapCallback onTap}) {
  return ListTile(
    title: Row(
      children: <Widget>[
        Icon(
          icon,
          color: const Color(0xFF808080)
        ),
        Padding(
          padding: const EdgeInsets.only(left: 15.0),
          child: Text(
            text,
            style: const TextStyle(color: Color(0xFF484848))
          ),
        )
      ]
    ),
    onTap: onTap
  );
}