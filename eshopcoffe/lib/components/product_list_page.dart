import 'package:eshopcoffe/services/products_service.dart';
import 'package:eshopcoffe/widgets/product_grid_widget.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../blocs/products/product_list_cubit.dart';
import '../blocs/products/product_list_wrapper_model.dart';
import '../models/product/product_model.dart';
import '../utils/snack_bar_helper.dart';
import '../widgets/circular_progress_widget.dart';

class ProductListPage extends StatefulWidget {
  final String slug;

  const ProductListPage(this.slug, {super.key});

  @override
  ProductListPageState createState() => ProductListPageState();
}

class ProductListPageState extends State<ProductListPage> {
  ScrollController _scrollController = ScrollController();

  void _scrollListener() async {
    if (_scrollController.offset >=
        _scrollController.position.maxScrollExtent &&
        !_scrollController.position.outOfRange) {
      var currentWrapper = context.read<CatalogCubit>().state;

      if (currentWrapper.products.length == currentWrapper.totalItems) return;

      await ProductsService().get(currentWrapper.currentPage + 1).then((response) async {
        context.read<CatalogCubit>().setProductList(response);
      },
      onError: (error) {
        SnackBarHelper.failure(context, error.toString());
      });
    }
  }

  @override
  void initState() {
    super.initState();
    _scrollController.addListener(_scrollListener);
  }

  @override
  void dispose() {
    _scrollController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    onLoadProductList() async {
      await ProductsService().get(0).then((response) async {
        context.read<CatalogCubit>().setProductList(response);
      },
      onError: (error) {
        SnackBarHelper.failure(context, error.toString());
        context.read<CatalogCubit>().setFailedState();
      });
    }

    return BlocBuilder<CatalogCubit, ProductListWrapperModel>(
      builder: (BuildContext context, ProductListWrapperModel productListWrapperModel) {
        if (productListWrapperModel.isLoaded) {
          return createListView(context, productListWrapperModel.products, _scrollController);
        }
        else if (productListWrapperModel.isFailed) {
          return createFailedView(context);
        }
        else {
          onLoadProductList();
          return const CircularProgressWidget();
        }
      }
    );
  }
}

Widget createListView(BuildContext context, List<ProductModel> products, ScrollController scrollController) {
  return SingleChildScrollView(
    controller: scrollController,
    child: GridView.count(
      crossAxisCount: 2,
      shrinkWrap: true,
      physics: const NeverScrollableScrollPhysics(),
      padding: const EdgeInsets.all(1.0),
      childAspectRatio: 8.0 / 12.0,
      children: List<Widget>.generate(products.length, (index) {
        return GridTile(
            child: ProductGridWidget(products[index].name, products[index].imageUrl, "", products[index].price)
        );
      }),
    )
  );
}

Widget createFailedView(BuildContext context) {
  return IconButton(
      icon: const Icon(Icons.refresh),
      tooltip: 'Refresh',
      onPressed: () {
        context.read<CatalogCubit>().setRealoadState();
      }
  );
}
