import 'package:flutter/material.dart';
import 'package:eshopcoffe/pages/product_list_page.dart';
import 'package:eshopcoffe/widgets/search_widget.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  HomeScreenState createState() => HomeScreenState();
}

class HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Column(
        children: <Widget>[
          const SearchWidget(),
          SizedBox(
            height: 10,
            child: Container(
              color: const Color(0xFFF5F6F7)
            )
          ),
          SizedBox(
              height: 10,
              child: Container(
                  color: const Color(0xFFF5F6F7)
              )
          ),
          const Expanded(
            child: ProductListPage('products/')
          ),
        ]
      )
    );
  }
}