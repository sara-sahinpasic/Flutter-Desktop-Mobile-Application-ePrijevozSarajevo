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
                    { 1, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7560), "Afghanistan" },
                    { 2, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7567), "Albania" },
                    { 3, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7568), "Algeria" },
                    { 4, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7569), "Andorra" },
                    { 5, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7570), "Angola" },
                    { 6, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7572), "Antigua and Barbuda" },
                    { 7, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7573), "Argentina" },
                    { 8, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7573), "Armenia" },
                    { 9, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7574), "Australia" },
                    { 10, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7576), "Austria" },
                    { 11, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7576), "Azerbaijan" },
                    { 12, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7577), "Bahrain" },
                    { 13, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7578), "Bangladesh" },
                    { 14, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7579), "Barbados" },
                    { 15, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7580), "Belarus" },
                    { 16, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7581), "Belgium" },
                    { 17, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7582), "Belize" },
                    { 18, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7583), "Benin" },
                    { 19, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7584), "Bhutan" },
                    { 20, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7585), "Bolivia" },
                    { 21, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7585), "Bosnia and Herzegovina" },
                    { 22, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7586), "Botswana" },
                    { 23, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7587), "Brazil" },
                    { 24, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7588), "Brunei" },
                    { 25, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7589), "Bulgaria" },
                    { 26, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7589), "Burkina Faso" },
                    { 27, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7590), "Burundi" },
                    { 28, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7591), "Cambodia" },
                    { 29, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7592), "Cameroon" },
                    { 30, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7593), "Canada" },
                    { 31, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7594), "Cape Verde" },
                    { 32, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7594), "Central African Republic" },
                    { 33, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7595), "Chad" },
                    { 34, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7596), "Chile" },
                    { 35, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7597), "China" },
                    { 36, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7598), "Colombia" },
                    { 37, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7599), "Comoros" },
                    { 38, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7600), "Congo" },
                    { 39, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7601), "Congo (Democratic Republic)" },
                    { 40, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7601), "Costa Rica" },
                    { 41, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7602), "Croatia" },
                    { 42, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7603), "Cuba" },
                    { 43, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7604), "Cyprus" },
                    { 44, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7605), "Czechia" },
                    { 45, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7605), "Denmark" },
                    { 46, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7606), "Djibouti" },
                    { 47, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7607), "Dominica" },
                    { 48, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7608), "Dominican Republic" },
                    { 49, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7609), "East Timor" },
                    { 50, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7610), "Ecuador" },
                    { 51, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7611), "Egypt" },
                    { 52, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7611), "El Salvador" },
                    { 53, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7612), "Equatorial Guinea" },
                    { 54, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7613), "Eritrea" },
                    { 55, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7614), "Estonia" },
                    { 56, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7615), "Eswatini" },
                    { 57, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7615), "Ethiopia" },
                    { 58, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7616), "Fiji" },
                    { 59, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7617), "Finland" },
                    { 60, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7618), "France" },
                    { 61, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7619), "Gabon" },
                    { 62, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7619), "Georgia" },
                    { 63, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7620), "Germany" },
                    { 64, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7621), "Ghana" },
                    { 65, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7622), "Greece" },
                    { 66, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7623), "Grenada" },
                    { 67, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7624), "Guatemala" },
                    { 68, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7625), "Guinea" },
                    { 69, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7626), "Guinea-Bissau" },
                    { 70, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7627), "Guyana" },
                    { 71, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7627), "Haiti" },
                    { 72, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7628), "Honduras" },
                    { 73, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7629), "Hungary" },
                    { 74, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7630), "Iceland" },
                    { 75, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7631), "India" },
                    { 76, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7632), "Indonesia" },
                    { 77, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7632), "Iran" },
                    { 78, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7633), "Iraq" },
                    { 79, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7634), "Ireland" },
                    { 80, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7635), "Israel" },
                    { 81, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7636), "Italy" },
                    { 82, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7636), "Ivory Coast" },
                    { 83, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7637), "Jamaica" },
                    { 84, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7638), "Japan" },
                    { 85, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7639), "Jordan" },
                    { 86, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7640), "Kazakhstan" },
                    { 87, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7641), "Kenya" },
                    { 88, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7642), "Kiribati" },
                    { 89, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7642), "Kosovo" },
                    { 90, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7647), "Kuwait" },
                    { 91, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7649), "Kyrgyzstan" },
                    { 92, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7649), "Laos" },
                    { 93, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7650), "Latvia" },
                    { 94, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7651), "Lebanon" },
                    { 95, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7652), "Lesotho" },
                    { 96, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7653), "Liberia" },
                    { 97, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7653), "Libya" },
                    { 98, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7654), "Liechtenstein" },
                    { 99, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7655), "Lithuania" },
                    { 100, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7656), "Luxembourg" },
                    { 101, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7657), "Madagascar" },
                    { 102, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7657), "Malawi" },
                    { 103, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7658), "Malaysia" },
                    { 104, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7659), "Maldives" },
                    { 105, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7660), "Mali" },
                    { 106, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7661), "Malta" },
                    { 107, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7662), "Marshall Islands" },
                    { 108, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7662), "Mauritania" },
                    { 109, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7663), "Mauritius" },
                    { 110, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7664), "Mexico" },
                    { 111, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7665), "Federated States of Micronesia" },
                    { 112, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7666), "Moldova" },
                    { 113, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7666), "Monaco" },
                    { 114, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7667), "Mongolia" },
                    { 115, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7668), "Montenegro" },
                    { 116, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7669), "Morocco" },
                    { 117, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7670), "Mozambique" },
                    { 118, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7670), "Myanmar (Burma)" },
                    { 119, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7671), "Namibia" },
                    { 120, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7672), "Nauru" },
                    { 121, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7673), "Nepal" },
                    { 122, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7674), "Netherlands" },
                    { 123, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7675), "New Zealand" },
                    { 124, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7675), "Nicaragua" },
                    { 125, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7676), "Niger" },
                    { 126, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7677), "Nigeria" },
                    { 127, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7678), "North Korea" },
                    { 128, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7679), "North Macedonia" },
                    { 129, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7679), "Norway" },
                    { 130, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7681), "Oman" },
                    { 131, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7681), "Pakistan" },
                    { 132, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7682), "Palau" },
                    { 133, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7683), "Panama" },
                    { 134, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7684), "Papua New Guinea" },
                    { 135, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7685), "Paraguay" },
                    { 136, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7685), "Peru" },
                    { 137, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7686), "Philippines" },
                    { 138, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7687), "Poland" },
                    { 139, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7688), "Portugal" },
                    { 140, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7689), "Qatar" },
                    { 141, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7689), "Romania" },
                    { 142, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7690), "Russia" },
                    { 143, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7691), "Rwanda" },
                    { 144, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7692), "St Kitts and Nevis" },
                    { 145, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7693), "St Lucia" },
                    { 146, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7693), "St Vincent" },
                    { 147, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7694), "Samoa" },
                    { 148, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7695), "San Marino" },
                    { 149, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7696), "Sao Tome and Principe" },
                    { 150, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7697), "Saudi Arabia" },
                    { 151, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7697), "Senegal" },
                    { 152, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7698), "Serbia" },
                    { 153, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7699), "Seychelles" },
                    { 154, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7700), "Sierra Leone" },
                    { 155, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7701), "Singapore" },
                    { 156, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7701), "Slovakia" },
                    { 157, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7702), "Slovenia" },
                    { 158, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7703), "Solomon Islands" },
                    { 159, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7704), "Somalia" },
                    { 160, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7705), "South Africa" },
                    { 161, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7706), "South Korea" },
                    { 162, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7706), "South Sudan" },
                    { 163, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7707), "Spain" },
                    { 164, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7708), "Sri Lanka" },
                    { 165, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7709), "Sudan" },
                    { 166, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7710), "Suriname" },
                    { 167, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7710), "Sweden" },
                    { 168, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7711), "Switzerland" },
                    { 169, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7712), "Syria" },
                    { 170, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7713), "Tajikistan" },
                    { 171, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7714), "Tanzania" },
                    { 172, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7714), "Thailand" },
                    { 173, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7715), "The Bahamas" },
                    { 174, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7716), "The Gambia" },
                    { 175, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7717), "Togo" },
                    { 176, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7718), "Tonga" },
                    { 177, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7718), "Trinidad and Tobago" },
                    { 178, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7719), "Tunisia" },
                    { 179, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7720), "Turkey" },
                    { 180, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7721), "Turkmenistan" },
                    { 181, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7722), "Tuvalu" },
                    { 182, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7722), "Uganda" },
                    { 183, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7723), "Ukraine" },
                    { 184, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7724), "United Arab Emirates" },
                    { 185, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7725), "United Kingdom" },
                    { 186, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7726), "United States" },
                    { 187, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7726), "Uruguay" },
                    { 188, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7727), "Uzbekistan" },
                    { 189, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7728), "Vanuatu" },
                    { 190, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7729), "Vatican City" },
                    { 191, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7730), "Venezuela" },
                    { 192, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7730), "Vietnam" },
                    { 193, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7731), "Yemen" },
                    { 194, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7732), "Zambia" },
                    { 195, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7733), "Zimbabwe" }
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
                    { 1, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7884), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7882), "Ilidža" },
                    { 2, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7886), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7885), "Stup" },
                    { 3, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7888), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7889), "Nedžarići" },
                    { 4, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7890), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7891), "Socijalno" },
                    { 5, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7892), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7893), "Malta" },
                    { 6, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7894), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7895), "Baščaršija" },
                    { 7, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7896), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7898), "Otoka" },
                    { 8, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7899), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7900), "Skenderija" },
                    { 9, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7901), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7902), "Drvenija" },
                    { 10, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7904), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7905), "Dobrinja" },
                    { 11, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7907), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7908), "Grbavica" },
                    { 12, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7909), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7910), "Hrasno" },
                    { 13, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7911), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7912), "Aneks" },
                    { 14, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7914), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7915), "Alipašino polje" },
                    { 15, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7916), new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7917), "Švrakino selo" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "CurrentUserId", "Discount", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, 0.0, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8027), "Default" },
                    { 2, null, 0.29999999999999999, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8029), "Student" },
                    { 3, null, 0.5, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8031), "Penzioner" },
                    { 4, null, 0.14999999999999999, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8032), "Zaposlenik" },
                    { 5, null, 0.40000000000000002, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8034), "Nezaposlen" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CurrentUserId", "ModifiedDate", "Name", "Price", "StateMachine" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8044), "Jednosmjerna", 1.8, "draft" },
                    { 2, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8046), "Povratna", 3.2000000000000002, "draft" },
                    { 3, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8047), "Jednosmjerna dječija", 0.80000000000000004, "draft" },
                    { 4, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8049), "Povratna dječija", 1.2, "draft" },
                    { 5, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8050), "Mjesečna", 75.0, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "CurrentUserId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7975), "Trolejbus" },
                    { 2, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7976), "Tramvaj" },
                    { 3, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7978), "Minibus" },
                    { 4, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7979), "Autobus" },
                    { 5, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7980), "Kombi" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "CurrentUserId", "ManufacturerCountryId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7945), "MAN" },
                    { 2, null, 2, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7947), "Solaris" },
                    { 3, null, 3, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7950), "Volvo" },
                    { 4, null, 4, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7955), "Mercedes" },
                    { 5, null, 5, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7958), "Setra" },
                    { 6, null, 6, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7959), "Neoplan" },
                    { 7, null, 7, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7961), "Siemens" },
                    { 8, null, 8, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7962), "Traton" },
                    { 9, null, 9, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7964), "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "City", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImage", "RegistrationDate", "StatusExpirationDate", "UserCountryId", "UserName", "UserStatusId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6508), "y/OimZhhIz7tnipKM8DxQSPA5KY=", "36jWlfL2r7dDAR7iHywfxg==", "+38761222333", null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6507), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevoapp@gmail.com", "Senada", "Senadić", new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6519), "iR8IuPYuaXMJjkg7j8Bff9IITcs=", "LhFupQ4GfYKSAUk7YGu/Kg==", "+38761222444", null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6518), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 1, "72000" },
                    { 3, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Test", "Testni", new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6524), "209+S5CKSwcrM58PdYBUv4mhLlc=", "70cjOeE8Ttai5wiFwrOfRA==", "+38761222444", null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6523), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevotest@outlook.com", "Testni", "Test", new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6529), "NEeMApJc+qaG3Wm4ZHU0FUx233E=", "KProqb2sJtnQ2AbFkZpS2A==", "+38761222666", null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6528), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevo.app@gmx.de", "Proba", "Probni", new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6534), "1+8wOJDrkDoVAM0Trc2KUFCeM1Y=", "7VEyDT873TghBzuKsWWsEg==", "+38761222777", null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6533), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6541), "hoTC5IRPEyft54WqnMo0E2RsjGg=", "O8KmtBwmtlnjBnRO540dFw==", "+38761222888", null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(6540), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "Active", "Approved", "DateCreated", "RejectionReason", "UserId", "UserStatusId" },
                values: new object[,]
                {
                    { 2, true, false, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7785), "", 3, 5 },
                    { 3, true, false, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7788), "", 4, 2 },
                    { 4, true, false, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7790), "", 5, 4 },
                    { 5, true, false, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7792), "", 1, 2 },
                    { 6, true, false, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(7794), "", 6, 3 }
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
                    { 1, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8059), "Opis kvara: Test 1", true, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8062), 1, 1 },
                    { 2, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8063), "Opis kvara: Test 2", false, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8065), 2, 2 },
                    { 3, null, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8067), "Opis kvara: Test 3", true, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8068), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 5 },
                    { 2, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 3, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 4, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 6 },
                    { 5, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 2 },
                    { 6, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 6 },
                    { 7, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 8, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 2 },
                    { 9, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 1 },
                    { 10, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 2 },
                    { 11, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 2 },
                    { 12, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 5 },
                    { 13, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 14, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 15, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 2 },
                    { 16, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 1 },
                    { 17, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 18, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 5 },
                    { 19, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 5 },
                    { 20, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 5 },
                    { 21, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 22, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 6 },
                    { 23, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 2 },
                    { 24, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 25, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 4 },
                    { 26, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 2 },
                    { 27, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 6 },
                    { 28, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 5 },
                    { 29, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 6 },
                    { 30, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 5 },
                    { 31, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 32, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 4 },
                    { 33, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 3 },
                    { 34, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 5 },
                    { 35, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 1 },
                    { 36, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 1 },
                    { 37, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 3 },
                    { 38, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 4 },
                    { 39, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 40, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 5 },
                    { 41, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 3 },
                    { 42, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 2 },
                    { 43, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 3 },
                    { 44, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 5 },
                    { 45, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 2 },
                    { 46, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 1 },
                    { 47, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 6 },
                    { 48, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 49, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 50, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 1 },
                    { 51, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 5 },
                    { 52, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 1 },
                    { 53, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 2 },
                    { 54, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 55, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 6 },
                    { 56, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 2 },
                    { 57, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 2 },
                    { 58, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 59, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 2 },
                    { 60, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 1 },
                    { 61, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 62, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 63, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 5 },
                    { 64, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 1 },
                    { 65, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 66, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 4 },
                    { 67, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 6 },
                    { 68, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 6 },
                    { 69, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 3 },
                    { 70, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 2 },
                    { 71, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 72, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 6 },
                    { 73, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 74, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 3 },
                    { 75, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 3 },
                    { 76, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 3 },
                    { 77, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 2 },
                    { 78, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 79, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 5 },
                    { 80, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 2 },
                    { 81, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 4 },
                    { 82, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 3 },
                    { 83, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 6 },
                    { 84, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 85, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 3 },
                    { 86, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 87, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 3 },
                    { 88, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 89, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 90, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 91, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 4 },
                    { 92, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 1 },
                    { 93, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 1 },
                    { 94, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 5 },
                    { 95, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 1 },
                    { 96, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 6 },
                    { 97, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 5 },
                    { 98, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 2 },
                    { 99, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 6 },
                    { 100, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 6 },
                    { 101, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 4 },
                    { 102, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 5 },
                    { 103, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 2 },
                    { 104, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 1 },
                    { 105, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 106, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 2 },
                    { 107, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 3 },
                    { 108, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 6 },
                    { 109, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 110, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 1 },
                    { 111, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 4 },
                    { 112, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 113, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 3 },
                    { 114, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 115, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 116, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 1 },
                    { 117, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 1 },
                    { 118, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 1 },
                    { 119, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 1 },
                    { 120, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 2 },
                    { 121, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 122, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 },
                    { 123, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 124, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 2 },
                    { 125, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 1 },
                    { 126, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 3 },
                    { 127, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 128, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 129, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 5 },
                    { 130, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 6 },
                    { 131, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 1 },
                    { 132, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 5 },
                    { 133, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 1 },
                    { 134, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 135, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 5 },
                    { 136, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 4 },
                    { 137, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 4 },
                    { 138, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 139, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 140, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 1 },
                    { 141, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 3 },
                    { 142, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 143, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 144, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 5 },
                    { 145, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 2 },
                    { 146, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 3 },
                    { 147, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 6 },
                    { 148, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 5 },
                    { 149, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 6 },
                    { 150, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 6 },
                    { 151, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 3 },
                    { 152, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 5 },
                    { 153, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 154, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 155, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 2 },
                    { 156, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 6 },
                    { 157, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 2 },
                    { 158, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 159, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 160, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 4 },
                    { 161, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 1 },
                    { 162, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 6 },
                    { 163, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 164, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 5 },
                    { 165, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 4 },
                    { 166, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 4 },
                    { 167, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 1 },
                    { 168, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 2 },
                    { 169, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 3 },
                    { 170, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 2 },
                    { 171, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 5 },
                    { 172, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 2 },
                    { 173, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 174, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 3 },
                    { 175, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 1 },
                    { 176, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 2 },
                    { 177, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 1 },
                    { 178, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 4 },
                    { 179, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 1 },
                    { 180, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 5 },
                    { 181, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 182, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 183, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 3 },
                    { 184, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 185, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 186, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 187, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 4 },
                    { 188, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 4 },
                    { 189, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 190, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 191, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 5 },
                    { 192, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 193, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 1 },
                    { 194, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 195, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 196, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 5 },
                    { 197, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 2 },
                    { 198, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 199, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 2 },
                    { 200, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 6 },
                    { 201, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 3 },
                    { 202, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 3 },
                    { 203, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 204, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 205, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 1 },
                    { 206, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 2 },
                    { 207, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 1 },
                    { 208, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 209, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 5 },
                    { 210, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 1 },
                    { 211, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 5 },
                    { 212, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 1 },
                    { 213, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 6 },
                    { 214, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 2 },
                    { 215, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 1 },
                    { 216, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 4 },
                    { 217, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 2 },
                    { 218, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 5 },
                    { 219, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 4 },
                    { 220, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 221, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 3 },
                    { 222, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 4 },
                    { 223, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 5 },
                    { 224, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 6 },
                    { 225, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 4 },
                    { 226, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 5 },
                    { 227, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 5 },
                    { 228, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 1 },
                    { 229, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 3 },
                    { 230, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 1 },
                    { 231, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 6 },
                    { 232, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 4 },
                    { 233, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 2 },
                    { 234, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 235, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 2 },
                    { 236, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 237, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 2 },
                    { 238, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 4 },
                    { 239, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 5 },
                    { 240, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 4 },
                    { 241, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 242, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 6 },
                    { 243, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 244, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 1 },
                    { 245, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 6 },
                    { 246, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 247, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 248, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 5 },
                    { 249, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 6 },
                    { 250, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 6 },
                    { 251, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 4 },
                    { 252, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 253, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 2 },
                    { 254, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 255, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 256, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 5 },
                    { 257, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 3 },
                    { 258, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 259, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 260, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 2 },
                    { 261, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 3 },
                    { 262, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 6 },
                    { 263, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 5 },
                    { 264, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 4 },
                    { 265, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 5 },
                    { 266, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 6 },
                    { 267, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 4 },
                    { 268, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 6 },
                    { 269, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 5 },
                    { 270, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 1 },
                    { 271, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 4 },
                    { 272, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 2 },
                    { 273, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 6 },
                    { 274, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 2 },
                    { 275, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 6 },
                    { 276, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 3 },
                    { 277, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 4 },
                    { 278, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 3 },
                    { 279, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 6 },
                    { 280, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 4 },
                    { 281, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 1 },
                    { 282, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 283, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 3 },
                    { 284, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 2 },
                    { 285, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 286, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 2 },
                    { 287, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 288, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 289, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 1 },
                    { 290, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 6 },
                    { 291, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 6 },
                    { 292, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 293, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 2 },
                    { 294, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 3 },
                    { 295, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 2 },
                    { 296, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 2 },
                    { 297, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 4 },
                    { 298, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 299, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 1 },
                    { 300, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 5 },
                    { 301, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 302, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 1 },
                    { 303, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 6 },
                    { 304, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 305, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 306, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 4 },
                    { 307, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 4 },
                    { 308, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 2 },
                    { 309, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 310, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 3 },
                    { 311, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 312, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 3 },
                    { 313, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 5 },
                    { 314, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 4 },
                    { 315, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 5 },
                    { 316, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 317, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 1 },
                    { 318, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 319, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 4 },
                    { 320, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 2 },
                    { 321, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 5 },
                    { 322, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 3 },
                    { 323, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 324, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 4 },
                    { 325, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 6 },
                    { 326, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 327, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 4 },
                    { 328, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 6 },
                    { 329, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 330, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 2 },
                    { 331, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 332, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 6 },
                    { 333, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 4 },
                    { 334, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 4 },
                    { 335, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 2 },
                    { 336, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 5 },
                    { 337, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 6 },
                    { 338, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 4 },
                    { 339, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 4 },
                    { 340, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 2 },
                    { 341, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 5 },
                    { 342, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 3 },
                    { 343, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 4 },
                    { 344, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 5 },
                    { 345, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 6 },
                    { 346, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 6 },
                    { 347, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 4 },
                    { 348, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 3 },
                    { 349, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 1 },
                    { 350, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 1 },
                    { 351, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 5 },
                    { 352, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 1 },
                    { 353, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 2 },
                    { 354, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 5 },
                    { 355, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 5 },
                    { 356, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 4 },
                    { 357, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 2 },
                    { 358, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 2 },
                    { 359, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 4 },
                    { 360, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 361, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 362, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 363, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 5 },
                    { 364, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 2 },
                    { 365, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 2 },
                    { 366, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 6 },
                    { 367, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 5 },
                    { 368, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 4 },
                    { 369, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 1 },
                    { 370, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 1 },
                    { 371, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 1 },
                    { 372, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 3 },
                    { 373, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 3 },
                    { 374, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 375, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 1 },
                    { 376, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 377, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 1 },
                    { 378, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 4 },
                    { 379, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 5 },
                    { 380, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 4 },
                    { 381, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 382, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 2 },
                    { 383, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 },
                    { 384, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 385, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 386, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 4 },
                    { 387, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 6 },
                    { 388, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 3 },
                    { 389, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 1 },
                    { 390, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 5 },
                    { 391, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 392, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 4 },
                    { 393, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 5 },
                    { 394, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 5 },
                    { 395, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 1 },
                    { 396, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 3 },
                    { 397, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 1 },
                    { 398, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 5 },
                    { 399, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 2 },
                    { 400, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 6 },
                    { 401, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 402, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 5 },
                    { 403, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 2 },
                    { 404, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 2 },
                    { 405, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 2 },
                    { 406, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 1 },
                    { 407, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 5 },
                    { 408, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 1 },
                    { 409, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 5 },
                    { 410, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 6 },
                    { 411, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 3 },
                    { 412, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 6 },
                    { 413, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 3 },
                    { 414, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 5 },
                    { 415, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 1 },
                    { 416, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 6 },
                    { 417, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 3 },
                    { 418, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 5 },
                    { 419, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 1 },
                    { 420, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 421, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 5 },
                    { 422, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 6 },
                    { 423, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 424, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 425, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 6 },
                    { 426, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 2 },
                    { 427, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 428, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 5 },
                    { 429, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 3 },
                    { 430, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 3 },
                    { 431, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 432, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 433, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 434, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 6 },
                    { 435, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 5 },
                    { 436, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 5 },
                    { 437, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 438, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 2 },
                    { 439, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 440, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 5 },
                    { 441, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 3 },
                    { 442, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 5 },
                    { 443, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 444, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 5 },
                    { 445, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 446, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 447, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 448, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 1 },
                    { 449, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 3 },
                    { 450, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 2 },
                    { 451, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 452, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 2 },
                    { 453, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 454, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 2 },
                    { 455, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 4 },
                    { 456, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 4 },
                    { 457, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 4 },
                    { 458, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 459, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 1 },
                    { 460, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 6 },
                    { 461, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 5 },
                    { 462, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 463, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 4 },
                    { 464, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 4 },
                    { 465, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 3 },
                    { 466, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 1 },
                    { 467, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 4 },
                    { 468, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 5 },
                    { 469, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 1 },
                    { 470, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 2 },
                    { 471, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 472, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 473, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 4 },
                    { 474, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 475, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 6 },
                    { 476, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 2 },
                    { 477, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 2 },
                    { 478, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 479, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 5 },
                    { 480, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 481, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 6 },
                    { 482, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 3 },
                    { 483, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 484, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 485, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 2 },
                    { 486, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 6 },
                    { 487, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 2 },
                    { 488, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 4 },
                    { 489, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 490, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 3 },
                    { 491, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 6 },
                    { 492, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 1 },
                    { 493, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 2 },
                    { 494, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 6 },
                    { 495, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 4 },
                    { 496, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 6 },
                    { 497, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 4 },
                    { 498, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 6 },
                    { 499, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 2 },
                    { 500, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 501, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 5 },
                    { 502, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 2 },
                    { 503, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 504, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 505, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 6 },
                    { 506, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 3 },
                    { 507, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 6 },
                    { 508, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 6 },
                    { 509, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 4 },
                    { 510, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 511, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 2 },
                    { 512, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 1 },
                    { 513, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 514, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 4 },
                    { 515, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 516, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 5 },
                    { 517, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 2 },
                    { 518, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 2 },
                    { 519, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 520, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 521, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 5 },
                    { 522, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 4 },
                    { 523, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 524, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 525, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 526, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 527, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 1 },
                    { 528, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 4 },
                    { 529, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 2 },
                    { 530, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 531, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 3 },
                    { 532, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 1 },
                    { 533, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 3 },
                    { 534, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 535, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 4 },
                    { 536, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 537, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 5 },
                    { 538, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 539, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 6 },
                    { 540, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 3 },
                    { 541, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 6 },
                    { 542, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 4 },
                    { 543, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 2 },
                    { 544, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 1 },
                    { 545, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 3 },
                    { 546, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 547, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 5 },
                    { 548, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 2 },
                    { 549, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 550, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 551, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 552, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 553, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 554, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 5 },
                    { 555, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 5 },
                    { 556, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 2 },
                    { 557, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 558, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 2 },
                    { 559, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 6 },
                    { 560, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 561, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 5 },
                    { 562, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 2 },
                    { 563, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 6 },
                    { 564, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 5 },
                    { 565, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 4 },
                    { 566, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 4 },
                    { 567, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 5 },
                    { 568, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 4 },
                    { 569, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 570, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 1 },
                    { 571, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 1 },
                    { 572, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 5 },
                    { 573, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 574, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 6 },
                    { 575, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 576, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 577, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 1 },
                    { 578, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 2 },
                    { 579, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 580, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 1 },
                    { 581, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 582, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 583, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 4 },
                    { 584, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 4 },
                    { 585, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 2 },
                    { 586, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 3 },
                    { 587, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 4 },
                    { 588, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 5 },
                    { 589, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 5 },
                    { 590, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 591, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 1 },
                    { 592, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 5 },
                    { 593, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 594, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 3 },
                    { 595, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 5 },
                    { 596, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 597, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 2 },
                    { 598, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 4 },
                    { 599, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 6 },
                    { 600, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 3 },
                    { 601, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 1 },
                    { 602, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 6 },
                    { 603, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 604, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 605, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 3 },
                    { 606, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 6 },
                    { 607, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 608, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 5 },
                    { 609, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 3 },
                    { 610, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 1 },
                    { 611, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 2 },
                    { 612, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 613, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 6 },
                    { 614, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 6 },
                    { 615, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 616, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 3 },
                    { 617, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 3 },
                    { 618, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 1 },
                    { 619, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 620, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 2 },
                    { 621, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 4 },
                    { 622, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 623, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 624, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 625, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 626, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 4 },
                    { 627, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 2 },
                    { 628, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 6 },
                    { 629, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 3 },
                    { 630, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 631, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 4 },
                    { 632, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 5 },
                    { 633, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 4 },
                    { 634, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 6 },
                    { 635, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 1 },
                    { 636, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 1 },
                    { 637, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 3 },
                    { 638, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 639, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 640, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 4 },
                    { 641, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 5 },
                    { 642, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 2 },
                    { 643, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 2 },
                    { 644, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 5 },
                    { 645, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 4 },
                    { 646, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 5 },
                    { 647, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 4 },
                    { 648, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 649, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 650, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 651, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 2 },
                    { 652, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 1 },
                    { 653, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 3 },
                    { 654, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 3 },
                    { 655, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 656, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 3 },
                    { 657, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 6 },
                    { 658, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 3 },
                    { 659, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 3 },
                    { 660, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 6 },
                    { 661, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 1 },
                    { 662, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 663, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 2 },
                    { 664, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 1 },
                    { 665, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 666, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 667, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 3 },
                    { 668, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 1 },
                    { 669, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 670, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 671, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 4 },
                    { 672, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 3 },
                    { 673, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 6 },
                    { 674, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 4 },
                    { 675, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 5 },
                    { 676, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 1 },
                    { 677, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 5 },
                    { 678, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 5 },
                    { 679, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 680, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 6 },
                    { 681, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 682, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 6 },
                    { 683, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 684, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 685, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 1 },
                    { 686, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 687, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 2 },
                    { 688, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 3 },
                    { 689, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 1 },
                    { 690, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 1 },
                    { 691, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 1 },
                    { 692, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 693, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 1 },
                    { 694, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 5 },
                    { 695, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 3 },
                    { 696, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 6 },
                    { 697, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 2 },
                    { 698, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 2 },
                    { 699, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 2 },
                    { 700, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 701, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 5 },
                    { 702, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 4 },
                    { 703, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 5 },
                    { 704, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 3 },
                    { 705, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 5 },
                    { 706, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 5 },
                    { 707, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 3 },
                    { 708, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 4 },
                    { 709, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 710, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 3 },
                    { 711, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 6 },
                    { 712, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 2 },
                    { 713, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 5 },
                    { 714, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "Delays",
                columns: new[] { "DelayId", "CurrentUserId", "DelayAmountMinutes", "ModifiedDate", "Reason", "RouteId", "TypeId" },
                values: new object[,]
                {
                    { 1, null, 30, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8077), "Gužva", 1, 1 },
                    { 2, null, 60, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8082), "Udes", 2, 2 },
                    { 3, null, 15, new DateTime(2025, 1, 26, 19, 44, 24, 493, DateTimeKind.Local).AddTicks(8084), "Led", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "IssuedTickets",
                columns: new[] { "IssuedTicketId", "Amount", "IssuedDate", "RouteId", "TicketId", "UserId", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 261, 5, 4, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 356, 2, 3, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 447, 2, 4, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 26, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 8, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 470, 3, 5, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 6, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 526, 3, 4, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 693, 3, 6, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 406, 5, 5, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 4, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 329, 3, 4, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 6, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 361, 5, 5, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 2, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 5, 5, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 349, 5, 5, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 7, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 429, 3, 5, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 8, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 419, 4, 5, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 7, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 5, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 6, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 540, 4, 1, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 3, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 285, 1, 3, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 341, 3, 6, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 472, 5, 5, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 708, 5, 2, new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 3, 6, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 5, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 453, 2, 6, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 9, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 227, 1, 5, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 4, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 533, 3, 4, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 3, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 332, 4, 4, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 4, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 634, 3, 3, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 3, 6, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 4, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 225, 4, 3, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 8, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 412, 5, 6, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 8, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 161, 1, 3, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 713, 3, 5, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 6, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 3, 4, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 5, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 527, 5, 1, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 5, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 2, 2, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 4, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 236, 2, 5, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 3, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 316, 1, 6, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 373, 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 9, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 2, 5, new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 21, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 3, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 4, 6, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 26, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 3, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 423, 3, 6, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 9, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 630, 3, 1, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 7, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 499, 1, 4, new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 6, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 476, 1, 6, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 625, 1, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 3, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 429, 2, 3, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 4, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 647, 1, 3, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 4, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 2, 3, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 9, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 270, 4, 4, new DateTime(2024, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 631, 2, 3, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 6, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 355, 5, 4, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 4, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 163, 4, 2, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 11, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 4, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 420, 2, 4, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 1, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 4, 5, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 9, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 5, 5, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 5, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 118, 1, 6, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 8, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3, 5, new DateTime(2024, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 7, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 684, 3, 4, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 9, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 507, 2, 2, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 7, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 402, 5, 3, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 7, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 658, 2, 4, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 3, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 459, 5, 5, new DateTime(2024, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 2, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 336, 1, 1, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 9, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 618, 1, 6, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 4, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 676, 1, 6, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 6, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 157, 4, 2, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 7, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 3, 2, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 7, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 334, 2, 5, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 262, 2, 4, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 9, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 1, 1, new DateTime(2024, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 6, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 469, 3, 4, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 7, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 493, 1, 4, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 6, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 576, 5, 5, new DateTime(2024, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 9, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 217, 1, 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 6, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 3, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 2, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 5, 6, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 8, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 226, 3, 2, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 7, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 441, 1, 1, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 4, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 626, 2, 5, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 8, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 286, 1, 1, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 6, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 187, 5, 3, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 7, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 4, 5, new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 2, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 586, 4, 4, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 8, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 479, 1, 1, new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 8, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 341, 4, 4, new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 1, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 2, 1, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 4, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 284, 1, 5, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 28, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 2, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 512, 1, 2, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 2, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 4, 5, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 1, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 238, 5, 2, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 4, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 2, 5, new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 21, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 8, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 457, 1, 2, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 1, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 3, 4, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 6, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, 2, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 1, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 4, 4, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 248, 2, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 3, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 571, 1, 2, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 1, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 1, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 6, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 1, 6, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 2, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 448, 3, 1, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 1, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 330, 5, 2, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
