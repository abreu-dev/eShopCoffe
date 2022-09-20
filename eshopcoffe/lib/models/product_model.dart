class ProductModel {
  String name;
  String slug;
  String imageUrl;
  String price;

  ProductModel(this.name, this.slug, this.imageUrl, this.price);

  ProductModel.fromJson(Map<String, dynamic> json):
    name = json['name'],
    slug = json['slug'],
    imageUrl = json['image_url'],
    price = json['price'];

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['name'] = name;
    data['slug'] = slug;
    data['image_url'] = imageUrl;
    data['price'] = price;
    return data;
  }
}
