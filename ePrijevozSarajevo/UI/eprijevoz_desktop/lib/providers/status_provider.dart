import 'package:eprijevoz_desktop/models/status.dart';
import 'package:eprijevoz_desktop/providers/base_provider.dart';

class StatusProvider extends BaseProvider<Status> {
  StatusProvider() : super("Status");

  @override
  Status fromJson(data) {
    return Status.fromJson(data);
  }
}
