using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class someseeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Additions",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "OwnerId", "Price", "ReservationId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 11, 2, 18, 37, 464, DateTimeKind.Local).AddTicks(5999), "Includes a variety of local dishes for your trip.", "Lunch Package", 2, 15.0, null, null },
                    { 2, new DateTime(2024, 9, 11, 2, 18, 37, 464, DateTimeKind.Local).AddTicks(6003), "High-quality snorkeling gear for underwater exploration.", "Snorkeling Gear", 2, 25.0, null, null },
                    { 3, new DateTime(2024, 9, 11, 2, 18, 37, 464, DateTimeKind.Local).AddTicks(6007), "Full fishing kit for a day of fishing on the boat.", "Fishing Equipment", 2, 30.0, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Additions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
