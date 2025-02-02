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
                name: "VrijednostRaspolozenjas",
                columns: table => new
                {
                    VrijednostRaspolozenjaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrijednostRaspolozenjas", x => x.VrijednostRaspolozenjaId);
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
                name: "MoodTracker30012025s",
                columns: table => new
                {
                    MoodTracker30012025Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    VrijednostRaspolozenjaId = table.Column<int>(type: "int", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumEvidencije = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoodTracker30012025s", x => x.MoodTracker30012025Id);
                    table.ForeignKey(
                        name: "FK_MoodTracker30012025s_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_MoodTracker30012025s_VrijednostRaspolozenjas_VrijednostRaspolozenjaId",
                        column: x => x.VrijednostRaspolozenjaId,
                        principalTable: "VrijednostRaspolozenjas",
                        principalColumn: "VrijednostRaspolozenjaId");
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
                    { 1, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(834), "Afghanistan" },
                    { 2, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(843), "Albania" },
                    { 3, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(845), "Algeria" },
                    { 4, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(846), "Andorra" },
                    { 5, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(847), "Angola" },
                    { 6, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(848), "Antigua and Barbuda" },
                    { 7, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(849), "Argentina" },
                    { 8, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(850), "Armenia" },
                    { 9, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(851), "Australia" },
                    { 10, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(852), "Austria" },
                    { 11, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(853), "Azerbaijan" },
                    { 12, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(854), "Bahrain" },
                    { 13, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(855), "Bangladesh" },
                    { 14, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(856), "Barbados" },
                    { 15, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(857), "Belarus" },
                    { 16, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(857), "Belgium" },
                    { 17, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(858), "Belize" },
                    { 18, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(860), "Benin" },
                    { 19, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(860), "Bhutan" },
                    { 20, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(861), "Bolivia" },
                    { 21, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(862), "Bosnia and Herzegovina" },
                    { 22, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(863), "Botswana" },
                    { 23, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(864), "Brazil" },
                    { 24, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(865), "Brunei" },
                    { 25, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(866), "Bulgaria" },
                    { 26, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(866), "Burkina Faso" },
                    { 27, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(867), "Burundi" },
                    { 28, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(868), "Cambodia" },
                    { 29, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(869), "Cameroon" },
                    { 30, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(870), "Canada" },
                    { 31, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(871), "Cape Verde" },
                    { 32, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(872), "Central African Republic" },
                    { 33, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(872), "Chad" },
                    { 34, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(874), "Chile" },
                    { 35, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(874), "China" },
                    { 36, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(875), "Colombia" },
                    { 37, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(876), "Comoros" },
                    { 38, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(877), "Congo" },
                    { 39, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(878), "Congo (Democratic Republic)" },
                    { 40, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(879), "Costa Rica" },
                    { 41, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(880), "Croatia" },
                    { 42, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(880), "Cuba" },
                    { 43, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(881), "Cyprus" },
                    { 44, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(882), "Czechia" },
                    { 45, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(888), "Denmark" },
                    { 46, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(889), "Djibouti" },
                    { 47, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(890), "Dominica" },
                    { 48, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(891), "Dominican Republic" },
                    { 49, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(891), "East Timor" },
                    { 50, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(892), "Ecuador" },
                    { 51, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(893), "Egypt" },
                    { 52, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(894), "El Salvador" },
                    { 53, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(895), "Equatorial Guinea" },
                    { 54, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(896), "Eritrea" },
                    { 55, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(896), "Estonia" },
                    { 56, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(897), "Eswatini" },
                    { 57, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(898), "Ethiopia" },
                    { 58, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(899), "Fiji" },
                    { 59, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(900), "Finland" },
                    { 60, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(901), "France" },
                    { 61, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(901), "Gabon" },
                    { 62, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(902), "Georgia" },
                    { 63, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(903), "Germany" },
                    { 64, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(904), "Ghana" },
                    { 65, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(905), "Greece" },
                    { 66, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(906), "Grenada" },
                    { 67, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(907), "Guatemala" },
                    { 68, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(908), "Guinea" },
                    { 69, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(909), "Guinea-Bissau" },
                    { 70, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(910), "Guyana" },
                    { 71, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(911), "Haiti" },
                    { 72, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(912), "Honduras" },
                    { 73, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(912), "Hungary" },
                    { 74, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(913), "Iceland" },
                    { 75, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(914), "India" },
                    { 76, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(915), "Indonesia" },
                    { 77, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(916), "Iran" },
                    { 78, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(917), "Iraq" },
                    { 79, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(917), "Ireland" },
                    { 80, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(918), "Israel" },
                    { 81, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(919), "Italy" },
                    { 82, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(920), "Ivory Coast" },
                    { 83, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(921), "Jamaica" },
                    { 84, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(922), "Japan" },
                    { 85, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(923), "Jordan" },
                    { 86, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(924), "Kazakhstan" },
                    { 87, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(924), "Kenya" },
                    { 88, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(925), "Kiribati" },
                    { 89, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(926), "Kosovo" },
                    { 90, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(927), "Kuwait" },
                    { 91, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(928), "Kyrgyzstan" },
                    { 92, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(929), "Laos" },
                    { 93, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(929), "Latvia" },
                    { 94, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(930), "Lebanon" },
                    { 95, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(931), "Lesotho" },
                    { 96, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(932), "Liberia" },
                    { 97, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(933), "Libya" },
                    { 98, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(934), "Liechtenstein" },
                    { 99, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(934), "Lithuania" },
                    { 100, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(935), "Luxembourg" },
                    { 101, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(936), "Madagascar" },
                    { 102, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(937), "Malawi" },
                    { 103, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(938), "Malaysia" },
                    { 104, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(939), "Maldives" },
                    { 105, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(940), "Mali" },
                    { 106, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(940), "Malta" },
                    { 107, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(941), "Marshall Islands" },
                    { 108, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(942), "Mauritania" },
                    { 109, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(943), "Mauritius" },
                    { 110, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(944), "Mexico" },
                    { 111, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(945), "Federated States of Micronesia" },
                    { 112, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(946), "Moldova" },
                    { 113, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(946), "Monaco" },
                    { 114, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(947), "Mongolia" },
                    { 115, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(948), "Montenegro" },
                    { 116, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(949), "Morocco" },
                    { 117, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(950), "Mozambique" },
                    { 118, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(951), "Myanmar (Burma)" },
                    { 119, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(951), "Namibia" },
                    { 120, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(952), "Nauru" },
                    { 121, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(953), "Nepal" },
                    { 122, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(954), "Netherlands" },
                    { 123, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(955), "New Zealand" },
                    { 124, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(956), "Nicaragua" },
                    { 125, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(957), "Niger" },
                    { 126, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(958), "Nigeria" },
                    { 127, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(959), "North Korea" },
                    { 128, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(959), "North Macedonia" },
                    { 129, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(960), "Norway" },
                    { 130, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(962), "Oman" },
                    { 131, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(963), "Pakistan" },
                    { 132, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(963), "Palau" },
                    { 133, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(964), "Panama" },
                    { 134, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(965), "Papua New Guinea" },
                    { 135, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(971), "Paraguay" },
                    { 136, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(973), "Peru" },
                    { 137, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(973), "Philippines" },
                    { 138, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(974), "Poland" },
                    { 139, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(975), "Portugal" },
                    { 140, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(976), "Qatar" },
                    { 141, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(977), "Romania" },
                    { 142, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(978), "Russia" },
                    { 143, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(978), "Rwanda" },
                    { 144, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(979), "St Kitts and Nevis" },
                    { 145, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(980), "St Lucia" },
                    { 146, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(981), "St Vincent" },
                    { 147, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(982), "Samoa" },
                    { 148, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(983), "San Marino" },
                    { 149, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(983), "Sao Tome and Principe" },
                    { 150, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(984), "Saudi Arabia" },
                    { 151, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(985), "Senegal" },
                    { 152, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(986), "Serbia" },
                    { 153, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(987), "Seychelles" },
                    { 154, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(988), "Sierra Leone" },
                    { 155, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(989), "Singapore" },
                    { 156, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(989), "Slovakia" },
                    { 157, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(990), "Slovenia" },
                    { 158, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(991), "Solomon Islands" },
                    { 159, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(992), "Somalia" },
                    { 160, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(993), "South Africa" },
                    { 161, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(994), "South Korea" },
                    { 162, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(994), "South Sudan" },
                    { 163, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(995), "Spain" },
                    { 164, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(996), "Sri Lanka" },
                    { 165, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(997), "Sudan" },
                    { 166, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(998), "Suriname" },
                    { 167, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(999), "Sweden" },
                    { 168, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1000), "Switzerland" },
                    { 169, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1000), "Syria" },
                    { 170, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1001), "Tajikistan" },
                    { 171, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1002), "Tanzania" },
                    { 172, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1003), "Thailand" },
                    { 173, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1004), "The Bahamas" },
                    { 174, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1005), "The Gambia" },
                    { 175, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1006), "Togo" },
                    { 176, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1007), "Tonga" },
                    { 177, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1007), "Trinidad and Tobago" },
                    { 178, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1008), "Tunisia" },
                    { 179, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1009), "Turkey" },
                    { 180, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1010), "Turkmenistan" },
                    { 181, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1011), "Tuvalu" },
                    { 182, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1012), "Uganda" },
                    { 183, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1012), "Ukraine" },
                    { 184, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1013), "United Arab Emirates" },
                    { 185, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1014), "United Kingdom" },
                    { 186, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1015), "United States" },
                    { 187, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1016), "Uruguay" },
                    { 188, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1017), "Uzbekistan" },
                    { 189, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1018), "Vanuatu" },
                    { 190, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1018), "Vatican City" },
                    { 191, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1019), "Venezuela" },
                    { 192, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1020), "Vietnam" },
                    { 193, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1021), "Yemen" },
                    { 194, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1022), "Zambia" },
                    { 195, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1023), "Zimbabwe" }
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
                    { 1, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1197), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1196), "Ilidža" },
                    { 2, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1200), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1199), "Stup" },
                    { 3, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1201), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1202), "Nedžarići" },
                    { 4, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1204), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1205), "Socijalno" },
                    { 5, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1206), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1207), "Malta" },
                    { 6, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1208), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1209), "Baščaršija" },
                    { 7, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1210), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1212), "Otoka" },
                    { 8, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1213), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1214), "Skenderija" },
                    { 9, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1215), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1216), "Drvenija" },
                    { 10, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1218), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1219), "Dobrinja" },
                    { 11, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1220), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1221), "Grbavica" },
                    { 12, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1222), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1224), "Hrasno" },
                    { 13, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1225), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1226), "Aneks" },
                    { 14, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1227), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1228), "Alipašino polje" },
                    { 15, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1230), new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1231), "Švrakino selo" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "CurrentUserId", "Discount", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, 0.0, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1333), "Default" },
                    { 2, null, 0.29999999999999999, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1335), "Student" },
                    { 3, null, 0.5, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1337), "Penzioner" },
                    { 4, null, 0.14999999999999999, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1338), "Zaposlenik" },
                    { 5, null, 0.40000000000000002, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1341), "Nezaposlen" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "CurrentUserId", "ModifiedDate", "Name", "Price", "StateMachine" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1351), "Jednosmjerna", 1.8, "draft" },
                    { 2, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1353), "Povratna", 3.2000000000000002, "draft" },
                    { 3, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1354), "Jednosmjerna dječija", 0.80000000000000004, "draft" },
                    { 4, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1356), "Povratna dječija", 1.2, "draft" },
                    { 5, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1357), "Mjesečna", 75.0, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "CurrentUserId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1292), "Trolejbus" },
                    { 2, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1294), "Tramvaj" },
                    { 3, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1295), "Minibus" },
                    { 4, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1297), "Autobus" },
                    { 5, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1298), "Kombi" }
                });

            migrationBuilder.InsertData(
                table: "VrijednostRaspolozenjas",
                columns: new[] { "VrijednostRaspolozenjaId", "Naziv" },
                values: new object[,]
                {
                    { 1, "Sretan" },
                    { 2, "Tuzan" },
                    { 3, "Pod stresom" },
                    { 4, "Uzbuđen" },
                    { 5, "Umoran" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "CurrentUserId", "ManufacturerCountryId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1263), "MAN" },
                    { 2, null, 2, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1264), "Solaris" },
                    { 3, null, 3, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1266), "Volvo" },
                    { 4, null, 4, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1268), "Mercedes" },
                    { 5, null, 5, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1270), "Setra" },
                    { 6, null, 6, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1271), "Neoplan" },
                    { 7, null, 7, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1273), "Siemens" },
                    { 8, null, 8, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1274), "Traton" },
                    { 9, null, 9, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1278), "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "City", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImage", "RegistrationDate", "StatusExpirationDate", "UserCountryId", "UserName", "UserStatusId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9451), "yiStGrjJ/1YRn23GGWjNt7QcWXk=", "IqR1wJN/MvlSM3syWmRaPw==", "+38761222333", null, new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9450), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevoapp@gmail.com", "Senada", "Senadić", new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9463), "TsbF20j+mPbf5CBTtZNSmYxLrfY=", "Uc+REfQVkJHTEyvs/1IDkA==", "+38761222444", null, new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9461), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 1, "72000" },
                    { 3, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Test", "Testni", new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9472), "jzKDK/s68Ffi79VgvJGiAtCr+ow=", "jeUZQA1yOhKv+jBXbg/nsQ==", "+38761222444", null, new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9471), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevotest@outlook.com", "Testni", "Test", new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9477), "0lif3FPmc6eGqn4FFYvQc9zsqCA=", "IuZUakGzlc2g/gP/HnYXOg==", "+38761222666", null, new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9476), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevo.app@gmx.de", "Proba", "Probni", new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9482), "SNkyp2wASlrgfcvtmksyaxMrDM4=", "SNXI+uIBWtQ8RpuuiDk6fQ==", "+38761222777", null, new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9481), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9491), "gRsh4XNq+l11s/S36GlP1kO/TCU=", "4ZaRQ95ge1gT08jVKj4n0g==", "+38761222888", null, new DateTime(2025, 1, 30, 16, 30, 24, 80, DateTimeKind.Local).AddTicks(9490), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
                });

            migrationBuilder.InsertData(
                table: "MoodTracker30012025s",
                columns: new[] { "MoodTracker30012025Id", "DatumEvidencije", "Opis", "UserId", "VrijednostRaspolozenjaId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1447), "Test", 1, 1 },
                    { 2, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1450), "Test", 2, 2 },
                    { 3, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1452), "Test", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "Active", "Approved", "DateCreated", "RejectionReason", "UserId", "UserStatusId" },
                values: new object[,]
                {
                    { 2, true, false, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1082), "", 3, 5 },
                    { 3, true, false, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1090), "", 4, 2 },
                    { 4, true, false, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1093), "", 5, 4 },
                    { 5, true, false, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1095), "", 1, 2 },
                    { 6, true, false, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1097), "", 6, 3 }
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
                    { 1, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1375), "Opis kvara: Test 1", true, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1377), 1, 1 },
                    { 2, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1383), "Opis kvara: Test 2", false, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1385), 2, 2 },
                    { 3, null, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1386), "Opis kvara: Test 3", true, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1387), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 6 },
                    { 2, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 3, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { 4, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 5, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 6 },
                    { 6, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 5 },
                    { 7, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 8, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 9, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 4 },
                    { 10, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 6 },
                    { 11, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 2 },
                    { 12, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 13, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 14, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 1 },
                    { 15, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 6 },
                    { 16, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 4 },
                    { 17, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 18, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 6 },
                    { 19, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 4 },
                    { 20, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 21, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 5 },
                    { 22, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 4 },
                    { 23, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 24, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 1 },
                    { 25, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 2 },
                    { 26, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 },
                    { 27, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 28, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 4 },
                    { 29, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 5 },
                    { 30, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 5 },
                    { 31, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 3 },
                    { 32, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 5 },
                    { 33, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 5 },
                    { 34, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 35, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 5 },
                    { 36, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 4 },
                    { 37, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 4 },
                    { 38, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 6 },
                    { 39, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 2 },
                    { 40, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 6 },
                    { 41, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 6 },
                    { 42, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 4 },
                    { 43, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 3 },
                    { 44, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 45, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 1 },
                    { 46, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 1 },
                    { 47, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 48, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 2 },
                    { 49, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 50, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 6 },
                    { 51, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 4 },
                    { 52, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 4 },
                    { 53, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 54, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 55, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 2 },
                    { 56, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 57, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 3 },
                    { 58, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 6 },
                    { 59, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 5 },
                    { 60, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 4 },
                    { 61, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 2 },
                    { 62, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 1 },
                    { 63, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 1 },
                    { 64, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 6 },
                    { 65, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 3 },
                    { 66, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 67, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 68, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 6 },
                    { 69, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 3 },
                    { 70, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 71, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 3 },
                    { 72, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 5 },
                    { 73, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 5 },
                    { 74, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 3 },
                    { 75, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 4 },
                    { 76, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 77, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 78, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 3 },
                    { 79, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 1 },
                    { 80, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 81, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 82, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 83, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 4 },
                    { 84, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 5 },
                    { 85, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 6 },
                    { 86, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 87, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 3 },
                    { 88, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 89, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 3 },
                    { 90, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 6 },
                    { 91, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 92, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 2 },
                    { 93, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 2 },
                    { 94, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 95, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 3 },
                    { 96, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 2 },
                    { 97, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 98, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 3 },
                    { 99, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 1 },
                    { 100, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 1 },
                    { 101, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 5 },
                    { 102, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 6 },
                    { 103, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 6 },
                    { 104, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 1 },
                    { 105, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 4 },
                    { 106, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 2 },
                    { 107, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 5 },
                    { 108, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 109, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 110, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 5 },
                    { 111, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 4 },
                    { 112, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 113, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 3 },
                    { 114, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 4 },
                    { 115, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 2 },
                    { 116, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 4 },
                    { 117, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 1 },
                    { 118, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 4 },
                    { 119, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 1 },
                    { 120, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 2 },
                    { 121, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 5 },
                    { 122, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 5 },
                    { 123, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 4 },
                    { 124, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 2 },
                    { 125, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 6 },
                    { 126, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 2 },
                    { 127, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 },
                    { 128, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 129, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 4 },
                    { 130, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 6 },
                    { 131, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 6 },
                    { 132, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 3 },
                    { 133, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 4 },
                    { 134, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 3 },
                    { 135, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 136, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 5 },
                    { 137, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 5 },
                    { 138, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { 139, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 1 },
                    { 140, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 141, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 1 },
                    { 142, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 1 },
                    { 143, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 4 },
                    { 144, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 5 },
                    { 145, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 6 },
                    { 146, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 147, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 4 },
                    { 148, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 5 },
                    { 149, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 3 },
                    { 150, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 151, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 3 },
                    { 152, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 3 },
                    { 153, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 154, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 3 },
                    { 155, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 2 },
                    { 156, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 1 },
                    { 157, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 3 },
                    { 158, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 159, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 160, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 2 },
                    { 161, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 1 },
                    { 162, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 1 },
                    { 163, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 164, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 2 },
                    { 165, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 1 },
                    { 166, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 167, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 4 },
                    { 168, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 1 },
                    { 169, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 1 },
                    { 170, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 2 },
                    { 171, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 4 },
                    { 172, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 173, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 174, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 6 },
                    { 175, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 3 },
                    { 176, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 2 },
                    { 177, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 2 },
                    { 178, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 4 },
                    { 179, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 180, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 181, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 4 },
                    { 182, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 6 },
                    { 183, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 5 },
                    { 184, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 6 },
                    { 185, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 186, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 4 },
                    { 187, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 1 },
                    { 188, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 1 },
                    { 189, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 3 },
                    { 190, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 3 },
                    { 191, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 2 },
                    { 192, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 193, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 194, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 5 },
                    { 195, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 3 },
                    { 196, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 3 },
                    { 197, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 6 },
                    { 198, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 6 },
                    { 199, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 6 },
                    { 200, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 1 },
                    { 201, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 202, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 203, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 3 },
                    { 204, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 205, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 3 },
                    { 206, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 6 },
                    { 207, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 1 },
                    { 208, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 6 },
                    { 209, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 4 },
                    { 210, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 5 },
                    { 211, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 6 },
                    { 212, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 1 },
                    { 213, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 214, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 4 },
                    { 215, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 6 },
                    { 216, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 217, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 1 },
                    { 218, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 4 },
                    { 219, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 2 },
                    { 220, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 4 },
                    { 221, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 4 },
                    { 222, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 2 },
                    { 223, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 3 },
                    { 224, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 225, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 226, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 3 },
                    { 227, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 4 },
                    { 228, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 2 },
                    { 229, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 2 },
                    { 230, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 1 },
                    { 231, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 232, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 5 },
                    { 233, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 234, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 3 },
                    { 235, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 2 },
                    { 236, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 4 },
                    { 237, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 2 },
                    { 238, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 5 },
                    { 239, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 240, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 1 },
                    { 241, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 242, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 5 },
                    { 243, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 4 },
                    { 244, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 5 },
                    { 245, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 246, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 },
                    { 247, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 4 },
                    { 248, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 5 },
                    { 249, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 250, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 251, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 3 },
                    { 252, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 4 },
                    { 253, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 254, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 5 },
                    { 255, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 256, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 257, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 5 },
                    { 258, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 259, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 1 },
                    { 260, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 2 },
                    { 261, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 2 },
                    { 262, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 4 },
                    { 263, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 264, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 4 },
                    { 265, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 266, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 4 },
                    { 267, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 268, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 2 },
                    { 269, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 3 },
                    { 270, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 2 },
                    { 271, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 3 },
                    { 272, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 5 },
                    { 273, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 6 },
                    { 274, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 3 },
                    { 275, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 276, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 5 },
                    { 277, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 2 },
                    { 278, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 5 },
                    { 279, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 1 },
                    { 280, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 4 },
                    { 281, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 5 },
                    { 282, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 283, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 3 },
                    { 284, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 5 },
                    { 285, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 4 },
                    { 286, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 3 },
                    { 287, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 6 },
                    { 288, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 5 },
                    { 289, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 6 },
                    { 290, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 1 },
                    { 291, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 292, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 293, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 3 },
                    { 294, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 2 },
                    { 295, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 3 },
                    { 296, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 3 },
                    { 297, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 2 },
                    { 298, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 6 },
                    { 299, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 300, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 301, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 2 },
                    { 302, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 4 },
                    { 303, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 5 },
                    { 304, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 1 },
                    { 305, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 4 },
                    { 306, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 5 },
                    { 307, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 2 },
                    { 308, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 309, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 2 },
                    { 310, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 2 },
                    { 311, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 1 },
                    { 312, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 313, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 5 },
                    { 314, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 315, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 3 },
                    { 316, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 317, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 4 },
                    { 318, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 6 },
                    { 319, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 1 },
                    { 320, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 321, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 4 },
                    { 322, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 323, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 4 },
                    { 324, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 325, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 4 },
                    { 326, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 327, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 328, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 5 },
                    { 329, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 4 },
                    { 330, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 3 },
                    { 331, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 3 },
                    { 332, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 1 },
                    { 333, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 4 },
                    { 334, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 4 },
                    { 335, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 336, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 1 },
                    { 337, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 1 },
                    { 338, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 1 },
                    { 339, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 340, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 4 },
                    { 341, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 342, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 1 },
                    { 343, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 2 },
                    { 344, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 345, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 4 },
                    { 346, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 347, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 3 },
                    { 348, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 6 },
                    { 349, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 5 },
                    { 350, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 3 },
                    { 351, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 4 },
                    { 352, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 3 },
                    { 353, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 6 },
                    { 354, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 4 },
                    { 355, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 1 },
                    { 356, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 1 },
                    { 357, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 2 },
                    { 358, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 359, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 360, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { 361, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 1 },
                    { 362, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 5 },
                    { 363, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 5 },
                    { 364, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 365, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 5 },
                    { 366, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 367, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 3 },
                    { 368, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 369, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 5 },
                    { 370, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 6 },
                    { 371, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 5 },
                    { 372, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 2 },
                    { 373, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 1 },
                    { 374, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 4 },
                    { 375, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 376, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 377, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 378, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 379, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 5 },
                    { 380, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 381, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 382, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 5 },
                    { 383, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 },
                    { 384, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 385, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 4 },
                    { 386, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 6 },
                    { 387, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 388, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 2 },
                    { 389, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 3 },
                    { 390, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 6 },
                    { 391, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 6 },
                    { 392, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 4 },
                    { 393, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 2 },
                    { 394, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 1 },
                    { 395, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 3 },
                    { 396, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 6 },
                    { 397, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 6 },
                    { 398, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 3 },
                    { 399, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 6 },
                    { 400, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 6 },
                    { 401, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 6 },
                    { 402, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 1 },
                    { 403, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 6 },
                    { 404, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 405, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 1 },
                    { 406, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 407, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 3 },
                    { 408, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 2 },
                    { 409, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 5 },
                    { 410, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 6 },
                    { 411, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 3 },
                    { 412, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 413, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 414, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 5 },
                    { 415, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 6 },
                    { 416, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 6 },
                    { 417, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 418, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 419, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 6 },
                    { 420, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 421, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 3 },
                    { 422, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 4 },
                    { 423, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 424, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 425, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 4 },
                    { 426, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 6 },
                    { 427, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 428, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 429, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 2 },
                    { 430, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 431, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 5 },
                    { 432, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 433, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 434, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 6 },
                    { 435, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 436, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 437, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 438, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 5 },
                    { 439, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 2 },
                    { 440, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 441, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 442, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 443, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 5 },
                    { 444, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 4 },
                    { 445, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 3 },
                    { 446, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 3 },
                    { 447, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 1 },
                    { 448, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 3 },
                    { 449, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 4 },
                    { 450, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 451, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 4 },
                    { 452, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 5 },
                    { 453, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 454, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 2 },
                    { 455, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 1 },
                    { 456, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 457, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 458, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 459, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 1 },
                    { 460, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 6 },
                    { 461, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 3 },
                    { 462, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 463, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 464, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 4 },
                    { 465, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 466, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 467, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 6 },
                    { 468, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 2 },
                    { 469, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 5 },
                    { 470, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 3 },
                    { 471, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 472, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 5 },
                    { 473, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 1 },
                    { 474, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 475, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 3 },
                    { 476, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 5 },
                    { 477, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 478, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 479, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 },
                    { 480, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 4 },
                    { 481, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 5 },
                    { 482, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 6 },
                    { 483, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 484, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 485, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 486, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 4 },
                    { 487, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 3 },
                    { 488, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 6 },
                    { 489, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 1 },
                    { 490, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 5 },
                    { 491, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 2 },
                    { 492, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 3 },
                    { 493, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 494, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 495, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 4 },
                    { 496, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 2 },
                    { 497, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 498, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 2 },
                    { 499, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 2 },
                    { 500, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 501, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 2 },
                    { 502, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 6 },
                    { 503, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 6 },
                    { 504, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 5 },
                    { 505, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 6 },
                    { 506, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 5 },
                    { 507, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 3 },
                    { 508, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 5 },
                    { 509, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 2 },
                    { 510, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 511, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 2 },
                    { 512, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 3 },
                    { 513, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 3 },
                    { 514, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 5 },
                    { 515, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 3 },
                    { 516, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 517, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 5 },
                    { 518, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 3 },
                    { 519, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 4 },
                    { 520, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 521, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 5 },
                    { 522, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 2 },
                    { 523, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 1 },
                    { 524, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 1 },
                    { 525, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 3 },
                    { 526, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 2 },
                    { 527, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 4 },
                    { 528, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 5 },
                    { 529, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 530, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 531, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 2 },
                    { 532, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 2 },
                    { 533, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 5 },
                    { 534, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 3 },
                    { 535, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 4 },
                    { 536, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 3 },
                    { 537, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 3 },
                    { 538, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 539, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 1 },
                    { 540, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 3 },
                    { 541, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 3 },
                    { 542, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 543, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 3 },
                    { 544, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 2 },
                    { 545, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 2 },
                    { 546, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 3 },
                    { 547, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 548, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 549, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 550, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 3 },
                    { 551, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 1 },
                    { 552, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 553, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 554, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 5 },
                    { 555, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 5 },
                    { 556, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 6 },
                    { 557, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 558, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 3 },
                    { 559, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 3 },
                    { 560, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 561, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 562, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 6 },
                    { 563, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 1 },
                    { 564, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 565, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 3 },
                    { 566, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 567, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 568, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 6 },
                    { 569, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 4 },
                    { 570, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 571, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 3 },
                    { 572, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 1 },
                    { 573, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 1 },
                    { 574, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 4 },
                    { 575, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 5 },
                    { 576, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 6 },
                    { 577, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 5 },
                    { 578, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 4 },
                    { 579, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 580, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 5 },
                    { 581, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 4 },
                    { 582, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 1 },
                    { 583, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 4 },
                    { 584, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 585, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 4 },
                    { 586, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 3 },
                    { 587, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 6 },
                    { 588, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 1 },
                    { 589, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 4 },
                    { 590, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 3 },
                    { 591, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 6 },
                    { 592, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 5 },
                    { 593, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 2 },
                    { 594, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 6 },
                    { 595, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 1 },
                    { 596, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 597, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 6 },
                    { 598, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 4 },
                    { 599, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 1 },
                    { 600, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 5 },
                    { 601, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 1 },
                    { 602, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 603, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 4 },
                    { 604, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 6 },
                    { 605, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 2 },
                    { 606, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 2 },
                    { 607, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 6 },
                    { 608, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 3 },
                    { 609, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 3 },
                    { 610, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 3 },
                    { 611, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 2 },
                    { 612, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 3 },
                    { 613, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 3 },
                    { 614, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 615, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 4 },
                    { 616, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 2 },
                    { 617, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 6 },
                    { 618, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 4 },
                    { 619, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 620, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 3 },
                    { 621, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 3 },
                    { 622, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 623, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 5 },
                    { 624, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 5 },
                    { 625, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 6 },
                    { 626, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 2 },
                    { 627, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 4 },
                    { 628, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 629, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 5 },
                    { 630, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 6 },
                    { 631, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 2 },
                    { 632, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 5 },
                    { 633, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 1 },
                    { 634, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 3 },
                    { 635, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 636, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 1 },
                    { 637, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 6 },
                    { 638, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 4 },
                    { 639, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 640, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 2 },
                    { 641, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 5 },
                    { 642, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 4 },
                    { 643, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 1 },
                    { 644, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 645, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 1 },
                    { 646, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 5 },
                    { 647, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 2 },
                    { 648, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 649, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 650, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 5 },
                    { 651, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 6 },
                    { 652, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 6 },
                    { 653, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 1 },
                    { 654, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 655, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 3 },
                    { 656, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 2 },
                    { 657, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 658, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 1 },
                    { 659, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 2 },
                    { 660, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 661, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 662, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 2 },
                    { 663, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 5 },
                    { 664, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 4 },
                    { 665, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 666, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 667, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 6 },
                    { 668, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 669, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 670, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 4 },
                    { 671, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 672, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 673, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 4 },
                    { 674, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 675, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 5 },
                    { 676, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 5 },
                    { 677, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 5 },
                    { 678, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 1 },
                    { 679, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 680, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 4 },
                    { 681, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 2 },
                    { 682, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 4 },
                    { 683, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 1 },
                    { 684, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 3 },
                    { 685, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 2 },
                    { 686, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 6 },
                    { 687, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 4 },
                    { 688, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 3 },
                    { 689, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 5 },
                    { 690, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 5 },
                    { 691, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 5 },
                    { 692, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 6 },
                    { 693, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 3 },
                    { 694, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 695, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 696, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 5 },
                    { 697, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 2 },
                    { 698, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 699, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 4 },
                    { 700, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 5 },
                    { 701, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 702, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 2 },
                    { 703, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 4 },
                    { 704, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 4 },
                    { 705, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 1 },
                    { 706, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 3 },
                    { 707, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 708, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 4 },
                    { 709, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 3 },
                    { 710, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 3 },
                    { 711, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 6 },
                    { 712, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 5 },
                    { 713, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 3 },
                    { 714, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 4 }
                });

            migrationBuilder.InsertData(
                table: "Delays",
                columns: new[] { "DelayId", "CurrentUserId", "DelayAmountMinutes", "ModifiedDate", "Reason", "RouteId", "TypeId" },
                values: new object[,]
                {
                    { 1, null, 30, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1418), "Gužva", 1, 1 },
                    { 2, null, 60, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1421), "Udes", 2, 2 },
                    { 3, null, 15, new DateTime(2025, 1, 30, 16, 30, 24, 81, DateTimeKind.Local).AddTicks(1423), "Led", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "IssuedTickets",
                columns: new[] { "IssuedTicketId", "Amount", "IssuedDate", "RouteId", "TicketId", "UserId", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 5, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 592, 1, 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 367, 4, 3, new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 26, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 5, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 510, 1, 3, new DateTime(2025, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 7, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 220, 4, 6, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 672, 4, 3, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 9, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 4, 2, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 8, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 325, 2, 4, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 5, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 453, 3, 3, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 8, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 2, 4, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 3, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1, 1, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 4, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 162, 2, 1, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 2, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 237, 4, 6, new DateTime(2024, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 606, 1, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 2, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 5, 4, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 3, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 704, 4, 2, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 25, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 3, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 4, 5, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 3, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 2, 2, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 8, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 611, 1, 4, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 341, 3, 3, new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 4, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 322, 4, 3, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 3, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 3, 6, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 17, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 9, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 468, 1, 6, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 4, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 697, 1, 3, new DateTime(2025, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 2, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 3, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 483, 4, 5, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 6, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 405, 1, 4, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 8, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 4, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 681, 4, 3, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 26, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 3, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 686, 2, 5, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 6, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 464, 1, 1, new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 5, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 126, 3, 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 9, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 403, 5, 3, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 6, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 253, 2, 3, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 6, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 127, 1, 4, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 9, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 315, 1, 5, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 9, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 392, 5, 4, new DateTime(2025, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 1, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 347, 5, 2, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 5, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 459, 5, 3, new DateTime(2024, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 5, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 126, 1, 6, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 20, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 3, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 675, 3, 6, new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 16, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 2, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 319, 5, 3, new DateTime(2025, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 3, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 670, 2, 3, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 4, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 1, 3, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 4, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3, 3, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 1, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 268, 2, 6, new DateTime(2024, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 8, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 563, 4, 3, new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 18, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 8, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 643, 3, 1, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 3, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 345, 2, 4, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 3, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 437, 5, 1, new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 7, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 364, 1, 6, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 18, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 3, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 612, 1, 3, new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 621, 5, 6, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 3, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 649, 1, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 7, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 5, 3, new DateTime(2025, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 2, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, 3, 6, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 3, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 299, 4, 5, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 4, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 340, 4, 3, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 14, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 9, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 340, 4, 2, new DateTime(2024, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 26, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 3, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 590, 3, 3, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 5, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 521, 1, 6, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 9, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 538, 4, 2, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 2, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 247, 3, 1, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 2, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 469, 3, 1, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 9, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 499, 5, 1, new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 3, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 419, 5, 2, new DateTime(2024, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 8, new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 450, 5, 2, new DateTime(2024, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 4, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 4, 4, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 8, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 220, 3, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 6, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 671, 3, 4, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 1, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 4, 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 245, 4, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 9, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 680, 5, 6, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 6, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 2, 6, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 1, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 139, 1, 3, new DateTime(2025, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 21, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 6, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 2, 5, new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 6, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 413, 2, 5, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 26, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 527, 1, 6, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 6, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 5, 2, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 8, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 2, 3, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 2, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 3, 5, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 1, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 646, 3, 4, new DateTime(2024, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 13, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 5, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 635, 5, 4, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 5, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 137, 4, 5, new DateTime(2024, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 12, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 5, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 2, 5, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 5, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 454, 4, 5, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 1, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 418, 3, 6, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 1, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 465, 4, 4, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 9, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 389, 2, 1, new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 8, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 425, 5, 5, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 2, 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 5, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, 2, 2, new DateTime(2025, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 22, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 8, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 701, 1, 4, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 6, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 248, 5, 1, new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 3, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 297, 3, 1, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 7, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 581, 1, 1, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 4, 4, new DateTime(2025, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 23, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 9, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 617, 1, 5, new DateTime(2025, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 6, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 633, 2, 6, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 8, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 1, 3, new DateTime(2024, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 28, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 413, 3, 3, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 3, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 189, 2, 3, new DateTime(2025, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 19, 3, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_MoodTracker30012025s_UserId",
                table: "MoodTracker30012025s",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MoodTracker30012025s_VrijednostRaspolozenjaId",
                table: "MoodTracker30012025s",
                column: "VrijednostRaspolozenjaId");

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
                name: "MoodTracker30012025s");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "VrijednostRaspolozenjas");

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
