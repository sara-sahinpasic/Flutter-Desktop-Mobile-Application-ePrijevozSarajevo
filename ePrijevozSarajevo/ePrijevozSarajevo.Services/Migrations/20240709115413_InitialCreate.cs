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
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                    UserStatusId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    DocumentLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
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
                    TimeOfDeparture = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeOfArrival = table.Column<TimeSpan>(type: "time", nullable: true),
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    { 1, 0.29999999999999999, "Student" },
                    { 2, 0.5, "Pensioner" },
                    { 3, 0.14999999999999999, "Employed" },
                    { 4, 0.40000000000000002, "Unemployed" }
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
                    { 1, true, "Adresa 11", new DateTime(1998, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@edu.fit.ba", "Sara", "Šahinpašić", new DateTime(2024, 7, 9, 13, 54, 13, 90, DateTimeKind.Local).AddTicks(6057), "F09vSkvhluS56pu5yjetSqW5QRs=", "9UuUiDRoUpna/WWH/2aurA==", "061222333", "", new DateTime(2024, 7, 9, 13, 54, 13, 90, DateTimeKind.Local).AddTicks(6019), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "desktop", 3 },
                    { 2, true, "Adresa 12", new DateTime(1988, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.sahinpasic@hotmail.com", "Senada", "Šahinpašić", new DateTime(2024, 7, 9, 13, 54, 13, 90, DateTimeKind.Local).AddTicks(6071), "fOtBcZ5o/u0bXTMQnmmfcZym0yU=", "ZIlvdvjIqiPbLlNwubz37g==", "061222444", "", new DateTime(2024, 7, 9, 13, 54, 13, 90, DateTimeKind.Local).AddTicks(6070), new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "mobile", 3 }
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
                table: "Routes",
                columns: new[] { "RouteId", "Active", "ActiveOnHolidays", "ActiveOnWeekends", "EndStationId", "StartStationId", "TimeOfArrival", "TimeOfDeparture", "VehicleId" },
                values: new object[,]
                {
                    { 1, true, true, true, 6, 1, new TimeSpan(0, 2, 30, 0, 0), new TimeSpan(0, 2, 0, 0, 0), 2 },
                    { 2, true, true, true, 8, 1, new TimeSpan(0, 7, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 4 },
                    { 3, true, true, true, 6, 1, new TimeSpan(0, 22, 30, 0, 0), new TimeSpan(0, 22, 0, 0, 0), 6 },
                    { 4, true, true, true, 7, 2, new TimeSpan(0, 1, 30, 0, 0), new TimeSpan(0, 1, 0, 0, 0), 4 },
                    { 5, true, true, true, 3, 7, new TimeSpan(0, 20, 30, 0, 0), new TimeSpan(0, 20, 0, 0, 0), 2 },
                    { 6, true, true, true, 1, 8, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0), 6 },
                    { 7, true, true, true, 15, 9, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 14, 0, 0, 0), 1 },
                    { 8, true, true, true, 8, 11, new TimeSpan(0, 7, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0), 3 },
                    { 9, true, true, true, 14, 10, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 9, 0, 0, 0), 5 },
                    { 10, true, true, true, 7, 13, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 10, 0, 0, 0), 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "ModificationDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 9, 13, 54, 13, 90, DateTimeKind.Local).AddTicks(6469), 1, 1 },
                    { 2, new DateTime(2024, 7, 9, 13, 54, 13, 90, DateTimeKind.Local).AddTicks(6472), 2, 2 }
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
