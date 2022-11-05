import 'package:eshopcoffe/models/basket/basket_model.dart';
import 'package:eshopcoffe/screens/orders_screen.dart';
import 'package:eshopcoffe/services/orders_service.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:eshopcoffe/widgets/app_bar_widget.dart';
import 'package:eshopcoffe/models/create_order_item/create_order_item_model.dart';
import 'package:eshopcoffe/models/payment_method/payment_method_enum.dart';
import 'package:eshopcoffe/utils/snack_bar_helper.dart';
import 'package:eshopcoffe/widgets/basket_item_grid_widget.dart';

class CreateOrderPage extends StatefulWidget {
  final BasketModel basket;

  const CreateOrderPage(this.basket, {super.key});

  @override
  CreateOrderPageState createState() => CreateOrderPageState();
}

class CreateOrderPageState extends State<CreateOrderPage> {
  final _cepController = TextEditingController();
  final _numberController = TextEditingController();
  PaymentMethodEnum? _paymentMethodController = PaymentMethodEnum.cash;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        resizeToAvoidBottomInset: false,
        appBar: appBarWidget(context, 'CreateOrderPage'),
      body: buildView(),
    );
  }

  Widget buildView() {
    onCreateOrderButtonPressed() async {
      var items = widget.basket.items.map((e) => CreateOrderItemModel(productId: e.product.id, amount: e.amount));

      await OrdersService().post(
          _cepController.text,
          _numberController.text,
          _paymentMethodController,
          items.toList())
          .then((response) async {

        SnackBarHelper.success(context, 'Pedido criado com sucesso!');

        Navigator.of(context).pop();
        Navigator.of(context).pop();
        Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => const OrdersScreen(0))
        );
      },
      onError: (error) {
        SnackBarHelper.failure(context, error.toString());
      });
    }

    var itemsWidgets =
      List<Widget>.generate(widget.basket.items.length, (index) {
      return GridTile(
          child: BasketItemGridWidget(widget.basket.items[index], null, false)
      );
    });

    String defaultFontFamily = 'Roboto-Light.ttf';
    double defaultFontSize = 14;
    double defaultIconSize = 17;

    return SingleChildScrollView(
      child: Column(
        children: [
          Container(
            padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
            color: const Color(0xFFFFFFFF),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Endereço".toUpperCase(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF656565)
                  )
                )
              ],
            )
          ),
          Padding(
              padding: const EdgeInsets.only(left: 15, right: 15),
              child:
              TextField(
                controller: _cepController,
                showCursor: true,
                decoration: InputDecoration(
                  border: const OutlineInputBorder(
                    borderRadius: BorderRadius.all(Radius.circular(10.0)),
                    borderSide: BorderSide(
                      width: 0,
                      style: BorderStyle.none,
                    ),
                  ),
                  filled: true,
                  prefixIcon: Icon(
                    FontAwesomeIcons.user,
                    color: const Color(0xFF666666),
                    size: defaultIconSize,
                  ),
                  fillColor: const Color(0xFFF2F3F5),
                  hintStyle: TextStyle(
                      color: const Color(0xFF666666),
                      fontFamily: defaultFontFamily,
                      fontSize: defaultFontSize),
                  hintText: "Cep",
                ),
              )
          ),
          const SizedBox(
            height: 15,
          ),
          Padding(
            padding: const EdgeInsets.only(left: 15, right: 15),
            child:
            TextField(
              controller: _numberController,
              showCursor: true,
              decoration: InputDecoration(
                border: const OutlineInputBorder(
                  borderRadius: BorderRadius.all(Radius.circular(10.0)),
                  borderSide: BorderSide(
                    width: 0,
                    style: BorderStyle.none,
                  ),
                ),
                filled: true,
                prefixIcon: Icon(
                  FontAwesomeIcons.user,
                  color: const Color(0xFF666666),
                  size: defaultIconSize,
                ),
                fillColor: const Color(0xFFF2F3F5),
                hintStyle: TextStyle(
                    color: const Color(0xFF666666),
                    fontFamily: defaultFontFamily,
                    fontSize: defaultFontSize),
                hintText: "Número",
              ),
            )
          ),
          const SizedBox(
            height: 15,
          ),
          Container(
              padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
              color: const Color(0xFFFFFFFF),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                      "Forma de pagamento".toUpperCase(),
                      style: const TextStyle(
                          fontSize: 16,
                          fontWeight: FontWeight.w700,
                          color: Color(0xFF656565)
                      )
                  )
                ],
              )
          ),
          Padding(
              padding: const EdgeInsets.only(left: 15, right: 15),
              child:
                Column(
                  children: [
                    ListTile(
                      title: const Text('Dinheiro'),
                      leading: Radio<PaymentMethodEnum>(
                        value: PaymentMethodEnum.cash,
                        groupValue: _paymentMethodController,
                        onChanged: (PaymentMethodEnum? value) {
                          setState(() {
                            _paymentMethodController = value;
                          });
                        },
                      ),
                    ),
                    ListTile(
                      title: const Text('Cartão de crédito'),
                      leading: Radio<PaymentMethodEnum>(
                        value: PaymentMethodEnum.creditCard,
                        groupValue: _paymentMethodController,
                        onChanged: (PaymentMethodEnum? value) {
                          setState(() {
                            _paymentMethodController = value;
                          });
                        },
                      ),
                    ),
                    ListTile(
                      title: const Text('Cartão de débito'),
                      leading: Radio<PaymentMethodEnum>(
                        value: PaymentMethodEnum.debitCard,
                        groupValue: _paymentMethodController,
                        onChanged: (PaymentMethodEnum? value) {
                          setState(() {
                            _paymentMethodController = value;
                          });
                        },
                      ),
                    ),
                    ListTile(
                      title: const Text('Pix'),
                      leading: Radio<PaymentMethodEnum>(
                        value: PaymentMethodEnum.pix,
                        groupValue: _paymentMethodController,
                        onChanged: (PaymentMethodEnum? value) {
                          setState(() {
                            _paymentMethodController = value;
                          });
                        },
                      ),
                    ),
                  ],
                )
          ),
          const SizedBox(
            height: 15,
          ),
          Container(
            padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
            color: const Color(0xFFFFFFFF),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Itens".toUpperCase(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF656565)
                  )
                )
              ],
            )
          ),
          Column(
            children: [...itemsWidgets],
          ),
          const SizedBox(
            height: 15,
          ),
          Container(
            padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
            color: const Color(0xFFFFFFFF),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Valor total".toUpperCase(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF656565)
                  )
                ),
                Text(
                    widget.basket.totalValue(),
                    style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w700,
                        color: Color(0xFF656565)
                    )
                )
              ],
            )
          ),
          const SizedBox(
            height: 15,
          ),
          Container(
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
                    onPressed: onCreateOrderButtonPressed,
                    child: Text(
                      'Confirmar'.toUpperCase(),
                      style: const TextStyle(
                          fontSize: 14,
                          fontWeight: FontWeight.w400,
                          color: Colors.white
                      )
                    ),
                  )
                ],
              )
          )
        ],
      )
    );
  }
}

