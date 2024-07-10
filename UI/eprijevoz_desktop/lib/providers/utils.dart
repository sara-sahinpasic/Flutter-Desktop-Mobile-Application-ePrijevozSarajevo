import 'package:intl/intl.dart';

String formatDate(DateTime? date) {
  if (date == null) {
    return '';
  }
  return DateFormat('MM/dd/yyyy').format(date);
}

String formatTime(DateTime? date) {
  if (date == null) {
    return '';
  }
  return DateFormat('HH:mm').format(date);
}
