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
  final DateFormat formatter = DateFormat('yyyy-MM-ddTHH:mm:ss');
  return formatter.format(dateTime);
}
