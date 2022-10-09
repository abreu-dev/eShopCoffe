enum Flavor {
  DEVELOPMENT,
  PRODUCTION,
}

class F {
  static Flavor? appFlavor;

  static String get name => appFlavor?.name ?? '';

  static String get title {
    switch (appFlavor) {
      case Flavor.DEVELOPMENT:
        return 'eShopCoffe.Dev';
      case Flavor.PRODUCTION:
        return 'eShopCoffe';
      default:
        return 'title';
    }
  }

  static String get apiUrl {
    switch (appFlavor) {
      case Flavor.PRODUCTION:
        return 'http://20.226.216.12';
      case Flavor.DEVELOPMENT:
      default:
        return 'http://10.0.2.2:5003';
    }
  }
}
