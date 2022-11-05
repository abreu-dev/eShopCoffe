import 'package:eshopcoffe/widgets/basket_item_grid_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/models/basket/basket_model.dart';
import 'package:eshopcoffe/services/baskets_service.dart';
import 'package:eshopcoffe/blocs/authentication/authentication_cubit.dart';
import 'package:eshopcoffe/widgets/circular_progress_widget.dart';
import 'package:eshopcoffe/widgets/app_bar_widget.dart';
import 'package:eshopcoffe/pages/create_order_page.dart';

class BasketScreen extends StatefulWidget {
  const BasketScreen({super.key});

  @override
  BasketScreenState createState() => BasketScreenState();
}

class BasketScreenState extends State<BasketScreen> {
  @override
  Widget build(BuildContext context) {
    void reload() {
      setState(() {});
    }

    var needToSignIn = context.read<AuthenticationCubit>().state == null;
    if (needToSignIn) {
      return Scaffold(
          backgroundColor: const Color(0xFFfafafa),
          appBar: appBarWidget(context, 'BasketScreen'),
          body: const NotSignInBasketScreen()
      );
    }

    return Scaffold(
      backgroundColor: const Color(0xFFfafafa),
      appBar: appBarWidget(context, 'BasketScreen'),
      body: FutureBuilder(
          future: getBasketData(),
          builder: (context, AsyncSnapshot snapshot) {
            switch (snapshot.connectionState) {
              case ConnectionState.none:
              case ConnectionState.waiting:
                return const CircularProgressWidget();
              default:
                if (snapshot.hasError) {
                  return const EmptyBasketScreen();
                }
                else {
                  return createBasketView(context, snapshot, reload);
                }
            }
          }
      )
    );
  }
}

class BottomNavBar extends StatelessWidget {
  final BasketModel basket;
  const BottomNavBar(this.basket, {super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.only(left: 20, right: 10),
      child: Row(
        children: [
          const Icon(
            Icons.favorite_border,
            color: Color(0x0ffe5e5e)
          ),
          const Spacer(),
          ElevatedButton(
            style: ElevatedButton.styleFrom(
              backgroundColor: const Color(0xFF74AA50),
              elevation: 0,
              shape: const RoundedRectangleBorder(
                borderRadius: BorderRadius.only(
                    topLeft: Radius.circular(10),
                    bottomLeft: Radius.circular(10)
                ),
                side: BorderSide(color: Color(0xFFfef2f2))
              )
            ),
            onPressed: () {
              Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => CreateOrderPage(basket))
              );
            },
            child: Text(
              'Criar pedido'.toUpperCase(),
              style: const TextStyle(
                  fontSize: 14,
                  fontWeight: FontWeight.w400,
                  color: Colors.white
              )
            ),
          )
        ],
      )
    );
  }
}

class EmptyBasketScreen extends StatefulWidget {
  const EmptyBasketScreen({super.key});

  @override
  EmptyBasketScreenState createState() => EmptyBasketScreenState();
}

class EmptyBasketScreenState extends State<EmptyBasketScreen> {
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
                "Seu carrinho está vazio!",
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

class NotSignInBasketScreen extends StatefulWidget {
  const NotSignInBasketScreen({super.key});

  @override
  NotSignInBasketScreenState createState() => NotSignInBasketScreenState();
}

class NotSignInBasketScreenState extends State<NotSignInBasketScreen> {
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
                "Você precisa realizar login para ver seu carrinho!",
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

class FilledBasketScreen extends StatefulWidget {
  final BasketModel basket;
  final Function reload;

  const FilledBasketScreen(this.basket, this.reload, {super.key});

  @override
  FilledBasketScreenState createState() => FilledBasketScreenState();
}

class FilledBasketScreenState extends State<FilledBasketScreen> {
  @override
  Widget build(BuildContext context) {
    var scrollBasket = SingleChildScrollView(
        child: GridView.count(
          crossAxisCount: 1,
          shrinkWrap: true,
          physics: const NeverScrollableScrollPhysics(),
          padding: const EdgeInsets.all(1.0),
          childAspectRatio: 3.0 / 1.1,
          children: List<Widget>.generate(widget.basket.items.length, (index) {
            return GridTile(
                child: BasketItemGridWidget(widget.basket.items[index], widget.reload, true)
            );
          }),
        )
    );

    return Column(
      children: [
        scrollBasket,
        const Spacer(),
        BottomNavBar(widget.basket)
      ],
    );
  }
}

Future<BasketModel> getBasketData() async {
  return await BasketsService().get();
}

Widget createBasketView(BuildContext context, AsyncSnapshot snapshot, Function reload) {
  BasketModel basketModel = snapshot.data;

  if (basketModel.items.isEmpty) return const EmptyBasketScreen();

  return FilledBasketScreen(basketModel, reload);
}