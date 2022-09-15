import 'package:auto_route/annotations.dart';

import '../pages/home_page.dart';
import '../pages/login_page.dart';
import '../pages/page_provider.dart';
import '../pages/loading_page.dart';

@MaterialAutoRouter(
  replaceInRouteName: 'Page,Route',
  routes: <AutoRoute>[
    AutoRoute(
      page: PageProvider,
      path: '',
      initial: true,
      children: [
        AutoRoute(page: HomePage),
        AutoRoute(page: LoginPage),
        AutoRoute(page: LoadingPage)
      ]
    )
  ],
)
class $AppRouter {}