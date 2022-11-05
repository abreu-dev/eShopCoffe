import 'package:flutter/material.dart';
import 'package:eshopcoffe/models/order_item/order_item_model.dart';

class OrderItemDetailGridWidget extends StatelessWidget {
  final OrderItemModel orderItem;

  const OrderItemDetailGridWidget(this.orderItem, {super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: const EdgeInsets.fromLTRB(10, 10, 10, 0),
      height: 130,
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
                              orderItemImage(orderItem.imageUrl),
                              const SizedBox(
                                  height: 10
                              ),
                              orderItemName(orderItem.name, orderItem.amount)
                            ],
                          ),
                          Row(
                              mainAxisAlignment: MainAxisAlignment.end,
                              children: [
                                orderItemCurrency(orderItem.currencyText())
                              ]
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

Widget orderItemImage(itemImageUrl) {
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

Widget orderItemName(String itemName, int itemAmount) {
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

Widget orderItemCurrency(String currencyText) {
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