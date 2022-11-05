enum PaymentMethodEnum {
  none,
  cash,
  creditCard,
  debitCard,
  pix
}

String getEnumDesc(PaymentMethodEnum e) {
  switch (e) {
    case PaymentMethodEnum.cash:
      return 'Cash';
    case PaymentMethodEnum.creditCard:
      return 'Credit Card';
    case PaymentMethodEnum.debitCard:
      return 'Debit Card';
    case PaymentMethodEnum.pix:
      return 'Pix';
    default:
      return 'None';
  }
}