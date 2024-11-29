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
                    { 1, true, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4951), "692gid7clBfbofUDGaucJtyT5So=", "zx3pMGqgwxVvosbj/OSLAw==", "061222333", null, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4950), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, true, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Senada", "Šahinpašić", new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4963), "I+fSrfJ8LQaaGsUxDcabSxBDXyE=", "2MX/00Z8uPPUbDchzi4zJA==", "061222444", null, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4962), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 4, "72000" },
                    { 3, true, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "neki@mail.com", "Test", "Testni", new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4969), "RFgaxggfFOdRpW8/JNdO1iqRfI0=", "os7Ge8nQ7qqOF0uHNJl8WQ==", "061222555", null, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4968), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, true, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "neko@mail.com", "Testni", "Test", new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4975), "iqVbrkHUYjHqSBgVg3pcFj/djjs=", "Vf4n5xebk2CZOimrA6qPzQ==", "061222666", null, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4974), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, true, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "proba@mail.com", "Proba", "Probni", new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4979), "yZ1+XmlOxlRYYZfAh119CmvTZSQ=", "CMVs/PlH1BQH9kKFDq0wdw==", "061222777", null, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4979), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, true, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4985), "2FLtrIb18PoKGTLies5uN42+gvo=", "BNBd3Zlf3TOIp3aGZLFDkQ==", "061222888", null, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(4985), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
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
                    { 1, true, false, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(5254), "", 2, 3 },
                    { 2, true, false, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(5257), "", 3, 5 },
                    { 3, true, false, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(5260), "", 4, 2 },
                    { 4, true, false, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(5262), "", 5, 4 },
                    { 5, true, false, new DateTime(2024, 11, 29, 14, 50, 36, 733, DateTimeKind.Local).AddTicks(5264), "", 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 4, 20, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 19, 57, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 },
                    { 2, new DateTime(2024, 12, 20, 13, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 12, 12, 0, 0, DateTimeKind.Unspecified), 1, 8, 3 },
                    { 3, new DateTime(2024, 11, 12, 9, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 8, 22, 0, 0, DateTimeKind.Unspecified), 12, 1, 6 },
                    { 4, new DateTime(2024, 11, 14, 18, 19, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 17, 42, 0, 0, DateTimeKind.Unspecified), 14, 10, 4 },
                    { 5, new DateTime(2024, 12, 15, 16, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 16, 18, 0, 0, DateTimeKind.Unspecified), 11, 5, 5 },
                    { 6, new DateTime(2024, 12, 10, 6, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 10, 6, 24, 0, 0, DateTimeKind.Unspecified), 12, 8, 5 },
                    { 7, new DateTime(2024, 12, 28, 6, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 5, 48, 0, 0, DateTimeKind.Unspecified), 15, 12, 5 },
                    { 8, new DateTime(2024, 11, 13, 20, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 19, 54, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 9, new DateTime(2024, 12, 12, 14, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 13, 21, 0, 0, DateTimeKind.Unspecified), 12, 1, 4 },
                    { 10, new DateTime(2024, 11, 7, 18, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 18, 19, 0, 0, DateTimeKind.Unspecified), 13, 12, 3 },
                    { 11, new DateTime(2024, 11, 8, 21, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 21, 9, 0, 0, DateTimeKind.Unspecified), 12, 15, 3 },
                    { 12, new DateTime(2024, 12, 6, 22, 27, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 21, 41, 0, 0, DateTimeKind.Unspecified), 10, 9, 3 },
                    { 13, new DateTime(2024, 11, 15, 22, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 22, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 4 },
                    { 14, new DateTime(2024, 12, 19, 19, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 19, 24, 0, 0, DateTimeKind.Unspecified), 15, 9, 5 },
                    { 15, new DateTime(2024, 11, 21, 23, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 21, 22, 18, 0, 0, DateTimeKind.Unspecified), 14, 1, 4 },
                    { 16, new DateTime(2024, 12, 21, 5, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 21, 5, 17, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 17, new DateTime(2024, 11, 14, 23, 28, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 23, 14, 0, 0, DateTimeKind.Unspecified), 7, 4, 1 },
                    { 18, new DateTime(2024, 12, 17, 18, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 17, 42, 0, 0, DateTimeKind.Unspecified), 15, 4, 3 },
                    { 19, new DateTime(2024, 12, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 13, 35, 0, 0, DateTimeKind.Unspecified), 6, 5, 3 },
                    { 20, new DateTime(2024, 11, 10, 9, 2, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 8, 40, 0, 0, DateTimeKind.Unspecified), 14, 5, 6 },
                    { 21, new DateTime(2024, 12, 14, 12, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 11, 38, 0, 0, DateTimeKind.Unspecified), 3, 5, 4 },
                    { 22, new DateTime(2024, 12, 30, 22, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 22, 19, 0, 0, DateTimeKind.Unspecified), 15, 9, 4 },
                    { 23, new DateTime(2024, 11, 17, 13, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 13, 2, 0, 0, DateTimeKind.Unspecified), 14, 1, 2 },
                    { 24, new DateTime(2024, 11, 28, 22, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 22, 15, 0, 0, DateTimeKind.Unspecified), 14, 9, 5 },
                    { 25, new DateTime(2024, 12, 26, 22, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 22, 21, 0, 0, DateTimeKind.Unspecified), 10, 4, 1 },
                    { 26, new DateTime(2024, 12, 20, 9, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 20, 9, 8, 0, 0, DateTimeKind.Unspecified), 6, 15, 1 },
                    { 27, new DateTime(2024, 12, 26, 15, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 15, 5, 0, 0, DateTimeKind.Unspecified), 4, 3, 1 },
                    { 28, new DateTime(2024, 12, 13, 5, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 5, 11, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 29, new DateTime(2024, 12, 15, 22, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 21, 47, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 30, new DateTime(2024, 12, 7, 14, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 7, 13, 23, 0, 0, DateTimeKind.Unspecified), 4, 15, 4 },
                    { 31, new DateTime(2024, 11, 7, 9, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 9, 5, 0, 0, DateTimeKind.Unspecified), 7, 5, 2 },
                    { 32, new DateTime(2024, 12, 30, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 9, 53, 0, 0, DateTimeKind.Unspecified), 8, 4, 6 },
                    { 33, new DateTime(2024, 11, 3, 6, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 3, 5, 41, 0, 0, DateTimeKind.Unspecified), 1, 15, 4 },
                    { 34, new DateTime(2024, 11, 29, 19, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 18, 46, 0, 0, DateTimeKind.Unspecified), 15, 12, 6 },
                    { 35, new DateTime(2024, 12, 11, 14, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 11, 13, 50, 0, 0, DateTimeKind.Unspecified), 9, 4, 1 },
                    { 36, new DateTime(2024, 11, 23, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 23, 9, 57, 0, 0, DateTimeKind.Unspecified), 13, 6, 3 },
                    { 37, new DateTime(2024, 12, 28, 18, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 18, 8, 0, 0, DateTimeKind.Unspecified), 6, 7, 4 },
                    { 38, new DateTime(2024, 11, 27, 13, 37, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 12, 43, 0, 0, DateTimeKind.Unspecified), 15, 13, 5 },
                    { 39, new DateTime(2024, 12, 17, 9, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 9, 4, 0, 0, DateTimeKind.Unspecified), 15, 5, 6 },
                    { 40, new DateTime(2024, 12, 2, 10, 47, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 2, 10, 1, 0, 0, DateTimeKind.Unspecified), 6, 5, 5 },
                    { 41, new DateTime(2024, 12, 24, 8, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 7, 41, 0, 0, DateTimeKind.Unspecified), 6, 14, 3 },
                    { 42, new DateTime(2024, 11, 16, 7, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 16, 7, 1, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 43, new DateTime(2024, 12, 26, 23, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 23, 5, 0, 0, DateTimeKind.Unspecified), 12, 1, 6 },
                    { 44, new DateTime(2024, 12, 5, 6, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 6, 41, 0, 0, DateTimeKind.Unspecified), 14, 11, 4 },
                    { 45, new DateTime(2024, 11, 20, 11, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 10, 36, 0, 0, DateTimeKind.Unspecified), 6, 10, 1 },
                    { 46, new DateTime(2024, 11, 7, 14, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 14, 1, 0, 0, DateTimeKind.Unspecified), 15, 1, 6 },
                    { 47, new DateTime(2024, 11, 21, 15, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 21, 14, 36, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 48, new DateTime(2024, 12, 16, 9, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 9, 43, 0, 0, DateTimeKind.Unspecified), 13, 6, 3 },
                    { 49, new DateTime(2024, 11, 6, 10, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 10, 8, 0, 0, DateTimeKind.Unspecified), 11, 8, 4 },
                    { 50, new DateTime(2024, 12, 8, 20, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 8, 20, 39, 0, 0, DateTimeKind.Unspecified), 1, 10, 3 },
                    { 51, new DateTime(2024, 12, 11, 20, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 11, 20, 19, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 52, new DateTime(2024, 12, 14, 20, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 19, 57, 0, 0, DateTimeKind.Unspecified), 1, 13, 3 },
                    { 53, new DateTime(2024, 12, 27, 13, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 13, 17, 0, 0, DateTimeKind.Unspecified), 14, 8, 4 },
                    { 54, new DateTime(2024, 11, 27, 19, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 18, 57, 0, 0, DateTimeKind.Unspecified), 4, 8, 5 },
                    { 55, new DateTime(2024, 12, 24, 17, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 56, new DateTime(2024, 12, 30, 11, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 10, 52, 0, 0, DateTimeKind.Unspecified), 13, 5, 1 },
                    { 57, new DateTime(2024, 12, 23, 9, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 9, 12, 0, 0, DateTimeKind.Unspecified), 12, 2, 6 },
                    { 58, new DateTime(2024, 11, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 19, 32, 0, 0, DateTimeKind.Unspecified), 1, 7, 2 },
                    { 59, new DateTime(2024, 12, 26, 22, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 22, 12, 0, 0, DateTimeKind.Unspecified), 1, 14, 6 },
                    { 60, new DateTime(2024, 11, 27, 16, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 16, 20, 0, 0, DateTimeKind.Unspecified), 7, 12, 6 },
                    { 61, new DateTime(2024, 12, 13, 6, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 13, 5, 20, 0, 0, DateTimeKind.Unspecified), 2, 6, 5 },
                    { 62, new DateTime(2024, 12, 16, 11, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 10, 47, 0, 0, DateTimeKind.Unspecified), 3, 8, 2 },
                    { 63, new DateTime(2024, 12, 19, 23, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 19, 23, 12, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 64, new DateTime(2024, 11, 17, 18, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 17, 18, 32, 0, 0, DateTimeKind.Unspecified), 15, 14, 5 },
                    { 65, new DateTime(2024, 12, 22, 20, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 20, 4, 0, 0, DateTimeKind.Unspecified), 13, 3, 3 },
                    { 66, new DateTime(2024, 12, 25, 19, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 19, 17, 0, 0, DateTimeKind.Unspecified), 9, 4, 1 },
                    { 67, new DateTime(2024, 12, 27, 12, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 11, 41, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { 68, new DateTime(2024, 12, 26, 12, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 11, 59, 0, 0, DateTimeKind.Unspecified), 11, 6, 5 },
                    { 69, new DateTime(2024, 12, 28, 15, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 28, 15, 24, 0, 0, DateTimeKind.Unspecified), 5, 1, 3 },
                    { 70, new DateTime(2024, 12, 16, 22, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 22, 23, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 71, new DateTime(2024, 12, 18, 18, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 18, 17, 58, 0, 0, DateTimeKind.Unspecified), 9, 5, 2 },
                    { 72, new DateTime(2024, 11, 1, 23, 14, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 22, 52, 0, 0, DateTimeKind.Unspecified), 8, 13, 5 },
                    { 73, new DateTime(2024, 11, 1, 16, 34, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 16, 22, 0, 0, DateTimeKind.Unspecified), 15, 13, 1 },
                    { 74, new DateTime(2024, 11, 26, 9, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 9, 34, 0, 0, DateTimeKind.Unspecified), 2, 15, 5 },
                    { 75, new DateTime(2024, 11, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 13, 43, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 76, new DateTime(2024, 12, 19, 0, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 18, 23, 53, 0, 0, DateTimeKind.Unspecified), 2, 8, 5 },
                    { 77, new DateTime(2024, 12, 2, 6, 41, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 2, 6, 31, 0, 0, DateTimeKind.Unspecified), 11, 2, 1 },
                    { 78, new DateTime(2024, 12, 30, 18, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 17, 43, 0, 0, DateTimeKind.Unspecified), 14, 9, 6 },
                    { 79, new DateTime(2024, 12, 6, 23, 34, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 6, 23, 22, 0, 0, DateTimeKind.Unspecified), 1, 7, 5 },
                    { 80, new DateTime(2024, 12, 16, 14, 24, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 16, 13, 32, 0, 0, DateTimeKind.Unspecified), 14, 7, 1 },
                    { 81, new DateTime(2024, 11, 16, 23, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 16, 23, 5, 0, 0, DateTimeKind.Unspecified), 14, 10, 6 },
                    { 82, new DateTime(2024, 12, 23, 15, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 14, 55, 0, 0, DateTimeKind.Unspecified), 9, 4, 4 },
                    { 83, new DateTime(2024, 11, 10, 14, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 14, 1, 0, 0, DateTimeKind.Unspecified), 8, 1, 6 },
                    { 84, new DateTime(2024, 12, 4, 22, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 21, 54, 0, 0, DateTimeKind.Unspecified), 6, 12, 3 },
                    { 85, new DateTime(2024, 12, 22, 6, 51, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 22, 6, 39, 0, 0, DateTimeKind.Unspecified), 8, 13, 6 },
                    { 86, new DateTime(2024, 12, 14, 11, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 14, 10, 19, 0, 0, DateTimeKind.Unspecified), 10, 8, 4 },
                    { 87, new DateTime(2024, 11, 30, 16, 22, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 15, 52, 0, 0, DateTimeKind.Unspecified), 15, 1, 6 },
                    { 88, new DateTime(2024, 11, 22, 15, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 15, 12, 0, 0, DateTimeKind.Unspecified), 11, 12, 5 },
                    { 89, new DateTime(2024, 11, 15, 12, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 12, 11, 0, 0, DateTimeKind.Unspecified), 2, 3, 6 },
                    { 90, new DateTime(2024, 12, 23, 6, 49, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 23, 6, 33, 0, 0, DateTimeKind.Unspecified), 12, 4, 6 },
                    { 91, new DateTime(2024, 12, 12, 20, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 19, 59, 0, 0, DateTimeKind.Unspecified), 7, 9, 3 },
                    { 92, new DateTime(2024, 11, 18, 9, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 9, 30, 0, 0, DateTimeKind.Unspecified), 14, 3, 3 },
                    { 93, new DateTime(2024, 11, 22, 15, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 22, 15, 12, 0, 0, DateTimeKind.Unspecified), 6, 5, 2 },
                    { 94, new DateTime(2024, 11, 15, 18, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 17, 37, 0, 0, DateTimeKind.Unspecified), 11, 2, 2 },
                    { 95, new DateTime(2024, 11, 12, 22, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 22, 32, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 96, new DateTime(2024, 11, 9, 20, 11, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 9, 19, 59, 0, 0, DateTimeKind.Unspecified), 2, 14, 4 },
                    { 97, new DateTime(2024, 12, 24, 11, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 10, 24, 0, 0, DateTimeKind.Unspecified), 13, 6, 1 },
                    { 98, new DateTime(2024, 12, 9, 9, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 9, 9, 4, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 99, new DateTime(2024, 12, 4, 23, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 22, 28, 0, 0, DateTimeKind.Unspecified), 12, 3, 1 },
                    { 100, new DateTime(2024, 11, 6, 12, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 6, 12, 1, 0, 0, DateTimeKind.Unspecified), 1, 15, 6 }
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
                    { 1, 17, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, 1, 4, new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 19, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 6, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 5, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 4, 1, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 16, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 4, 4, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 11, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 6, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 7, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 2, 6, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 31, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 11, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 5, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 18, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 1, 4, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 11, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 3, 3, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 6, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 4, 4, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 30, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 9, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 3, 6, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 16, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 5, 3, new DateTime(2023, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 19, new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 4, 6, new DateTime(2023, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 31, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 15, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 3, 6, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 13, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 4, 2, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 5, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 5, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 11, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 4, 2, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 1, 4, new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 11, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 3, 5, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 23, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 5, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 1, 5, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 15, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 3, 6, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 5, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 4, 3, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 14, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 1, 4, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 9, new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 2, 2, new DateTime(2023, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 10, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 3, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 5, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 1, 3, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 19, new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 4, 6, new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 8, new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 4, 1, new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 15, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 2, 3, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 17, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, 6, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 31, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 13, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 4, 4, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 18, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 4, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 15, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 1, 5, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 15, new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 5, 3, new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 3, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 3, 4, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 10, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3, 4, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 7, new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 4, 6, new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 17, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 5, 4, new DateTime(2024, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 9, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 3, 6, new DateTime(2024, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 1, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 5, 1, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 16, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 3, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 11, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 2, 1, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 19, new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 3, 2, new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 14, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 4, 2, new DateTime(2023, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 13, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 3, 6, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 4, new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 5, 1, new DateTime(2024, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 19, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 1, new DateTime(2024, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 4, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, 3, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 4, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 4, 2, new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 1, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 5, 2, new DateTime(2024, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 19, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 4, 6, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 19, new DateTime(2023, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 3, 6, new DateTime(2023, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 27, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 5, new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 2, 5, new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 8, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 2, 3, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 7, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1, 5, new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 23, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 15, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 2, 5, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 18, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 1, 6, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 15, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 5, 2, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 16, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 4, 6, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 13, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 4, 2, new DateTime(2024, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 19, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 5, 3, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 8, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 2, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 16, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 4, 1, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 9, new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 2, 6, new DateTime(2024, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 30, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 17, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 5, 3, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 6, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 3, 6, new DateTime(2023, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 31, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 9, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 4, 4, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 14, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 1, 5, new DateTime(2023, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 26, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 14, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 5, 1, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 4, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1, 5, new DateTime(2023, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 10, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, 6, new DateTime(2023, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 7, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 2, 3, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 13, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 1, 1, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 13, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 1, 4, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 17, new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 2, 6, new DateTime(2023, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 27, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 16, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, 4, new DateTime(2024, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 14, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 5, 4, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 8, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 2, 5, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 7, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 5, 2, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 12, new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 4, 3, new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 6, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 5, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 1, 3, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 3, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 3, 2, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 15, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 3, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 12, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 1, 1, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 12, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 5, new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 17, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 5, 3, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 16, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 5, 6, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 10, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 5, 2, new DateTime(2023, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 14, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 1, 2, new DateTime(2023, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 14, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 3, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 4, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 5, 1, new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 17, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 5, 6, new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 4, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5, 2, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 13, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 2, 3, new DateTime(2024, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 19, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 1, 2, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 14, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 1, 2, new DateTime(2024, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 4, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 4, 4, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 7, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 4, 1, new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 3, new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 5, 5, new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
