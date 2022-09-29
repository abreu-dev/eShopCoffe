import '../../models/product/product_model.dart';

class ProductListWrapperModel {
  List<ProductModel> products;
  int currentPage;
  int totalItems;
  int totalPages;
  bool isFailed;
  bool isLoaded;

  ProductListWrapperModel.succeed(this.products, this.currentPage, this.totalItems, this.totalPages):
        isFailed = false,
        isLoaded = true;

  ProductListWrapperModel.failed():
        products = <ProductModel>[],
        currentPage = 0,
        totalItems = 0,
        totalPages = 0,
        isFailed = true,
        isLoaded = false;

  ProductListWrapperModel.initial():
        products = <ProductModel>[],
        currentPage = 0,
        totalItems = 0,
        totalPages = 0,
        isFailed = false,
        isLoaded = false;
}