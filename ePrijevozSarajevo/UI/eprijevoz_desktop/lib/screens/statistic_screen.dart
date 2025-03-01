import 'dart:async';

import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/issuedTicket.dart';
import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/models/station.dart';
import 'package:eprijevoz_desktop/models/ticket.dart';
import 'package:eprijevoz_desktop/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:eprijevoz_desktop/providers/station_provider.dart';
import 'package:eprijevoz_desktop/providers/ticket_provider.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter/rendering.dart';
import 'package:provider/provider.dart';
import 'dart:typed_data';
import 'dart:ui' as ui;
import 'package:pdf/widgets.dart' as pw;
import 'dart:io';
import 'package:file_picker/file_picker.dart';

class StatisticScreen extends StatefulWidget {
  const StatisticScreen({super.key});

  @override
  State<StatisticScreen> createState() => _StatisticScreenState();
}

class _StatisticScreenState extends State<StatisticScreen> {
  final List<String> _yearList = [];
  late int selectedYearIndex;
  String selectedYear = "";
  late int currentYear = DateTime.now().year;
  // grpah hoover
  int touchedIndex = -1;
  bool isTouched = false;
  // PDF
  final GlobalKey _ticketChartKey = GlobalKey();
  final GlobalKey _routeChartKey = GlobalKey();
  // ticket
  late IssuedTicketProvider issuedTicketProvider;
  SearchResult<IssuedTicket>? issuedTicketResult;
  late List<IssuedTicket> ticketsForYearAndMonths = [];
  late Map<int, int> ticketTypeAmounts = {};
  late List<int> selectedMonthsforTickets = [];
  var maxTicketValue = 0;
  var ticketInterval = 0;
  var maxStationValue = 0;
  var stationInterval = 0;
  late TicketProvider ticketProvider;
  SearchResult<Ticket>? ticketResult;
  late Map<int, String> ticketTypeLabels = {};
  final Map<int, Color> ticketTypeColors = {};
  // station
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;
  late StationProvider stationProvider;
  SearchResult<Station>? stationResult;
  late Map<int, String> stationLabels = {};
  late Map<int, Color> stationColors = {};

  @override
  void initState() {
    issuedTicketProvider = context.read<IssuedTicketProvider>();
    routeProvider = context.read<RouteProvider>();
    stationProvider = context.read<StationProvider>();
    ticketProvider = context.read<TicketProvider>();

    super.initState();

    initForm();
  }

  Future<void> initForm() async {
    for (int i = 2020; i <= 2100; i++) {
      _yearList.add(i.toString());
    }
    setState(() {
      selectedYearIndex = _yearList.indexOf(currentYear.toString());
      selectedYear = _yearList[selectedYearIndex]; // default selected year
    });

    issuedTicketResult = await issuedTicketProvider.get();
    routeResult = await routeProvider.get();
    stationResult = await stationProvider.get();
    ticketResult = await ticketProvider.get();

    if (stationResult?.result != null) {
      stationLabels = {
        for (var station in stationResult!.result)
          station.stationId!: station.name ?? ""
      };
    }

    if (ticketResult?.result != null) {
      ticketTypeLabels = {
        for (var ticket in ticketResult!.result)
          ticket.ticketId!: ticket.name ?? ""
      };
    }

    final colorList = [
      Colors.purple,
      Colors.blue,
      Colors.orange,
      Colors.green,
      Colors.red,
      Colors.pink,
      Colors.grey,
      Colors.yellow,
      Colors.brown,
      Colors.cyan,
      Colors.indigo,
      Colors.teal,
      Colors.black,
      Colors.lightBlue,
      Colors.lightGreen,
      Colors.lightBlueAccent,
      Colors.lightGreenAccent,
      Colors.deepOrange,
      Colors.deepOrangeAccent,
      Colors.deepPurple,
      Colors.deepPurpleAccent,
      Colors.blue.shade900,
      Colors.blue.shade700,
      Colors.blue.shade300,
      Colors.green.shade900,
      Colors.green.shade700,
      Colors.green.shade300,
      Colors.pink.shade900,
      Colors.pink.shade700,
      Colors.pink.shade300,
      Colors.purple.shade900,
      Colors.purple.shade700,
      Colors.purple.shade300,
      Colors.lime,
      Colors.limeAccent,
      Colors.yellow.shade700,
      Colors.orange.shade700,
      Colors.brown.shade700,
    ];

    for (var station in stationResult!.result) {
      stationColors[station.stationId!] =
          colorList[station.stationId! % colorList.length];
    }

    for (var ticket in ticketResult!.result) {
      ticketTypeColors[ticket.ticketId!] =
          colorList[ticket.ticketId! % colorList.length];
    }

    setState(() {
      updateTicketValues();
    });
  }

  // PDF
  Future<Uint8List?> _capturePng(GlobalKey key) async {
    try {
      RenderRepaintBoundary boundary =
          key.currentContext!.findRenderObject() as RenderRepaintBoundary;
      ui.Image image = await boundary.toImage(pixelRatio: 3.0);
      ByteData? byteData =
          await image.toByteData(format: ui.ImageByteFormat.png);
      return byteData?.buffer.asUint8List();
    } catch (e) {
      debugPrint(e.toString());
    }
    return null;
  }

  Timer? _hoverUpdateTimer;

  void onHoverUpdate() {
    if (_hoverUpdateTimer?.isActive ?? false) _hoverUpdateTimer!.cancel();
    _hoverUpdateTimer = Timer(const Duration(milliseconds: 500), () {
      updateTicketValues();
    });
  }

  void updateTicketValues() async {
    issuedTicketResult = await issuedTicketProvider.get();
    routeResult = await routeProvider.get();
    stationResult = await stationProvider.get();
    if (issuedTicketResult?.result == null ||
        issuedTicketResult!.result.isEmpty) {
      ticketsForYearAndMonths = [];
      selectedMonthsforTickets = [];
      ticketTypeAmounts = {};
      return;
    }

    final ticketsForSelectedYear = issuedTicketResult?.result
        .where(
          (ticket) => ticket.issuedDate?.year == int.parse(selectedYear),
        )
        .toList();

    if (ticketsForSelectedYear == null || ticketsForSelectedYear.isEmpty) {
      ticketsForYearAndMonths = [];
      selectedMonthsforTickets = [];
      ticketTypeAmounts = {};
      return;
    }

    selectedMonthsforTickets = getIssuedTicketbyMonths(ticketsForSelectedYear);

    ticketsForYearAndMonths = getTicketsForYearAndMonths(
      issuedTicketResult!.result,
      int.parse(selectedYear),
      selectedMonthsforTickets,
    );

    ticketTypeAmounts = calculateTicketTypeAmounts(ticketsForYearAndMonths);
    setState(() {});
  }

  Future<void> generatePdf() async {
    try {
      issuedTicketResult = await issuedTicketProvider.get();
      routeResult = await routeProvider.get();
      stationResult = await stationProvider.get();

      setState(() {
        updateTicketValues();
      });

      await Future.delayed(const Duration(milliseconds: 2000));

      Uint8List? ticketChartImage = await _capturePng(_ticketChartKey);
      if (ticketChartImage == null) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
              content: Text('Snimanje dijagrama karti nije uspjelo')),
        );
        return;
      }

      Uint8List? routeChartImage = await _capturePng(_routeChartKey);
      if (routeChartImage == null) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
              content: Text('Snimanje dijagrama stanica nije uspjelo.')),
        );
        return;
      }

      final pdf = pw.Document();
      pdf.addPage(
        pw.MultiPage(
          build: (pw.Context context) => [
            pw.Header(level: 0, text: 'Statistika'),
            pw.Text('Statistika - Karte',
                style: const pw.TextStyle(fontSize: 18)),
            pw.SizedBox(height: 10),
            pw.Image(pw.MemoryImage(ticketChartImage)),
            pw.SizedBox(height: 20),
            pw.Text('Statistika - Stanice',
                style: const pw.TextStyle(fontSize: 18)),
            pw.SizedBox(height: 10),
            pw.Image(pw.MemoryImage(routeChartImage)),
          ],
        ),
      );

      Uint8List pdfBytes = await pdf.save();
      String? selectedDirectory = await FilePicker.platform.getDirectoryPath();
      if (selectedDirectory != null) {
        final file = File('$selectedDirectory/Statistika_$selectedYear.pdf');
        await file.writeAsBytes(pdfBytes);
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('PDF spašen na lokaciji: ${file.path}')),
        );
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Prekinuta opcija spašavanja')),
        );
      }
    } catch (e) {
      debugPrint('Greška s generisanjem PDF: $e');
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Greška s generisanje PDF')),
      );
    }
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreen(
      "Statistika",
      SingleChildScrollView(
        child: Column(
          children: [
            const SizedBox(height: 5),
            const Align(
              alignment: Alignment.centerLeft,
              child: Text(
                "Za potrebe ispisa statistike, neophodno je pritisnuti dugme 'Print'.",
                style: TextStyle(fontWeight: FontWeight.w400),
              ),
            ),
            const SizedBox(height: 10),
            _buildSearch(), // search
            _buildTicketTypeChart(), // tickets
            const SizedBox(height: 20),
            _buildRouteChart(), // stations
          ],
        ),
      ),
    );
  }

  Widget _buildSearch() {
    if (_yearList.isEmpty) {
      return const Center(
        child: CircularProgressIndicator(),
      );
    }
    return Column(
      children: [
        Row(
          children: [
            const Text(
              "Godina:",
              style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
            ),
            const SizedBox(width: 15),
            Expanded(
                child: DropdownButton(
              items: _yearList
                  .map((e) => DropdownMenuItem(value: e, child: Text(e)))
                  .toList(),
              value: _yearList.contains(selectedYear)
                  ? selectedYear
                  : _yearList.first,
              onChanged: (value) {
                setState(() {
                  selectedYear = value ?? _yearList.first;
                });
                updateTicketValues();
              },
            )),
            const SizedBox(width: 15),
            ElevatedButton(
              onPressed: ticketsForYearAndMonths.isEmpty
                  ? null // disable button if no data
                  : () async {
                      await generatePdf();
                    },
              style: ElevatedButton.styleFrom(
                backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
                shape: RoundedRectangleBorder(
                    borderRadius: BorderRadius.circular(2.0)),
                minimumSize: const Size(100, 65),
              ),
              child: const Text("Print", style: TextStyle(fontSize: 18)),
            ),
          ],
        ),
      ],
    );
  }

// months:
  Widget bottomGraphTitles(double value, TitleMeta meta) {
    const style = TextStyle(fontSize: 10);
    String text;
    switch (value.toInt()) {
      case 1:
        text = 'JAN';
        break;
      case 2:
        text = 'FEB';
        break;
      case 3:
        text = 'MAR';
        break;
      case 4:
        text = 'APR';
        break;
      case 5:
        text = 'MAY';
        break;
      case 6:
        text = 'JUN';
        break;
      case 7:
        text = 'JUL';
        break;
      case 8:
        text = 'AUG';
        break;
      case 9:
        text = 'SEP';
        break;
      case 10:
        text = 'OCT';
        break;
      case 11:
        text = 'NOV';
        break;
      case 12:
        text = 'DEC';
        break;
      default:
        text = '';
    }
    return SideTitleWidget(
      axisSide: meta.axisSide,
      child: Text(text, style: style),
    );
  }

// values:
  Widget leftGraphTitles(double value, TitleMeta meta, int maxTickets) {
    if (value == meta.max) {
      return Container();
    }

    const style = TextStyle(
      fontSize: 10,
      color: Colors.black,
    );

    return SideTitleWidget(
      axisSide: meta.axisSide,
      child: Text(
        value.round().toString(),
        style: style,
      ),
    );
  }

// ticketTypeChart()
  List<int> getIssuedTicketbyMonths(List<IssuedTicket> tickets) {
    final Set<int> months = {};

    for (var ticket in tickets) {
      if (ticket.issuedDate != null) {
        months.add(ticket.issuedDate!.month);
      }
    }
    return months.toList()..sort();
  }

  List<IssuedTicket> getTicketsForYearAndMonths(
      List<IssuedTicket> tickets, int year, List<int> months) {
    return tickets
        .where((ticket) =>
            ticket.issuedDate != null &&
            ticket.issuedDate!.year == year &&
            months.contains(ticket.issuedDate!.month))
        .toList();
  }

  Map<int, int> calculateTicketTypeAmounts(List<IssuedTicket> tickets) {
    final Map<int, int> ticketTypeAmounts = {};

    for (var ticket in tickets) {
      if (ticket.ticketId != null && ticket.amount != null) {
        ticketTypeAmounts[ticket.ticketId!] =
            (ticketTypeAmounts[ticket.ticketId!] ?? 0) + ticket.amount!;
      }
    }
    return ticketTypeAmounts;
  }

  List<BarChartGroupData> getBarChartGroupTicketData(
      List<IssuedTicket> tickets, List<int> months) {
    maxTicketValue = 0;
    ticketInterval = 0;
    if (months.isEmpty || tickets.isEmpty) {
      return [
        BarChartGroupData(
          x: 0,
          barRods: [BarChartRodData(toY: 0, color: Colors.grey, width: 10)],
          showingTooltipIndicators: [0],
        ),
      ];
    }

    var list = months.map((month) {
      final monthTickets =
          tickets.where((ticket) => ticket.issuedDate?.month == month).toList();

      // group tickets by ticket type
      final Map<int, List<IssuedTicket>> groupedTickets = {};
      for (var ticket in monthTickets) {
        groupedTickets.putIfAbsent(ticket.ticketId!, () => []).add(ticket);
      }

      // create a list of BarChartRodData for each ticket type
      final List<BarChartRodData> barRods = groupedTickets.entries.map((entry) {
        final ticketTypeId = entry.key;
        final ticketsForType = entry.value;

        // total amount for this ticket type
        final totalAmount =
            ticketsForType.fold(0.0, (sum, ticket) => sum + ticket.amount!);

        if (totalAmount > maxTicketValue) {
          maxTicketValue = totalAmount.toInt();
        }

        return BarChartRodData(
          toY: totalAmount,
          color: ticketTypeColors[ticketTypeId],
          width: 10,
        );
      }).toList();

      return BarChartGroupData(
        x: month,
        barRods: barRods,
      );
    }).toList();

    int i = maxTicketValue;
    while (i % 100 != 0) {
      i++;
    }
    ticketInterval = i ~/ 10;
    return list;
  }

  Widget buildTicketTypeLegend() {
    return Wrap(
      spacing: 16,
      runSpacing: 7,
      children: ticketTypeColors.entries.map((entry) {
        final ticketTypeId = entry.key;
        final color = entry.value;
        final label = ticketTypeLabels[ticketTypeId] ?? "";

        return Wrap(
          children: [
            Container(
              width: 16,
              height: 16,
              color: color,
            ),
            const SizedBox(width: 8),
            Text(
              label,
              style: const TextStyle(fontSize: 14),
              overflow: TextOverflow.ellipsis,
            ),
          ],
        );
      }).toList(),
    );
  }

  Widget _buildTicketTypeChart() {
    if (ticketsForYearAndMonths.isEmpty) {
      return const Padding(
        padding: EdgeInsets.all(16.0),
        child: Center(
          child: Text(
            "Nema dostupnih podataka o izdatim kartama za odabranu godinu.",
            style: TextStyle(fontSize: 16, fontStyle: FontStyle.italic),
          ),
        ),
      );
    }
    return RepaintBoundary(
      key: _ticketChartKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const SizedBox(
            height: 15,
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 8.0, vertical: 4.0),
            child: Text(
              "Statistika - Karte",
              style: TextStyle(
                fontSize: 18.0,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          // legend
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: buildTicketTypeLegend(),
          ),
          AspectRatio(
            aspectRatio: 4,
            child: Padding(
              padding: const EdgeInsets.only(top: 16),
              child: LayoutBuilder(
                builder: (context, constraints) {
                  final barsSpace = 4.0 * constraints.maxWidth / 400;
                  final barChartGroupData = getBarChartGroupTicketData(
                      ticketsForYearAndMonths, selectedMonthsforTickets);
                  return BarChart(
                    BarChartData(
                        alignment: BarChartAlignment.center,
                        maxY: (maxTicketValue + 5).toDouble(),
                        barTouchData: BarTouchData(
                          enabled: true,
                          touchTooltipData: BarTouchTooltipData(
                            tooltipRoundedRadius: 8,
                            getTooltipItem: (group, groupIndex, rod, rodIndex) {
                              final value = rod.toY.toInt();
                              return BarTooltipItem(
                                '$value',
                                const TextStyle(color: Colors.white),
                              );
                            },
                          ),
                          touchCallback: (event, response) {
                            if (!event.isInterestedForInteractions ||
                                response == null ||
                                response.spot == null) {
                              onHoverUpdate();
                              return;
                            }
                            onHoverUpdate();
                          },
                        ),
                        titlesData: FlTitlesData(
                          show: true,
                          bottomTitles: AxisTitles(
                            sideTitles: SideTitles(
                                showTitles: true,
                                reservedSize: 28,
                                getTitlesWidget: bottomGraphTitles),
                          ),
                          leftTitles: AxisTitles(
                            sideTitles: SideTitles(
                              showTitles: true,
                              reservedSize: 30.0,
                              interval: ticketInterval.toDouble(),
                              getTitlesWidget: (value, meta) =>
                                  leftGraphTitles(value, meta, 100),
                            ),
                          ),
                          topTitles: const AxisTitles(
                            sideTitles: SideTitles(showTitles: false),
                          ),
                          rightTitles: const AxisTitles(
                            sideTitles: SideTitles(showTitles: false),
                          ),
                        ),
                        groupsSpace: barsSpace,
                        barGroups: barChartGroupData,
                        gridData: FlGridData(
                            verticalInterval: ticketInterval.toDouble(),
                            horizontalInterval: ticketInterval.toDouble())),
                  );
                },
              ),
            ),
          ),
        ],
      ),
    );
  }

// RouteChart()
  List<BarChartGroupData> getBarChartGroupRouteData(
      List<IssuedTicket> tickets, List<int> months) {
    maxStationValue = 0;
    stationInterval = 0;
    if (months.isEmpty || tickets.isEmpty) {
      return [
        BarChartGroupData(
          x: 0,
          barRods: [BarChartRodData(toY: 0, color: Colors.grey, width: 10)],
          showingTooltipIndicators: [0],
        ),
      ];
    }

    var list = months.map((month) {
      final monthTickets =
          tickets.where((ticket) => ticket.issuedDate?.month == month).toList();

      // group issuedTickets by start station
      final Map<int, List<IssuedTicket>> groupedStations = {};
      for (var ticket in monthTickets) {
        var startStationId = routeResult?.result
            .where((route) => route.routeId == ticket.routeId)
            .firstOrNull
            ?.startStationId;

        var endStationId = routeResult?.result
            .where((route) => route.routeId == ticket.routeId)
            .firstOrNull
            ?.endStationId;
        if (startStationId != null) {
          groupedStations.putIfAbsent(startStationId!, () => []).add(ticket);
        }
        if (endStationId != null) {
          groupedStations.putIfAbsent(endStationId!, () => []).add(ticket);
        }
      }

      // create a list of BarChartRodData for each ticket type
      final List<BarChartRodData> barRods =
          groupedStations.entries.map((entry) {
        final routeId = entry.key;
        final ticketsForRoute = entry.value;

        // total amount for this route
        final totalAmount =
            ticketsForRoute.fold(0.0, (sum, ticket) => sum + ticket.amount!);

        if (totalAmount > maxStationValue) {
          maxStationValue = totalAmount.toInt();
        }

        return BarChartRodData(
          toY: totalAmount,
          color: stationColors[routeId],
          width: 10,
        );
      }).toList();

      return BarChartGroupData(
        x: month,
        barRods: barRods,
      );
    }).toList();

    int i = maxStationValue;
    while (i % 100 != 0) {
      i++;
    }
    stationInterval = i ~/ 10;

    return list;
  }

  Widget buildStationsLegend() {
    return Wrap(
      spacing: 16,
      runSpacing: 7,
      children: stationColors.entries.map((entry) {
        final stationId = entry.key;
        final color = entry.value;
        final label = stationLabels[stationId] ?? "";

        return Wrap(
          children: [
            Container(
              width: 16,
              height: 16,
              color: color,
            ),
            const SizedBox(width: 8),
            Text(
              label,
              style: const TextStyle(fontSize: 14),
              overflow: TextOverflow.ellipsis,
            ),
          ],
        );
      }).toList(),
    );
  }

  Widget _buildRouteChart() {
    if (ticketsForYearAndMonths.isEmpty) {
      return const Padding(
        padding: EdgeInsets.all(16.0),
        child: Center(
          child: Text(
            "Nema dostupnih podataka o rutama za odabranu godinu..",
            style: TextStyle(fontSize: 16, fontStyle: FontStyle.italic),
          ),
        ),
      );
    }
    return RepaintBoundary(
      key: _routeChartKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const SizedBox(
            height: 15,
          ),
          const Padding(
            padding: EdgeInsets.symmetric(horizontal: 8.0, vertical: 4.0),
            child: Text(
              "Statistika - Stanice",
              style: TextStyle(
                fontSize: 18.0,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          // legend
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: buildStationsLegend(),
          ),
          AspectRatio(
            aspectRatio: 4,
            child: Padding(
              padding: const EdgeInsets.only(top: 16),
              child: LayoutBuilder(
                builder: (context, constraints) {
                  final barsSpace = 4.0 * constraints.maxWidth / 400;
                  final barChartGroupData = getBarChartGroupRouteData(
                      ticketsForYearAndMonths, selectedMonthsforTickets);
                  return BarChart(
                    BarChartData(
                        alignment: BarChartAlignment.center,
                        maxY: (maxStationValue + 5).toDouble(),
                        barTouchData: BarTouchData(
                          enabled: true,
                          touchTooltipData: BarTouchTooltipData(
                            tooltipRoundedRadius: 8,
                            getTooltipItem: (group, groupIndex, rod, rodIndex) {
                              final value = rod.toY.toInt();
                              return BarTooltipItem(
                                '$value',
                                const TextStyle(color: Colors.white),
                              );
                            },
                          ),
                          touchCallback: (event, response) {
                            if (!event.isInterestedForInteractions ||
                                response == null ||
                                response.spot == null) {
                              onHoverUpdate();
                              return;
                            }
                            onHoverUpdate();
                          },
                        ),
                        titlesData: FlTitlesData(
                          show: true,
                          bottomTitles: AxisTitles(
                            sideTitles: SideTitles(
                                showTitles: true,
                                reservedSize: 28,
                                getTitlesWidget: bottomGraphTitles),
                          ),
                          leftTitles: AxisTitles(
                            sideTitles: SideTitles(
                              showTitles: true,
                              reservedSize: 30.0,
                              interval: stationInterval.toDouble(),
                              getTitlesWidget: (value, meta) =>
                                  leftGraphTitles(value, meta, 100),
                            ),
                          ),
                          topTitles: const AxisTitles(
                            sideTitles: SideTitles(showTitles: false),
                          ),
                          rightTitles: const AxisTitles(
                            sideTitles: SideTitles(showTitles: false),
                          ),
                        ),
                        groupsSpace: barsSpace,
                        barGroups: barChartGroupData,
                        gridData: FlGridData(
                            horizontalInterval: stationInterval.toDouble(),
                            verticalInterval: stationInterval.toDouble())),
                  );
                },
              ),
            ),
          ),
        ],
      ),
    );
  }
}
