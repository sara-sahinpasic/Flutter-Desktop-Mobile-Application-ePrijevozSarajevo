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
                columns: new[] { "UserId", "Address", "City", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImage", "RegistrationDate", "StatusExpirationDate", "UserCountryId", "UserName", "UserStatusId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(627), "uMTWuGi9HTuwiawNZmhuw/4bxGg=", "yp+xxgmOIWgNhSVktNz2Cg==", "061222333", null, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(626), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Senada", "Šahinpašić", new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(640), "k6tcnxnPjTX5/V/YVc0qFSRn2FI=", "TwWU7ftq3zCBbonX30cLvA==", "061222444", null, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(639), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 4, "72000" },
                    { 3, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevoapp@gmail.com", "Test", "Testni", new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(646), "l1GKKwVR3YzQpR+726287iLgURw=", "qC9RMcri76X8gqpm3Td9gg==", "061222555", null, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(645), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevotest@outlook.com", "Testni", "Test", new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(651), "7jkXYc+J68YFStSLDXEEX0vrUbc=", "E4E46lWGG+G8lS8BG5tfcg==", "061222666", null, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(650), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevo.app@gmx.de", "Proba", "Probni", new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(656), "Ah+St64FercnxCywiJuxIigCJpw=", "zggBDon4VOYzZtK/Tqha0w==", "061222777", null, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(655), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(662), "+WlKAa3aAPbs+c+fvIive/G3P+c=", "9SL5LaQPJ30g4fxrGgJdcg==", "061222888", null, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(661), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
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
                    { 1, true, false, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(1027), "", 2, 3 },
                    { 2, true, false, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(1031), "", 3, 5 },
                    { 3, true, false, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(1033), "", 4, 2 },
                    { 4, true, false, new DateTime(2025, 1, 5, 22, 53, 24, 369, DateTimeKind.Local).AddTicks(1035), "", 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 6 },
                    { 2, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 3, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 5 },
                    { 4, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 5, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 2 },
                    { 6, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 2 },
                    { 7, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 4 },
                    { 8, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 9, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 10, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 2 },
                    { 11, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 2 },
                    { 12, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 6 },
                    { 13, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 3 },
                    { 14, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 3 },
                    { 15, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 6 },
                    { 16, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 2 },
                    { 17, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 3 },
                    { 18, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 3 },
                    { 19, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 20, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 21, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 22, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 3 },
                    { 23, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 6 },
                    { 24, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 6 },
                    { 25, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 2 },
                    { 26, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 2 },
                    { 27, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 28, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 29, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 2 },
                    { 30, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 31, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 32, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 2 },
                    { 33, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 3 },
                    { 34, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 3 },
                    { 35, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 6 },
                    { 36, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 2 },
                    { 37, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 5 },
                    { 38, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 2 },
                    { 39, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 2 },
                    { 40, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 41, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 4 },
                    { 42, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 5 },
                    { 43, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 6 },
                    { 44, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 2 },
                    { 45, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 6 },
                    { 46, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 6 },
                    { 47, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 48, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 1 },
                    { 49, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 50, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 3 },
                    { 51, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 1 },
                    { 52, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 4 },
                    { 53, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 6 },
                    { 54, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 55, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 1 },
                    { 56, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 1 },
                    { 57, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 1 },
                    { 58, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 59, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 60, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 61, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 4 },
                    { 62, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 63, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 6 },
                    { 64, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 5 },
                    { 65, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 1 },
                    { 66, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 67, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 4 },
                    { 68, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 1 },
                    { 69, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 4 },
                    { 70, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 71, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 72, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 73, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 3 },
                    { 74, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 75, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 76, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 1 },
                    { 77, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 78, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 2 },
                    { 79, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 80, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 81, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 5 },
                    { 82, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 83, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 84, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 85, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 6 },
                    { 86, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 6 },
                    { 87, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 1 },
                    { 88, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 89, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 3 },
                    { 90, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 4 },
                    { 91, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 4 },
                    { 92, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 1 },
                    { 93, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 1 },
                    { 94, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 5 },
                    { 95, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 5 },
                    { 96, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 2 },
                    { 97, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 2 },
                    { 98, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 3 },
                    { 99, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 100, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 4 },
                    { 101, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 102, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 5 },
                    { 103, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 4 },
                    { 104, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 4 },
                    { 105, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 5 },
                    { 106, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 6 },
                    { 107, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 6 },
                    { 108, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 2 },
                    { 109, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 110, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 3 },
                    { 111, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 2 },
                    { 112, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 113, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 2 },
                    { 114, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 6 },
                    { 115, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 4 },
                    { 116, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 2 },
                    { 117, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 2 },
                    { 118, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 4 },
                    { 119, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 5 },
                    { 120, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 121, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 5 },
                    { 122, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 123, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 124, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 6 },
                    { 125, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 6 },
                    { 126, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 127, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 128, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 4 },
                    { 129, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 3 },
                    { 130, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 4 },
                    { 131, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 132, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 133, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 134, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 2 },
                    { 135, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 3 },
                    { 136, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 3 },
                    { 137, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 138, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 139, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 6 },
                    { 140, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 1 },
                    { 141, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 4 },
                    { 142, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 4 },
                    { 143, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 6 },
                    { 144, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 145, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 3 },
                    { 146, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 147, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 148, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 6 },
                    { 149, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 4 },
                    { 150, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 151, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 1 },
                    { 152, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 6 },
                    { 153, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 6 },
                    { 154, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 155, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 1 },
                    { 156, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 157, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 5 },
                    { 158, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 159, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 6 },
                    { 160, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 5 },
                    { 161, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 5 },
                    { 162, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 6 },
                    { 163, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 164, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 6 },
                    { 165, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 5 },
                    { 166, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 167, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 168, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 2 },
                    { 169, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 3 },
                    { 170, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 3 },
                    { 171, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 1 },
                    { 172, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 173, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 5 },
                    { 174, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 6 },
                    { 175, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 176, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 4 },
                    { 177, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 6 },
                    { 178, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 6 },
                    { 179, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 5 },
                    { 180, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 2 },
                    { 181, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 182, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 5 },
                    { 183, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 1 },
                    { 184, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 185, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 1 },
                    { 186, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 5 },
                    { 187, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 4 },
                    { 188, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 1 },
                    { 189, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 2 },
                    { 190, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 191, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 6 },
                    { 192, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 5 },
                    { 193, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 194, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 195, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 1 },
                    { 196, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 197, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 198, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 2 },
                    { 199, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 3 },
                    { 200, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 201, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 202, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 203, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 204, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 205, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 2 },
                    { 206, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 1 },
                    { 207, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 1 },
                    { 208, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 3 },
                    { 209, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 3 },
                    { 210, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 4 },
                    { 211, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 3 },
                    { 212, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 213, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 214, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 3 },
                    { 215, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 6 },
                    { 216, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 3 },
                    { 217, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 3 },
                    { 218, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 1 },
                    { 219, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 2 },
                    { 220, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 221, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 6 },
                    { 222, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 5 },
                    { 223, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 2 },
                    { 224, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 225, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 226, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 1 },
                    { 227, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 3 },
                    { 228, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 1 },
                    { 229, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 6 },
                    { 230, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 4 },
                    { 231, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 232, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 6 },
                    { 233, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 234, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 2 },
                    { 235, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 1 },
                    { 236, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 2 },
                    { 237, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 5 },
                    { 238, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 3 },
                    { 239, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 6 },
                    { 240, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 241, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { 242, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 243, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 4 },
                    { 244, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 1 },
                    { 245, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 246, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 4 },
                    { 247, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 248, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 6 },
                    { 249, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 250, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 5 },
                    { 251, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 6 },
                    { 252, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 253, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 2 },
                    { 254, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 1 },
                    { 255, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 256, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 5 },
                    { 257, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 3 },
                    { 258, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 259, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 3 },
                    { 260, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 6 },
                    { 261, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 3 },
                    { 262, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 263, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 4 },
                    { 264, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 2 },
                    { 265, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 4 },
                    { 266, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 267, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 6 },
                    { 268, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 4 },
                    { 269, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 270, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 1 },
                    { 271, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 272, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 1 },
                    { 273, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 2 },
                    { 274, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 6 },
                    { 275, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 276, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 1 },
                    { 277, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 6 },
                    { 278, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 5 },
                    { 279, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 2 },
                    { 280, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 6 },
                    { 281, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 282, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 283, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 3 },
                    { 284, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 5 },
                    { 285, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 286, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 4 },
                    { 287, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 288, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 1 },
                    { 289, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 6 },
                    { 290, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 291, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 3 },
                    { 292, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 4 },
                    { 293, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 2 },
                    { 294, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 5 },
                    { 295, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 2 },
                    { 296, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 3 },
                    { 297, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 298, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 6 },
                    { 299, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 3 },
                    { 300, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 4 },
                    { 301, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 6 },
                    { 302, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 6 },
                    { 303, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 3 },
                    { 304, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 305, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 5 },
                    { 306, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 3 },
                    { 307, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 3 },
                    { 308, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 309, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 310, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 311, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 312, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 313, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 3 },
                    { 314, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 315, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 5 },
                    { 316, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 2 },
                    { 317, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 2 },
                    { 318, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 319, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 320, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 4 },
                    { 321, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 2 },
                    { 322, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 323, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 3 },
                    { 324, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 6 },
                    { 325, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 2 },
                    { 326, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 327, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 5 },
                    { 328, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 329, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 4 },
                    { 330, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 1 },
                    { 331, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 6 },
                    { 332, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 4 },
                    { 333, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 2 },
                    { 334, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 1 },
                    { 335, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 4 },
                    { 336, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 2 },
                    { 337, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 1 },
                    { 338, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 6 },
                    { 339, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 3 },
                    { 340, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 4 },
                    { 341, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 2 },
                    { 342, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 2 },
                    { 343, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 4 },
                    { 344, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 5 },
                    { 345, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 5 },
                    { 346, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 5 },
                    { 347, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 348, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 1 },
                    { 349, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 2 },
                    { 350, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 2 },
                    { 351, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 3 },
                    { 352, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 353, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 354, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 2 },
                    { 355, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 4 },
                    { 356, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 6 },
                    { 357, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 6 },
                    { 358, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 359, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 360, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 361, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 362, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 3 },
                    { 363, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 4 },
                    { 364, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 3 },
                    { 365, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 },
                    { 366, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 6 },
                    { 367, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 5 },
                    { 368, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 5 },
                    { 369, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 5 },
                    { 370, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 5 },
                    { 371, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 4 },
                    { 372, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 373, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 1 },
                    { 374, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 4 },
                    { 375, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 5 },
                    { 376, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 4 },
                    { 377, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 378, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 6 },
                    { 379, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 5 },
                    { 380, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 3 },
                    { 381, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 382, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 6 },
                    { 383, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 },
                    { 384, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 5 },
                    { 385, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 5 },
                    { 386, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 3 },
                    { 387, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 4 },
                    { 388, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 2 },
                    { 389, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 4 },
                    { 390, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 4 },
                    { 391, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 6 },
                    { 392, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 5 },
                    { 393, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 6 },
                    { 394, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 1 },
                    { 395, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 2 },
                    { 396, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 397, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 3 },
                    { 398, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 4 },
                    { 399, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 6 },
                    { 400, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 1 },
                    { 401, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 3 },
                    { 402, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 3 },
                    { 403, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 3 },
                    { 404, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 4 },
                    { 405, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 3 },
                    { 406, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 5 },
                    { 407, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 408, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 1 },
                    { 409, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 2 },
                    { 410, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 411, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 412, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 5 },
                    { 413, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 5 },
                    { 414, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 3 },
                    { 415, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 3 },
                    { 416, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 2 },
                    { 417, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 5 },
                    { 418, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 3 },
                    { 419, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 420, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 421, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 2 },
                    { 422, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 5 },
                    { 423, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 3 },
                    { 424, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 5 },
                    { 425, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 3 },
                    { 426, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 6 },
                    { 427, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 428, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 429, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 3 },
                    { 430, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 431, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 2 },
                    { 432, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 433, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 1 },
                    { 434, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 435, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 6 },
                    { 436, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 437, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 438, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 6 },
                    { 439, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 4 },
                    { 440, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 4 },
                    { 441, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 5 },
                    { 442, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 3 },
                    { 443, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 4 },
                    { 444, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 1 },
                    { 445, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 3 },
                    { 446, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 447, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 448, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 6 },
                    { 449, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 6 },
                    { 450, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 451, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 4 },
                    { 452, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 5 },
                    { 453, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 2 },
                    { 454, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 4 },
                    { 455, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 5 },
                    { 456, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 1 },
                    { 457, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 458, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 4 },
                    { 459, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 2 },
                    { 460, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 1 },
                    { 461, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 1 },
                    { 462, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 5 },
                    { 463, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 464, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 1 },
                    { 465, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 2 },
                    { 466, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 5 },
                    { 467, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 5 },
                    { 468, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 4 },
                    { 469, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 2 },
                    { 470, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 6 },
                    { 471, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 472, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 5 },
                    { 473, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 2 },
                    { 474, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 475, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 1 },
                    { 476, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 5 },
                    { 477, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 478, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 5 },
                    { 479, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 5 },
                    { 480, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 1 },
                    { 481, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 482, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 5 },
                    { 483, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 2 },
                    { 484, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 485, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 486, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 3 },
                    { 487, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 488, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 4 },
                    { 489, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 6 },
                    { 490, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 491, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 4 },
                    { 492, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 493, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 5 },
                    { 494, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 3 },
                    { 495, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 6 },
                    { 496, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 6 },
                    { 497, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 6 },
                    { 498, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 1 },
                    { 499, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 2 },
                    { 500, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 1 },
                    { 501, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 3 },
                    { 502, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 5 },
                    { 503, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 504, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 505, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 506, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 507, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 3 },
                    { 508, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 3 },
                    { 509, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 5 },
                    { 510, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 3 },
                    { 511, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 512, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 6 },
                    { 513, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 514, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 1 },
                    { 515, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 3 },
                    { 516, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 517, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 4 },
                    { 518, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 3 },
                    { 519, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 5 },
                    { 520, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 521, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 6 },
                    { 522, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 6 },
                    { 523, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 524, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 6 },
                    { 525, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 526, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 3 },
                    { 527, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 6 },
                    { 528, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 5 },
                    { 529, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 3 },
                    { 530, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 531, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 5 },
                    { 532, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 1 },
                    { 533, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 2 },
                    { 534, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 535, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 3 },
                    { 536, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 537, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 1 },
                    { 538, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 539, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 540, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 2 },
                    { 541, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 3 },
                    { 542, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 6 },
                    { 543, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 2 },
                    { 544, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 5 },
                    { 545, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 6 },
                    { 546, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 547, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 3 },
                    { 548, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 549, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 550, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 1 },
                    { 551, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 2 },
                    { 552, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 4 },
                    { 553, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 1 },
                    { 554, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 1 },
                    { 555, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 5 },
                    { 556, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 557, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 2 },
                    { 558, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 559, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 2 },
                    { 560, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 6 },
                    { 561, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 562, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 1 },
                    { 563, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 1 },
                    { 564, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 4 },
                    { 565, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 5 },
                    { 566, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 4 },
                    { 567, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 6 },
                    { 568, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 5 },
                    { 569, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 570, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 571, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 5 },
                    { 572, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 573, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 3 },
                    { 574, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 5 },
                    { 575, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 3 },
                    { 576, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 1 },
                    { 577, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 5 },
                    { 578, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 3 },
                    { 579, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 580, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 3 },
                    { 581, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 2 },
                    { 582, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 583, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 6 },
                    { 584, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 6 },
                    { 585, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 4 },
                    { 586, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 1 },
                    { 587, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 5 },
                    { 588, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 589, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 6 },
                    { 590, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 2 },
                    { 591, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 3 },
                    { 592, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 4 },
                    { 593, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 4 },
                    { 594, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 5 },
                    { 595, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 4 },
                    { 596, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 597, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 598, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 5 },
                    { 599, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 1 },
                    { 600, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 4 },
                    { 601, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 2 },
                    { 602, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 2 },
                    { 603, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 5 },
                    { 604, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 605, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 1 },
                    { 606, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 3 },
                    { 607, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 5 },
                    { 608, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 5 },
                    { 609, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 610, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 2 },
                    { 611, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 612, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 2 },
                    { 613, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 3 },
                    { 614, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { 615, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 616, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 617, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 5 },
                    { 618, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 6 },
                    { 619, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 6 },
                    { 620, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 621, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 5 },
                    { 622, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 6 },
                    { 623, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 624, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 625, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 6 },
                    { 626, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 3 },
                    { 627, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 1 },
                    { 628, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 629, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 630, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 631, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 3 },
                    { 632, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 6 },
                    { 633, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 5 },
                    { 634, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 4 },
                    { 635, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 3 },
                    { 636, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 3 },
                    { 637, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 5 },
                    { 638, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 4 },
                    { 639, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 640, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 2 },
                    { 641, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 3 },
                    { 642, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 643, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 644, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 645, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 646, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 4 },
                    { 647, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 2 },
                    { 648, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 649, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 4 },
                    { 650, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 5 },
                    { 651, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 652, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 4 },
                    { 653, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 2 },
                    { 654, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 655, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 1 },
                    { 656, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 657, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 658, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 2 },
                    { 659, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 4 },
                    { 660, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 6 },
                    { 661, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 1 },
                    { 662, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 6 },
                    { 663, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 3 },
                    { 664, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 1 },
                    { 665, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 666, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 5 },
                    { 667, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 668, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 5 },
                    { 669, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 670, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 5 },
                    { 671, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 3 },
                    { 672, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 5 },
                    { 673, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 1 },
                    { 674, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 675, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 676, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 5 },
                    { 677, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 678, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 3 },
                    { 679, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 680, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 681, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 4 },
                    { 682, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 5 },
                    { 683, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 684, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 2 },
                    { 685, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 686, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 687, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 4 },
                    { 688, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 1 },
                    { 689, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 4 },
                    { 690, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 3 },
                    { 691, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 6 },
                    { 692, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 5 },
                    { 693, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 4 },
                    { 694, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 3 },
                    { 695, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 2 },
                    { 696, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 6 },
                    { 697, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 5 },
                    { 698, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 1 },
                    { 699, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 6 },
                    { 700, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 2 },
                    { 701, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 702, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 3 },
                    { 703, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 5 },
                    { 704, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 4 },
                    { 705, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 3 },
                    { 706, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 2 },
                    { 707, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 2 },
                    { 708, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 1 },
                    { 709, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 3 },
                    { 710, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 711, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 2 },
                    { 712, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 5 },
                    { 713, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 6 },
                    { 714, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 2, 3 },
                    { 4, 1, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "IssuedTickets",
                columns: new[] { "IssuedTicketId", "Amount", "IssuedDate", "RouteId", "TicketId", "UserId", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 463, 1, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 268, 5, 5, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 5, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 5, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 148, 1, 1, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 470, 2, 3, new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 9, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 404, 2, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 6, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 665, 2, 5, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 318, 2, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 344, 4, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 548, 2, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 3, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 328, 3, 5, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 621, 4, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 1, 5, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 8, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 613, 4, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 2, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 269, 3, 3, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 526, 3, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 5, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 3, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 368, 1, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 5, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 396, 4, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 315, 4, 4, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 3, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, 3, 3, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 470, 2, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 227, 3, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 9, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 5, 4, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 6, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 2, 5, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 587, 1, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 7, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 217, 1, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 159, 2, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 8, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 6, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 3, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 467, 3, 4, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 6, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 139, 1, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 4, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 249, 2, 5, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 18, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 1, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 218, 3, 6, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 2, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 592, 1, 2, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 555, 1, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 1, new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 5, 3, new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 5, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 694, 5, 1, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 9, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 680, 1, 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 3, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 481, 5, 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 6, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 3, 1, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 9, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 2, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 3, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 218, 4, 1, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 526, 5, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 3, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 2, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 545, 3, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 7, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 286, 5, 5, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 4, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 227, 4, 1, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 163, 5, 1, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 9, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 464, 5, 3, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 8, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 6, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 333, 3, 6, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 3, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 709, 2, 6, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 368, 2, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 3, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 390, 1, 1, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 8, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 569, 2, 2, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 7, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 287, 4, 3, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 5, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 686, 4, 1, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 18, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 2, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 238, 1, 1, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 23, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 1, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 3, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 625, 1, 1, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 9, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 5, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 7, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 5, 6, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 400, 1, 1, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 8, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 708, 3, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 1, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 413, 4, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 2, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 666, 1, 5, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 9, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 1, 3, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 2, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 135, 2, 1, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 31, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 588, 2, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 8, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 4, 4, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 1, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 2, 6, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 1, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 346, 4, 6, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 4, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, 3, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 2, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 294, 2, 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 4, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 515, 4, 3, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 5, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 483, 3, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 7, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 384, 1, 4, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 452, 5, 5, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 3, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 323, 2, 1, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 421, 5, 6, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, 5, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 5, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 658, 1, 1, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 3, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 670, 3, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 3, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 274, 3, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 390, 1, 6, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 8, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 2, 3, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 196, 3, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 305, 1, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 4, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 324, 5, 3, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 5, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 687, 5, 6, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 7, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 372, 4, 5, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 7, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 360, 5, 3, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 7, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 5, 6, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 2, new DateTime(2024, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 1, 1, new DateTime(2024, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 6, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 4, 4, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) }
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
