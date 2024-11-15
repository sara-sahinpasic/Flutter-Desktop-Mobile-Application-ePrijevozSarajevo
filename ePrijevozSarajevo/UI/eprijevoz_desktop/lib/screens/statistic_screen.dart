import 'package:eprijevoz_desktop/layouts/master_screen.dart';
import 'package:eprijevoz_desktop/models/issuedTicket.dart';
import 'package:eprijevoz_desktop/models/search_result.dart';
import 'package:eprijevoz_desktop/providers/issuedTicket_provider.dart';
import 'package:fl_chart/fl_chart.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class StatisticScreen extends StatefulWidget {
  const StatisticScreen({super.key});

  @override
  State<StatisticScreen> createState() => _StatisticScreenState();
}

class _StatisticScreenState extends State<StatisticScreen> {
  late IssuedTicketProvider issuedTicketProvider;
  SearchResult<IssuedTicket>? issuedTicketResult;
  final List<String> _yearList = [];
  late int selectedYearIndex;
  String selectedYear = "";
  late int initialYear = 2023;
  late int startYear = 2020;
  late int currentYear = 2024;
  late int endYear = 2100;
  late List<int> selectedMonths = [];
  late List<IssuedTicket> ticketsForYearAndMonths = [];
  late Map<int, int> ticketTypeAmounts = {};
  var maxValue = 0;

  @override
  void initState() {
    issuedTicketProvider = context.read<IssuedTicketProvider>();

    initForm();
    super.initState();
  }

  Future<void> initForm() async {
    for (int i = startYear; i <= endYear; i++) {
      _yearList.add(i.toString());
    }
    selectedYearIndex = _yearList.indexOf(currentYear.toString());
    selectedYear = _yearList[selectedYearIndex]; // default selected year

    issuedTicketResult = await issuedTicketProvider.get();
    updateValues(issuedTicketResult);
  }

  void updateValues(SearchResult<IssuedTicket>? issuedTicketResult) {
    // issued tickets per month
    if (issuedTicketResult?.result != null) {
      getIssuedTicketbyMonths(issuedTicketResult!.result);

      // amount of issued tickets for year and month on that year
      selectedMonths = getIssuedTicketbyMonths(issuedTicketResult.result
          .where(
              (element) => element.issuedDate?.year == int.parse(selectedYear))
          .toList());

      // tickets filtered by year and months
      ticketsForYearAndMonths = getTicketsForYearAndMonths(
          issuedTicketResult.result, int.parse(selectedYear), selectedMonths);

      // calculate total amounts for each ticket type
      ticketTypeAmounts = calculateTicketTypeAmounts(ticketsForYearAndMonths);
    }
  }

  //Colors and legend for graph bars
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
                "Za prikaz svih rezultata, neophodno je pritisnuti dugme 'Print'.",
                style: TextStyle(fontWeight: FontWeight.w400),
              ),
            ),
            const SizedBox(height: 10),
            _buildSearch(),
            _buildTicketTypeChart(),
            //const SizedBox(height: 20),
            //_buildRouteChart(), // Display the second chart
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

                  updateValues(issuedTicketResult);
                });
              },
            )),
            const SizedBox(width: 15),
            ElevatedButton(
              onPressed: () async {},
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

  //-> Bottom titles == Issued ticket months
  //**********************************************************************/
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

  //-> Left titles == Issued ticket amount
  //**********************************************************************/
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

  List<BarChartGroupData> getBarChartGroupData(
      List<IssuedTicket> tickets, List<int> months) {
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

        if (totalAmount > maxValue) {
          maxValue = totalAmount.toInt();
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

  Widget buildLegend() {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: ticketTypeColors.entries.map((entry) {
        final ticketTypeId = entry.key;
        final color = entry.value;
        final label = ticketTypeLabels[ticketTypeId] ?? "Unknown";

        return Padding(
          padding: const EdgeInsets.symmetric(vertical: 4.0),
          child: Row(
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
              ),
            ],
          ),
        );
      }).toList(),
    );
  }

  Widget leftGraphTitles(double value, TitleMeta meta, int maxTickets) {
    if (value == meta.max) {
      return Container();
    }

    const style = TextStyle(
      fontSize: 10,
      color: Colors.black,
    );

    // map the value back to its corresponding label
    return SideTitleWidget(
      axisSide: meta.axisSide,
      child: Text(
        value.round().toString(),
        style: style,
      ),
    );
  }

  Widget _buildTicketTypeChart() {
    return Column(
      children: [
        Padding(
          padding: const EdgeInsets.all(8.0),
          child: buildLegend(),
        ),
        AspectRatio(
          aspectRatio: 5,
          child: Padding(
            padding: const EdgeInsets.only(top: 16),
            child: LayoutBuilder(
              builder: (context, constraints) {
                final barsSpace = 4.0 * constraints.maxWidth / 400;
                final barsWidth = 8.0 * constraints.maxWidth / 400;

                final barChartGroupData = getBarChartGroupData(
                    ticketsForYearAndMonths, selectedMonths);

                return BarChart(
                  BarChartData(
                    alignment: BarChartAlignment.center,
                    maxY: (maxValue + 5).toDouble(),
                    barTouchData: BarTouchData(
                      enabled: false,
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
                    // borderData: FlBorderData(
                    //   show: false,
                    // ),
                    groupsSpace: barsSpace,
                    barGroups: barChartGroupData,
                  ),
                );
              },
            ),
          ),
        ),
      ],
    );
  }
}
