import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:eshopcoffe/blocs/authentication/authentication_cubit.dart';
import 'package:eshopcoffe/blocs/products/product_list_cubit.dart';
import 'package:eshopcoffe/screens/basket_screen.dart';
import 'package:eshopcoffe/screens/home_screen.dart';
import 'package:eshopcoffe/widgets/app_bar_widget.dart';
import 'package:eshopcoffe/widgets/drawer_widget.dart';

void main() => runApp(const MyApp());

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MultiBlocProvider(
      providers: [
        BlocProvider<AuthenticationCubit>(
            create: (BuildContext context) => AuthenticationCubit()..tryLoadFromLocalStorage()
        ),
        BlocProvider<CatalogCubit>(
            create: (BuildContext context) => CatalogCubit()
        ),
      ],
      child: MaterialApp(
        home: const MyHomePage(),
        theme: ThemeData(
            fontFamily: 'Roboto',
            primaryColor: Colors.white,
            primaryColorDark: Colors.white,
            backgroundColor: Colors.white),
        debugShowCheckedModeBanner: false,
      )
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key});

  @override
  MyHomePageState createState() => MyHomePageState();
}

class MyHomePageState extends State<MyHomePage> {
  int selectedIndex = 0;
  final List<Widget> tabs = [
    const HomeScreen(),
    const BasketScreen()
  ];

  void onItemTapped(int index) {
    setState(() {
      selectedIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return buildView();
  }

  Widget buildView() {
    return DefaultTabController(
        length: tabs.length,
        child: Scaffold(
            appBar: appBarWidget(context),
            drawer: const DrawerWidget(),
            body: IndexedStack(
              index: selectedIndex,
              children: tabs,
            ),
            bottomNavigationBar: BottomNavigationBar(
              type: BottomNavigationBarType.fixed,
              items: const <BottomNavigationBarItem>[
                BottomNavigationBarItem(
                    icon: Icon(Icons.home),
                    label: 'Home'
                ),
                BottomNavigationBarItem(
                    icon: Icon(FontAwesomeIcons.bagShopping),
                    label: 'Basket'
                )
              ],
              currentIndex: selectedIndex,
              selectedItemColor: const Color(0xFF77AF4D),
              onTap: onItemTapped,
            )
        )
    );
  }
}