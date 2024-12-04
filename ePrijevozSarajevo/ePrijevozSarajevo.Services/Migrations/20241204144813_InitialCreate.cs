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
                    { 1, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9625), "Di0Pl497qDmbASiXANIu17gh2mM=", "5jHdF+EU9mdJTovbt+vwEw==", "061222333", null, new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9622), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Senada", "Šahinpašić", new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9637), "CsBt0QRUQ+nzMTYE89Qt7XI4Y5c=", "Cstpm2O9WpGyN70WN3igPg==", "061222444", null, new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9636), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 4, "72000" },
                    { 3, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "neki@mail.com", "Test", "Testni", new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9643), "u5WW1N9Frl8w9Ujm6hpAIeVDg5I=", "KF1Ugj1oouz+FXLxI5xVNw==", "061222555", null, new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9641), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "neko@mail.com", "Testni", "Test", new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9648), "EeJhu/w7WFJEbN7DGpcfpI7zWf0=", "VGU8NcAog0T2IMxwwV6byg==", "061222666", null, new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9647), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "proba@mail.com", "Proba", "Probni", new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9661), "BCgDq9lyuzYavd8q2ZBsH3DlD1E=", "hJZcc93QpNLSb0zl39E0Ig==", "061222777", null, new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9659), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9668), "lHRnuQzfTll3sBOQCzTwLe6MfYE=", "SmnCNaoRlGAiMwec31d9bA==", "061222888", null, new DateTime(2024, 12, 4, 15, 48, 12, 902, DateTimeKind.Local).AddTicks(9667), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
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
                    { 1, true, false, new DateTime(2024, 12, 4, 15, 48, 12, 903, DateTimeKind.Local).AddTicks(55), "", 2, 3 },
                    { 2, true, false, new DateTime(2024, 12, 4, 15, 48, 12, 903, DateTimeKind.Local).AddTicks(58), "", 3, 5 },
                    { 3, true, false, new DateTime(2024, 12, 4, 15, 48, 12, 903, DateTimeKind.Local).AddTicks(61), "", 4, 2 },
                    { 4, true, false, new DateTime(2024, 12, 4, 15, 48, 12, 903, DateTimeKind.Local).AddTicks(63), "", 5, 4 },
                    { 5, true, false, new DateTime(2024, 12, 4, 15, 48, 12, 903, DateTimeKind.Local).AddTicks(65), "", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 15, 20, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 19, 37, 0, 0, DateTimeKind.Unspecified), 9, 10, 6 },
                    { 2, new DateTime(2024, 12, 17, 16, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 15, 41, 0, 0, DateTimeKind.Unspecified), 8, 15, 5 },
                    { 3, new DateTime(2024, 11, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 15, 32, 0, 0, DateTimeKind.Unspecified), 3, 12, 6 },
                    { 4, new DateTime(2024, 12, 9, 17, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), 9, 6, 1 },
                    { 5, new DateTime(2024, 11, 18, 22, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 21, 18, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 6, new DateTime(2024, 12, 21, 20, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 19, 51, 0, 0, DateTimeKind.Unspecified), 12, 7, 2 },
                    { 7, new DateTime(2024, 12, 7, 7, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 7, 6, 51, 0, 0, DateTimeKind.Unspecified), 5, 8, 1 },
                    { 8, new DateTime(2024, 12, 27, 7, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 7, 34, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 9, new DateTime(2024, 11, 16, 8, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 16, 7, 30, 0, 0, DateTimeKind.Unspecified), 2, 15, 2 },
                    { 10, new DateTime(2024, 11, 20, 11, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 11, 28, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 11, new DateTime(2024, 12, 4, 6, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 6, 21, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 12, new DateTime(2024, 12, 4, 14, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 13, 50, 0, 0, DateTimeKind.Unspecified), 13, 11, 3 },
                    { 13, new DateTime(2024, 11, 6, 21, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 21, 5, 0, 0, DateTimeKind.Unspecified), 9, 3, 5 },
                    { 14, new DateTime(2024, 11, 6, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 12, 55, 0, 0, DateTimeKind.Unspecified), 10, 1, 4 },
                    { 15, new DateTime(2024, 11, 24, 11, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 24, 11, 3, 0, 0, DateTimeKind.Unspecified), 9, 2, 5 },
                    { 16, new DateTime(2024, 12, 22, 12, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 12, 49, 0, 0, DateTimeKind.Unspecified), 14, 4, 2 },
                    { 17, new DateTime(2024, 12, 1, 23, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 23, 3, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 18, new DateTime(2024, 12, 17, 16, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 15, 35, 0, 0, DateTimeKind.Unspecified), 3, 2, 6 },
                    { 19, new DateTime(2024, 11, 25, 6, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 5, 24, 0, 0, DateTimeKind.Unspecified), 9, 13, 4 },
                    { 20, new DateTime(2024, 12, 22, 8, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 7, 24, 0, 0, DateTimeKind.Unspecified), 14, 12, 6 },
                    { 21, new DateTime(2024, 11, 29, 13, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 12, 11, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 22, new DateTime(2024, 12, 22, 16, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 15, 50, 0, 0, DateTimeKind.Unspecified), 10, 3, 6 },
                    { 23, new DateTime(2024, 12, 4, 23, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 22, 33, 0, 0, DateTimeKind.Unspecified), 14, 3, 1 },
                    { 24, new DateTime(2024, 12, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 3, 18, 19, 0, 0, DateTimeKind.Unspecified), 4, 1, 6 },
                    { 25, new DateTime(2024, 12, 21, 20, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 20, 2, 0, 0, DateTimeKind.Unspecified), 8, 6, 3 },
                    { 26, new DateTime(2024, 12, 30, 6, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 5, 43, 0, 0, DateTimeKind.Unspecified), 3, 11, 3 },
                    { 27, new DateTime(2024, 12, 14, 0, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 23, 34, 0, 0, DateTimeKind.Unspecified), 8, 14, 2 },
                    { 28, new DateTime(2024, 12, 29, 13, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 13, 38, 0, 0, DateTimeKind.Unspecified), 15, 7, 5 },
                    { 29, new DateTime(2024, 11, 17, 0, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 16, 23, 59, 0, 0, DateTimeKind.Unspecified), 15, 8, 5 },
                    { 30, new DateTime(2024, 11, 5, 13, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 13, 21, 0, 0, DateTimeKind.Unspecified), 2, 3, 5 },
                    { 31, new DateTime(2024, 12, 7, 0, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 23, 14, 0, 0, DateTimeKind.Unspecified), 6, 13, 2 },
                    { 32, new DateTime(2024, 11, 14, 22, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 22, 14, 0, 0, DateTimeKind.Unspecified), 8, 6, 1 },
                    { 33, new DateTime(2024, 12, 22, 11, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 10, 59, 0, 0, DateTimeKind.Unspecified), 10, 5, 1 },
                    { 34, new DateTime(2024, 12, 26, 20, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 19, 25, 0, 0, DateTimeKind.Unspecified), 10, 7, 6 },
                    { 35, new DateTime(2024, 11, 18, 12, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 11, 20, 0, 0, DateTimeKind.Unspecified), 11, 14, 1 },
                    { 36, new DateTime(2024, 12, 17, 21, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 20, 52, 0, 0, DateTimeKind.Unspecified), 1, 14, 5 },
                    { 37, new DateTime(2024, 11, 6, 23, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 23, 23, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 38, new DateTime(2024, 12, 19, 21, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 21, 9, 0, 0, DateTimeKind.Unspecified), 5, 1, 3 },
                    { 39, new DateTime(2024, 12, 23, 18, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 18, 19, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 40, new DateTime(2024, 11, 24, 6, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 24, 5, 55, 0, 0, DateTimeKind.Unspecified), 10, 8, 3 },
                    { 41, new DateTime(2024, 11, 6, 22, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 21, 36, 0, 0, DateTimeKind.Unspecified), 5, 4, 6 },
                    { 42, new DateTime(2024, 12, 19, 13, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 13, 5, 0, 0, DateTimeKind.Unspecified), 15, 1, 5 },
                    { 43, new DateTime(2024, 11, 4, 20, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 19, 46, 0, 0, DateTimeKind.Unspecified), 13, 8, 5 },
                    { 44, new DateTime(2024, 12, 19, 12, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 11, 16, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 45, new DateTime(2024, 12, 14, 18, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 18, 42, 0, 0, DateTimeKind.Unspecified), 15, 2, 2 },
                    { 46, new DateTime(2024, 11, 7, 12, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 12, 5, 0, 0, DateTimeKind.Unspecified), 8, 11, 2 },
                    { 47, new DateTime(2024, 11, 22, 21, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 21, 26, 0, 0, DateTimeKind.Unspecified), 13, 3, 1 },
                    { 48, new DateTime(2024, 11, 15, 6, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 6, 10, 0, 0, DateTimeKind.Unspecified), 4, 1, 3 },
                    { 49, new DateTime(2024, 11, 13, 23, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 22, 11, 0, 0, DateTimeKind.Unspecified), 13, 8, 3 },
                    { 50, new DateTime(2024, 12, 29, 13, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 13, 14, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 51, new DateTime(2024, 11, 10, 10, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 9, 43, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 52, new DateTime(2024, 12, 10, 8, 37, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 10, 8, 15, 0, 0, DateTimeKind.Unspecified), 9, 7, 1 },
                    { 53, new DateTime(2024, 11, 26, 13, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 12, 49, 0, 0, DateTimeKind.Unspecified), 9, 1, 3 },
                    { 54, new DateTime(2024, 11, 17, 19, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), 14, 2, 2 },
                    { 55, new DateTime(2024, 11, 3, 16, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 3, 16, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 56, new DateTime(2024, 12, 3, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 3, 12, 17, 0, 0, DateTimeKind.Unspecified), 1, 15, 5 },
                    { 57, new DateTime(2024, 11, 11, 9, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 8, 56, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 58, new DateTime(2024, 11, 29, 17, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 16, 54, 0, 0, DateTimeKind.Unspecified), 3, 15, 4 },
                    { 59, new DateTime(2024, 11, 24, 12, 7, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 24, 11, 53, 0, 0, DateTimeKind.Unspecified), 15, 3, 3 },
                    { 60, new DateTime(2024, 12, 6, 7, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 7, 23, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 61, new DateTime(2024, 12, 29, 10, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 10, 10, 0, 0, DateTimeKind.Unspecified), 6, 11, 1 },
                    { 62, new DateTime(2024, 12, 26, 12, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 12, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 5 },
                    { 63, new DateTime(2024, 11, 18, 17, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 17, 8, 0, 0, DateTimeKind.Unspecified), 6, 15, 1 },
                    { 64, new DateTime(2024, 11, 17, 16, 37, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 15, 39, 0, 0, DateTimeKind.Unspecified), 12, 5, 2 },
                    { 65, new DateTime(2024, 11, 25, 23, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 23, 23, 0, 0, DateTimeKind.Unspecified), 15, 1, 2 },
                    { 66, new DateTime(2024, 12, 14, 8, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 7, 29, 0, 0, DateTimeKind.Unspecified), 7, 5, 3 },
                    { 67, new DateTime(2024, 11, 22, 8, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 8, 44, 0, 0, DateTimeKind.Unspecified), 10, 7, 1 },
                    { 68, new DateTime(2024, 11, 19, 13, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 19, 13, 16, 0, 0, DateTimeKind.Unspecified), 6, 9, 6 },
                    { 69, new DateTime(2024, 11, 29, 19, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 19, 4, 0, 0, DateTimeKind.Unspecified), 6, 10, 4 },
                    { 70, new DateTime(2024, 12, 6, 21, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 21, 13, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 71, new DateTime(2024, 12, 29, 6, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 29, 5, 46, 0, 0, DateTimeKind.Unspecified), 4, 1, 6 },
                    { 72, new DateTime(2024, 12, 1, 10, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 7, 6 },
                    { 73, new DateTime(2024, 11, 12, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 15, 1, 0, 0, DateTimeKind.Unspecified), 14, 5, 5 },
                    { 74, new DateTime(2024, 12, 21, 22, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 21, 52, 0, 0, DateTimeKind.Unspecified), 14, 3, 2 },
                    { 75, new DateTime(2024, 12, 1, 13, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 13, 22, 0, 0, DateTimeKind.Unspecified), 14, 10, 6 },
                    { 76, new DateTime(2024, 12, 30, 11, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 11, 3, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 77, new DateTime(2024, 12, 14, 7, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 6, 59, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 78, new DateTime(2024, 12, 2, 21, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 2, 21, 2, 0, 0, DateTimeKind.Unspecified), 2, 12, 1 },
                    { 79, new DateTime(2024, 11, 26, 19, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 19, 27, 0, 0, DateTimeKind.Unspecified), 1, 3, 3 },
                    { 80, new DateTime(2024, 11, 7, 16, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 16, 4, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 81, new DateTime(2024, 12, 14, 14, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 13, 59, 0, 0, DateTimeKind.Unspecified), 8, 2, 6 },
                    { 82, new DateTime(2024, 12, 30, 9, 7, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 8, 30, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 83, new DateTime(2024, 12, 25, 0, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 23, 41, 0, 0, DateTimeKind.Unspecified), 12, 8, 3 },
                    { 84, new DateTime(2024, 12, 5, 15, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 15, 39, 0, 0, DateTimeKind.Unspecified), 4, 3, 6 },
                    { 85, new DateTime(2024, 11, 4, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 19, 46, 0, 0, DateTimeKind.Unspecified), 15, 5, 1 },
                    { 86, new DateTime(2024, 12, 30, 12, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 11, 42, 0, 0, DateTimeKind.Unspecified), 14, 11, 6 },
                    { 87, new DateTime(2024, 11, 14, 22, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 21, 52, 0, 0, DateTimeKind.Unspecified), 3, 14, 6 },
                    { 88, new DateTime(2024, 11, 8, 22, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 22, 27, 0, 0, DateTimeKind.Unspecified), 3, 5, 4 },
                    { 89, new DateTime(2024, 12, 15, 8, 52, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 8, 6, 0, 0, DateTimeKind.Unspecified), 11, 9, 6 },
                    { 90, new DateTime(2024, 12, 21, 6, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 6, 6, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 91, new DateTime(2024, 11, 2, 19, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 2, 19, 25, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 92, new DateTime(2024, 12, 24, 9, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 8, 32, 0, 0, DateTimeKind.Unspecified), 9, 10, 4 },
                    { 93, new DateTime(2024, 11, 8, 10, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 9, 47, 0, 0, DateTimeKind.Unspecified), 5, 9, 6 },
                    { 94, new DateTime(2024, 12, 7, 20, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 7, 19, 54, 0, 0, DateTimeKind.Unspecified), 15, 7, 4 },
                    { 95, new DateTime(2024, 12, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 9, 17, 23, 0, 0, DateTimeKind.Unspecified), 13, 7, 3 },
                    { 96, new DateTime(2024, 12, 19, 12, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 11, 12, 0, 0, DateTimeKind.Unspecified), 14, 3, 3 },
                    { 97, new DateTime(2024, 11, 28, 10, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 9, 45, 0, 0, DateTimeKind.Unspecified), 11, 10, 5 },
                    { 98, new DateTime(2024, 12, 4, 12, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 12, 32, 0, 0, DateTimeKind.Unspecified), 15, 14, 4 },
                    { 99, new DateTime(2024, 12, 25, 14, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 13, 12, 0, 0, DateTimeKind.Unspecified), 14, 15, 5 },
                    { 100, new DateTime(2024, 12, 9, 17, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 9, 16, 48, 0, 0, DateTimeKind.Unspecified), 8, 3, 2 }
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
                    { 6, 1, 6 }
                });

            migrationBuilder.InsertData(
                table: "IssuedTickets",
                columns: new[] { "IssuedTicketId", "Amount", "IssuedDate", "RouteId", "TicketId", "UserId", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 15, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, 1, 5, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2, 4, new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1, 3, new DateTime(2024, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 19, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 3, 4, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 16, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 5, 2, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 7, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 5, 6, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 14, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 3, 4, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 3, 3, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 30, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 18, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 16, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 1, 1, new DateTime(2023, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 2, 2, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 11, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 3, 5, new DateTime(2023, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 9, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 4, 3, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 16, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 2, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 18, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 2, 1, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 6, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 2, 2, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 11, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 2, 2, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 7, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 3, 4, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 8, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 2, 4, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 8, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 3, 2, new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 1, 3, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 31, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 9, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 1, 2, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 22, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 16, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 2, 2, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 19, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 4, 2, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 4, new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 3, 2, new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 17, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 4, 2, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 14, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 4, 6, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 26, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 7, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 2, 4, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 7, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 3, 3, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 16, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 2, 2, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 11, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 5, 5, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 13, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 2, 2, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 18, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 2, 2, new DateTime(2023, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 9, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 4, 3, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 11, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 1, 6, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 30, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 2, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, 4, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 13, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 4, 2, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 13, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 2, 3, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 10, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 2, 5, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 17, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 3, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 1, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 2, 1, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 28, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 17, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3, 5, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 27, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 17, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 4, 2, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 17, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 1, 5, new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 4, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 4, 2, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 9, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 5, 2, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 9, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 4, 5, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 14, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 4, 1, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 7, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 1, 3, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 5, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 4, 2, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 10, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 5, 3, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 19, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 3, 5, new DateTime(2023, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 7, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 5, 3, new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 10, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 4, 2, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 15, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 4, 4, new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 19, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 1, 6, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 10, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 5, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 5, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 5, 5, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 1, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, 5, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 3, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2, 5, new DateTime(2023, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 10, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 5, 5, new DateTime(2023, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 6, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 3, 1, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 13, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 1, 4, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 2, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 1, new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 6, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 4, 5, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 8, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, 4, 1, new DateTime(2023, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 21, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 15, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 5, 4, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 18, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 1, 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 3, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 4, 6, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 10, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 4, 5, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 5, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 3, new DateTime(2023, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 16, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 2, 1, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 17, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 3, 1, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 7, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 4, 5, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 5, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 3, 2, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 11, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 4, 4, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 21, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 17, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, 3, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 8, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 2, 6, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 15, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 3, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 31, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 8, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 3, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 2, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4, 3, new DateTime(2024, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 28, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 6, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 3, 3, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 8, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 4, 1, new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 16, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 1, 5, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 1, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 1, 1, new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 19, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 4, 6, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 6, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 2, 1, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 19, new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4, 4, new DateTime(2023, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 5, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3, 6, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 19, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 4, 1, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 4, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 3, 4, new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 18, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 18, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 4, 1, new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 1, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 5, 5, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 7, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 4, 3, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 11, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 3, 4, new DateTime(2024, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 8, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 1, 6, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 9, new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, 6, new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 15, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 5, 5, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 18, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 2, 4, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 2, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 3, 2, new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 1, 0, 0, 0, DateTimeKind.Unspecified) }
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
