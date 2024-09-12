using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Bookings_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ReservationAdditions");

            migrationBuilder.AddColumn<int>(
                name: "ReservationAdditionId",
                table: "ReservationAdditions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Additions",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions",
                column: "ReservationAdditionId");

            migrationBuilder.CreateTable(
                name: "BoatBookings",
                columns: table => new
                {
                    BoatBookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BoatId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationHours = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CanceledAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatBookings", x => x.BoatBookingId);
                    table.ForeignKey(
                        name: "FK_BoatBookings_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BoatBookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BookingAdditions",
                columns: table => new
                {
                    BookingAdditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatBookingId = table.Column<int>(type: "int", nullable: false),
                    AdditionId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingAdditions", x => x.BookingAdditionId);
                    table.ForeignKey(
                        name: "FK_BookingAdditions_Additions_AdditionId",
                        column: x => x.AdditionId,
                        principalTable: "Additions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BookingAdditions_BoatBookings_BoatBookingId",
                        column: x => x.BoatBookingId,
                        principalTable: "BoatBookings",
                        principalColumn: "BoatBookingId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BookingAdditions_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cancellations",
                columns: table => new
                {
                    CancellationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true),
                    BoatBookingId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CancellationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancellations", x => x.CancellationId);
                    table.ForeignKey(
                        name: "FK_Cancellations_BoatBookings_BoatBookingId",
                        column: x => x.BoatBookingId,
                        principalTable: "BoatBookings",
                        principalColumn: "BoatBookingId");
                    table.ForeignKey(
                        name: "FK_Cancellations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cancellations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "ReservationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationAdditions_AdditionId",
                table: "ReservationAdditions",
                column: "AdditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Additions_ReservationId",
                table: "Additions",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_BoatBookings_BoatId",
                table: "BoatBookings",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_BoatBookings_CustomerId",
                table: "BoatBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingAdditions_AdditionId",
                table: "BookingAdditions",
                column: "AdditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingAdditions_BoatBookingId",
                table: "BookingAdditions",
                column: "BoatBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingAdditions_ReservationId",
                table: "BookingAdditions",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_BoatBookingId",
                table: "Cancellations",
                column: "BoatBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_CustomerId",
                table: "Cancellations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cancellations_ReservationId",
                table: "Cancellations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Additions_Reservations_ReservationId",
                table: "Additions",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Additions_Reservations_ReservationId",
                table: "Additions");

            migrationBuilder.DropTable(
                name: "BookingAdditions");

            migrationBuilder.DropTable(
                name: "Cancellations");

            migrationBuilder.DropTable(
                name: "BoatBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions");

            migrationBuilder.DropIndex(
                name: "IX_ReservationAdditions_AdditionId",
                table: "ReservationAdditions");

            migrationBuilder.DropIndex(
                name: "IX_Additions_ReservationId",
                table: "Additions");

            migrationBuilder.DropColumn(
                name: "ReservationAdditionId",
                table: "ReservationAdditions");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Additions");

            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "ReservationAdditions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReservationAdditions",
                table: "ReservationAdditions",
                columns: new[] { "AdditionId", "ReservationId" });
        }
    }
}
