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
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCountryId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserStatusId = table.Column<int>(type: "int", nullable: false),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    StatusExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Countries_UserCountryId",
                        column: x => x.UserCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
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
                    UserId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
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
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    RouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedTickets", x => x.IssuedTicketId);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Bosnia and Herzegovina" },
                    { 2, "Germany" },
                    { 3, "Austria" },
                    { 4, "Croatia" },
                    { 5, "Serbia" },
                    { 6, "Slovenia" },
                    { 7, "Montenegro" },
                    { 8, "Albania" },
                    { 9, "China" },
                    { 10, "Japan" }
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
                columns: new[] { "UserId", "Active", "Address", "City", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImage", "RegistrationDate", "StatusExpirationDate", "UserCountryId", "UserName", "UserStatusId", "ZipCode" },
                values: new object[,]
                {
                    { 1, true, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7422), "hi4v4fRCXSr8UxX/eNP2xW4JaV0=", "FRA/EY2kfg3L43WaPbkphg==", "061222333", null, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7421), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, true, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Senada", "Šahinpašić", new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7433), "xeMW58DyjXAzmk2YdR10klxuz3M=", "NQEk39wGTm/ttqJa0g6BzQ==", "061222444", null, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7432), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 4, "72000" },
                    { 3, true, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "neki@mail.com", "Test", "Testni", new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7439), "6pEqpJJlhzHxLf9jF30JBsrSMbM=", "A7MzLXKTy7hQBA51yMZKaQ==", "061222555", null, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7438), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, true, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "neko@mail.com", "Testni", "Test", new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7444), "NNiw1K8pPSqtaHs2h0TBNi5V4+A=", "m+ysH8IcfSBU1PvTRPpFiQ==", "061222666", null, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7443), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, true, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "proba@mail.com", "Proba", "Probni", new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7449), "Z6PRVbOSNT2a6Yzp/WpCDZP1hIw=", "AOYVPm/Lr/P+KEkQ5thQ0g==", "061222777", null, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7448), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, true, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7459), "wR2B59hZoDAhKX0DT1/cfTl9owk=", "O9xBJMjvfXKHfaM3w8rJeQ==", "061222888", null, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7458), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
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
                    { 1, true, false, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7762), "", 2, 3 },
                    { 2, true, false, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7765), "", 3, 1 },
                    { 3, true, false, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7768), "", 4, 2 },
                    { 4, true, false, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7770), "", 5, 4 },
                    { 5, true, false, new DateTime(2024, 11, 26, 18, 42, 45, 982, DateTimeKind.Local).AddTicks(7772), "", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 8, 23, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 8, 23, 2, 0, 0, DateTimeKind.Unspecified), 9, 15, 2 },
                    { 2, new DateTime(2024, 12, 4, 17, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 16, 34, 0, 0, DateTimeKind.Unspecified), 4, 8, 5 },
                    { 3, new DateTime(2024, 11, 22, 14, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 13, 9, 0, 0, DateTimeKind.Unspecified), 15, 11, 3 },
                    { 4, new DateTime(2024, 11, 26, 10, 14, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 9, 43, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 5, new DateTime(2024, 12, 13, 11, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 10, 36, 0, 0, DateTimeKind.Unspecified), 2, 10, 5 },
                    { 6, new DateTime(2024, 12, 28, 7, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 7, 30, 0, 0, DateTimeKind.Unspecified), 4, 2, 6 },
                    { 7, new DateTime(2024, 11, 7, 19, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 19, 4, 0, 0, DateTimeKind.Unspecified), 15, 6, 2 },
                    { 8, new DateTime(2024, 11, 6, 20, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 20, 3, 0, 0, DateTimeKind.Unspecified), 14, 11, 3 },
                    { 9, new DateTime(2024, 11, 13, 15, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), 5, 9, 1 },
                    { 10, new DateTime(2024, 12, 20, 5, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 5, 17, 0, 0, DateTimeKind.Unspecified), 8, 15, 5 },
                    { 11, new DateTime(2024, 12, 3, 8, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 3, 7, 27, 0, 0, DateTimeKind.Unspecified), 9, 5, 6 },
                    { 12, new DateTime(2024, 12, 25, 9, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 8, 28, 0, 0, DateTimeKind.Unspecified), 10, 11, 4 },
                    { 13, new DateTime(2024, 12, 5, 6, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 5, 45, 0, 0, DateTimeKind.Unspecified), 8, 11, 4 },
                    { 14, new DateTime(2024, 11, 28, 22, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 21, 23, 0, 0, DateTimeKind.Unspecified), 14, 13, 6 },
                    { 15, new DateTime(2024, 12, 30, 14, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 13, 40, 0, 0, DateTimeKind.Unspecified), 14, 10, 4 },
                    { 16, new DateTime(2024, 11, 11, 12, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 12, 14, 0, 0, DateTimeKind.Unspecified), 13, 1, 5 },
                    { 17, new DateTime(2024, 12, 3, 21, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 3, 20, 20, 0, 0, DateTimeKind.Unspecified), 14, 9, 2 },
                    { 18, new DateTime(2024, 12, 16, 0, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 23, 23, 0, 0, DateTimeKind.Unspecified), 8, 4, 2 },
                    { 19, new DateTime(2024, 12, 21, 7, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 6, 10, 0, 0, DateTimeKind.Unspecified), 11, 4, 4 },
                    { 20, new DateTime(2024, 12, 2, 22, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 2, 21, 49, 0, 0, DateTimeKind.Unspecified), 4, 5, 6 },
                    { 21, new DateTime(2024, 11, 5, 10, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 9, 56, 0, 0, DateTimeKind.Unspecified), 8, 7, 3 },
                    { 22, new DateTime(2024, 11, 23, 23, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 23, 22, 33, 0, 0, DateTimeKind.Unspecified), 15, 8, 4 },
                    { 23, new DateTime(2024, 12, 23, 13, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 12, 50, 0, 0, DateTimeKind.Unspecified), 14, 5, 1 },
                    { 24, new DateTime(2024, 11, 11, 16, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 16, 10, 0, 0, DateTimeKind.Unspecified), 5, 3, 4 },
                    { 25, new DateTime(2024, 12, 13, 7, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 7, 26, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 26, new DateTime(2024, 11, 10, 21, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 21, 6, 0, 0, DateTimeKind.Unspecified), 5, 7, 1 },
                    { 27, new DateTime(2024, 12, 1, 20, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 19, 42, 0, 0, DateTimeKind.Unspecified), 10, 12, 4 },
                    { 28, new DateTime(2024, 11, 25, 17, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 17, 28, 0, 0, DateTimeKind.Unspecified), 9, 6, 3 },
                    { 29, new DateTime(2024, 12, 13, 7, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 7, 21, 0, 0, DateTimeKind.Unspecified), 9, 14, 6 },
                    { 30, new DateTime(2024, 12, 9, 14, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 9, 14, 4, 0, 0, DateTimeKind.Unspecified), 15, 13, 6 },
                    { 31, new DateTime(2024, 12, 14, 14, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 14, 19, 0, 0, DateTimeKind.Unspecified), 2, 14, 6 },
                    { 32, new DateTime(2024, 11, 14, 6, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 5, 50, 0, 0, DateTimeKind.Unspecified), 15, 12, 6 },
                    { 33, new DateTime(2024, 12, 7, 12, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 7, 11, 46, 0, 0, DateTimeKind.Unspecified), 11, 12, 2 },
                    { 34, new DateTime(2024, 12, 16, 20, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 20, 8, 0, 0, DateTimeKind.Unspecified), 11, 15, 5 },
                    { 35, new DateTime(2024, 12, 6, 16, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 15, 54, 0, 0, DateTimeKind.Unspecified), 3, 1, 3 },
                    { 36, new DateTime(2024, 11, 21, 21, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 21, 21, 34, 0, 0, DateTimeKind.Unspecified), 13, 6, 5 },
                    { 37, new DateTime(2024, 12, 20, 18, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 18, 22, 0, 0, DateTimeKind.Unspecified), 4, 3, 6 },
                    { 38, new DateTime(2024, 12, 4, 23, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 23, 3, 0, 0, DateTimeKind.Unspecified), 4, 6, 4 },
                    { 39, new DateTime(2024, 12, 5, 23, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 23, 2, 0, 0, DateTimeKind.Unspecified), 6, 5, 3 },
                    { 40, new DateTime(2024, 11, 10, 9, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 8, 27, 0, 0, DateTimeKind.Unspecified), 15, 4, 4 },
                    { 41, new DateTime(2024, 11, 8, 0, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 23, 54, 0, 0, DateTimeKind.Unspecified), 13, 5, 4 },
                    { 42, new DateTime(2024, 11, 23, 23, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 23, 23, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 4 },
                    { 43, new DateTime(2024, 11, 17, 10, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 9, 50, 0, 0, DateTimeKind.Unspecified), 9, 5, 1 },
                    { 44, new DateTime(2024, 12, 1, 14, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 13, 55, 0, 0, DateTimeKind.Unspecified), 10, 11, 6 },
                    { 45, new DateTime(2024, 12, 21, 16, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 16, 41, 0, 0, DateTimeKind.Unspecified), 13, 9, 4 },
                    { 46, new DateTime(2024, 11, 5, 11, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 10, 40, 0, 0, DateTimeKind.Unspecified), 7, 14, 3 },
                    { 47, new DateTime(2024, 12, 30, 7, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 7, 1, 0, 0, DateTimeKind.Unspecified), 3, 8, 6 },
                    { 48, new DateTime(2024, 11, 5, 12, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 11, 58, 0, 0, DateTimeKind.Unspecified), 8, 9, 1 },
                    { 49, new DateTime(2024, 11, 13, 6, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 5, 44, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 50, new DateTime(2024, 11, 28, 11, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 10, 54, 0, 0, DateTimeKind.Unspecified), 9, 1, 2 },
                    { 51, new DateTime(2024, 11, 26, 22, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 22, 33, 0, 0, DateTimeKind.Unspecified), 4, 7, 4 },
                    { 52, new DateTime(2024, 12, 29, 14, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 14, 23, 0, 0, DateTimeKind.Unspecified), 5, 2, 5 },
                    { 53, new DateTime(2024, 12, 7, 11, 7, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 7, 10, 27, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 54, new DateTime(2024, 12, 13, 17, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 16, 23, 0, 0, DateTimeKind.Unspecified), 15, 7, 4 },
                    { 55, new DateTime(2024, 12, 24, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 9, 19, 0, 0, DateTimeKind.Unspecified), 7, 14, 6 },
                    { 56, new DateTime(2024, 11, 23, 14, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 23, 14, 31, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 57, new DateTime(2024, 12, 24, 8, 37, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 8, 25, 0, 0, DateTimeKind.Unspecified), 7, 5, 5 },
                    { 58, new DateTime(2024, 12, 15, 6, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 6, 34, 0, 0, DateTimeKind.Unspecified), 11, 7, 1 },
                    { 59, new DateTime(2024, 12, 28, 23, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 22, 29, 0, 0, DateTimeKind.Unspecified), 12, 5, 6 },
                    { 60, new DateTime(2024, 12, 4, 21, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 20, 31, 0, 0, DateTimeKind.Unspecified), 15, 5, 2 },
                    { 61, new DateTime(2024, 12, 12, 13, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 13, 28, 0, 0, DateTimeKind.Unspecified), 13, 7, 5 },
                    { 62, new DateTime(2024, 11, 4, 10, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 10, 7, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 63, new DateTime(2024, 11, 8, 8, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 8, 10, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 64, new DateTime(2024, 11, 27, 13, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 13, 9, 0, 0, DateTimeKind.Unspecified), 14, 8, 2 },
                    { 65, new DateTime(2024, 11, 4, 22, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 21, 39, 0, 0, DateTimeKind.Unspecified), 10, 6, 6 },
                    { 66, new DateTime(2024, 12, 14, 9, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 9, 3, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 67, new DateTime(2024, 11, 17, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 20, 46, 0, 0, DateTimeKind.Unspecified), 2, 7, 6 },
                    { 68, new DateTime(2024, 11, 29, 11, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 11, 1, 0, 0, DateTimeKind.Unspecified), 3, 5, 5 },
                    { 69, new DateTime(2024, 12, 25, 14, 7, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 13, 42, 0, 0, DateTimeKind.Unspecified), 11, 9, 1 },
                    { 70, new DateTime(2024, 11, 9, 11, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 9, 10, 35, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 71, new DateTime(2024, 12, 25, 18, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 18, 1, 0, 0, DateTimeKind.Unspecified), 11, 10, 1 },
                    { 72, new DateTime(2024, 12, 30, 18, 12, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 17, 19, 0, 0, DateTimeKind.Unspecified), 10, 5, 2 },
                    { 73, new DateTime(2024, 11, 8, 6, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 6, 2, 0, 0, DateTimeKind.Unspecified), 8, 5, 5 },
                    { 74, new DateTime(2024, 12, 25, 8, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 8, 20, 0, 0, DateTimeKind.Unspecified), 5, 3, 4 },
                    { 75, new DateTime(2024, 12, 6, 6, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 6, 33, 0, 0, DateTimeKind.Unspecified), 4, 15, 2 },
                    { 76, new DateTime(2024, 12, 14, 14, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 13, 32, 0, 0, DateTimeKind.Unspecified), 14, 6, 5 },
                    { 77, new DateTime(2024, 11, 9, 17, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 9, 16, 39, 0, 0, DateTimeKind.Unspecified), 8, 15, 3 },
                    { 78, new DateTime(2024, 11, 24, 6, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 24, 6, 45, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 79, new DateTime(2024, 12, 21, 20, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 20, 4, 0, 0, DateTimeKind.Unspecified), 15, 4, 4 },
                    { 80, new DateTime(2024, 11, 27, 14, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 14, 1, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 81, new DateTime(2024, 11, 24, 22, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 24, 21, 36, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 82, new DateTime(2024, 11, 13, 7, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 7, 17, 0, 0, DateTimeKind.Unspecified), 13, 8, 3 },
                    { 83, new DateTime(2024, 11, 8, 11, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 10, 59, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 84, new DateTime(2024, 12, 1, 19, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 18, 25, 0, 0, DateTimeKind.Unspecified), 15, 8, 6 },
                    { 85, new DateTime(2024, 12, 30, 22, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 22, 17, 0, 0, DateTimeKind.Unspecified), 13, 6, 6 },
                    { 86, new DateTime(2024, 11, 14, 16, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 15, 9, 0, 0, DateTimeKind.Unspecified), 14, 10, 6 },
                    { 87, new DateTime(2024, 11, 11, 7, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 7, 33, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 88, new DateTime(2024, 12, 23, 7, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 6, 52, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 89, new DateTime(2024, 12, 12, 10, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 10, 1, 0, 0, DateTimeKind.Unspecified), 2, 14, 6 },
                    { 90, new DateTime(2024, 11, 12, 8, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 7, 43, 0, 0, DateTimeKind.Unspecified), 10, 2, 3 },
                    { 91, new DateTime(2024, 12, 19, 14, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 14, 32, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 92, new DateTime(2024, 11, 25, 15, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 14, 48, 0, 0, DateTimeKind.Unspecified), 6, 10, 5 },
                    { 93, new DateTime(2024, 11, 29, 20, 37, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 19, 41, 0, 0, DateTimeKind.Unspecified), 12, 10, 2 },
                    { 94, new DateTime(2024, 11, 29, 21, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 20, 34, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 95, new DateTime(2024, 12, 11, 17, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 11, 16, 28, 0, 0, DateTimeKind.Unspecified), 3, 13, 4 },
                    { 96, new DateTime(2024, 12, 25, 7, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 6, 51, 0, 0, DateTimeKind.Unspecified), 15, 11, 2 },
                    { 97, new DateTime(2024, 12, 11, 12, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 11, 11, 59, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 98, new DateTime(2024, 12, 23, 22, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 21, 39, 0, 0, DateTimeKind.Unspecified), 15, 2, 4 },
                    { 99, new DateTime(2024, 11, 20, 18, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 18, 24, 0, 0, DateTimeKind.Unspecified), 14, 4, 6 },
                    { 100, new DateTime(2024, 11, 24, 10, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 24, 9, 55, 0, 0, DateTimeKind.Unspecified), 10, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "IssuedTickets",
                columns: new[] { "IssuedTicketId", "Amount", "IssuedDate", "RouteId", "TicketId", "UserId", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 5, 2, new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 9, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 2, 5, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 6, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 2, 1, new DateTime(2023, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 27, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 9, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 2, 2, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 1, 1, new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, 5, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 8, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 3, 2, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 18, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 4, 6, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 1, new DateTime(2023, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 6, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 5, 1, new DateTime(2023, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 10, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 5, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 5, 1, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 12, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 3, 5, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 12, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 1, 1, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 8, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, 5, 4, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 16, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 2, 4, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 8, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 2, 2, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 14, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 2, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 14, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 5, 2, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 7, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 5, 6, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 18, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 2, 6, new DateTime(2023, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 12, new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 4, 3, new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 17, new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 5, 3, new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 13, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 5, 6, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 19, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 5, 1, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 12, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 2, 3, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 8, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 4, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 11, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 4, 1, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 30, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 7, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, 6, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 5, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 2, 1, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 17, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 4, 2, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 30, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 12, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 3, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 15, new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 3, 3, new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 27, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 2, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 1, 1, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 17, new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 1, 6, new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 17, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 3, 3, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 12, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1, 6, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 2, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 6, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 6, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 4, 1, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 18, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 1, 3, new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 2, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 4, 6, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 7, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 4, 3, new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 18, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 5, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 11, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 5, 4, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 16, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 2, 4, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 8, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 3, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 4, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 4, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 5, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 19, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 3, 5, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 5, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 4, 4, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 17, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 4, 3, new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 10, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 5, 1, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 3, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2, 5, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 18, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 9, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, 3, 1, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 18, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 2, 1, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 4, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 2, 2, new DateTime(2023, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 17, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 2, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 18, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 1, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 3, 1, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 19, new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 5, 5, new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 2, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 5, 6, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 2, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 4, 6, new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 21, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 10, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 2, 3, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 4, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 2, 1, new DateTime(2023, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 18, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 2, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 1, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 1, 3, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 19, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 1, 6, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 8, new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 3, 3, new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 7, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 4, 4, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 16, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 1, 2, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 5, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 1, 6, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 5, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 2, 1, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 21, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 14, new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 1, 5, new DateTime(2023, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 16, new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 2, 1, new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 22, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 13, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, 5, 2, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 4, new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 1, 2, new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 9, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 4, 4, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 13, new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 4, 1, new DateTime(2023, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 15, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 3, 5, new DateTime(2023, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 15, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 3, 5, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 26, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 16, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 3, 6, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 11, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 1, 4, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 3, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 2, 4, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 14, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 1, 2, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 2, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 6, new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 18, new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 4, 6, new DateTime(2024, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 16, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 4, 5, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 4, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 5, 3, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 18, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 3, 3, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 18, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 3, 3, new DateTime(2023, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 28, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 6, new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 5, new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 16, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 2, 2, new DateTime(2024, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 3, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 4, 6, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 14, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 4, 5, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 28, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 17, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 1, 3, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 26, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 19, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 2, 2, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 12, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 3, 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 6, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 2, 2, new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 12, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1, 5, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 11, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 4, 3, new DateTime(2023, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 16, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 2, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_Users_UserCountryId",
                table: "Users",
                column: "UserCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
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
                name: "IssuedTickets");

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
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
