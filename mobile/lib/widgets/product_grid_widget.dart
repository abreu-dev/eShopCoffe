import 'package:eshopcoffe/blocs/authentication/authentication_cubit.dart';
import 'package:eshopcoffe/screens/product_detail_screen.dart';
import 'package:flutter/material.dart';
import 'package:eshopcoffe/models/product/product_model.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

import '../utils/snack_bar_helper.dart';

class ProductGridWidget extends StatelessWidget {
  final ProductModel product;

  const ProductGridWidget(this.product, {super.key});

  @override
  Widget build(BuildContext context) {
    var isAvailable = product.isAvailable();

    return InkWell(
      onTap: () {
        Navigator.push(
            context,
            MaterialPageRoute(
                builder: (context) => ProductDetailScreen(
                    product.id,
                    isAvailable)
            )
        );
      },
      child: Container(
        padding: const EdgeInsets.only(top: 5),
        child: Card(
            color: Colors.white,
            shape: const RoundedRectangleBorder(
              borderRadius: BorderRadius.all(
                Radius.circular(8.0),
              ),
            ),
            elevation: 0,
            child: Center(
              child: Column(
                children: <Widget>[
                  Image.network(
                    product.imageUrl,
                    width: 150,
                    height: 150,
                  ),
                  Container(
                    alignment: Alignment.center,
                    padding: const EdgeInsets.only(left: 10, right: 10, top: 15),
                    child: Text(
                        (product.name.length <= 40 ? product.name : product.name.substring(0, 40)),
                        textAlign: TextAlign.left,
                        style: const TextStyle(
                            color: Color(0xFF444444),
                            fontFamily: 'Roboto-Light.ttf',
                            fontSize: 15,
                            fontWeight: FontWeight.w400)),
                  ),
                  Container(
                    alignment: Alignment.bottomLeft,
                    padding: const EdgeInsets.only(left: 10, right: 10, top: 10),
                    child: Text((isAvailable) ? product.currencyText() : 'Unavailable',
                        style: TextStyle(
                            color: (isAvailable)
                                ? const Color(0xFF77AF4D)
                                : const Color(0xFF454A3E),
                            fontFamily: 'Roboto-Light.ttf',
                            fontSize: 20,
                            fontWeight: FontWeight.w500)),
                  )
                ],
              ),
            )),
      ),
    );
  }
}