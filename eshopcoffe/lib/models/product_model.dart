class ProductModel {
  String name;
  String slug;
  String imageUrl;

  ProductModel(this.name, this.slug, this.imageUrl);

  ProductModel.fromJson(Map<String, dynamic> json):
    name = json['name'],
    slug = json['slug'],
    imageUrl = json['image_url'];

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = <String, dynamic>{};
    data['name'] = name;
    data['slug'] = slug;
    data['image_url'] = imageUrl;
    return data;
  }
}
