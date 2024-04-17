using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ePrijevozSarajevo.Services.Migrations
{
    /// <inheritdoc />
    public partial class RS212_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Vehicles_VehicleId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_VehicleId",
                table: "Routes");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeOfDeparture",
                table: "Routes",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeOfArrival",
                table: "Routes",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeOfDeparture",
                table: "Routes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TimeOfArrival",
                table: "Routes",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_VehicleId",
                table: "Routes",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Vehicles_VehicleId",
                table: "Routes",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
