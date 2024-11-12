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

  Map<int, Map<int, int>>? ticketTypeData;
  Map<int, Map<int, int>>? routeData;

  @override
  void initState() {
    super.initState();
    issuedTicketProvider = context.read<IssuedTicketProvider>();

    for (int i = startYear; i <= endYear; i++) {
      _yearList.add(i.toString());
    }
    selectedYearIndex = _yearList.indexOf(currentYear.toString());
    selectedYear = _yearList[selectedYearIndex]; // Set a default selected year

    WidgetsBinding.instance.addPostFrameCallback((timeStamp) {
      setState(() {
        selectedYear = _yearList[selectedYearIndex];
      });
    });

    initForm();
  }

  Future<void> initForm() async {
    issuedTicketResult = await issuedTicketProvider.get();
    if (issuedTicketResult != null && issuedTicketResult!.result.isNotEmpty) {
      var filteredTickets =
          filterByYear(issuedTicketResult!.result, int.parse(selectedYear));
      setState(() {
        ticketTypeData = getTicketsByMonthAndType(filteredTickets);
        routeData = getTicketsByMonthAndRoute(filteredTickets);
      });
    }
  }

  // Method to filter tickets by year
  List<IssuedTicket> filterByYear(List<IssuedTicket> tickets, int year) {
    return tickets.where((ticket) => ticket.issuedDate?.year == year).toList();
  }

  // Generate data for the Ticket Type chart
  Map<int, Map<int, int>> getTicketsByMonthAndType(List<IssuedTicket> tickets) {
    var groupedData = <int, Map<int, int>>{};
    for (var ticket in tickets) {
      int month = ticket.issuedDate!.month;

      int typeId = ticket.ticketId!;
      groupedData[month] ??= {};
      groupedData[month]![typeId] = (groupedData[month]![typeId] ?? 0) + 1;
    }
    return groupedData;
  }

  // Generate data for the Route chart
  Map<int, Map<int, int>> getTicketsByMonthAndRoute(
      List<IssuedTicket> tickets) {
    var groupedData = <int, Map<int, int>>{};
    for (var ticket in tickets) {
      int month = ticket.issuedDate!.month;
      int routeId = ticket.routeId!;
      groupedData[month] ??= {};
      groupedData[month]![routeId] = (groupedData[month]![routeId] ?? 0) + 1;
    }
    return groupedData;
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
                "Za prikaz svih rezultata, neophodno je pritisnuti dugme 'Pretraga'.",
                style: TextStyle(fontWeight: FontWeight.w400),
              ),
            ),
            const SizedBox(height: 20),
            _buildSearch(),
            const SizedBox(height: 20),
            _buildTicketTypeChart(), // Display the first chart
            const SizedBox(height: 20),
            //_buildRouteChart(), // Display the second chart
          ],
        ),
      ),
    );
  }

  // Builds the search/filter UI and triggers data updates
  Widget _buildSearch() {
    return Row(
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
          onChanged: (val) {
            setState(() {
              selectedYear =
                  val ?? _yearList.first; // Fallback to a valid year if null
            });
          },
        )),
        const SizedBox(width: 15),
        ElevatedButton(
          onPressed: () async {
            var filteredTickets = filterByYear(
                issuedTicketResult?.result ?? [], int.parse(selectedYear));
            setState(() {
              ticketTypeData = getTicketsByMonthAndType(filteredTickets);
              routeData = getTicketsByMonthAndRoute(filteredTickets);
            });
          },
          style: ElevatedButton.styleFrom(
            backgroundColor: const Color.fromRGBO(72, 156, 118, 100),
            shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(2.0)),
            minimumSize: const Size(100, 65),
          ),
          child: const Text("Print", style: TextStyle(fontSize: 18)),
        )
      ],
    );
  }

  //horizontally
  Widget _buildTicketTypeChart() {
    if (ticketTypeData == null) {
      return const Center(child: Text("No data available for ticket types"));
    }

    // Define colors for each ticket type
    final Map<int, Color> ticketTypeColors = {
      1: Colors.purple, // Jednosmjerna
      2: Colors.blue, // Povratna
      3: Colors.orange, // Jednosmjerna dječija
      4: Colors.green, // Povratna dječija
      5: Colors.red, // Mjesečna
    };

    // Define labels for each ticket type for the legend
    final Map<int, String> ticketTypeLabels = {
      1: "Jednosmjerna",
      2: "Povratna",
      3: "Jednosmjerna dječija",
      4: "Povratna dječija",
      5: "Mjesečna",
    };

    return Column(
      children: [
        SizedBox(
          height: 400,
          child: BarChart(
            BarChartData(
              alignment: BarChartAlignment.spaceBetween,
              barGroups: ticketTypeData!.entries.map((entry) {
                final month = entry.key;
                final values = entry.value;

                return BarChartGroupData(
                  x: month,
                  barRods: values.entries.map((e) {
                    return BarChartRodData(
                      toY: e.value.toDouble(), // Ticket amount for each type
                      color:
                          ticketTypeColors[e.key], // Use color by ticket type
                      width: 10,
                      borderRadius: BorderRadius.circular(0),
                    );
                  }).toList(),
                );
              }).toList(),
              titlesData: FlTitlesData(
                bottomTitles: AxisTitles(
                  sideTitles: SideTitles(
                    showTitles: true,
                    reservedSize: 40,
                    getTitlesWidget: (value, meta) {
                      return Text(
                          value.toInt().toString()); // Display amount on x-axis
                    },
                  ),
                ),
                leftTitles: AxisTitles(
                  sideTitles: SideTitles(
                    showTitles: true,
                    reservedSize: 40,
                    getTitlesWidget: (value, meta) {
                      // Map month number to name for y-axis
                      final months = [
                        "Jan",
                        "Feb",
                        "Mar",
                        "Apr",
                        "May",
                        "Jun",
                        "Jul",
                        "Aug",
                        "Sep",
                        "Oct",
                        "Nov",
                        "Dec"
                      ];

                      int monthIndex = value.toInt() - 1;

                      if (monthIndex >= 0 && monthIndex < months.length) {
                        return Text(months[monthIndex]);
                      } else {
                        return const Text(""); // Return empty if out of range
                      }
                    },
                  ),
                ),
              ),
              gridData: FlGridData(show: true),
            ),
          ),
        ),
        const SizedBox(height: 20),
        // Legend
        Wrap(
          spacing: 10,
          children: ticketTypeColors.entries.map((entry) {
            return Row(
              mainAxisSize: MainAxisSize.min,
              children: [
                Container(
                  width: 16,
                  height: 16,
                  color: entry.value,
                ),
                const SizedBox(width: 5),
                Text(ticketTypeLabels[entry.key] ?? ""),
              ],
            );
          }).toList(),
        ),
      ],
    );
  }

//vertically
  /*Widget _buildTicketTypeChart() {
    if (ticketTypeData == null) {
      return const Center(child: Text("No data available for ticket types"));
    }

    // Define colors for each ticket type
    final Map<int, Color> ticketTypeColors = {
      1: Colors.purple, // Unemployed
      2: Colors.blue, // Employee
      3: Colors.orange, // Pensioner
      4: Colors.green, // Student
      5: Colors.red, // Kids
    };

    // Define labels for each ticket type for the legend
    final Map<int, String> ticketTypeLabels = {
      1: "Unemployed",
      2: "Employee",
      3: "Pensioner",
      4: "Student",
      5: "Kids",
    };

    return Column(
      children: [
        SizedBox(
          height: 400,
          child: BarChart(
            BarChartData(
              alignment: BarChartAlignment.spaceAround,
              barGroups: ticketTypeData!.entries.map((entry) {
                final month = entry.key;
                final values = entry.value;

                return BarChartGroupData(
                  x: month,
                  barRods: values.entries.map((e) {
                    return BarChartRodData(
                      toY: e.value.toDouble(), // Ticket amount for each type
                      color:
                          ticketTypeColors[e.key], // Use color by ticket type
                      width: 10,
                      borderRadius: BorderRadius.circular(0),
                    );
                  }).toList(),
                );
              }).toList(),
              titlesData: FlTitlesData(
                leftTitles: AxisTitles(
                  sideTitles: SideTitles(
                    showTitles: true,
                    reservedSize: 40,
                    getTitlesWidget: (value, meta) {
                      return Text(value
                          .toInt()
                          .toString()); // Display ticket amount on y-axis
                    },
                  ),
                ),
                bottomTitles: AxisTitles(
                  sideTitles: SideTitles(
                    showTitles: true,
                    reservedSize: 40,
                    getTitlesWidget: (value, meta) {
                      // Map month number to name for x-axis
                      final months = [
                        "Jan",
                        "Feb",
                        "Mar",
                        "Apr",
                        "May",
                        "Jun",
                        "Jul",
                        "Aug",
                        "Sep",
                        "Oct",
                        "Nov",
                        "Dec"
                      ];

                      int monthIndex = value.toInt() - 1;

                      if (monthIndex >= 0 && monthIndex < months.length) {
                        return Text(months[monthIndex]);
                      } else {
                        return const Text(""); // Return empty if out of range
                      }
                    },
                  ),
                ),
              ),
              gridData: FlGridData(show: true),
            ),
          ),
        ),
        const SizedBox(height: 20),
        // Legend
        Wrap(
          spacing: 10,
          children: ticketTypeColors.entries.map((entry) {
            return Row(
              mainAxisSize: MainAxisSize.min,
              children: [
                Container(
                  width: 16,
                  height: 16,
                  color: entry.value,
                ),
                const SizedBox(width: 5),
                Text(ticketTypeLabels[entry.key] ?? ""),
              ],
            );
          }).toList(),
        ),
      ],
    );
  }*/

/*
  Widget _buildRouteChart() {
    if (routeData == null || routeData!.isEmpty) {
      return const Center(child: Text("No data available for routes"));
    }
    return SizedBox(
      height: 300,
      child: BarChart(
        BarChartData(
          barGroups: routeData!.entries.map((entry) {
            final month = entry.key;
            final values = entry.value;
            return BarChartGroupData(
              x: month,
              barRods: values.entries.map((e) {
                return BarChartRodData(
                  toY: e.value.toDouble(),
                  width: 10, // Customize bar width
                  color: Colors.green, // Customize color
                );
              }).toList(),
            );
          }).toList(),
          titlesData: FlTitlesData(
            bottomTitles: AxisTitles(
              sideTitles: SideTitles(
                showTitles: true,
                getTitlesWidget: (value, meta) {
                  return Text("M${value.toInt()}"); // Month labeling
                },
              ),
            ),
            leftTitles: AxisTitles(
              sideTitles: SideTitles(showTitles: true, reservedSize: 40),
            ),
          ),
        ),
      ),
    );
  }*/
}
