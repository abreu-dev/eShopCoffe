enum Flavor {
  DEVELOPMENT,
  PRODUCTION,
}

class F {
  static Flavor? appFlavor;

  static String get name => appFlavor?.name ?? '';

  static String get title {
    switch (appFlavor) {
      case Flavor.PRODUCTION:
        return 'eShopCoffe';
      case Flavor.DEVELOPMENT:
      default:
        return 'eShopCoffe.Dev';
    }
  }

  static String get apiUrl {
    switch (appFlavor) {
      case Flavor.PRODUCTION:
        return 'http://191.253.111.175:8881';
      case Flavor.DEVELOPMENT:
      default:
        return 'http://10.0.2.2:5003';
    }
  }
}
