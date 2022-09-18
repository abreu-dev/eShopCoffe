import 'package:auto_route/annotations.dart';
import 'package:eshopcoffe/features/account/screens/login_screen.dart';
import 'package:eshopcoffe/features/home/screens/home_screen_wrapper.dart';
import 'package:eshopcoffe/features/home/screens/home_screen.dart';
import 'package:eshopcoffe/features/screen_wrapper.dart';

@MaterialAutoRouter(
  replaceInRouteName: 'Screen,Route',
  routes: <AutoRoute>[
    AutoRoute(
      path: '/wrapper',
      page: ScreenWrapper,
      children: [
        AutoRoute(
          initial: true,
          path: 'login',
          page: LoginScreen,
          children: [
            RedirectRoute(path: '*', redirectTo: ''),
          ],
        ),

        AutoRoute(
            path: 'home',
            page: HomeScreenWrapper,
            children: [
              AutoRoute(path: '', page: HomeScreen),
              RedirectRoute(path: '*', redirectTo: ''),
            ]
        ),
      ]
    ),

    RedirectRoute(path: '*', redirectTo: '/wrapper'),
  ],
)
class $AppRouter {}