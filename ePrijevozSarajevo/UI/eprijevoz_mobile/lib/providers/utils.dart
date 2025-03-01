import 'package:intl/intl.dart';
import 'package:flutter/widgets.dart';
import 'dart:convert';

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
  final DateFormat formatter = DateFormat('dd.MM.yyyy HH:mm');
  return formatter.format(dateTime);
}

String formatDateTimeAPI(DateTime dateTime) {
  final DateFormat formatter = DateFormat('yyyy-MM-ddTHH:mm:ss');
  return formatter.format(dateTime);
}

String formatPrice(double price) {
  final NumberFormat formatter = NumberFormat.currency(
      locale: 'bs_BA', symbol: 'KM', decimalDigits: 2 // two decimal places
      );
  return formatter.format(price);
}

Image imageFromString(String input) {
  return Image.memory(base64Decode(input));
}
