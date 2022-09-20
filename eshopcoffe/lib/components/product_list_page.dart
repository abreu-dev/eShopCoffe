import 'package:flutter/material.dart';
import '../models/product_model.dart';
import '../widgets/circular_progress_widget.dart';
import '../widgets/grid_tiles_category_widget.dart';

class ProductListPage extends StatefulWidget {
  final String slug;

  const ProductListPage(this.slug, {super.key});

  @override
  ProductListPageState createState() => ProductListPageState();
}

class ProductListPageState extends State<ProductListPage> {
  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
      future: getProductList(widget.slug),
      builder: (context, AsyncSnapshot snapshot) {
        switch (snapshot.connectionState) {
          case ConnectionState.none:
          case ConnectionState.waiting:
            return CircularProgressWidget();
          default:
            if (snapshot.hasError) {
              return Text('Error: ${snapshot.error}');
            }
            else {
              return createListView(context, snapshot);
            }
        }
      }
    );
  }
}

Widget createListView(BuildContext context, AsyncSnapshot snapshot) {
  List<ProductModel> values = snapshot.data;
  return GridView.count(
    crossAxisCount: 2,
    padding: const EdgeInsets.all(1.0),
    childAspectRatio: 8.0 / 9.0,
    children: List<Widget>.generate(values.length, (index) {
      return GridTile(
        child: GridTilesProductWidget(values[index].name, values[index].imageUrl, values[index].slug)
        );
    }),
  );
}

Future<List<ProductModel>> getProductList(String slug) async {
  return <ProductModel>[
    ProductModel('tester', '??', 'https://www.casasbahia-imagens.com.br/html/conteudo-produto/73/10442841/aspirador-agua-po-electrolux-acqua-power-aqp20_.jpg'),
    ProductModel('tester', '??', 'https://www.casasbahia-imagens.com.br/html/conteudo-produto/73/10442841/aspirador-agua-po-electrolux-acqua-power-aqp20_.jpg'),
    ProductModel('tester', '??', 'https://www.casasbahia-imagens.com.br/html/conteudo-produto/73/10442841/aspirador-agua-po-electrolux-acqua-power-aqp20_.jpg'),
    ProductModel('tester', '??', 'https://www.casasbahia-imagens.com.br/html/conteudo-produto/73/10442841/aspirador-agua-po-electrolux-acqua-power-aqp20_.jpg'),
    ProductModel('tester', '??', 'https://www.casasbahia-imagens.com.br/html/conteudo-produto/73/10442841/aspirador-agua-po-electrolux-acqua-power-aqp20_.jpg'),
    ProductModel('tester', '??', 'https://www.casasbahia-imagens.com.br/html/conteudo-produto/73/10442841/aspirador-agua-po-electrolux-acqua-power-aqp20_.jpg')
  ];
}
