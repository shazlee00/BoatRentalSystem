using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class datatypeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BookingAdditions");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BoatBookings");

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 0, 5, 12, 136, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 0, 5, 12, 136, DateTimeKind.Local).AddTicks(4008));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 0, 5, 12, 136, DateTimeKind.Local).AddTicks(4012));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "BookingAdditions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "BoatBookings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 31, 50, 799, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 31, 50, 799, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 31, 50, 799, DateTimeKind.Local).AddTicks(3437));
        }
    }
}
