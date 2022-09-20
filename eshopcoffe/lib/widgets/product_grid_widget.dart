import 'package:flutter/material.dart';

class ProductGridWidget extends StatelessWidget {
  final String name;
  final String imageUrl;
  final String slug;

  const ProductGridWidget(this.name, this.imageUrl, this.slug, {super.key});

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () { },
      child: Card(
          color: Colors.white,
          elevation: 0,
          child: Center(
            child: Column(
              children: <Widget>[
                Image.network(
                  imageUrl,
                  width: 100,
                  height: 100,
                ),
                Text(name,
                    style: const TextStyle(
                        color: Color(0xFF000000),
                        fontFamily: 'Roboto-Light.ttf',
                        fontSize: 12))
              ],
            ),
          )),
    );
  }
}