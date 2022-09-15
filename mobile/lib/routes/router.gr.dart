// **************************************************************************
// AutoRouteGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND

// **************************************************************************
// AutoRouteGenerator
// **************************************************************************
//
// ignore_for_file: type=lint

// ignore_for_file: no_leading_underscores_for_library_prefixes
import 'package:auto_route/auto_route.dart' as _i5;
import 'package:flutter/material.dart' as _i6;

import '../pages/home_page.dart' as _i2;
import '../pages/loading_page.dart' as _i4;
import '../pages/login_page.dart' as _i3;
import '../pages/page_provider.dart' as _i1;

class AppRouter extends _i5.RootStackRouter {
  AppRouter([_i6.GlobalKey<_i6.NavigatorState>? navigatorKey])
      : super(navigatorKey);

  @override
  final Map<String, _i5.PageFactory> pagesMap = {
    RouteProvider.name: (routeData) {
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: _i5.WrappedRoute(child: const _i1.PageProvider()),
      );
    },
    HomeRoute.name: (routeData) {
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: const _i2.HomePage(),
      );
    },
    LoginRoute.name: (routeData) {
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: const _i3.LoginPage(),
      );
    },
    LoadingRoute.name: (routeData) {
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: const _i4.LoadingPage(),
      );
    },
  };

  @override
  List<_i5.RouteConfig> get routes => [
        _i5.RouteConfig(
          '/#redirect',
          path: '/',
          redirectTo: '',
          fullMatch: true,
        ),
        _i5.RouteConfig(
          RouteProvider.name,
          path: '',
          children: [
            _i5.RouteConfig(
              HomeRoute.name,
              path: 'home-page',
              parent: RouteProvider.name,
            ),
            _i5.RouteConfig(
              LoginRoute.name,
              path: 'login-page',
              parent: RouteProvider.name,
            ),
            _i5.RouteConfig(
              LoadingRoute.name,
              path: 'loading-page',
              parent: RouteProvider.name,
            ),
          ],
        ),
      ];
}

/// generated route for
/// [_i1.PageProvider]
class RouteProvider extends _i5.PageRouteInfo<void> {
  const RouteProvider({List<_i5.PageRouteInfo>? children})
      : super(
          RouteProvider.name,
          path: '',
          initialChildren: children,
        );

  static const String name = 'RouteProvider';
}

/// generated route for
/// [_i2.HomePage]
class HomeRoute extends _i5.PageRouteInfo<void> {
  const HomeRoute()
      : super(
          HomeRoute.name,
          path: 'home-page',
        );

  static const String name = 'HomeRoute';
}

/// generated route for
/// [_i3.LoginPage]
class LoginRoute extends _i5.PageRouteInfo<void> {
  const LoginRoute()
      : super(
          LoginRoute.name,
          path: 'login-page',
        );

  static const String name = 'LoginRoute';
}

/// generated route for
/// [_i4.LoadingPage]
class LoadingRoute extends _i5.PageRouteInfo<void> {
  const LoadingRoute()
      : super(
          LoadingRoute.name,
          path: 'loading-page',
        );

  static const String name = 'LoadingRoute';
}
