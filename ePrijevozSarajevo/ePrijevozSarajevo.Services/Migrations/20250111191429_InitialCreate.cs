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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Discount = table.Column<double>(type: "float(5)", precision: 5, scale: 2, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManufacturerCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Countries_ManufacturerCountryId",
                        column: x => x.ManufacturerCountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Countries",
                columns: new[] { "CountryId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7733), "Afghanistan" },
                    { 2, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7736), "Albania" },
                    { 3, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7737), "Algeria" },
                    { 4, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7738), "Andorra" },
                    { 5, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7739), "Angola" },
                    { 6, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7740), "Antigua and Barbuda" },
                    { 7, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7741), "Argentina" },
                    { 8, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7742), "Armenia" },
                    { 9, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7743), "Australia" },
                    { 10, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7744), "Austria" },
                    { 11, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7745), "Azerbaijan" },
                    { 12, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7746), "Bahrain" },
                    { 13, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7747), "Bangladesh" },
                    { 14, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7748), "Barbados" },
                    { 15, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7749), "Belarus" },
                    { 16, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7749), "Belgium" },
                    { 17, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7750), "Belize" },
                    { 18, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7752), "Benin" },
                    { 19, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7752), "Bhutan" },
                    { 20, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7753), "Bolivia" },
                    { 21, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7754), "Bosnia and Herzegovina" },
                    { 22, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7755), "Botswana" },
                    { 23, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7756), "Brazil" },
                    { 24, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7756), "Brunei" },
                    { 25, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7757), "Bulgaria" },
                    { 26, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7758), "Burkina Faso" },
                    { 27, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7759), "Burundi" },
                    { 28, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7760), "Cambodia" },
                    { 29, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7761), "Cameroon" },
                    { 30, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7761), "Canada" },
                    { 31, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7762), "Cape Verde" },
                    { 32, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7763), "Central African Republic" },
                    { 33, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7764), "Chad" },
                    { 34, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7770), "Chile" },
                    { 35, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7771), "China" },
                    { 36, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7772), "Colombia" },
                    { 37, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7772), "Comoros" },
                    { 38, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7773), "Congo" },
                    { 39, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7774), "Congo (Democratic Republic)" },
                    { 40, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7775), "Costa Rica" },
                    { 41, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7776), "Croatia" },
                    { 42, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7776), "Cuba" },
                    { 43, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7777), "Cyprus" },
                    { 44, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7778), "Czechia" },
                    { 45, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7779), "Denmark" },
                    { 46, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7780), "Djibouti" },
                    { 47, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7781), "Dominica" },
                    { 48, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7782), "Dominican Republic" },
                    { 49, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7782), "East Timor" },
                    { 50, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7783), "Ecuador" },
                    { 51, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7784), "Egypt" },
                    { 52, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7785), "El Salvador" },
                    { 53, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7786), "Equatorial Guinea" },
                    { 54, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7786), "Eritrea" },
                    { 55, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7787), "Estonia" },
                    { 56, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7788), "Eswatini" },
                    { 57, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7789), "Ethiopia" },
                    { 58, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7790), "Fiji" },
                    { 59, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7790), "Finland" },
                    { 60, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7791), "France" },
                    { 61, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7792), "Gabon" },
                    { 62, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7793), "Georgia" },
                    { 63, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7794), "Germany" },
                    { 64, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7795), "Ghana" },
                    { 65, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7795), "Greece" },
                    { 66, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7797), "Grenada" },
                    { 67, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7798), "Guatemala" },
                    { 68, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7799), "Guinea" },
                    { 69, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7799), "Guinea-Bissau" },
                    { 70, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7800), "Guyana" },
                    { 71, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7801), "Haiti" },
                    { 72, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7802), "Honduras" },
                    { 73, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7803), "Hungary" },
                    { 74, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7803), "Iceland" },
                    { 75, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7804), "India" },
                    { 76, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7805), "Indonesia" },
                    { 77, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7806), "Iran" },
                    { 78, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7807), "Iraq" },
                    { 79, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7808), "Ireland" },
                    { 80, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7808), "Israel" },
                    { 81, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7809), "Italy" },
                    { 82, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7810), "Ivory Coast" },
                    { 83, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7811), "Jamaica" },
                    { 84, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7812), "Japan" },
                    { 85, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7813), "Jordan" },
                    { 86, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7813), "Kazakhstan" },
                    { 87, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7814), "Kenya" },
                    { 88, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7815), "Kiribati" },
                    { 89, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7816), "Kosovo" },
                    { 90, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7817), "Kuwait" },
                    { 91, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7817), "Kyrgyzstan" },
                    { 92, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7818), "Laos" },
                    { 93, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7819), "Latvia" },
                    { 94, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7820), "Lebanon" },
                    { 95, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7821), "Lesotho" },
                    { 96, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7822), "Liberia" },
                    { 97, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7822), "Libya" },
                    { 98, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7823), "Liechtenstein" },
                    { 99, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7824), "Lithuania" },
                    { 100, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7825), "Luxembourg" },
                    { 101, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7826), "Madagascar" },
                    { 102, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7826), "Malawi" },
                    { 103, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7827), "Malaysia" },
                    { 104, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7828), "Maldives" },
                    { 105, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7829), "Mali" },
                    { 106, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7830), "Malta" },
                    { 107, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7830), "Marshall Islands" },
                    { 108, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7831), "Mauritania" },
                    { 109, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7832), "Mauritius" },
                    { 110, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7833), "Mexico" },
                    { 111, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7834), "Federated States of Micronesia" },
                    { 112, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7835), "Moldova" },
                    { 113, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7835), "Monaco" },
                    { 114, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7836), "Mongolia" },
                    { 115, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7837), "Montenegro" },
                    { 116, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7838), "Morocco" },
                    { 117, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7839), "Mozambique" },
                    { 118, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7839), "Myanmar (Burma)" },
                    { 119, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7840), "Namibia" },
                    { 120, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7841), "Nauru" },
                    { 121, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7842), "Nepal" },
                    { 122, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7843), "Netherlands" },
                    { 123, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7843), "New Zealand" },
                    { 124, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7844), "Nicaragua" },
                    { 125, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7845), "Niger" },
                    { 126, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7846), "Nigeria" },
                    { 127, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7847), "North Korea" },
                    { 128, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7848), "North Macedonia" },
                    { 129, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7849), "Norway" },
                    { 130, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7850), "Oman" },
                    { 131, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7851), "Pakistan" },
                    { 132, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7852), "Palau" },
                    { 133, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7856), "Panama" },
                    { 134, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7858), "Papua New Guinea" },
                    { 135, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7859), "Paraguay" },
                    { 136, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7860), "Peru" },
                    { 137, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7860), "Philippines" },
                    { 138, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7861), "Poland" },
                    { 139, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7862), "Portugal" },
                    { 140, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7863), "Qatar" },
                    { 141, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7864), "Romania" },
                    { 142, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7865), "Russia" },
                    { 143, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7865), "Rwanda" },
                    { 144, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7866), "St Kitts and Nevis" },
                    { 145, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7867), "St Lucia" },
                    { 146, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7868), "St Vincent" },
                    { 147, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7869), "Samoa" },
                    { 148, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7869), "San Marino" },
                    { 149, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7870), "Sao Tome and Principe" },
                    { 150, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7871), "Saudi Arabia" },
                    { 151, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7872), "Senegal" },
                    { 152, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7873), "Serbia" },
                    { 153, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7873), "Seychelles" },
                    { 154, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7874), "Sierra Leone" },
                    { 155, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7875), "Singapore" },
                    { 156, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7876), "Slovakia" },
                    { 157, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7877), "Slovenia" },
                    { 158, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7878), "Solomon Islands" },
                    { 159, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7878), "Somalia" },
                    { 160, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7879), "South Africa" },
                    { 161, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7880), "South Korea" },
                    { 162, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7881), "South Sudan" },
                    { 163, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7882), "Spain" },
                    { 164, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7883), "Sri Lanka" },
                    { 165, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7883), "Sudan" },
                    { 166, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7884), "Suriname" },
                    { 167, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7885), "Sweden" },
                    { 168, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7886), "Switzerland" },
                    { 169, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7887), "Syria" },
                    { 170, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7888), "Tajikistan" },
                    { 171, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7888), "Tanzania" },
                    { 172, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7889), "Thailand" },
                    { 173, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7890), "The Bahamas" },
                    { 174, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7891), "The Gambia" },
                    { 175, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7892), "Togo" },
                    { 176, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7892), "Tonga" },
                    { 177, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7893), "Trinidad and Tobago" },
                    { 178, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7894), "Tunisia" },
                    { 179, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7895), "Turkey" },
                    { 180, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7896), "Turkmenistan" },
                    { 181, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7896), "Tuvalu" },
                    { 182, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7897), "Uganda" },
                    { 183, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7898), "Ukraine" },
                    { 184, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7899), "United Arab Emirates" },
                    { 185, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7900), "United Kingdom" },
                    { 186, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7901), "United States" },
                    { 187, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7901), "Uruguay" },
                    { 188, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7902), "Uzbekistan" },
                    { 189, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7903), "Vanuatu" },
                    { 190, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7904), "Vatican City" },
                    { 191, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7905), "Venezuela" },
                    { 192, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7905), "Vietnam" },
                    { 193, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7906), "Yemen" },
                    { 194, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7907), "Zambia" },
                    { 195, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7908), "Zimbabwe" }
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
                columns: new[] { "StationId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8048), "Ilidža" },
                    { 2, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8049), "Stup" },
                    { 3, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8051), "Nedžarići" },
                    { 4, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8052), "Socijalno" },
                    { 5, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8053), "Malta" },
                    { 6, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8055), "Baščaršija" },
                    { 7, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8056), "Otoka" },
                    { 8, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8058), "Skenderija" },
                    { 9, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8059), "Drvenija" },
                    { 10, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8060), "Dobrinja" },
                    { 11, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8061), "Grbavica" },
                    { 12, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8063), "Hrasno" },
                    { 13, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8064), "Aneks" },
                    { 14, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8065), "Alipašino polje" },
                    { 15, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8067), "Švrakino selo" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Discount", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 0.0, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8156), "Default" },
                    { 2, 0.29999999999999999, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8158), "Student" },
                    { 3, 0.5, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8160), "Penzioner" },
                    { 4, 0.14999999999999999, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8161), "Zaposlenik" },
                    { 5, 0.40000000000000002, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8162), "Nezaposlen" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "ModifiedDate", "Name", "Price", "StateMachine" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8170), "Jednosmjerna", 1.8, "draft" },
                    { 2, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8172), "Povratna", 3.2000000000000002, "draft" },
                    { 3, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8174), "Jednosmjerna dječija", 0.80000000000000004, "draft" },
                    { 4, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8175), "Povratna dječija", 1.2, "draft" },
                    { 5, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8177), "Mjesečna", 75.0, "draft" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "TypeId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8121), "Trolejbus" },
                    { 2, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8123), "Tramvaj" },
                    { 3, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8125), "Minibus" },
                    { 4, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8126), "Autobus" },
                    { 5, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8127), "Kombi" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerId", "ManufacturerCountryId", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8095), "MAN" },
                    { 2, 2, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8097), "Solaris" },
                    { 3, 3, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8098), "Volvo" },
                    { 4, 4, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8100), "Mercedes" },
                    { 5, 5, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8101), "Setra" },
                    { 6, 6, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8103), "Neoplan" },
                    { 7, 7, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8104), "Siemens" },
                    { 8, 8, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8106), "Traton" },
                    { 9, 9, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(8107), "Tesla" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "City", "DateOfBirth", "Email", "FirstName", "LastName", "ModifiedDate", "PasswordHash", "PasswordSalt", "PhoneNumber", "ProfileImage", "RegistrationDate", "StatusExpirationDate", "UserCountryId", "UserName", "UserStatusId", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Adresa 11", "Sarajevo", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7369), "TLEHdKT69oGkkj+eRQWHjf/kE4Q=", "z9OJcAM98iAG+MZ138Stjw==", "+38761222333", null, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7368), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "desktop", 4, "71000" },
                    { 2, "Adresa 12", "Zenica", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevoapp@gmail.com", "Senada", "Senadić", new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7379), "77nk1JNm06nmtps4ycafACdfKD4=", "71BKtkF6XMfHMZLXNBhfoA==", "+38761222444", null, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7378), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "mobile", 4, "72000" },
                    { 3, "Adresa 14", "Nürnberg", new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Test", "Testni", new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7384), "GvDGiPGNzh/UItN7n2V8uUhj+3I=", "BIbqeyIFNt2M3HjaqXJ7/w==", "+38761222444", null, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7383), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile1", 1, "90408" },
                    { 4, "Adresa 15", "Wien", new DateTime(1965, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevotest@outlook.com", "Testni", "Test", new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7388), "r8+QuOOLmUKtXGAYUvOPp3/1+D4=", "5m3GyS6CRW0ZWpFlPaToUQ==", "+38761222666", null, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7388), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile2", 1, "1010" },
                    { 5, "Adresa 16", "Wien", new DateTime(1982, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "eprijevozsarajevo.app@gmx.de", "Proba", "Probni", new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7393), "2sI0dd6eErPvc7/ow5vPfFYmpH4=", "avBBhe+5NWIRIHYbrflBZw==", "+38761222777", null, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7392), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "mobile3", 1, "1160" },
                    { 6, "Adresa 17", "Munich", new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "probe@mail.com", "Probe", "Probno", new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7401), "VdqjG0AKu7+2ZoN6nLg17Ned5YA=", "D+l3fag/ZXguzZAn8/SOcQ==", "+38761222888", null, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7400), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "mobile4", 1, "80331" }
                });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "RequestId", "Active", "Approved", "DateCreated", "RejectionReason", "UserId", "UserStatusId" },
                values: new object[,]
                {
                    { 1, true, false, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7960), "", 2, 3 },
                    { 2, true, false, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7962), "", 3, 5 },
                    { 3, true, false, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7966), "", 4, 2 },
                    { 4, true, false, new DateTime(2025, 1, 11, 20, 14, 29, 828, DateTimeKind.Local).AddTicks(7968), "", 5, 4 }
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
                table: "Routes",
                columns: new[] { "RouteId", "Arrival", "Departure", "EndStationId", "StartStationId", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 2, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 5 },
                    { 3, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 4, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 5 },
                    { 5, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 4 },
                    { 6, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 4 },
                    { 7, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 1 },
                    { 8, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 9, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 10, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 2 },
                    { 11, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 5 },
                    { 12, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 13, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 3 },
                    { 14, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 1 },
                    { 15, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 1 },
                    { 16, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 2 },
                    { 17, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 18, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 5 },
                    { 19, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 2 },
                    { 20, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 5 },
                    { 21, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 4 },
                    { 22, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 4 },
                    { 23, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 24, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 3 },
                    { 25, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 3 },
                    { 26, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 6 },
                    { 27, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 3 },
                    { 28, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 2 },
                    { 29, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 5 },
                    { 30, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 2 },
                    { 31, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 4 },
                    { 32, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 3 },
                    { 33, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 34, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 2 },
                    { 35, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 1 },
                    { 36, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 5 },
                    { 37, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 2 },
                    { 38, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 6 },
                    { 39, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 3 },
                    { 40, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 1 },
                    { 41, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 4 },
                    { 42, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 4 },
                    { 43, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 3 },
                    { 44, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 6 },
                    { 45, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 3 },
                    { 46, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 2 },
                    { 47, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 4 },
                    { 48, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 4 },
                    { 49, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 50, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 3 },
                    { 51, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 2 },
                    { 52, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 6 },
                    { 53, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 5 },
                    { 54, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 2 },
                    { 55, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 1 },
                    { 56, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 1 },
                    { 57, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 1 },
                    { 58, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 59, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 2 },
                    { 60, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 4 },
                    { 61, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 1 },
                    { 62, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 3 },
                    { 63, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 5 },
                    { 64, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 5 },
                    { 65, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 1 },
                    { 66, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 2 },
                    { 67, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 1 },
                    { 68, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 1 },
                    { 69, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 4 },
                    { 70, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 6 },
                    { 71, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 1 },
                    { 72, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 73, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 1 },
                    { 74, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 6 },
                    { 75, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 2 },
                    { 76, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 77, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 3 },
                    { 78, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 5 },
                    { 79, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 4 },
                    { 80, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 81, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 82, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 4 },
                    { 83, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 4 },
                    { 84, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 85, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 4 },
                    { 86, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 6 },
                    { 87, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 5 },
                    { 88, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 89, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 2 },
                    { 90, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 1 },
                    { 91, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 3 },
                    { 92, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 6 },
                    { 93, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 2 },
                    { 94, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 5 },
                    { 95, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 5 },
                    { 96, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 97, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 4 },
                    { 98, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 2 },
                    { 99, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 3 },
                    { 100, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 6 },
                    { 101, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 6 },
                    { 102, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 6 },
                    { 103, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 104, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 5 },
                    { 105, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 2 },
                    { 106, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 2 },
                    { 107, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 3 },
                    { 108, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 3 },
                    { 109, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 2 },
                    { 110, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 6 },
                    { 111, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 6 },
                    { 112, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 3 },
                    { 113, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 1 },
                    { 114, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 3 },
                    { 115, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 4 },
                    { 116, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 6 },
                    { 117, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 3 },
                    { 118, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 2 },
                    { 119, new DateTime(2025, 1, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 1 },
                    { 120, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 5 },
                    { 121, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 122, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 123, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 4 },
                    { 124, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 125, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 4 },
                    { 126, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 127, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 },
                    { 128, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 6 },
                    { 129, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 2 },
                    { 130, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 1 },
                    { 131, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 132, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 6 },
                    { 133, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 134, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 3 },
                    { 135, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 1 },
                    { 136, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 137, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 2 },
                    { 138, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 4 },
                    { 139, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 1 },
                    { 140, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 3 },
                    { 141, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 3 },
                    { 142, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 2 },
                    { 143, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 4 },
                    { 144, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 2 },
                    { 145, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 3 },
                    { 146, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 3 },
                    { 147, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 148, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 149, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 5 },
                    { 150, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 3 },
                    { 151, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 5 },
                    { 152, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 2 },
                    { 153, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 6 },
                    { 154, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 2 },
                    { 155, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 4 },
                    { 156, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 1 },
                    { 157, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 2 },
                    { 158, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 4 },
                    { 159, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 3 },
                    { 160, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 3 },
                    { 161, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 2 },
                    { 162, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 4 },
                    { 163, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 3 },
                    { 164, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 2 },
                    { 165, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 3 },
                    { 166, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 167, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 5 },
                    { 168, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 1 },
                    { 169, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 6 },
                    { 170, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 6 },
                    { 171, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 5 },
                    { 172, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 2 },
                    { 173, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 174, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 5 },
                    { 175, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 5 },
                    { 176, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 3 },
                    { 177, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 2 },
                    { 178, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 179, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 4 },
                    { 180, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 5 },
                    { 181, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 1 },
                    { 182, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 4 },
                    { 183, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 1 },
                    { 184, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 4 },
                    { 185, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 4 },
                    { 186, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 5 },
                    { 187, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 5 },
                    { 188, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 4 },
                    { 189, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 3 },
                    { 190, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 5 },
                    { 191, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 5 },
                    { 192, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 3 },
                    { 193, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 2 },
                    { 194, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 3 },
                    { 195, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 3 },
                    { 196, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 3 },
                    { 197, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 1 },
                    { 198, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 4 },
                    { 199, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 200, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 1 },
                    { 201, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 5 },
                    { 202, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 6 },
                    { 203, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 6 },
                    { 204, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 205, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 4 },
                    { 206, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 5 },
                    { 207, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 1 },
                    { 208, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 2 },
                    { 209, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 5 },
                    { 210, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 6 },
                    { 211, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 3 },
                    { 212, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 2 },
                    { 213, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 6 },
                    { 214, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 2 },
                    { 215, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 1 },
                    { 216, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 5 },
                    { 217, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 1 },
                    { 218, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 3 },
                    { 219, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 2 },
                    { 220, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 4 },
                    { 221, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 4 },
                    { 222, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 1 },
                    { 223, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 6 },
                    { 224, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 5 },
                    { 225, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 6 },
                    { 226, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 5 },
                    { 227, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 6 },
                    { 228, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 229, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 2 },
                    { 230, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 3 },
                    { 231, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 2 },
                    { 232, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 6 },
                    { 233, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 1 },
                    { 234, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 6 },
                    { 235, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 3 },
                    { 236, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 5 },
                    { 237, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 6 },
                    { 238, new DateTime(2025, 1, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 1 },
                    { 239, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 5 },
                    { 240, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 4 },
                    { 241, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 2 },
                    { 242, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 3 },
                    { 243, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 5 },
                    { 244, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 6 },
                    { 245, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 2 },
                    { 246, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 1 },
                    { 247, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 6 },
                    { 248, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 4 },
                    { 249, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 4 },
                    { 250, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 2 },
                    { 251, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 1 },
                    { 252, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 4 },
                    { 253, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 254, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 5 },
                    { 255, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 4 },
                    { 256, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 1 },
                    { 257, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { 258, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 6 },
                    { 259, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 5 },
                    { 260, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 6 },
                    { 261, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 1 },
                    { 262, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 5 },
                    { 263, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 5 },
                    { 264, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 6 },
                    { 265, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 266, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 6 },
                    { 267, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 268, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 2 },
                    { 269, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 6 },
                    { 270, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 4 },
                    { 271, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 4 },
                    { 272, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 5 },
                    { 273, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 6 },
                    { 274, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 4 },
                    { 275, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 5 },
                    { 276, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 4 },
                    { 277, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 5 },
                    { 278, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 1 },
                    { 279, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 3 },
                    { 280, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 1 },
                    { 281, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 1 },
                    { 282, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 5 },
                    { 283, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 4 },
                    { 284, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 5 },
                    { 285, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 2 },
                    { 286, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 1 },
                    { 287, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 2 },
                    { 288, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 6 },
                    { 289, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 3 },
                    { 290, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 291, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 2 },
                    { 292, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 1 },
                    { 293, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 294, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 5 },
                    { 295, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 3 },
                    { 296, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 1 },
                    { 297, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 298, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 5 },
                    { 299, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 2 },
                    { 300, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 1 },
                    { 301, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 2 },
                    { 302, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 4 },
                    { 303, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 2 },
                    { 304, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 305, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 3 },
                    { 306, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 2 },
                    { 307, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 3 },
                    { 308, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 5 },
                    { 309, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 5 },
                    { 310, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 5 },
                    { 311, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 312, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 1 },
                    { 313, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 4 },
                    { 314, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 315, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 3 },
                    { 316, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 2 },
                    { 317, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 4 },
                    { 318, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 319, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 3 },
                    { 320, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 4 },
                    { 321, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 3 },
                    { 322, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 5 },
                    { 323, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 1 },
                    { 324, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 4 },
                    { 325, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 5 },
                    { 326, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 327, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 2 },
                    { 328, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 1 },
                    { 329, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 2 },
                    { 330, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 5 },
                    { 331, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 5 },
                    { 332, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 2 },
                    { 333, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 4 },
                    { 334, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 5 },
                    { 335, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 2 },
                    { 336, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 4 },
                    { 337, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 4 },
                    { 338, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 6 },
                    { 339, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 340, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 4 },
                    { 341, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 2 },
                    { 342, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 6 },
                    { 343, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 344, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 4 },
                    { 345, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 2 },
                    { 346, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 4 },
                    { 347, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 5 },
                    { 348, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 5 },
                    { 349, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 5 },
                    { 350, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 1 },
                    { 351, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 6 },
                    { 352, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 2 },
                    { 353, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 3 },
                    { 354, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 1 },
                    { 355, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 1 },
                    { 356, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 5 },
                    { 357, new DateTime(2025, 1, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 6 },
                    { 358, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 359, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 360, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 3 },
                    { 361, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 1 },
                    { 362, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 2 },
                    { 363, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 4 },
                    { 364, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 365, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 366, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 3 },
                    { 367, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 1 },
                    { 368, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 3 },
                    { 369, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 4 },
                    { 370, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 4 },
                    { 371, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 372, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 1 },
                    { 373, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 374, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 6 },
                    { 375, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 4 },
                    { 376, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 5 },
                    { 377, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 6 },
                    { 378, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 3 },
                    { 379, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 5 },
                    { 380, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 381, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 382, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 3 },
                    { 383, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 },
                    { 384, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 1 },
                    { 385, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 5 },
                    { 386, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 3 },
                    { 387, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 1 },
                    { 388, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 5 },
                    { 389, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 5 },
                    { 390, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 6 },
                    { 391, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 1 },
                    { 392, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 1 },
                    { 393, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 4 },
                    { 394, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 4 },
                    { 395, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 4 },
                    { 396, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 397, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 3 },
                    { 398, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 1 },
                    { 399, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 3 },
                    { 400, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 401, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 4 },
                    { 402, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 6 },
                    { 403, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 1 },
                    { 404, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 3 },
                    { 405, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 6 },
                    { 406, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 407, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 4 },
                    { 408, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 4 },
                    { 409, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 3 },
                    { 410, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 4 },
                    { 411, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 3 },
                    { 412, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 1 },
                    { 413, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 1 },
                    { 414, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 3 },
                    { 415, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 4 },
                    { 416, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 2 },
                    { 417, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 6 },
                    { 418, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 5 },
                    { 419, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 420, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 1 },
                    { 421, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 4 },
                    { 422, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 1 },
                    { 423, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 1 },
                    { 424, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 5 },
                    { 425, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 5 },
                    { 426, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 5 },
                    { 427, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 4 },
                    { 428, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 4 },
                    { 429, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 1 },
                    { 430, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 4 },
                    { 431, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 3 },
                    { 432, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 433, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 5 },
                    { 434, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 5 },
                    { 435, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 2 },
                    { 436, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 2 },
                    { 437, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 4 },
                    { 438, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 4 },
                    { 439, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 440, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 6 },
                    { 441, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 2 },
                    { 442, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 443, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 6 },
                    { 444, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 6 },
                    { 445, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 2 },
                    { 446, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 4 },
                    { 447, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 5 },
                    { 448, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 5 },
                    { 449, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 3 },
                    { 450, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 5 },
                    { 451, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 1 },
                    { 452, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 3 },
                    { 453, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 6 },
                    { 454, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 3 },
                    { 455, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 4 },
                    { 456, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 6 },
                    { 457, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 3 },
                    { 458, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 1 },
                    { 459, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 5 },
                    { 460, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 3 },
                    { 461, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 3 },
                    { 462, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 463, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 464, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 5 },
                    { 465, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 3 },
                    { 466, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 3 },
                    { 467, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 1 },
                    { 468, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 5 },
                    { 469, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 5 },
                    { 470, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 6 },
                    { 471, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 6 },
                    { 472, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 4 },
                    { 473, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 4 },
                    { 474, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 6 },
                    { 475, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 6 },
                    { 476, new DateTime(2025, 2, 5, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 5, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 3 },
                    { 477, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 1 },
                    { 478, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 4 },
                    { 479, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 480, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 6 },
                    { 481, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 6 },
                    { 482, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 2 },
                    { 483, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 484, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 6 },
                    { 485, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 486, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 2 },
                    { 487, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 6 },
                    { 488, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 1 },
                    { 489, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 1 },
                    { 490, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 491, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 492, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 4 },
                    { 493, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 1 },
                    { 494, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 4 },
                    { 495, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 4 },
                    { 496, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 497, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 3 },
                    { 498, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 3 },
                    { 499, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 6 },
                    { 500, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 2 },
                    { 501, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 502, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 1 },
                    { 503, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 3 },
                    { 504, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 1 },
                    { 505, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 1 },
                    { 506, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 2 },
                    { 507, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 6 },
                    { 508, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 4 },
                    { 509, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 4 },
                    { 510, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 4 },
                    { 511, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 1 },
                    { 512, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 3 },
                    { 513, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 5 },
                    { 514, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 2 },
                    { 515, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 1 },
                    { 516, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 4 },
                    { 517, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 6 },
                    { 518, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 3 },
                    { 519, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 520, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 1 },
                    { 521, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 5 },
                    { 522, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 6 },
                    { 523, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 6 },
                    { 524, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 3 },
                    { 525, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 1 },
                    { 526, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 4 },
                    { 527, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 5 },
                    { 528, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 1 },
                    { 529, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 2 },
                    { 530, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 6 },
                    { 531, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 4 },
                    { 532, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 4 },
                    { 533, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 6 },
                    { 534, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 2 },
                    { 535, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 536, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 6 },
                    { 537, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 5 },
                    { 538, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 5 },
                    { 539, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 2 },
                    { 540, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 3 },
                    { 541, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 4 },
                    { 542, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 4 },
                    { 543, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 5 },
                    { 544, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 3 },
                    { 545, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 6 },
                    { 546, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 1 },
                    { 547, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 3 },
                    { 548, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 5 },
                    { 549, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 5 },
                    { 550, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 551, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 552, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 1 },
                    { 553, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 4 },
                    { 554, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 6 },
                    { 555, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 3 },
                    { 556, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 1 },
                    { 557, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 1 },
                    { 558, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 6 },
                    { 559, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 5 },
                    { 560, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 1 },
                    { 561, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 2 },
                    { 562, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 6 },
                    { 563, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 3 },
                    { 564, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 1 },
                    { 565, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 1 },
                    { 566, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 3 },
                    { 567, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 5 },
                    { 568, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 1 },
                    { 569, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 6 },
                    { 570, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 2 },
                    { 571, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 6 },
                    { 572, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 3 },
                    { 573, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 5 },
                    { 574, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 2 },
                    { 575, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 576, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 6 },
                    { 577, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 2 },
                    { 578, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 3 },
                    { 579, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 5 },
                    { 580, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 2 },
                    { 581, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 1 },
                    { 582, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 3 },
                    { 583, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 1 },
                    { 584, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 1 },
                    { 585, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 6 },
                    { 586, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 5 },
                    { 587, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 2 },
                    { 588, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 4 },
                    { 589, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 2 },
                    { 590, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 1 },
                    { 591, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 5 },
                    { 592, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 1 },
                    { 593, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 1 },
                    { 594, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 1 },
                    { 595, new DateTime(2025, 2, 15, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 15, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 6 },
                    { 596, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 597, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 598, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 2, 6 },
                    { 599, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 600, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 3, 1 },
                    { 601, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 3, 6 },
                    { 602, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 4, 5 },
                    { 603, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 4, 3 },
                    { 604, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 4, 5 },
                    { 605, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 4, 1 },
                    { 606, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 5, 2 },
                    { 607, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 5, 6 },
                    { 608, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 5, 2 },
                    { 609, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 5, 6 },
                    { 610, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 5, 5 },
                    { 611, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 6, 6 },
                    { 612, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 6, 3 },
                    { 613, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 6, 5 },
                    { 614, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 6, 5 },
                    { 615, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 6, 3 },
                    { 616, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 6, 4 },
                    { 617, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 7, 1 },
                    { 618, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 7, 5 },
                    { 619, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 7, 4 },
                    { 620, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 7, 6 },
                    { 621, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 7, 5 },
                    { 622, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 7, 2 },
                    { 623, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 7, 3 },
                    { 624, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 8, 3 },
                    { 625, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 8, 6 },
                    { 626, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 8, 1 },
                    { 627, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 8, 5 },
                    { 628, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 629, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 8, 5 },
                    { 630, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 8, 5 },
                    { 631, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 8, 3 },
                    { 632, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 9, 1 },
                    { 633, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 9, 3 },
                    { 634, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 9, 5 },
                    { 635, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 9, 2 },
                    { 636, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 9, 1 },
                    { 637, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 9, 1 },
                    { 638, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 9, 2 },
                    { 639, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 9, 6 },
                    { 640, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 9, 3 },
                    { 641, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 10, 6 },
                    { 642, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 10, 5 },
                    { 643, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 10, 6 },
                    { 644, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 10, 4 },
                    { 645, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 10, 5 },
                    { 646, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 10, 5 },
                    { 647, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 10, 2 },
                    { 648, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 10, 3 },
                    { 649, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 10, 4 },
                    { 650, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 10, 1 },
                    { 651, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 11, 2 },
                    { 652, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 11, 5 },
                    { 653, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 11, 1 },
                    { 654, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 11, 1 },
                    { 655, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 11, 2 },
                    { 656, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 11, 6 },
                    { 657, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 11, 2 },
                    { 658, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 11, 6 },
                    { 659, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 11, 2 },
                    { 660, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 11, 1 },
                    { 661, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 11, 5 },
                    { 662, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 12, 6 },
                    { 663, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 12, 5 },
                    { 664, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 12, 3 },
                    { 665, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 12, 2 },
                    { 666, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 12, 6 },
                    { 667, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 12, 4 },
                    { 668, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 12, 2 },
                    { 669, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 12, 4 },
                    { 670, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 12, 6 },
                    { 671, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 12, 2 },
                    { 672, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 12, 5 },
                    { 673, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 12, 5 },
                    { 674, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 13, 4 },
                    { 675, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 13, 2 },
                    { 676, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 13, 4 },
                    { 677, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 13, 1 },
                    { 678, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 13, 6 },
                    { 679, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 13, 4 },
                    { 680, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 13, 5 },
                    { 681, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 13, 3 },
                    { 682, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 13, 6 },
                    { 683, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 13, 6 },
                    { 684, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 13, 3 },
                    { 685, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 13, 4 },
                    { 686, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 13, 3 },
                    { 687, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 15, 14, 4 },
                    { 688, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 14, 3 },
                    { 689, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 14, 3 },
                    { 690, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 14, 4 },
                    { 691, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 14, 1 },
                    { 692, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 14, 2 },
                    { 693, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 14, 6 },
                    { 694, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 14, 2 },
                    { 695, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 14, 5 },
                    { 696, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 14, 1 },
                    { 697, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 14, 3 },
                    { 698, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 14, 4 },
                    { 699, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 14, 1 },
                    { 700, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 14, 3 },
                    { 701, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 14, 15, 5 },
                    { 702, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 13, 15, 3 },
                    { 703, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 12, 15, 5 },
                    { 704, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 11, 15, 1 },
                    { 705, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 10, 15, 3 },
                    { 706, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 9, 15, 1 },
                    { 707, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 8, 15, 2 },
                    { 708, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 7, 15, 1 },
                    { 709, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 6, 15, 5 },
                    { 710, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 15, 4 },
                    { 711, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 4, 15, 3 },
                    { 712, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 3, 15, 1 },
                    { 713, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 2, 15, 1 },
                    { 714, new DateTime(2025, 2, 25, 10, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 25, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 15, 3 }
                });

            migrationBuilder.InsertData(
                table: "IssuedTickets",
                columns: new[] { "IssuedTicketId", "Amount", "IssuedDate", "RouteId", "TicketId", "UserId", "ValidFrom", "ValidTo" },
                values: new object[,]
                {
                    { 1, 8, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 131, 4, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 5, 6, new DateTime(2024, 9, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 291, 1, 5, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 228, 1, 5, new DateTime(2024, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 17, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 3, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 3, 2, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 357, 5, 5, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 9, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, 3, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 9, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 160, 4, 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 376, 3, 4, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 5, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 326, 4, 2, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 7, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 539, 5, 1, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 6, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 686, 4, 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 8, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 251, 2, 5, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 3, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 451, 2, 5, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 9, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 2, 1, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 6, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 2, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 2, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 4, 2, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 2, new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 343, 2, 2, new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 4, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 3, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 627, 2, 3, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 5, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 544, 1, 1, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 9, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 475, 5, 4, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 258, 4, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 7, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 334, 2, 5, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 7, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 386, 2, 6, new DateTime(2024, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 2, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 609, 4, 4, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 9, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 5, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 7, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, 3, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, 2, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 2, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 663, 2, 4, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 4, new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 605, 4, 2, new DateTime(2024, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 21, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 7, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 503, 2, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 32, 9, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 474, 5, 2, new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 414, 2, 5, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 543, 1, 5, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 2, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 509, 4, 4, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 29, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 5, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 2, 4, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 7, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 237, 2, 6, new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 2, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 219, 4, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 7, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 386, 3, 2, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 9, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 437, 5, 2, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 8, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 246, 5, 5, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 1, new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4, 1, new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 27, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 7, new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 1, 4, new DateTime(2024, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 2, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 482, 3, 1, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 1, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 351, 2, 6, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 16, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 6, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 610, 3, 3, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 9, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 644, 4, 2, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 8, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 533, 5, 6, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 7, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 497, 3, 3, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 5, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 348, 1, 1, new DateTime(2025, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 6, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 648, 4, 4, new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 8, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5, 5, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 6, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 306, 3, 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 1, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 373, 5, 4, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 8, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 452, 1, 3, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 577, 2, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 8, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 289, 3, 6, new DateTime(2024, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 29, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 6, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 473, 2, 2, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 6, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 5, 3, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 2, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 554, 1, 3, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 5, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 334, 4, 3, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 3, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 2, 4, new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 24, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 3, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 2, new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 557, 5, 6, new DateTime(2024, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 523, 2, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 9, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 698, 2, 4, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 9, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 687, 3, 4, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 14, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 1, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 2, 3, new DateTime(2024, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 27, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 4, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 258, 3, 4, new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 19, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 4, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 2, 1, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 3, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 8, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 592, 3, 6, new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 2, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 2, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 470, 2, 6, new DateTime(2024, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 13, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 5, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 3, 1, new DateTime(2024, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 7, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 3, 5, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 6, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 321, 1, 6, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 1, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 3, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 8, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 7, new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 153, 3, 3, new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 22, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 4, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 396, 5, 3, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 1, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 4, 4, new DateTime(2025, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 6, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 4, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 633, 1, 6, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 3, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 4, 5, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 5, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 4, 3, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 17, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 85, 7, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 452, 2, 3, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 9, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 211, 4, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 6, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 5, 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 6, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 580, 3, 1, new DateTime(2024, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 4, 24, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 8, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 299, 5, 6, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 544, 4, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 576, 3, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 1, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 356, 5, 2, new DateTime(2024, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 7, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 510, 2, 4, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 5, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 2, 2, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 9, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 3, 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 10, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 9, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 3, new DateTime(2025, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 4, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 2, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 535, 1, 2, new DateTime(2025, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 9, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 1, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 514, 2, 4, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 4, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 440, 1, 5, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 7, 1, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 9, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 2, 1, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 5, 3, 0, 0, 0, DateTimeKind.Unspecified) }
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
                name: "IX_Manufacturers_ManufacturerCountryId",
                table: "Manufacturers",
                column: "ManufacturerCountryId");

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

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
