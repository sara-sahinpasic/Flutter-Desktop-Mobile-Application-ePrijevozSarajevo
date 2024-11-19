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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        name: "FK_Users_Statuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Vehicles_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.NoAction);
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
                columns: new[] { "UserId", "Active", "Address", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImage", "RegistrationDate", "StatusExpirationDate", "UserName", "UserStatusId" },
                values: new object[,]
                {
                    { 1, true, "Adresa 11", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2864), "Dj6A2Fg5Kk3Uft0F3VDxoZSFzEc=", "yd8SIQHhrsUy1RzIayZHqw==", "061222333", null, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2863), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "desktop", 4 },
                    { 2, true, "Adresa 12", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Senada", "Šahinpašić", new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2876), "YIaP+BUd1jFh7O6aQLsKYlvLyBw=", "rCiLMazTi/+xT/ux68mMHw==", "061222444", null, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2875), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile", 4 },
                    { 3, true, "Adresa 14", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "neki@mail.com", "Test", "Testni", new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2881), "K1IsOw8ETza9P2PS2uzdGVcnMKM=", "J9jaI0iXqVKQVq4sECyouw==", "061222555", null, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2880), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile1", 1 },
                    { 4, true, "Adresa 15", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "neko@mail.com", "Testni", "Test", new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2885), "m5ztuefcEspaAWUSui35KHnWQ60=", "q5PFRSNVm6L62vFen7cRPw==", "061222666", null, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2885), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile2", 1 },
                    { 5, true, "Adresa 16", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "proba@mail.com", "Proba", "Probni", new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2890), "2SmmCKTzF2mvJ+qSPQAnHR8+r+w=", "HsKCamLx1DjihXe8QLgTSQ==", "061222777", null, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2889), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile3", 1 },
                    { 6, true, "Adresa 17", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2894), "RoxSdJc7gIktzsBkG3qwpwKb224=", "cOU9Z1wzJEmBm0VsL5tXuQ==", "061222888", null, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(2894), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile4", 1 }
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
                    { 1, true, false, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(3204), "", 2, 3 },
                    { 2, true, false, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(3207), "", 3, 1 },
                    { 3, true, false, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(3209), "", 4, 2 },
                    { 4, true, false, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(3211), "", 5, 4 },
                    { 5, true, false, new DateTime(2024, 11, 19, 18, 40, 11, 65, DateTimeKind.Local).AddTicks(3213), "", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 7, 6, 40, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 7, 6, 29, 0, 0, DateTimeKind.Unspecified), 13, 4, 4 },
                    { 2, new DateTime(2024, 5, 26, 23, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 26, 23, 12, 0, 0, DateTimeKind.Unspecified), 4, 2, 1 },
                    { 3, new DateTime(2024, 5, 19, 6, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 19, 5, 46, 0, 0, DateTimeKind.Unspecified), 7, 3, 4 },
                    { 4, new DateTime(2024, 8, 14, 10, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 14, 9, 32, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 5, new DateTime(2024, 12, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 16, 59, 0, 0, DateTimeKind.Unspecified), 3, 1, 3 },
                    { 6, new DateTime(2024, 3, 3, 20, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 3, 19, 29, 0, 0, DateTimeKind.Unspecified), 3, 9, 3 },
                    { 7, new DateTime(2024, 1, 25, 9, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 25, 9, 21, 0, 0, DateTimeKind.Unspecified), 13, 8, 3 },
                    { 8, new DateTime(2024, 2, 24, 20, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 24, 20, 0, 0, 0, DateTimeKind.Unspecified), 13, 5, 6 },
                    { 9, new DateTime(2024, 1, 9, 23, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 9, 23, 7, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 10, new DateTime(2024, 7, 3, 16, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 3, 16, 5, 0, 0, DateTimeKind.Unspecified), 14, 10, 5 },
                    { 11, new DateTime(2024, 12, 25, 10, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 9, 33, 0, 0, DateTimeKind.Unspecified), 6, 10, 1 },
                    { 12, new DateTime(2024, 3, 14, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 14, 6, 2, 0, 0, DateTimeKind.Unspecified), 4, 9, 6 },
                    { 13, new DateTime(2024, 3, 26, 11, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 11, 3, 0, 0, DateTimeKind.Unspecified), 7, 15, 2 },
                    { 14, new DateTime(2024, 6, 14, 7, 14, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 14, 6, 56, 0, 0, DateTimeKind.Unspecified), 8, 2, 3 },
                    { 15, new DateTime(2024, 11, 30, 18, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 17, 30, 0, 0, DateTimeKind.Unspecified), 14, 5, 3 },
                    { 16, new DateTime(2024, 6, 14, 13, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 14, 12, 46, 0, 0, DateTimeKind.Unspecified), 8, 12, 4 },
                    { 17, new DateTime(2024, 10, 14, 18, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 14, 17, 55, 0, 0, DateTimeKind.Unspecified), 8, 2, 3 },
                    { 18, new DateTime(2024, 4, 6, 7, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 6, 6, 57, 0, 0, DateTimeKind.Unspecified), 15, 2, 4 },
                    { 19, new DateTime(2024, 6, 11, 14, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 11, 14, 10, 0, 0, DateTimeKind.Unspecified), 3, 7, 5 },
                    { 20, new DateTime(2024, 11, 27, 12, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 12, 7, 0, 0, DateTimeKind.Unspecified), 14, 12, 3 },
                    { 21, new DateTime(2024, 7, 14, 7, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 14, 6, 30, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 22, new DateTime(2024, 6, 29, 10, 12, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 29, 9, 19, 0, 0, DateTimeKind.Unspecified), 11, 2, 6 },
                    { 23, new DateTime(2024, 6, 26, 10, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 26, 9, 8, 0, 0, DateTimeKind.Unspecified), 5, 15, 5 },
                    { 24, new DateTime(2024, 9, 24, 12, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 11, 52, 0, 0, DateTimeKind.Unspecified), 7, 2, 5 },
                    { 25, new DateTime(2024, 3, 22, 18, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 17, 50, 0, 0, DateTimeKind.Unspecified), 2, 7, 5 },
                    { 26, new DateTime(2024, 11, 17, 7, 37, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 6, 48, 0, 0, DateTimeKind.Unspecified), 13, 11, 1 },
                    { 27, new DateTime(2024, 11, 16, 22, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 16, 22, 39, 0, 0, DateTimeKind.Unspecified), 12, 6, 1 },
                    { 28, new DateTime(2024, 5, 8, 5, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 8, 5, 9, 0, 0, DateTimeKind.Unspecified), 5, 10, 6 },
                    { 29, new DateTime(2024, 9, 8, 20, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 8, 19, 57, 0, 0, DateTimeKind.Unspecified), 15, 7, 5 },
                    { 30, new DateTime(2024, 5, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 12, 10, 26, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 31, new DateTime(2024, 3, 20, 17, 14, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 20, 16, 18, 0, 0, DateTimeKind.Unspecified), 1, 3, 1 },
                    { 32, new DateTime(2024, 3, 22, 23, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 22, 27, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 33, new DateTime(2024, 12, 13, 10, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 9, 30, 0, 0, DateTimeKind.Unspecified), 10, 3, 2 },
                    { 34, new DateTime(2024, 8, 15, 18, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 17, 44, 0, 0, DateTimeKind.Unspecified), 7, 3, 5 },
                    { 35, new DateTime(2024, 7, 19, 14, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 19, 13, 36, 0, 0, DateTimeKind.Unspecified), 14, 9, 6 },
                    { 36, new DateTime(2024, 5, 14, 18, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 17, 43, 0, 0, DateTimeKind.Unspecified), 13, 3, 4 },
                    { 37, new DateTime(2024, 6, 1, 22, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 21, 48, 0, 0, DateTimeKind.Unspecified), 3, 1, 3 },
                    { 38, new DateTime(2024, 11, 7, 14, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 13, 26, 0, 0, DateTimeKind.Unspecified), 13, 10, 3 },
                    { 39, new DateTime(2024, 5, 16, 20, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 16, 20, 30, 0, 0, DateTimeKind.Unspecified), 7, 3, 1 },
                    { 40, new DateTime(2024, 4, 28, 18, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 28, 17, 52, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 41, new DateTime(2024, 9, 5, 0, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 23, 27, 0, 0, DateTimeKind.Unspecified), 12, 7, 4 },
                    { 42, new DateTime(2024, 8, 3, 18, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 3, 17, 30, 0, 0, DateTimeKind.Unspecified), 4, 11, 6 },
                    { 43, new DateTime(2024, 7, 18, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 18, 11, 1, 0, 0, DateTimeKind.Unspecified), 8, 5, 1 },
                    { 44, new DateTime(2024, 12, 2, 11, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 2, 10, 45, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 45, new DateTime(2024, 11, 12, 22, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 22, 3, 0, 0, DateTimeKind.Unspecified), 3, 9, 3 },
                    { 46, new DateTime(2024, 12, 26, 9, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 9, 31, 0, 0, DateTimeKind.Unspecified), 11, 3, 3 },
                    { 47, new DateTime(2024, 3, 16, 14, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 16, 13, 43, 0, 0, DateTimeKind.Unspecified), 12, 14, 2 },
                    { 48, new DateTime(2024, 1, 10, 6, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 10, 5, 34, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 49, new DateTime(2024, 5, 4, 15, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 4, 14, 17, 0, 0, DateTimeKind.Unspecified), 7, 13, 3 },
                    { 50, new DateTime(2024, 3, 13, 17, 12, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 13, 16, 16, 0, 0, DateTimeKind.Unspecified), 1, 14, 6 },
                    { 51, new DateTime(2024, 4, 15, 22, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 22, 4, 0, 0, DateTimeKind.Unspecified), 2, 11, 1 },
                    { 52, new DateTime(2024, 12, 3, 7, 34, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 3, 7, 19, 0, 0, DateTimeKind.Unspecified), 3, 12, 1 },
                    { 53, new DateTime(2024, 3, 9, 22, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 9, 21, 31, 0, 0, DateTimeKind.Unspecified), 11, 1, 5 },
                    { 54, new DateTime(2024, 10, 5, 13, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), 6, 14, 4 },
                    { 55, new DateTime(2024, 9, 18, 10, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 18, 10, 34, 0, 0, DateTimeKind.Unspecified), 6, 8, 2 },
                    { 56, new DateTime(2024, 1, 19, 11, 12, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 19, 11, 1, 0, 0, DateTimeKind.Unspecified), 2, 7, 5 },
                    { 57, new DateTime(2024, 5, 18, 23, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 18, 22, 46, 0, 0, DateTimeKind.Unspecified), 6, 3, 1 },
                    { 58, new DateTime(2024, 9, 21, 19, 7, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 21, 18, 33, 0, 0, DateTimeKind.Unspecified), 15, 8, 3 },
                    { 59, new DateTime(2024, 4, 8, 18, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 8, 17, 27, 0, 0, DateTimeKind.Unspecified), 10, 12, 5 },
                    { 60, new DateTime(2024, 3, 22, 15, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 22, 14, 40, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 61, new DateTime(2024, 4, 1, 16, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 1, 16, 39, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 62, new DateTime(2024, 9, 3, 18, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 3, 17, 40, 0, 0, DateTimeKind.Unspecified), 15, 7, 4 },
                    { 63, new DateTime(2024, 3, 30, 14, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 30, 14, 3, 0, 0, DateTimeKind.Unspecified), 2, 12, 1 },
                    { 64, new DateTime(2024, 5, 5, 20, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 19, 47, 0, 0, DateTimeKind.Unspecified), 15, 14, 1 },
                    { 65, new DateTime(2024, 11, 17, 20, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 20, 20, 0, 0, DateTimeKind.Unspecified), 11, 2, 3 },
                    { 66, new DateTime(2024, 8, 14, 0, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 23, 46, 0, 0, DateTimeKind.Unspecified), 8, 4, 5 },
                    { 67, new DateTime(2024, 5, 27, 14, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 27, 13, 57, 0, 0, DateTimeKind.Unspecified), 10, 5, 6 },
                    { 68, new DateTime(2024, 3, 5, 5, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 5, 20, 0, 0, DateTimeKind.Unspecified), 13, 1, 1 },
                    { 69, new DateTime(2024, 5, 20, 6, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 6, 13, 0, 0, DateTimeKind.Unspecified), 11, 4, 2 },
                    { 70, new DateTime(2024, 3, 2, 14, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 2, 13, 30, 0, 0, DateTimeKind.Unspecified), 12, 4, 4 },
                    { 71, new DateTime(2024, 7, 27, 17, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 27, 16, 22, 0, 0, DateTimeKind.Unspecified), 8, 3, 6 },
                    { 72, new DateTime(2024, 4, 26, 15, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 15, 8, 0, 0, DateTimeKind.Unspecified), 13, 6, 2 },
                    { 73, new DateTime(2024, 1, 7, 23, 9, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 7, 22, 17, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 74, new DateTime(2024, 9, 23, 5, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 5, 7, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 75, new DateTime(2024, 7, 9, 6, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 9, 5, 51, 0, 0, DateTimeKind.Unspecified), 13, 8, 2 },
                    { 76, new DateTime(2024, 8, 3, 18, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 3, 18, 2, 0, 0, DateTimeKind.Unspecified), 5, 6, 5 },
                    { 77, new DateTime(2024, 2, 23, 7, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 23, 6, 3, 0, 0, DateTimeKind.Unspecified), 8, 13, 3 },
                    { 78, new DateTime(2024, 3, 8, 21, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 8, 21, 23, 0, 0, DateTimeKind.Unspecified), 12, 4, 5 },
                    { 79, new DateTime(2024, 5, 22, 15, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 22, 14, 28, 0, 0, DateTimeKind.Unspecified), 8, 3, 5 },
                    { 80, new DateTime(2024, 11, 8, 17, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 17, 38, 0, 0, DateTimeKind.Unspecified), 7, 3, 5 },
                    { 81, new DateTime(2024, 3, 12, 7, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 12, 7, 19, 0, 0, DateTimeKind.Unspecified), 9, 2, 5 },
                    { 82, new DateTime(2024, 3, 7, 8, 34, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 7, 8, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 6 },
                    { 83, new DateTime(2024, 1, 24, 0, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 23, 23, 53, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 84, new DateTime(2024, 4, 26, 7, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 7, 26, 0, 0, DateTimeKind.Unspecified), 14, 2, 3 },
                    { 85, new DateTime(2024, 3, 5, 11, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 10, 50, 0, 0, DateTimeKind.Unspecified), 4, 1, 2 },
                    { 86, new DateTime(2024, 5, 8, 9, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 11, 3 },
                    { 87, new DateTime(2024, 2, 6, 11, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 6, 10, 17, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 88, new DateTime(2024, 2, 13, 13, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 13, 13, 14, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 89, new DateTime(2024, 6, 21, 21, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), 10, 11, 4 },
                    { 90, new DateTime(2024, 3, 5, 7, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 5, 6, 40, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 91, new DateTime(2024, 4, 16, 21, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 20, 18, 0, 0, DateTimeKind.Unspecified), 11, 12, 1 },
                    { 92, new DateTime(2024, 5, 30, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 9, 38, 0, 0, DateTimeKind.Unspecified), 3, 9, 6 },
                    { 93, new DateTime(2024, 8, 23, 22, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 22, 31, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 },
                    { 94, new DateTime(2024, 7, 31, 20, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 31, 19, 39, 0, 0, DateTimeKind.Unspecified), 13, 1, 4 },
                    { 95, new DateTime(2024, 9, 25, 9, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 8, 9, 0, 0, DateTimeKind.Unspecified), 14, 5, 4 },
                    { 96, new DateTime(2024, 5, 22, 23, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 22, 22, 13, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 97, new DateTime(2024, 3, 24, 22, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 24, 22, 9, 0, 0, DateTimeKind.Unspecified), 9, 4, 4 },
                    { 98, new DateTime(2024, 4, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 27, 12, 4, 0, 0, DateTimeKind.Unspecified), 7, 3, 5 },
                    { 99, new DateTime(2024, 9, 23, 18, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), 10, 7, 4 },
                    { 100, new DateTime(2024, 6, 2, 12, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 2, 12, 28, 0, 0, DateTimeKind.Unspecified), 14, 1, 2 }
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
                    { 1, 4, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 4, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 1, 3, new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 22, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 15, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 2, 4, new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 24, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 7, new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 2, 2, new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 26, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 11, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 10, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 4, 2, new DateTime(2024, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 5, 6, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 8, 5, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 14, new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 5, 3, new DateTime(2024, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 16, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 6, new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 1, 4, new DateTime(2023, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 24, 2, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 19, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 4, 3, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 11, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 19, new DateTime(2023, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, 2, new DateTime(2023, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 19, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 3, new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 2, 4, new DateTime(2023, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 14, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 13, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 1, 5, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 6, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 1, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 31, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 19, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 2, 2, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 29, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 9, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 2, 1, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 22, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 6, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 3, 6, new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 4, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 11, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 1, 6, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 16, 5, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 2, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 3, 5, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 19, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 9, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 4, 4, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 4, new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 3, new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 9, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 14, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 4, 2, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 1, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 2, 2, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 27, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 2, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 1, 6, new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 21, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 2, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 1, 3, new DateTime(2024, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 16, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 2, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 2, 2, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 3, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 2, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 5, 4, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 8, new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 2, 2, new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 21, 2, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 14, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 3, 3, new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 22, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 9, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 1, 4, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 29, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 4, new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, 2, new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 4, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 2, 6, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 10, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 2, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 5, new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 17, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, 3, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 18, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 1, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 12, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 10, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 3, 5, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 14, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 16, new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 2, 6, new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 22, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 8, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 1, 1, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 8, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2, 1, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 21, 5, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 12, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 1, 3, new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 2, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 13, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 1, 2, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 4, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 3, 2, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 15, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 12, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 5, 3, new DateTime(2023, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 22, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 7, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 4, 2, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 7, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 19, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 5, new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 23, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 17, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 3, 5, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 3, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, 4, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 17, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 10, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 5, 1, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 1, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 9, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 5, 2, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 8, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 19, new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 2, 5, new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 9, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 1, 2, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 5, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 18, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 4, 2, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 19, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 5, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 2, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 18, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 4, new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 5, new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 22, 5, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 19, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 3, new DateTime(2023, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 17, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 18, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 5, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 1, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 4, 6, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 3, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 4, 6, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 2, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 17, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 2, 4, new DateTime(2024, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 4, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 12, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 4, 2, new DateTime(2024, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 14, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, 4, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 4, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 6, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 1, 4, new DateTime(2023, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 26, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 16, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 2, 3, new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 17, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 18, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 3, 4, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 18, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 4, 1, new DateTime(2023, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 1, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 16, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 4, 6, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 13, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 10, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 6, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 3, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 2, 6, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 16, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 10, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 1, 1, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 13, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 2, 2, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 2, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 8, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 4, 1, new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 16, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5, 1, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 22, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 8, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, 4, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 13, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 13, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 3, 3, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 30, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 19, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, 1, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 29, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 4, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 3, 2, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 4, new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 2, 3, new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 6, 13, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 14, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 5, 2, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 6, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 14, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 5, 3, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 18, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 10, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 4, 5, new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 17, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 6, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 1, 6, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 11, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, 2, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 11, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 1, 4, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 10, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 1, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 27, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 12, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 1, 4, new DateTime(2023, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 11, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 1, 6, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 9, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 19, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 5, 1, new DateTime(2023, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 7, 4, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 19, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 5, 1, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 8, 15, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 4, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1, 3, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 10, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 5, 5, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 8, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 3, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 5, 3, new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 11, 14, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 14, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 3, 3, new DateTime(2023, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 6, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 2, 3, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 2, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 10, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 3, 3, new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 1, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 2, 2, new DateTime(2023, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 4, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 13, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 4, 1, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 17, 22, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 8, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 3, 4, new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 14, 21, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 5, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 2, 2, new DateTime(2023, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 7, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 13, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 1, 3, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 11, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 4, 2, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 29, 22, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
