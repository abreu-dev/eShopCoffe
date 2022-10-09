import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:eshopcoffe/blocs/products/product_list_wrapper_model.dart';
import 'package:eshopcoffe/models/product_paged_list/product_paged_list_model.dart';

class CatalogCubit extends Cubit<ProductListWrapperModel> {
  CatalogCubit(): super(ProductListWrapperModel.initial());

  void setProductList(ProductPagedListModel productPagedListModel) {
    emit(ProductListWrapperModel.succeed(
        state.products + productPagedListModel.data,
        productPagedListModel.currentPage,
        productPagedListModel.totalItems,
        productPagedListModel.totalPages));
  }

  void setFailedState() {
    emit(ProductListWrapperModel.failed());
  }

  void setRealoadState() {
    emit(ProductListWrapperModel.initial());
  }
}