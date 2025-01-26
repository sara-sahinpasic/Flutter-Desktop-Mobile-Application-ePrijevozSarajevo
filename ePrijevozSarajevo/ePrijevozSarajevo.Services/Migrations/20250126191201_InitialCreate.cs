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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discount = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true),
                    ManufacturerCountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Countries_ManufacturerCountryId",
                        column: x => x.ManufacturerCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.SetNull);
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
                    UserCountryId = table.Column<int>(type: "int", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserStatusId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Users_Statuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.SetNull);
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
                    UserStatusId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Malfunctions",
                columns: table => new
                {
                    MalfunctionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfMalufunction = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fixed = table.Column<bool>(type: "bit", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    StationId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malfunctions", x => x.MalfunctionId);
                    table.ForeignKey(
                        name: "FK_Malfunctions_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId");
                    table.ForeignKey(
                        name: "FK_Malfunctions_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
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
                name: "Delays",
                columns: table => new
                {
                    DelayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    DelayAmountMinutes = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delays", x => x.DelayId);
                    table.ForeignKey(
                        name: "FK_Delays_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "RouteId");
                    table.ForeignKey(
                        name: "FK_Delays_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "TypeId");
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
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_IssuedTickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CurrentUserId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1062), "Afghanistan" },
                    { 2, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1065), "Albania" },
                    { 3, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1066), "Algeria" },
                    { 4, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1068), "Andorra" },
                    { 5, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1069), "Angola" },
                    { 6, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1071), "Antigua and Barbuda" },
                    { 7, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1072), "Argentina" },
                    { 8, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1074), "Armenia" },
                    { 9, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1075), "Australia" },
                    { 10, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1077), "Austria" },
                    { 11, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1078), "Azerbaijan" },
                    { 12, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1079), "Bahrain" },
                    { 13, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1081), "Bangladesh" },
                    { 14, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1082), "Barbados" },
                    { 15, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1083), "Belarus" },
                    { 16, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1084), "Belgium" },
                    { 17, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1085), "Belize" },
                    { 18, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1093), "Benin" },
                    { 19, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1094), "Bhutan" },
                    { 20, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1095), "Bolivia" },
                    { 21, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1096), "Bosnia and Herzegovina" },
                    { 22, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1097), "Botswana" },
                    { 23, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1099), "Brazil" },
                    { 24, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1100), "Brunei" },
                    { 25, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1101), "Bulgaria" },
                    { 26, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1102), "Burkina Faso" },
                    { 27, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1103), "Burundi" },
                    { 28, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1104), "Cambodia" },
                    { 29, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1106), "Cameroon" },
                    { 30, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1107), "Canada" },
                    { 31, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1108), "Cape Verde" },
                    { 32, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1109), "Central African Republic" },
                    { 33, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1110), "Chad" },
                    { 34, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1112), "Chile" },
                    { 35, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1113), "China" },
                    { 36, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1114), "Colombia" },
                    { 37, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1116), "Comoros" },
                    { 38, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1117), "Congo" },
                    { 39, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1118), "Congo (Democratic Republic)" },
                    { 40, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1119), "Costa Rica" },
                    { 41, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1120), "Croatia" },
                    { 42, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1121), "Cuba" },
                    { 43, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1123), "Cyprus" },
                    { 44, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1124), "Czechia" },
                    { 45, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1125), "Denmark" },
                    { 46, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1126), "Djibouti" },
                    { 47, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1127), "Dominica" },
                    { 48, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1128), "Dominican Republic" },
                    { 49, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1130), "East Timor" },
                    { 50, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1131), "Ecuador" },
                    { 51, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1132), "Egypt" },
                    { 52, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1133), "El Salvador" },
                    { 53, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1134), "Equatorial Guinea" },
                    { 54, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1135), "Eritrea" },
                    { 55, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1136), "Estonia" },
                    { 56, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1138), "Eswatini" },
                    { 57, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1139), "Ethiopia" },
                    { 58, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1140), "Fiji" },
                    { 59, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1141), "Finland" },
                    { 60, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1142), "France" },
                    { 61, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1143), "Gabon" },
                    { 62, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1144), "Georgia" },
                    { 63, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1145), "Germany" },
                    { 64, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1147), "Ghana" },
                    { 65, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1148), "Greece" },
                    { 66, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1150), "Grenada" },
                    { 67, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1151), "Guatemala" },
                    { 68, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1152), "Guinea" },
                    { 69, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1153), "Guinea-Bissau" },
                    { 70, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1154), "Guyana" },
                    { 71, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1155), "Haiti" },
                    { 72, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1156), "Honduras" },
                    { 73, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1158), "Hungary" },
                    { 74, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1159), "Iceland" },
                    { 75, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1160), "India" },
                    { 76, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1161), "Indonesia" },
                    { 77, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1162), "Iran" },
                    { 78, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1163), "Iraq" },
                    { 79, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1164), "Ireland" },
                    { 80, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1166), "Israel" },
                    { 81, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1167), "Italy" },
                    { 82, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1168), "Ivory Coast" },
                    { 83, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1169), "Jamaica" },
                    { 84, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1170), "Japan" },
                    { 85, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1171), "Jordan" },
                    { 86, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1172), "Kazakhstan" },
                    { 87, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1174), "Kenya" },
                    { 88, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1175), "Kiribati" },
                    { 89, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1176), "Kosovo" },
                    { 90, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1177), "Kuwait" },
                    { 91, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1178), "Kyrgyzstan" },
                    { 92, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1179), "Laos" },
                    { 93, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1180), "Latvia" },
                    { 94, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1182), "Lebanon" },
                    { 95, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1183), "Lesotho" },
                    { 96, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1184), "Liberia" },
                    { 97, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1185), "Libya" },
                    { 98, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1186), "Liechtenstein" },
                    { 99, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1187), "Lithuania" },
                    { 100, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1188), "Luxembourg" },
                    { 101, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1189), "Madagascar" },
                    { 102, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1191), "Malawi" },
                    { 103, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1192), "Malaysia" },
                    { 104, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1193), "Maldives" },
                    { 105, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1194), "Mali" },
                    { 106, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1195), "Malta" },
                    { 107, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1196), "Marshall Islands" },
                    { 108, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1197), "Mauritania" },
                    { 109, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1199), "Mauritius" },
                    { 110, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1200), "Mexico" },
                    { 111, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1201), "Federated States of Micronesia" },
                    { 112, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1202), "Moldova" },
                    { 113, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1203), "Monaco" },
                    { 114, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1204), "Mongolia" },
                    { 115, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1205), "Montenegro" },
                    { 116, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1206), "Morocco" },
                    { 117, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1208), "Mozambique" },
                    { 118, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1209), "Myanmar (Burma)" },
                    { 119, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1210), "Namibia" },
                    { 120, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1211), "Nauru" },
                    { 121, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1212), "Nepal" },
                    { 122, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1213), "Netherlands" },
                    { 123, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1214), "New Zealand" },
                    { 124, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1216), "Nicaragua" },
                    { 125, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1217), "Niger" },
                    { 126, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1218), "Nigeria" },
                    { 127, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1219), "North Korea" },
                    { 128, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1220), "North Macedonia" },
                    { 129, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1221), "Norway" },
                    { 130, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1230), "Oman" },
                    { 131, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1231), "Pakistan" },
                    { 132, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1232), "Palau" },
                    { 133, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1233), "Panama" },
                    { 134, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1234), "Papua New Guinea" },
                    { 135, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1235), "Paraguay" },
                    { 136, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1236), "Peru" },
                    { 137, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1238), "Philippines" },
                    { 138, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1239), "Poland" },
                    { 139, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1240), "Portugal" },
                    { 140, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1241), "Qatar" },
                    { 141, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1242), "Romania" },
                    { 142, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1243), "Russia" },
                    { 143, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1244), "Rwanda" },
                    { 144, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1245), "St Kitts and Nevis" },
                    { 145, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1247), "St Lucia" },
                    { 146, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1248), "St Vincent" },
                    { 147, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1249), "Samoa" },
                    { 148, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1250), "San Marino" },
                    { 149, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1251), "Sao Tome and Principe" },
                    { 150, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1252), "Saudi Arabia" },
                    { 151, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1253), "Senegal" },
                    { 152, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1254), "Serbia" },
                    { 153, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1256), "Seychelles" },
                    { 154, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1257), "Sierra Leone" },
                    { 155, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1258), "Singapore" },
                    { 156, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1259), "Slovakia" },
                    { 157, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1260), "Slovenia" },
                    { 158, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1261), "Solomon Islands" },
                    { 159, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1262), "Somalia" },
                    { 160, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1263), "South Africa" },
                    { 161, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1265), "South Korea" },
                    { 162, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1266), "South Sudan" },
                    { 163, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1267), "Spain" },
                    { 164, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1268), "Sri Lanka" },
                    { 165, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1269), "Sudan" },
                    { 166, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1270), "Suriname" },
                    { 167, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1271), "Sweden" },
                    { 168, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1273), "Switzerland" },
                    { 169, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1274), "Syria" },
                    { 170, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1275), "Tajikistan" },
                    { 171, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1276), "Tanzania" },
                    { 172, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1277), "Thailand" },
                    { 173, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1278), "The Bahamas" },
                    { 174, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1279), "The Gambia" },
                    { 175, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1281), "Togo" },
                    { 176, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1282), "Tonga" },
                    { 177, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1283), "Trinidad and Tobago" },
                    { 178, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1284), "Tunisia" },
                    { 179, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1285), "Turkey" },
                    { 180, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1286), "Turkmenistan" },
                    { 181, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1287), "Tuvalu" },
                    { 182, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1288), "Uganda" },
                    { 183, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1290), "Ukraine" },
                    { 184, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1291), "United Arab Emirates" },
                    { 185, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1292), "United Kingdom" },
                    { 186, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1293), "United States" },
                    { 187, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1294), "Uruguay" },
                    { 188, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1295), "Uzbekistan" },
                    { 189, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1296), "Vanuatu" },
                    { 190, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1297), "Vatican City" },
                    { 191, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1299), "Venezuela" },
                    { 192, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1300), "Vietnam" },
                    { 193, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1301), "Yemen" },
                    { 194, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1302), "Zambia" },
                    { 195, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1303), "Zimbabwe" }
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
                columns: new[] { "StationId", "CurrentUserId", "DateCreated", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1509), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1507), "Ilidža" },
                    { 2, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1512), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1511), "Stup" },
                    { 3, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1514), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1515), "Nedžarići" },
                    { 4, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1517), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1518), "Socijalno" },
                    { 5, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1519), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1521), "Malta" },
                    { 6, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1522), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1523), "Baščaršija" },
                    { 7, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1525), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1526), "Otoka" },
                    { 8, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1527), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1529), "Skenderija" },
                    { 9, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1530), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1531), "Drvenija" },
                    { 10, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1533), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1534), "Dobrinja" },
                    { 11, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1535), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1537), "Grbavica" },
                    { 12, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1538), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1539), "Hrasno" },
                    { 13, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1541), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1542), "Aneks" },
                    { 14, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1543), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1545), "Alipašino polje" },
                    { 15, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1546), new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1547), "Švrakino selo" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "CurrentUserId", "Discount", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, 0.0, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1737), "Default" },
                    { 2, null, 0.29999999999999999, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1740), "Student" },
                    { 3, null, 0.5, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1742), "Penzioner" },
                    { 4, null, 0.14999999999999999, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1744), "Zaposlenik" },
                    { 5, null, 0.40000000000000002, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1745), "Nezaposlen" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CurrentUserId", "ModifiedDate", "Name", "Price", "StateMachine" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1763), "Jednosmjerna", 1.8, "draft" },
                    { 2, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1765), "Povratna", 3.2000000000000002, "draft" },
                    { 3, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1767), "Jednosmjerna dječija", 0.80000000000000004, "draft" },
                    { 4, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1769), "Povratna dječija", 1.2, "draft" },
                    { 5, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1771), "Mjesečna", 75.0, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "CurrentUserId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1624), "Trolejbus" },
                    { 2, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1626), "Tramvaj" },
                    { 3, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1628), "Minibus" },
                    { 4, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1630), "Autobus" },
                    { 5, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1631), "Kombi" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "CurrentUserId", "ManufacturerCountryId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1591), "MAN" },
                    { 2, null, 2, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1594), "Solaris" },
                    { 3, null, 3, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1595), "Volvo" },
                    { 4, null, 4, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1597), "Mercedes" },
                    { 5, null, 5, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1599), "Setra" },
                    { 6, null, 6, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1601), "Neoplan" },
                    { 7, null, 7, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1602), "Siemens" },
                    { 8, null, 8, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1604), "Traton" },
                    { 9, null, 9, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1606), "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "City", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImage", "RegistrationDate", "StatusExpirationDate", "UserCountryId", "UserName", "UserStatusId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(563), "k/Q0g/z0Fc8Img73S4/52D1cqNM=", "Nc0IMhWDEFl1rQQVOdcpKg==", "+38761222333", null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(562), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevoapp@gmail.com", "Senada", "Senadić", new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(577), "RbLK/YU9qdWgu6Tki1e3FhLa1nE=", "5pzcHBU/s964D2SHXq0IRQ==", "+38761222444", null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(576), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 1, "72000" },
                    { 3, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Test", "Testni", new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(583), "jGO1qO6CVIwd/nyLiuSsSQLUZ9M=", "KBeSVHttEL/4nXDK/ZNABg==", "+38761222444", null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(582), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevotest@outlook.com", "Testni", "Test", new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(590), "sTlNvS87SyD52ONrA/OHN9ctjfM=", "iMXHNI8xL/RFSopWXMhY4A==", "+38761222666", null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(589), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevo.app@gmx.de", "Proba", "Probni", new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(595), "edX6yPwHjUgn822ofN6xQH73tT4=", "iyAAvpsuk5P7t1JoJ+7lrw==", "+38761222777", null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(594), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(602), "e21aO6kSs0RwcPYs1MzMXivIpXQ=", "B6YMXMtN2uTasy+OWA+NEA==", "+38761222888", null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(600), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "Active", "Approved", "DateCreated", "RejectionReason", "UserId", "UserStatusId" },
                values: new object[,]
                {
                    { 2, true, false, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1375), "", 3, 5 },
                    { 3, true, false, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1378), "", 4, 2 },
                    { 4, true, false, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1380), "", 5, 4 },
                    { 5, true, false, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1382), "", 1, 2 },
                    { 6, true, false, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1384), "", 6, 3 }
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
                table: "Vehicles",
                columns: new[] { "VehicleId", "BuildYear", "ManufacturerId", "Number", "RegistrationNumber", "TypeId" },
                values: new object[,]
                {
                    { 1, 2005, 1, 15, "A10-B-123", 1 },
                    { 2, 2015, 2, 20, "A11-C-124", 2 },
                    { 3, 2010, 3, 25, "A12-D-154", 1 },
                    { 4, 2007, 4, 30, "A14-E-174", 2 },
                    { 5, 2014, 4, 35, "A15-F-183", 1 },
                    { 6, 2011, 3, 40, "A16-G-195", 2 }
                });

            migrationBuilder.InsertData(
                table: "Malfunctions",
                columns: new[] { "MalfunctionId", "CurrentUserId", "DateOfMalufunction", "Description", "Fixed", "ModifiedDate", "StationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1786), "Opis kvara: Test 1", true, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1791), 1, 1 },
                    { 2, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1793), "Opis kvara: Test 2", false, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1794), 2, 2 },
                    { 3, null, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1796), "Opis kvara: Test 3", true, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1798), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 6 },
                    { 2, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 3, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 4 },
                    { 4, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 4 },
                    { 5, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 4 },
                    { 6, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 4 },
                    { 7, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 8, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 4 },
                    { 9, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 10, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 2 },
                    { 11, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 5 },
                    { 12, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 5 },
                    { 13, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 3 },
                    { 14, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 4 },
                    { 15, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 6 },
                    { 16, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 17, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 18, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 6 },
                    { 19, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 20, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 5 },
                    { 21, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 1 },
                    { 22, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 6 },
                    { 23, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 4 },
                    { 24, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 6 },
                    { 25, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 2 },
                    { 26, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 5 },
                    { 27, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 5 },
                    { 28, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 29, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 6 },
                    { 30, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 31, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 6 },
                    { 32, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 5 },
                    { 33, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 3 },
                    { 34, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 35, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 36, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 5 },
                    { 37, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 38, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 1 },
                    { 39, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 40, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 1 },
                    { 41, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 1 },
                    { 42, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 3 },
                    { 43, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 44, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 5 },
                    { 45, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 5 },
                    { 46, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 1 },
                    { 47, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 48, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 6 },
                    { 49, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 6 },
                    { 50, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 51, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 2 },
                    { 52, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 4 },
                    { 53, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 54, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 5 },
                    { 55, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 3 },
                    { 56, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 2 },
                    { 57, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 5 },
                    { 58, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 3 },
                    { 59, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 6 },
                    { 60, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 5 },
                    { 61, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 2 },
                    { 62, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 5 },
                    { 63, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 2 },
                    { 64, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 4 },
                    { 65, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 6 },
                    { 66, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 4 },
                    { 67, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 5 },
                    { 68, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 4 },
                    { 69, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 5 },
                    { 70, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 71, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 72, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 73, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 74, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 3 },
                    { 75, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 76, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 77, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 78, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 6 },
                    { 79, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 5 },
                    { 80, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 81, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 82, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 83, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 2 },
                    { 84, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 3 },
                    { 85, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 6 },
                    { 86, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 87, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 3 },
                    { 88, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 3 },
                    { 89, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 5 },
                    { 90, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 5 },
                    { 91, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 92, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 1 },
                    { 93, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 94, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 1 },
                    { 95, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 6 },
                    { 96, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 97, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 5 },
                    { 98, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 1 },
                    { 99, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 3 },
                    { 100, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 101, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 102, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 1 },
                    { 103, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 104, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 5 },
                    { 105, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 106, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 107, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 6 },
                    { 108, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 109, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 2 },
                    { 110, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 1 },
                    { 111, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 6 },
                    { 112, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 113, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 3 },
                    { 114, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 115, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 2 },
                    { 116, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 6 },
                    { 117, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 118, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 1 },
                    { 119, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 3 },
                    { 120, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 121, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 6 },
                    { 122, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 4 },
                    { 123, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 124, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 3 },
                    { 125, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 3 },
                    { 126, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 4 },
                    { 127, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 4 },
                    { 128, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 2 },
                    { 129, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 4 },
                    { 130, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 6 },
                    { 131, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 132, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 6 },
                    { 133, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 134, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 135, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 5 },
                    { 136, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 137, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 138, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 3 },
                    { 139, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 6 },
                    { 140, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 141, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 6 },
                    { 142, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 3 },
                    { 143, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 144, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 5 },
                    { 145, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 4 },
                    { 146, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 147, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 148, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 5 },
                    { 149, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 6 },
                    { 150, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 151, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 4 },
                    { 152, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 4 },
                    { 153, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 3 },
                    { 154, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 4 },
                    { 155, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 5 },
                    { 156, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 4 },
                    { 157, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 3 },
                    { 158, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 3 },
                    { 159, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 6 },
                    { 160, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 5 },
                    { 161, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 4 },
                    { 162, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 163, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 164, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 4 },
                    { 165, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 6 },
                    { 166, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 4 },
                    { 167, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 2 },
                    { 168, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 169, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 5 },
                    { 170, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 5 },
                    { 171, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 1 },
                    { 172, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 6 },
                    { 173, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 5 },
                    { 174, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 175, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 176, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 2 },
                    { 177, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 2 },
                    { 178, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 2 },
                    { 179, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 6 },
                    { 180, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 181, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 6 },
                    { 182, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 183, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 5 },
                    { 184, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 1 },
                    { 185, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 186, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 6 },
                    { 187, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 6 },
                    { 188, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 1 },
                    { 189, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 190, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 191, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 2 },
                    { 192, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 6 },
                    { 193, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 2 },
                    { 194, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 4 },
                    { 195, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 1 },
                    { 196, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 197, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 2 },
                    { 198, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 1 },
                    { 199, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 200, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 1 },
                    { 201, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 202, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 203, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 204, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 6 },
                    { 205, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 3 },
                    { 206, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 4 },
                    { 207, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 3 },
                    { 208, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 209, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 5 },
                    { 210, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 3 },
                    { 211, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 4 },
                    { 212, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 6 },
                    { 213, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 1 },
                    { 214, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 6 },
                    { 215, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 4 },
                    { 216, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 217, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 3 },
                    { 218, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 219, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 3 },
                    { 220, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 1 },
                    { 221, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 5 },
                    { 222, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 223, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 6 },
                    { 224, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 225, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 5 },
                    { 226, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 5 },
                    { 227, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 228, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 3 },
                    { 229, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 4 },
                    { 230, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 4 },
                    { 231, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 232, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 2 },
                    { 233, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 234, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 5 },
                    { 235, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 4 },
                    { 236, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 2 },
                    { 237, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 3 },
                    { 238, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 6 },
                    { 239, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 6 },
                    { 240, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 241, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 5 },
                    { 242, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 243, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 244, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 3 },
                    { 245, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 3 },
                    { 246, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 247, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 248, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 6 },
                    { 249, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 4 },
                    { 250, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 1 },
                    { 251, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 6 },
                    { 252, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 253, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 254, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 4 },
                    { 255, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 4 },
                    { 256, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 4 },
                    { 257, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 258, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 259, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 4 },
                    { 260, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 2 },
                    { 261, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 1 },
                    { 262, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 6 },
                    { 263, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 3 },
                    { 264, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 3 },
                    { 265, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 3 },
                    { 266, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 6 },
                    { 267, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 268, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 5 },
                    { 269, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 270, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 3 },
                    { 271, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 6 },
                    { 272, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 2 },
                    { 273, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 5 },
                    { 274, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 3 },
                    { 275, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 4 },
                    { 276, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 6 },
                    { 277, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 6 },
                    { 278, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 4 },
                    { 279, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 3 },
                    { 280, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 4 },
                    { 281, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 282, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 2 },
                    { 283, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 1 },
                    { 284, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 6 },
                    { 285, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 286, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 287, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 1 },
                    { 288, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 4 },
                    { 289, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 1 },
                    { 290, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 291, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 292, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 1 },
                    { 293, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 294, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 2 },
                    { 295, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 4 },
                    { 296, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 297, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 4 },
                    { 298, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 6 },
                    { 299, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 2 },
                    { 300, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 301, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 6 },
                    { 302, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 1 },
                    { 303, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 3 },
                    { 304, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 3 },
                    { 305, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 4 },
                    { 306, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 6 },
                    { 307, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 2 },
                    { 308, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 1 },
                    { 309, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 310, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 5 },
                    { 311, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 312, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 313, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 2 },
                    { 314, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 6 },
                    { 315, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 316, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 6 },
                    { 317, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 6 },
                    { 318, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 319, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 6 },
                    { 320, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 321, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 3 },
                    { 322, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 6 },
                    { 323, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 5 },
                    { 324, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 2 },
                    { 325, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 3 },
                    { 326, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 4 },
                    { 327, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 4 },
                    { 328, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 4 },
                    { 329, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 5 },
                    { 330, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 2 },
                    { 331, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 3 },
                    { 332, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 5 },
                    { 333, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 1 },
                    { 334, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 335, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 4 },
                    { 336, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 6 },
                    { 337, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 1 },
                    { 338, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 339, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 6 },
                    { 340, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 5 },
                    { 341, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 4 },
                    { 342, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 2 },
                    { 343, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 2 },
                    { 344, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 345, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 6 },
                    { 346, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 3 },
                    { 347, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 4 },
                    { 348, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 4 },
                    { 349, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 6 },
                    { 350, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 1 },
                    { 351, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 6 },
                    { 352, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 353, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 354, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 6 },
                    { 355, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 2 },
                    { 356, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 1 },
                    { 357, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 3 },
                    { 358, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 359, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 360, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { 361, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 1 },
                    { 362, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 5 },
                    { 363, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 5 },
                    { 364, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 4 },
                    { 365, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 4 },
                    { 366, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 367, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 1 },
                    { 368, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 369, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 370, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 371, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 372, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 1 },
                    { 373, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 4 },
                    { 374, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 3 },
                    { 375, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 4 },
                    { 376, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 4 },
                    { 377, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 5 },
                    { 378, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 379, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 4 },
                    { 380, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 381, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 382, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 4 },
                    { 383, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 3 },
                    { 384, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 385, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 386, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 3 },
                    { 387, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 5 },
                    { 388, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 389, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 5 },
                    { 390, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 391, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 3 },
                    { 392, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 5 },
                    { 393, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 5 },
                    { 394, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 395, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 3 },
                    { 396, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 4 },
                    { 397, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 4 },
                    { 398, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 6 },
                    { 399, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 6 },
                    { 400, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 5 },
                    { 401, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 402, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 6 },
                    { 403, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 2 },
                    { 404, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 6 },
                    { 405, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 406, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 6 },
                    { 407, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 408, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 2 },
                    { 409, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 410, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 411, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 1 },
                    { 412, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 1 },
                    { 413, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 1 },
                    { 414, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 4 },
                    { 415, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 5 },
                    { 416, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 3 },
                    { 417, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 418, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 419, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 5 },
                    { 420, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 421, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 4 },
                    { 422, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 3 },
                    { 423, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 424, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 6 },
                    { 425, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 2 },
                    { 426, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 3 },
                    { 427, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 4 },
                    { 428, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 429, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 430, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 431, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 3 },
                    { 432, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 433, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 4 },
                    { 434, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 435, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 2 },
                    { 436, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 437, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 3 },
                    { 438, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 439, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 4 },
                    { 440, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 441, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 442, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 5 },
                    { 443, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 444, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 2 },
                    { 445, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 1 },
                    { 446, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 447, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 6 },
                    { 448, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 6 },
                    { 449, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 2 },
                    { 450, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 1 },
                    { 451, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 452, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 3 },
                    { 453, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 4 },
                    { 454, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 2 },
                    { 455, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 5 },
                    { 456, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 5 },
                    { 457, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 1 },
                    { 458, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 6 },
                    { 459, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 1 },
                    { 460, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 2 },
                    { 461, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 1 },
                    { 462, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 5 },
                    { 463, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 464, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 2 },
                    { 465, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 2 },
                    { 466, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 467, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 6 },
                    { 468, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 1 },
                    { 469, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 470, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 1 },
                    { 471, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 3 },
                    { 472, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 2 },
                    { 473, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 3 },
                    { 474, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 6 },
                    { 475, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 4 },
                    { 476, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 5 },
                    { 477, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 478, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 479, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 480, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 4 },
                    { 481, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 5 },
                    { 482, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 4 },
                    { 483, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 484, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 5 },
                    { 485, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 6 },
                    { 486, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 1 },
                    { 487, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 5 },
                    { 488, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 1 },
                    { 489, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 3 },
                    { 490, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 491, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 3 },
                    { 492, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 493, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 494, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 4 },
                    { 495, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 6 },
                    { 496, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 1 },
                    { 497, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 1 },
                    { 498, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 4 },
                    { 499, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 6 },
                    { 500, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 501, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 3 },
                    { 502, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 3 },
                    { 503, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 504, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 505, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 2 },
                    { 506, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 507, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 2 },
                    { 508, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 4 },
                    { 509, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 2 },
                    { 510, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 2 },
                    { 511, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 512, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 4 },
                    { 513, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 514, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 6 },
                    { 515, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 516, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 3 },
                    { 517, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 3 },
                    { 518, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 3 },
                    { 519, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 6 },
                    { 520, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 521, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 2 },
                    { 522, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 1 },
                    { 523, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 6 },
                    { 524, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 3 },
                    { 525, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 526, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 1 },
                    { 527, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 6 },
                    { 528, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 529, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 3 },
                    { 530, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 5 },
                    { 531, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 5 },
                    { 532, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 533, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 1 },
                    { 534, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 535, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 536, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 3 },
                    { 537, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 538, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 539, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 3 },
                    { 540, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 2 },
                    { 541, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 542, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 543, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 3 },
                    { 544, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 4 },
                    { 545, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 6 },
                    { 546, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 547, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 2 },
                    { 548, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 4 },
                    { 549, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 5 },
                    { 550, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 1 },
                    { 551, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 4 },
                    { 552, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 4 },
                    { 553, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 5 },
                    { 554, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 1 },
                    { 555, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 2 },
                    { 556, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 5 },
                    { 557, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 6 },
                    { 558, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 3 },
                    { 559, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 2 },
                    { 560, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 3 },
                    { 561, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 6 },
                    { 562, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 2 },
                    { 563, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 5 },
                    { 564, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 565, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 2 },
                    { 566, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 6 },
                    { 567, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 6 },
                    { 568, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 5 },
                    { 569, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 6 },
                    { 570, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 4 },
                    { 571, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 5 },
                    { 572, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 573, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 5 },
                    { 574, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 1 },
                    { 575, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 6 },
                    { 576, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 577, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 1 },
                    { 578, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 1 },
                    { 579, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 6 },
                    { 580, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 6 },
                    { 581, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 582, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 583, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 4 },
                    { 584, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 585, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 4 },
                    { 586, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 4 },
                    { 587, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 4 },
                    { 588, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 589, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 5 },
                    { 590, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 591, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 5 },
                    { 592, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 1 },
                    { 593, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 4 },
                    { 594, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 2 },
                    { 595, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 3 },
                    { 596, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 597, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 6 },
                    { 598, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 },
                    { 599, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 600, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 6 },
                    { 601, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 6 },
                    { 602, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 603, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 604, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 6 },
                    { 605, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 6 },
                    { 606, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 5 },
                    { 607, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 5 },
                    { 608, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 609, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 4 },
                    { 610, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 4 },
                    { 611, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 2 },
                    { 612, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 613, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 614, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 3 },
                    { 615, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 616, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 4 },
                    { 617, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 3 },
                    { 618, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 619, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 620, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 621, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 6 },
                    { 622, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 5 },
                    { 623, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 5 },
                    { 624, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 625, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 626, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 4 },
                    { 627, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 6 },
                    { 628, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 5 },
                    { 629, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 2 },
                    { 630, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 2 },
                    { 631, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 2 },
                    { 632, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 6 },
                    { 633, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 3 },
                    { 634, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 2 },
                    { 635, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 636, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 2 },
                    { 637, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 5 },
                    { 638, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 639, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 640, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 5 },
                    { 641, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 4 },
                    { 642, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 643, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 644, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 1 },
                    { 645, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 4 },
                    { 646, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 5 },
                    { 647, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 1 },
                    { 648, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 2 },
                    { 649, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 650, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 6 },
                    { 651, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 652, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 6 },
                    { 653, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 6 },
                    { 654, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 5 },
                    { 655, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 5 },
                    { 656, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 4 },
                    { 657, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 658, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 3 },
                    { 659, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 1 },
                    { 660, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 661, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 662, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 663, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 2 },
                    { 664, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 2 },
                    { 665, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 4 },
                    { 666, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 3 },
                    { 667, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 2 },
                    { 668, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 1 },
                    { 669, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 670, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 671, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 672, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 673, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 674, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 675, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 676, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 6 },
                    { 677, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 2 },
                    { 678, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 5 },
                    { 679, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 680, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 681, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 1 },
                    { 682, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 6 },
                    { 683, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 684, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 4 },
                    { 685, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 686, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 687, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 5 },
                    { 688, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 5 },
                    { 689, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 4 },
                    { 690, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 6 },
                    { 691, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 4 },
                    { 692, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 693, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 3 },
                    { 694, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 1 },
                    { 695, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 4 },
                    { 696, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 1 },
                    { 697, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 4 },
                    { 698, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 1 },
                    { 699, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 3 },
                    { 700, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 701, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 5 },
                    { 702, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 6 },
                    { 703, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 704, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 3 },
                    { 705, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 5 },
                    { 706, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 1 },
                    { 707, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 708, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 4 },
                    { 709, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 1 },
                    { 710, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 4 },
                    { 711, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 1 },
                    { 712, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 2 },
                    { 713, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 5 },
                    { 714, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 6 }
                });

            migrationBuilder.InsertData(
                table: "Delays",
                columns: new[] { "DelayId", "CurrentUserId", "DelayAmountMinutes", "ModifiedDate", "Reason", "RouteId", "TypeId" },
                values: new object[,]
                {
                    { 1, null, 30, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1818), "Gužva", 1, 1 },
                    { 2, null, 60, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1821), "Udes", 2, 2 },
                    { 3, null, 15, new DateTime(2025, 1, 26, 20, 12, 1, 268, DateTimeKind.Local).AddTicks(1823), "Led", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "IssuedTickets",
                columns: new[] { "IssuedTicketId", "Amount", "IssuedDate", "RouteId", "TicketId", "UserId", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 7, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 2, 1, new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 6, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 157, 5, 1, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 6, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 1, 3, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 8, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 519, 4, 2, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 30, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 5, 2, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 2, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 679, 2, 5, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 4, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 335, 5, 4, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 4, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 2, 5, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 505, 5, 6, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 555, 1, 2, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 500, 5, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 5, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 3, 1, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 5, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 5, 2, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 8, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 5, 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 2, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 1, 5, new DateTime(2024, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 8, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 465, 2, 4, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 4, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 696, 3, 4, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 624, 5, 6, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 3, new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 2, 4, new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 8, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 147, 5, 4, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 9, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 324, 2, 5, new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 5, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 4, 4, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 8, new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 411, 1, 1, new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 28, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 5, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 703, 2, 4, new DateTime(2024, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 8, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 4, 4, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 8, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 2, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 8, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 159, 3, 1, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 8, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 2, 3, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 4, new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 325, 2, 3, new DateTime(2024, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 5, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 406, 4, 1, new DateTime(2024, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 263, 4, 3, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 5, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 443, 4, 3, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 1, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 315, 4, 1, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 6, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 4, 2, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 8, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 2, 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 1, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 221, 2, 3, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 1, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 4, 4, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 2, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 461, 2, 6, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 3, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 555, 3, 2, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 4, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 5, 5, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 9, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 338, 4, 1, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 2, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 272, 4, 4, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 5, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 2, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 233, 5, 5, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 7, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 320, 3, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 7, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, 1, new DateTime(2024, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 8, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 541, 1, 2, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 8, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 423, 1, 6, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 3, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 402, 5, 6, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 4, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 4, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 427, 1, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 5, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 298, 2, 2, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 8, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 273, 4, 6, new DateTime(2024, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 4, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 327, 2, 3, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 5, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 251, 3, 1, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 2, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 340, 4, 2, new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 8, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 4, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 481, 3, 3, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 1, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, 5, 5, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 4, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 333, 1, 6, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 4, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 446, 1, 6, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 6, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 298, 2, 5, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 22, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 1, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 572, 1, 6, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 5, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 534, 3, 6, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 6, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 583, 2, 1, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 470, 5, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 5, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 457, 5, 1, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 1, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 157, 3, 5, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 4, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 156, 5, 3, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 2, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 644, 2, 3, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 7, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 630, 5, 6, new DateTime(2024, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 4, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 539, 3, 4, new DateTime(2024, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 9, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 1, 2, new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 7, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 3, 6, new DateTime(2024, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 458, 1, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 7, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 282, 4, 1, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 6, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 528, 5, 2, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 2, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 288, 4, 6, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 2, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 494, 2, 5, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 1, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 336, 1, 4, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 9, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 630, 3, 3, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 8, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 401, 5, 5, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 5, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 514, 3, 1, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 18, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 2, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 430, 4, 6, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 7, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 192, 5, 4, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 2, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 5, 5, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 9, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 159, 3, 3, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 4, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 581, 2, 5, new DateTime(2024, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 27, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 3, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 5, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 328, 5, 4, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 1, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 536, 3, 5, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 472, 4, 5, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 3, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 500, 3, 1, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 8, new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 632, 2, 2, new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 27, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 5, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 4, 5, new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 7, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 274, 3, 2, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 333, 4, 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 5, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 639, 1, 1, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 4, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 462, 5, 6, new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Delays_RouteId",
                table: "Delays",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Delays_TypeId",
                table: "Delays",
                column: "TypeId");

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
                name: "IX_Malfunctions_StationId",
                table: "Malfunctions",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Malfunctions_VehicleId",
                table: "Malfunctions",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_ManufacturerCountryId",
                table: "Manufacturers",
                column: "ManufacturerCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);

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
                name: "IX_Stations_Name",
                table: "Stations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_Name",
                table: "Statuses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Name",
                table: "Tickets",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Types_Name",
                table: "Types",
                column: "Name",
                unique: true);

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
                name: "IX_Vehicles_Number",
                table: "Vehicles",
                column: "Number",
                unique: true);

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
                name: "Delays");

            migrationBuilder.DropTable(
                name: "IssuedTickets");

            migrationBuilder.DropTable(
                name: "Malfunctions");

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

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
