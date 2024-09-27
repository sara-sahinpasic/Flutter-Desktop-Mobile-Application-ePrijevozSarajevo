import 'package:intl/intl.dart';

String formatDate(DateTime? date) {
  if (date == null) {
    return '';
  }
  return DateFormat('dd.MM.yyyy').format(date);
}

String formatTime(DateTime? date) {
  if (date == null) {
    return '';
  }
  return DateFormat('HH:mm').format(date);
}

String formatDateTime(DateTime dateTime) {
  final DateFormat formatter = DateFormat('dd-MM-yyyy HH:mm');
  return formatter.format(dateTime);
}

String formatPrice(double price) {
  final NumberFormat formatter = NumberFormat.currency(
      locale: 'bs_BA', // Bosnian locale
      symbol:
          'KM', // Currency symbol for Bosnia and Herzegovina (Convertible Mark)
      decimalDigits: 2 // Ensures two decimal places
      );
  return formatter.format(price);
}
