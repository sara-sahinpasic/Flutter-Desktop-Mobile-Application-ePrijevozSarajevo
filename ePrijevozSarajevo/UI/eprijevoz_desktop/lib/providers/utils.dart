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

String formatDateTimeAPI(DateTime dateTime) {
  final DateFormat formatter = DateFormat('yyyy-MM-ddTHH:mm:ss');
  return formatter.format(dateTime);
}

String formatDateTimeUI(DateTime dateTime) {
  return '${dateTime.day.toString().padLeft(2, '0')}.${dateTime.month.toString().padLeft(2, '0')}.${dateTime.year} '
      '${dateTime.hour.toString().padLeft(2, '0')}:${dateTime.minute.toString().padLeft(2, '0')}';
}
