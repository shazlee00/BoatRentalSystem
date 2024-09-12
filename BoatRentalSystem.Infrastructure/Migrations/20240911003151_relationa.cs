using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationa : Migration
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
    }
}
