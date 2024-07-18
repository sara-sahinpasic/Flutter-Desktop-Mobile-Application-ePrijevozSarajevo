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
