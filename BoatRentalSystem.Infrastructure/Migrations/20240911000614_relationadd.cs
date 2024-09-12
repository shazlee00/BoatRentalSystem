using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Boats_BoatId",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 6, 14, 186, DateTimeKind.Local).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 6, 14, 186, DateTimeKind.Local).AddTicks(8727));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 6, 14, 186, DateTimeKind.Local).AddTicks(8731));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Boats_BoatId",
                table: "Reservations",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "BoatId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Boats_BoatId",
                table: "Reservations");

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 2, 39, 10, 689, DateTimeKind.Local).AddTicks(9896));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 2, 39, 10, 689, DateTimeKind.Local).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 2, 39, 10, 689, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Boats_BoatId",
                table: "Reservations",
                column: "BoatId",
                principalTable: "Boats",
                principalColumn: "BoatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
