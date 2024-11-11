using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ePrijevozSarajevo.Services.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentOptions",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptions", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketId);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    UserStatusId = table.Column<int>(type: "int", nullable: true),
                    ProfileImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BuildYear = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserStatusId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Requests_Statuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_Requests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartStationId = table.Column<int>(type: "int", nullable: false),
                    EndStationId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Departure = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ActiveOnHolidays = table.Column<bool>(type: "bit", nullable: false),
                    ActiveOnWeekends = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteId);
                    table.ForeignKey(
                        name: "FK_Routes_Stations_EndStationId",
                        column: x => x.EndStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId");
                    table.ForeignKey(
                        name: "FK_Routes_Stations_StartStationId",
                        column: x => x.StartStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId");
                    table.ForeignKey(
                        name: "FK_Routes_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IssuedTickets",
                columns: table => new
                {
                    IssuedTicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedTickets", x => x.IssuedTicketId);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId");
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId");
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "HolidayId", "Date", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bajram" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nova godina" },
                    { 3, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Božić" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 1, "MAN" },
                    { 2, "Solaris" },
                    { 3, "Volvo" },
                    { 4, "Mercedes" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "StationId", "Name" },
                values: new object[,]
                {
                    { 1, "Ilidža" },
                    { 2, "Stup" },
                    { 3, "Nedžarići" },
                    { 4, "Socijalno" },
                    { 5, "Malta" },
                    { 6, "Baščaršija" },
                    { 7, "Otoka" },
                    { 8, "Skenderija" },
                    { 9, "Drvenija" },
                    { 10, "Dobrinja" },
                    { 11, "Grbavica" },
                    { 12, "Hrasno" },
                    { 13, "Aneks" },
                    { 14, "Alipašino polje" },
                    { 15, "Švrakino selo" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Discount", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, "Default" },
                    { 2, 0.29999999999999999, "Student" },
                    { 3, 0.5, "Penzioner" },
                    { 4, 0.14999999999999999, "Zaposlenik" },
                    { 5, 0.40000000000000002, "Nezaposlen" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "Name", "Price", "StateMachine" },
                values: new object[,]
                {
                    { 1, "Jednosmjerna", 1.8, "draft" },
                    { 2, "Povratna", 3.2000000000000002, "draft" },
                    { 3, "Jednosmjerna dječija", 0.80000000000000004, "draft" },
                    { 4, "Povratna dječija", 1.2, "draft" },
                    { 5, "Mjesečna", 75.0, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Trolleybus" },
                    { 2, "Tram" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Active", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImagePath", "RegistrationDate", "StatusExpirationDate", "UserName", "UserStatusId" },
                values: new object[,]
                {
                    { 1, true, "Adresa 11", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9816), "4bg+LqbZe4lLNqDvkEaswOMRuGg=", "49CtNjUzi0R4Ga5SLISdNA==", "061222333", "", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9815), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "desktop", 4 },
                    { 2, true, "Adresa 12", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Senada", "Šahinpašić", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9826), "IWfFFS9PrsTSpEfn9cuou9PcIPk=", "GvyNXrpe1gEubF5MT0qBUw==", "061222444", "", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9825), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile", 4 },
                    { 3, true, "Adresa 14", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "neki@mail.com", "Test", "Testni", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9842), "PWJGrmGpQPEvLkNUYrIFUtKTPAc=", "CjKDg72pxDD/K27/rhKHJg==", "061222555", "", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9841), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile1", 1 },
                    { 4, true, "Adresa 15", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "neko@mail.com", "Testni", "Test", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9847), "0rXDO/wKYDysdBl71VX3ViX857I=", "7cwxLdPI2OoTeDlDlGl8eQ==", "061222666", "", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9846), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile2", 1 },
                    { 5, true, "Adresa 16", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "proba@mail.com", "Proba", "Probni", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9853), "nfst21oPchLqYgM4/bgpKXyfoYk=", "zAM2YlVuVyJcFD6+V+f6tA==", "061222777", "", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9852), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile3", 1 },
                    { 6, true, "Adresa 17", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9858), "G4po4cq0GaRsY4E+v52+pHPRbYg=", "2xU5a/YP4GBjbgGDNaOvnA==", "061222888", "", new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9857), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile4", 1 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "BuildYear", "ManufacturerId", "Number", "RegistrationNumber", "TypeId" },
                values: new object[,]
                {
                    { 1, 2005, 1, 15, "A10-B-123", 1 },
                    { 2, 2015, 2, 20, "A11-C-124", 2 },
                    { 3, 2010, 3, 25, "A12-D-154", 1 },
                    { 4, 2007, 4, 30, "A14-E-174", 2 },
                    { 5, 2014, 4, 35, "A15-F-183", 1 },
                    { 6, 2011, 3, 35, "A16-G-195", 2 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "Active", "Approved", "DateCreated", "RejectionReason", "UserId", "UserStatusId" },
                values: new object[,]
                {
                    { 1, true, false, new DateTime(2024, 11, 11, 16, 47, 54, 981, DateTimeKind.Local).AddTicks(201), "", 2, 3 },
                    { 2, true, false, new DateTime(2024, 11, 11, 16, 47, 54, 981, DateTimeKind.Local).AddTicks(205), "", 3, 1 },
                    { 3, true, false, new DateTime(2024, 11, 11, 16, 47, 54, 981, DateTimeKind.Local).AddTicks(208), "", 4, 2 },
                    { 4, true, false, new DateTime(2024, 11, 11, 16, 47, 54, 981, DateTimeKind.Local).AddTicks(210), "", 5, 4 },
                    { 5, true, false, new DateTime(2024, 11, 11, 16, 47, 54, 981, DateTimeKind.Local).AddTicks(212), "", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Active", "ActiveOnHolidays", "ActiveOnWeekends", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, true, true, true, new DateTime(2024, 5, 24, 10, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 24, 9, 54, 0, 0, DateTimeKind.Unspecified), 6, 1, 2 },
                    { 2, true, true, true, new DateTime(2024, 10, 2, 6, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 2, 6, 10, 0, 0, DateTimeKind.Unspecified), 8, 1, 4 },
                    { 3, true, true, true, new DateTime(2024, 11, 3, 6, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 3, 6, 1, 0, 0, DateTimeKind.Unspecified), 6, 1, 6 },
                    { 4, true, true, true, new DateTime(2024, 7, 2, 5, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 2, 5, 5, 0, 0, DateTimeKind.Unspecified), 7, 2, 4 },
                    { 5, true, true, true, new DateTime(2024, 4, 4, 9, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 4, 8, 44, 0, 0, DateTimeKind.Unspecified), 3, 7, 2 },
                    { 6, true, true, true, new DateTime(2024, 4, 17, 14, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 17, 14, 48, 0, 0, DateTimeKind.Unspecified), 1, 8, 6 },
                    { 7, true, true, true, new DateTime(2024, 4, 25, 12, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 12, 15, 0, 0, DateTimeKind.Unspecified), 15, 9, 1 },
                    { 8, true, true, true, new DateTime(2024, 5, 11, 5, 14, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 11, 5, 2, 0, 0, DateTimeKind.Unspecified), 8, 11, 3 },
                    { 9, true, true, true, new DateTime(2024, 5, 14, 9, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 9, 19, 0, 0, DateTimeKind.Unspecified), 14, 10, 5 },
                    { 10, true, true, true, new DateTime(2024, 12, 17, 19, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 19, 40, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 11, true, true, true, new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9748), new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9747), 15, 7, 1 },
                    { 12, true, true, true, new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9750), new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9749), 6, 8, 2 },
                    { 13, true, true, true, new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9752), new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9751), 4, 7, 5 },
                    { 14, true, true, true, new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9754), new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9753), 13, 8, 3 },
                    { 15, true, true, true, new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9755), new DateTime(2024, 11, 11, 16, 47, 54, 980, DateTimeKind.Local).AddTicks(9754), 2, 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "ModificationDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 11, 16, 47, 54, 981, DateTimeKind.Local).AddTicks(449), 1, 1 },
                    { 2, new DateTime(2024, 11, 11, 16, 47, 54, 981, DateTimeKind.Local).AddTicks(451), 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssuedTickets_RouteId",
                table: "IssuedTickets",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedTickets_TicketId",
                table: "IssuedTickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedTickets_UserId",
                table: "IssuedTickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserStatusId",
                table: "Requests",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_EndStationId",
                table: "Routes",
                column: "EndStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartStationId",
                table: "Routes",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_VehicleId",
                table: "Routes",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusId",
                table: "Users",
                column: "UserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RegistrationNumber",
                table: "Vehicles",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TypeId",
                table: "Vehicles",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "IssuedTickets");

            migrationBuilder.DropTable(
                name: "PaymentOptions");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
