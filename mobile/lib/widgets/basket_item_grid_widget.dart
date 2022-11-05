import 'package:flutter/material.dart';
import 'package:eshopcoffe/models/basket_item/basket_item_model.dart';

import 'package:eshopcoffe/services/baskets_service.dart';
import 'package:eshopcoffe/utils/snack_bar_helper.dart';

class BasketItemGridWidget extends StatelessWidget {
  final BasketItemModel basketItem;
  final Function? reloadMainScreen;
  final bool showRemove;

  const BasketItemGridWidget(this.basketItem, this.reloadMainScreen, this.showRemove, {super.key});

  @override
  Widget build(BuildContext context) {
    onRemoveFromBasketButtonPressed() async {
      await BasketsService()
          .removeFromBasket(basketItem.product.id)
          .then((response) async
      {
        SnackBarHelper.success(context, 'Product was successfully removed from your cart.');
        reloadMainScreen!();
      },
      onError: (error) {
        SnackBarHelper.failure(context, error.toString());
      });
    }

    var buttonsWidgets = [];
    if (showRemove) {
      buttonsWidgets.add(removeFromBasketButton(onRemoveFromBasketButtonPressed));
    }

    return Container(
      padding: const EdgeInsets.fromLTRB(10, 10, 10, 0),
      height: showRemove ? 220 : 130,
      width: double.maxFinite,
      child: Card(
        elevation: 1,
        child: Padding(
          padding: const EdgeInsets.all(5),
          child: Stack(
            children: [
              Align(
                alignment: Alignment.centerRight,
                child: Stack(
                  children: [
                    Padding(
                      padding: const EdgeInsets.only(left: 10, top: 5),
                      child: Column(
                        children: [
                          Row(
                            children: [
                              basketItemImage(basketItem.product.imageUrl),
                              const SizedBox(
                                  height: 10
                              ),
                              basketItemName(basketItem.product.name, basketItem.amount)
                            ],
                          ),
                          Row(
                              mainAxisAlignment: MainAxisAlignment.end,
                              children: [
                                basketItemCurrency(basketItem.product.currencyText(basketItem.amount))
                              ]
                          ),
                          const Divider(),
                          Row(
                            children: [
                              ...buttonsWidgets
                            ],
                          )
                        ],
                      ),
                    )
                  ],
                ),
              )
            ],
          ),
        ),
      )
    );
  }
}

Widget basketItemImage(itemImageUrl) {
  return Padding(
    padding: const EdgeInsets.only(left: 0.0),
    child: Align(
      alignment: Alignment.centerLeft,
      child: Image.network(
        itemImageUrl,
        width: 50,
        height: 50,
      ),
    ),
  );
}

Widget basketItemName(String itemName, int itemAmount) {
  return Align(
    alignment: Alignment.centerLeft,
    child: RichText(
      text: TextSpan(
        text: (itemName.length <= 20 ? itemName : itemName.substring(0, 20)),
        style: const TextStyle(
          color: Color(0xFF444444),
          fontFamily: 'Roboto-Light.ttf',
          fontSize: 15,
          fontWeight: FontWeight.w400
        ),
        children: <TextSpan>[
          TextSpan(
            text: '\n$itemAmount u.',
            style: const TextStyle(
              color: Colors.grey,
              fontSize: 15,
              fontWeight: FontWeight.bold
            )
          ),
        ],
      ),
    ),
  );
}

Widget basketItemCurrency(String currencyText) {
  return Align(
    alignment: Alignment.centerRight,
    child: Padding(
      padding: const EdgeInsets.only(),
      child: Row(
        children: <Widget>[
          RichText(
            textAlign: TextAlign.right,
            text: TextSpan(
              text: currencyText,
              style: const TextStyle(
                color: Color(0xFF77AF4D),
                fontFamily: 'Roboto-Light.ttf',
                fontWeight: FontWeight.w500,
                fontSize: 20,
              )
            ),
          ),
        ],
      ),
    ),
  );
}

Widget removeFromBasketButton(Function onButtonPressed) {
  return Padding(
    padding: const EdgeInsets.only(right: 10.0),
    child: InkWell(
      onTap: () async => onButtonPressed(),
      child: const Text(
        "Remove",
        style: TextStyle(
          color: Color(0xFF454A3E),
          fontFamily: 'Roboto-Light.ttf',
          fontSize: 15,
          fontStyle: FontStyle.normal,
        ),
      ),
    )
  );
}