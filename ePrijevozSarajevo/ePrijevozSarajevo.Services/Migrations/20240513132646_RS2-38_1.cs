using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ePrijevozSarajevo.Services.Migrations
{
    /// <inheritdoc />
    public partial class RS238_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserRoleId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "ModificationDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 12, 16, 19, 48, 962, DateTimeKind.Local).AddTicks(2617), 1, 8 },
                    { 2, new DateTime(2024, 5, 12, 16, 19, 48, 962, DateTimeKind.Local).AddTicks(2662), 2, 9 }
                });
        }
    }
}
