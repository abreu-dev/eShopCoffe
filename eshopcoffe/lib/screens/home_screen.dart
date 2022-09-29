import 'package:flutter/material.dart';

import 'package:eshopcoffe/components/product_list_page.dart';
import 'package:eshopcoffe/widgets/search_widget.dart';

import '../widgets/circular_progress_widget.dart';

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
          const PreferredSize(
            preferredSize: Size.fromHeight(50.0),
            child: TabBar(
                labelColor: Colors.black,
                tabs: [
                  Tab(
                    text: 'Products'
                  ),
                  Tab(
                    text: 'Nothing'
                  )
                ]
            ),
          ),
          SizedBox(
              height: 10,
              child: Container(
                  color: const Color(0xFFF5F6F7)
              )
          ),
          Expanded(
            child: TabBarView(
              children: [
                Container(
                  color: Colors.white24,
                  child: const ProductListPage('products/'),
                ),
                Container(
                  color: Colors.white24,
                  child: const CircularProgressWidget(),
                )
              ],
            ),
          ),
        ]
      )
    );
  }
}