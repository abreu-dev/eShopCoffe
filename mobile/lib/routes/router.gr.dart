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

import '../features/account/screens/login_screen.dart' as _i2;
import '../features/home/screens/home_screen.dart' as _i4;
import '../features/home/screens/home_screen_wrapper.dart' as _i3;
import '../features/screen_wrapper.dart' as _i1;
import '../shared/services/snack_bar_service.dart' as _i7;

class AppRouter extends _i5.RootStackRouter {
  AppRouter([_i6.GlobalKey<_i6.NavigatorState>? navigatorKey])
      : super(navigatorKey);

  @override
  final Map<String, _i5.PageFactory> pagesMap = {
    RouteWrapper.name: (routeData) {
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: _i5.WrappedRoute(child: const _i1.ScreenWrapper()),
      );
    },
    LoginRoute.name: (routeData) {
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: const _i2.LoginScreen(),
      );
    },
    HomeRouteWrapper.name: (routeData) {
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: const _i3.HomeScreenWrapper(),
      );
    },
    HomeRoute.name: (routeData) {
      final args = routeData.argsAs<HomeRouteArgs>();
      return _i5.MaterialPageX<dynamic>(
        routeData: routeData,
        child: _i4.HomeScreen(
          args.snackBarService,
          key: args.key,
        ),
      );
    },
  };

  @override
  List<_i5.RouteConfig> get routes => [
        _i5.RouteConfig(
          RouteWrapper.name,
          path: '/wrapper',
          children: [
            _i5.RouteConfig(
              '#redirect',
              path: '',
              parent: RouteWrapper.name,
              redirectTo: 'login',
              fullMatch: true,
            ),
            _i5.RouteConfig(
              LoginRoute.name,
              path: 'login',
              parent: RouteWrapper.name,
              children: [
                _i5.RouteConfig(
                  '*#redirect',
                  path: '*',
                  parent: LoginRoute.name,
                  redirectTo: '',
                  fullMatch: true,
                )
              ],
            ),
            _i5.RouteConfig(
              HomeRouteWrapper.name,
              path: 'home',
              parent: RouteWrapper.name,
              children: [
                _i5.RouteConfig(
                  HomeRoute.name,
                  path: '',
                  parent: HomeRouteWrapper.name,
                ),
                _i5.RouteConfig(
                  '*#redirect',
                  path: '*',
                  parent: HomeRouteWrapper.name,
                  redirectTo: '',
                  fullMatch: true,
                ),
              ],
            ),
          ],
        ),
        _i5.RouteConfig(
          '*#redirect',
          path: '*',
          redirectTo: '/wrapper',
          fullMatch: true,
        ),
      ];
}

/// generated route for
/// [_i1.ScreenWrapper]
class RouteWrapper extends _i5.PageRouteInfo<void> {
  const RouteWrapper({List<_i5.PageRouteInfo>? children})
      : super(
          RouteWrapper.name,
          path: '/wrapper',
          initialChildren: children,
        );

  static const String name = 'RouteWrapper';
}

/// generated route for
/// [_i2.LoginScreen]
class LoginRoute extends _i5.PageRouteInfo<void> {
  const LoginRoute({List<_i5.PageRouteInfo>? children})
      : super(
          LoginRoute.name,
          path: 'login',
          initialChildren: children,
        );

  static const String name = 'LoginRoute';
}

/// generated route for
/// [_i3.HomeScreenWrapper]
class HomeRouteWrapper extends _i5.PageRouteInfo<void> {
  const HomeRouteWrapper({List<_i5.PageRouteInfo>? children})
      : super(
          HomeRouteWrapper.name,
          path: 'home',
          initialChildren: children,
        );

  static const String name = 'HomeRouteWrapper';
}

/// generated route for
/// [_i4.HomeScreen]
class HomeRoute extends _i5.PageRouteInfo<HomeRouteArgs> {
  HomeRoute({
    required _i7.SnackBarService snackBarService,
    _i6.Key? key,
  }) : super(
          HomeRoute.name,
          path: '',
          args: HomeRouteArgs(
            snackBarService: snackBarService,
            key: key,
          ),
        );

  static const String name = 'HomeRoute';
}

class HomeRouteArgs {
  const HomeRouteArgs({
    required this.snackBarService,
    this.key,
  });

  final _i7.SnackBarService snackBarService;

  final _i6.Key? key;

  @override
  String toString() {
    return 'HomeRouteArgs{snackBarService: $snackBarService, key: $key}';
  }
}
