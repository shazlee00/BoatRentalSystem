using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationadd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationAdditions_Additions_AdditionId",
                table: "ReservationAdditions");

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 25, 39, 846, DateTimeKind.Local).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 25, 39, 846, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 11, 3, 25, 39, 846, DateTimeKind.Local).AddTicks(3795));

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationAdditions_Additions_AdditionId",
                table: "ReservationAdditions",
                column: "AdditionId",
                principalTable: "Additions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationAdditions_Additions_AdditionId",
                table: "ReservationAdditions");

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
                name: "FK_ReservationAdditions_Additions_AdditionId",
                table: "ReservationAdditions",
                column: "AdditionId",
                principalTable: "Additions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
