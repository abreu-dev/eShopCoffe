import 'package:eshopcoffe/widgets/basket_item_grid_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/models/basket/basket_model.dart';
import 'package:eshopcoffe/services/baskets_service.dart';
import 'package:eshopcoffe/blocs/authentication/authentication_cubit.dart';
import 'package:eshopcoffe/widgets/circular_progress_widget.dart';

import '../widgets/app_bar_widget.dart';

class BasketScreen extends StatefulWidget {
  const BasketScreen({super.key});

  @override
  BasketScreenState createState() => BasketScreenState();
}

class BasketScreenState extends State<BasketScreen> {
  @override
  Widget build(BuildContext context) {
    void reload() {
      setState(() {

      });
    }

    var needToSignIn = context.read<AuthenticationCubit>().state == null;

    if (needToSignIn) {
      return Scaffold(
          backgroundColor: const Color(0xFFfafafa),
          appBar: appBarWidget(context, showBasket: false),
          body: const NotSignInBasketScreen()
      );
    }

    return Scaffold(
      backgroundColor: const Color(0xFFfafafa),
      appBar: appBarWidget(context, showBasket: false),
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
                "You haven't anything in your basket!",
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
                "You need to sign in to see your basket!",
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
    return SingleChildScrollView(
      child: GridView.count(
        crossAxisCount: 1,
        shrinkWrap: true,
        physics: const NeverScrollableScrollPhysics(),
        padding: const EdgeInsets.all(1.0),
        childAspectRatio: 3.0 / 1.1,
        children: List<Widget>.generate(widget.basket.items.length, (index) {
          return GridTile(
              child: BasketItemGridWidget(widget.basket.items[index], widget.reload)
          );
        }),
      )
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