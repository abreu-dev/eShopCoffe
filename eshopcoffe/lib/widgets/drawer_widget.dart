import 'package:eshopcoffe/components/sign_in_page.dart';
import 'package:eshopcoffe/main.dart';
import 'package:flutter/material.dart';

class DrawerWidget extends StatefulWidget {
  const DrawerWidget({super.key});

  @override
  DrawerWidgetState createState() => DrawerWidgetState();
}

class DrawerWidgetState extends State<DrawerWidget> {
  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: MediaQuery.of(context).size.width * 0.65,
      child: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: <Widget>[
            _createDrawerHeader(),
            _createDrawerItem(
              icon: Icons.home,
              text: 'Home',
              onTap: () =>
                  Navigator.push(context, MaterialPageRoute(builder: (context) => const MyHomePage()))
            )
          ],
        )
      )
    );
  }
}

Widget _createDrawerHeader() {
  return DrawerHeader(
    margin: EdgeInsets.zero,
    padding: EdgeInsets.zero,
    child: Stack(
      children: <Widget>[
        Container(
          padding: const EdgeInsets.all(20),
          child: Center(
            child: Image.asset(
              'assets/images/ic_app_icon.png',
              width: 130,
              height: 130,
            )
          )
        ),
        const Positioned(
          bottom: 12.0,
          left: 16.0,
          child: Text(
            'Developed for learning purposes by "Gabriel"',
            style: TextStyle(
              color: Color(0xFF545454),
              fontSize: 10.0,
              fontWeight: FontWeight.w500
            ),
          ),
        )
      ],
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