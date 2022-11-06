import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:intl/intl.dart';

part 'order_event_model.freezed.dart';
part 'order_event_model.g.dart';

@Freezed()
class OrderEventModel with _$OrderEventModel {
  const OrderEventModel._();

  factory OrderEventModel({
    required String status,
    required DateTime date
  }) = _OrderEventModel;

  factory OrderEventModel.fromJson(Map<String, dynamic> json) =>
      _$OrderEventModelFromJson(json);

  String formattedDate() {
    return DateFormat('dd/MM/yyyy HH:mm').format(date.toLocal());
  }

  Color color() {
    return Colors.black;
  }

  String statusText() {
    if (status == 'Pending') return 'Pendente';
    if (status == 'Confirmed') return 'Confirmado';
    if (status == 'In Production') return 'Em produção';
    if (status == 'In DeliveryRoute') return 'Em rota de entrega';
    if (status == 'Delivered') return 'Entregue';
    else return status;
  }

  String statusDescText() {
    if (status == 'Pending') return 'O pedido está pendente.';
    if (status == 'Confirmed') return 'O pedido foi aceito.';
    if (status == 'In Production') return 'O pedido está em produção';
    if (status == 'In DeliveryRoute') return 'O pedido está em rota de entrega';
    if (status == 'Delivered') return 'O pedido foi entregue';
    else return status;
  }
}