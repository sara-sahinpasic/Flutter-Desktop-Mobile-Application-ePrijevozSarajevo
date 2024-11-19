import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/issuedTicket.dart';
import 'package:eprijevoz_desktop/models/route.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/providers/issuedTicket_provider.dart';
import 'package:eprijevoz_desktop/providers/route_provider.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart' hide Route;
import 'package:flutter/rendering.dart';
import 'package:provider/provider.dart';
//
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
  late int currentYear = 2024;
// Grpah hoover
  int touchedIndex = -1;
  bool isTouched = false;
// Pdf
  final GlobalKey _ticketChartKey = GlobalKey();
  final GlobalKey _routeChartKey = GlobalKey();

// Ticket
  late IssuedTicketProvider issuedTicketProvider;
  SearchResult<IssuedTicket>? issuedTicketResult;
  late List<IssuedTicket> ticketsForYearAndMonths = [];
  late Map<int, int> ticketTypeAmounts = {};
  late List<int> selectedMonthsforTickets = [];
  var maxTicketValue = 0;
  var maxStationValue = 0;
// Station
  late RouteProvider routeProvider;
  SearchResult<Route>? routeResult;

  @override
  void initState() {
    issuedTicketProvider = context.read<IssuedTicketProvider>();
    routeProvider = context.read<RouteProvider>();

    initForm();
    super.initState();
  }

  Future<void> initForm() async {
    for (int i = 2020; i <= 2100; i++) {
      _yearList.add(i.toString());
    }
    selectedYearIndex = _yearList.indexOf(currentYear.toString());
    selectedYear = _yearList[selectedYearIndex]; // default selected year

    issuedTicketResult = await issuedTicketProvider.get();
    routeResult = await routeProvider.get();
    updateTicketValues(issuedTicketResult);
  }

  void updateTicketValues(SearchResult<IssuedTicket>? issuedTicketResult) {
    if (issuedTicketResult?.result != null) {
      getIssuedTicketbyMonths(issuedTicketResult!.result);

      selectedMonthsforTickets = getIssuedTicketbyMonths(issuedTicketResult
          .result
          .where(
              (element) => element.issuedDate?.year == int.parse(selectedYear))
          .toList());

      ticketsForYearAndMonths = getTicketsForYearAndMonths(
          issuedTicketResult.result,
          int.parse(selectedYear),
          selectedMonthsforTickets);

      ticketTypeAmounts = calculateTicketTypeAmounts(ticketsForYearAndMonths);
    }
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
      print(e);
    }
    return null;
  }

  Future<void> _generatePdf() async {
    try {
      // Capture the ticket type chart
      Uint8List? ticketChartImage = await _capturePng(_ticketChartKey);
      if (ticketChartImage == null) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Failed to capture Ticket Chart')),
        );
        return;
      }

      // Capture the route chart
      Uint8List? routeChartImage = await _capturePng(_routeChartKey);
      if (routeChartImage == null) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Failed to capture Route Chart')),
        );
        return;
      }

      // Create a PDF document
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

      // Save the PDF to bytes
      Uint8List pdfBytes = await pdf.save();

      // Use File Picker to select save location
      String? selectedDirectory = await FilePicker.platform.getDirectoryPath();
      if (selectedDirectory != null) {
        final file = File('$selectedDirectory/Statistika_$selectedYear.pdf');
        await file.writeAsBytes(pdfBytes);
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('PDF saved at: ${file.path}')),
        );
      } else {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Save operation cancelled')),
        );
      }
    } catch (e) {
      print('Error generating PDF: $e');
      ScaffoldMessenger.of(context).showSnackBar(
        const SnackBar(content: Text('Error generating PDF')),
      );
    }
  }

  // Colors and legend for ticket graph bars
  final Map<int, Color> ticketTypeColors = {
    1: Colors.purple, // Jednosmjerna
    2: Colors.blue, // Povratna
    3: Colors.orange, // Jednosmjerna dječija
    4: Colors.green, // Povratna dječija
    5: Colors.red, // Mjesečna
  };
  final Map<int, String> ticketTypeLabels = {
    1: "Jednosmjerna",
    2: "Povratna",
    3: "Jednosmjerna dječija",
    4: "Povratna dječija",
    5: "Mjesečna",
  };
  // Colors and legend for stations graph bars
  final Map<int, Color> stationColors = {
    1: Colors.purple, //Ilidža
    2: Colors.blue, //Stup
    3: Colors.orange, //Nedžarići
    4: Colors.green, //Socijalno
    5: Colors.red, //Malta
    6: Colors.pink, //Baščaršija
    7: Colors.grey, //Otoka
    8: Colors.yellow, //Skenderija
    9: Colors.brown, //Drvenija
    10: Colors.amber, //Dobrinja
    11: Colors.cyan, //Grbavica
    12: Colors.indigo, //Hrasno
    13: Colors.teal, //Aneks
    14: Colors.lightGreenAccent, //Alipašino polje
    15: Colors.deepPurpleAccent, //Švrakino selo
  };
  final Map<int, String> stationLabels = {
    1: "Ilidža",
    2: "Stup",
    3: "Nedžarići",
    4: "Socijalno",
    5: "Malta",
    6: "Baščaršija",
    7: "Otoka",
    8: "Skenderija",
    9: "Drvenija",
    10: "Dobrinja",
    11: "Grbavica",
    12: "Hrasno",
    13: "Aneks",
    14: "Alipašino polje",
    15: "Švrakino selo",
  };

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
            _buildSearch(), // Search
            _buildTicketTypeChart(), // Tickets
            const SizedBox(height: 20),
            _buildRouteChart(), // Stations
          ],
        ),
      ),
    );
  }

  Widget _buildSearch() {
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
              value: selectedYear.isNotEmpty ? selectedYear : _yearList.first,
              onChanged: (value) {
                setState(() {
                  selectedYear = value ?? _yearList.first;
                });
                updateTicketValues(issuedTicketResult);
              },
            )),
            const SizedBox(width: 15),
            ElevatedButton(
              onPressed: () async {
                // pdf file
                await _generatePdf();
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

// Months:
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

// Values:
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

// TicketTypeChart()
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
    if (months.isEmpty || tickets.isEmpty) {
      return [
        BarChartGroupData(
          x: 0,
          barRods: [BarChartRodData(toY: 0, color: Colors.grey)],
        ),
      ];
    }

    return months.map((month) {
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
  }

  Widget buildTicketTypeLegend() {
    return Wrap(
      spacing: 16,
      runSpacing: 7,
      children: ticketTypeColors.entries.map((entry) {
        final ticketTypeId = entry.key;
        final color = entry.value;
        final label = ticketTypeLabels[ticketTypeId] ?? "";

        return SizedBox(
          width: 120,
          child: Row(
            children: [
              Container(
                width: 16,
                height: 16,
                color: color,
              ),
              const SizedBox(width: 8),
              Expanded(
                child: Text(
                  label,
                  style: const TextStyle(fontSize: 14),
                  overflow: TextOverflow.ellipsis,
                ),
              ),
            ],
          ),
        );
      }).toList(),
    );
  }

  Widget _buildTicketTypeChart() {
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
          // Legend
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
                            setState(() {
                              touchedIndex = -1;
                              isTouched = false;
                            });
                            return;
                          }
                          setState(() {
                            touchedIndex = response.spot!.touchedBarGroupIndex;
                            isTouched = true;
                          });
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
                            reservedSize: 20.0,
                            interval: 1,
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
                    ),
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
    if (months.isEmpty || tickets.isEmpty) {
      return [
        BarChartGroupData(
          x: 0,
          barRods: [BarChartRodData(toY: 0, color: Colors.grey)],
        ),
      ];
    }

    return months.map((month) {
      final monthTickets =
          tickets.where((ticket) => ticket.issuedDate?.month == month).toList();

      // group issuedTickets by start station
      final Map<int, List<IssuedTicket>> groupedStations = {};
      for (var ticket in monthTickets) {
        var startStationId = routeResult?.result
            .firstWhere((route) => route.routeId == ticket.routeId)
            .startStationId;

        var endStationId = routeResult?.result
            .firstWhere((route) => route.routeId == ticket.routeId)
            .endStationId;
        groupedStations.putIfAbsent(startStationId!, () => []).add(ticket);
        groupedStations.putIfAbsent(endStationId!, () => []).add(ticket);
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
  }

  Widget buildStationsLegend() {
    return Wrap(
      spacing: 16,
      runSpacing: 7,
      children: stationColors.entries.map((entry) {
        final stationId = entry.key;
        final color = entry.value;
        final label = stationLabels[stationId] ?? "";

        return SizedBox(
          width: 120,
          child: Row(
            children: [
              Container(
                width: 16,
                height: 16,
                color: color,
              ),
              const SizedBox(width: 8),
              Expanded(
                child: Text(
                  label,
                  style: const TextStyle(fontSize: 14),
                  overflow: TextOverflow.ellipsis,
                ),
              ),
            ],
          ),
        );
      }).toList(),
    );
  }

  Widget _buildRouteChart() {
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
          // Legend
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
                            setState(() {
                              touchedIndex = -1;
                              isTouched = false;
                            });
                            return;
                          }
                          setState(() {
                            touchedIndex = response.spot!.touchedBarGroupIndex;
                            isTouched = true;
                          });
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
                            reservedSize: 20.0,
                            interval: 1,
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
                    ),
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
