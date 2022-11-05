import 'package:eshopcoffe/models/order_event/order_event_model.dart';
import 'package:flutter/material.dart';
import 'package:eshopcoffe/widgets/circular_progress_widget.dart';
import 'package:eshopcoffe/widgets/app_bar_widget.dart';
import 'package:eshopcoffe/models/order/order_model.dart';
import 'package:eshopcoffe/services/orders_service.dart';

import '../widgets/order_item_detail_grid_widget.dart';

class OrderDetailScreen extends StatefulWidget {
  final String orderId;

  const OrderDetailScreen(this.orderId, {super.key});

  @override
  OrderDetailScreenState createState() => OrderDetailScreenState();
}

class OrderDetailScreenState extends State<OrderDetailScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color(0xFFfafafa),
      appBar: appBarWidget(context, 'OrderDetailScreen'),
      body: FutureBuilder(
        future: getDetailData(widget.orderId),
        builder: (context, AsyncSnapshot snapshot) {
          switch (snapshot.connectionState) {
            case ConnectionState.none:
            case ConnectionState.waiting:
              return const CircularProgressWidget();
            default:
              if (snapshot.hasError) {
                return Text('Error: ${snapshot.error}');
              }
              else {
                return createDetailView(context, snapshot);
              }
          }
        }
      )
    );
  }
}

Widget createDetailView(BuildContext context, AsyncSnapshot snapshot) {
  OrderModel orderModel = snapshot.data;
  return DetailScreen(orderModel);
}

class DetailScreen extends StatefulWidget {
  final OrderModel order;

  const DetailScreen(this.order, {super.key});

  @override
  DetailScreenState createState() => DetailScreenState();
}

class DetailScreenState extends State<DetailScreen> {
  @override
  Widget build(BuildContext context) {
    var itemsWidgets = List<Widget>.generate(widget.order.items.length, (index) {
      return GridTile(
          child: OrderItemDetailGridWidget(widget.order.items[index])
      );
    });

    var timelineWidgets = List<Widget>.generate(widget.order.events.length, (index) {
      return createTimelineEvent(widget.order.events[index], MediaQuery.of(context).size);
    });

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
                  "Order".toUpperCase(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF656565)
                  )
                ),
                Text(
                  widget.order.id,
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF74AA50)
                  )
                )
              ],
            )
          ),
          Container(
              padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
              color: const Color(0xFFFFFFFF),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                      "Created Date".toUpperCase(),
                      style: const TextStyle(
                          fontSize: 16,
                          fontWeight: FontWeight.w700,
                          color: Color(0xFF656565)
                      )
                  ),
                  Text(
                      widget.order.formattedDate(),
                      style: const TextStyle(
                          fontSize: 16,
                          fontWeight: FontWeight.w700,
                          color: Color(0xFF74AA50)
                      )
                  )
                ],
              )
          ),
          Container(
            padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
            color: const Color(0xFFFFFFFF),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Address".toUpperCase(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF656565)
                  )
                ),
                Text(
                  widget.order.address.get(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF74AA50)
                  )
                )
              ],
            )
          ),
          Container(
              padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
              color: const Color(0xFFFFFFFF),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                    "Payment".toUpperCase(),
                    style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w700,
                        color: Color(0xFF656565)
                    )
                  ),
                  Text(
                    widget.order.paymentMethod,
                    style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w700,
                        color: Color(0xFF74AA50)
                    )
                  )
                ],
              )
          ),
          Container(
              padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
              color: const Color(0xFFFFFFFF),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  Text(
                    "Status".toUpperCase(),
                    style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w700,
                        color: Color(0xFF656565)
                    )
                  ),
                  Text(
                    widget.order.status,
                    style: const TextStyle(
                        fontSize: 16,
                        fontWeight: FontWeight.w700,
                        color: Color(0xFF74AA50)
                    )
                  )
                ],
              )
          ),
          Container(
            padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
            color: const Color(0xFFFFFFFF),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Items".toUpperCase(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF656565)
                  )
                )
              ],
            )
          ),
          ...itemsWidgets,
          Container(
            padding: const EdgeInsets.only(left: 15, right: 15, top: 20, bottom: 20),
            color: const Color(0xFFFFFFFF),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                Text(
                  "Timeline".toUpperCase(),
                  style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.w700,
                      color: Color(0xFF656565)
                  )
                )
              ],
            )
          ),
          ...timelineWidgets
        ],
      )
    );
  }
}

Future<OrderModel> getDetailData(String orderId) async {
  return await OrdersService().getDetails(orderId);
}

Widget createTimelineEvent(OrderEventModel event, Size size) {
  return Stack(
    children: [
      Padding(
        padding: const EdgeInsets.all(40),
        child: Row(
          children: [
            SizedBox(width: size.width * 0.1),
            SizedBox(
              width: size.width * 0.2,
              child: Text(event.formattedDate()),
            ),
            SizedBox(
              child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(event.status),
                    Text(
                      event.status,
                      style: const TextStyle(color: Colors.grey, fontSize: 12),
                    )
                  ]
              ),
            )
          ],
        ),
      ),
      Positioned(
        left: 50,
        child: Container(
          height: size.height * 0.7,
          width: 1.0,
          color: Colors.grey.shade400,
        ),
      ),
      Positioned(
        bottom: 5,
        child: Padding(
          padding: const EdgeInsets.all(40.0),
          child: Container(
            height: 20.0,
            width: 20.0,
            decoration: BoxDecoration(
              color: event.color(),
              borderRadius: BorderRadius.circular(20),
            ),
          ),
        ),
      ),
    ],
  );
}