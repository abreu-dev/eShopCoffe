import 'package:eshopcoffe/models/order_paged_list/order_paged_list_model.dart';
import 'package:eshopcoffe/services/orders_service.dart';
import 'package:flutter/material.dart';
import 'package:eshopcoffe/widgets/app_bar_widget.dart';
import 'package:eshopcoffe/widgets/circular_progress_widget.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:eshopcoffe/widgets/order_item_grid_widget.dart';

class OrdersScreen extends StatefulWidget {
  final int page;

  const OrdersScreen(this.page, {super.key});

  @override
  OrdersScreenState createState() => OrdersScreenState();
}

class OrdersScreenState extends State<OrdersScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFfafafa),
      appBar: appBarWidget(context, 'OrdersScreen'),
      body: FutureBuilder(
          future: getOrdersData(widget.page),
          builder: (context, AsyncSnapshot snapshot) {
            switch (snapshot.connectionState) {
              case ConnectionState.none:
              case ConnectionState.waiting:
                return const CircularProgressWidget();
              default:
                if (snapshot.hasError) {
                  return const Text('Nada aqui.');
                }
                else {
                  return createOrdersView(context, snapshot);
                }
            }
          }
        )
    );
  }
}

class EmptyOrdersScreen extends StatefulWidget {
  const EmptyOrdersScreen({super.key});

  @override
  EmptyOrdersScreenState createState() => EmptyOrdersScreenState();
}

class EmptyOrdersScreenState extends State<EmptyOrdersScreen> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Container(
        decoration: const BoxDecoration(color: Colors.white),
        child: Column(
          children: <Widget>[
            SizedBox(
              height: 70,
              child: Container(
                color: const Color(0xFFFFFFFF),
              ),
            ),
            SizedBox(
              width: double.infinity,
              height: 250,
              child: Image.asset(
                "assets/images/empty_shopping_cart.png",
                height: 250,
                width: double.infinity,
              ),
            ),
            SizedBox(
              height: 40,
              child: Container(
                color: const Color(0xFFFFFFFF),
              ),
            ),
            const SizedBox(
              width: double.infinity,
              child: Text(
                "Você não tem nada em seu histórico de pedidos!",
                style: TextStyle(
                  color: Color(0xFF67778E),
                  fontFamily: 'Roboto-Light.ttf',
                  fontSize: 20,
                  fontStyle: FontStyle.normal,
                ),
                textAlign: TextAlign.center,
              ),
            )
          ],
        ),
      ),
    );
  }
}

class FilledOrdersScreen extends StatefulWidget {
  OrderPagedListModel orders;

  FilledOrdersScreen(this.orders, {super.key});

  @override
  FilledOrdersScreenState createState() => FilledOrdersScreenState();
}

class FilledOrdersScreenState extends State<FilledOrdersScreen> {
  @override
  Widget build(BuildContext context) {
    var widgets = List<Widget>.generate(widget.orders.data.length, (index) {
      return GridTile(
          child: OrderGridWidget(widget.orders.data[index])
      );
    });

    if (widget.orders.currentPage + 1 < widget.orders.totalPages) {
      widgets.add(
        Align(
          alignment: Alignment.center,
          child: IconButton(
            onPressed: () {
              Navigator.push(
                  context,
                  MaterialPageRoute(
                      builder: (context) => OrdersScreen(widget.orders.currentPage + 1)
                  )
              );
            },
            icon: const Icon(FontAwesomeIcons.arrowRight, size: 25),
            color: const Color(0xFF323232),
          ),
        ),
      );
    }

    return SingleChildScrollView(
        child: GridView.count(
          crossAxisCount: 1,
          shrinkWrap: true,
          physics: const NeverScrollableScrollPhysics(),
          padding: const EdgeInsets.all(1.0),
          childAspectRatio: 3.0 / 1,
          children: widgets
        )
    );
  }
}

Future<OrderPagedListModel> getOrdersData(int page) async {
  return await OrdersService().getPaged(page);
}

Widget createOrdersView(BuildContext context, AsyncSnapshot snapshot) {
  OrderPagedListModel orderPagedListModel = snapshot.data;

  if (orderPagedListModel.data.isEmpty) return const EmptyOrdersScreen();

  return FilledOrdersScreen(orderPagedListModel);
}

