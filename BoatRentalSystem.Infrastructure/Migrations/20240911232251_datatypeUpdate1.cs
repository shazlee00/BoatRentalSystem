using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class datatypeUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingAdditions_Reservations_ReservationId",
                table: "BookingAdditions");

            migrationBuilder.DropIndex(
                name: "IX_BookingAdditions_ReservationId",
                table: "BookingAdditions");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "BookingAdditions");

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 2, 22, 51, 119, DateTimeKind.Local).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 2, 22, 51, 119, DateTimeKind.Local).AddTicks(7818));

            migrationBuilder.UpdateData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 12, 2, 22, 51, 119, DateTimeKind.Local).AddTicks(7822));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "BookingAdditions",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_BookingAdditions_ReservationId",
                table: "BookingAdditions",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingAdditions_Reservations_ReservationId",
                table: "BookingAdditions",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
