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
