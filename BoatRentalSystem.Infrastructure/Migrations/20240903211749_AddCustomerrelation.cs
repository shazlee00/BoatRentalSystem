using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e51d44a-9b49-408a-88cb-c90fc64dc738");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae5cdfac-a203-4445-96bc-1d06e64032f7", null, "Customer", "CUSTOMER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5cdfac-a203-4445-96bc-1d06e64032f7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e51d44a-9b49-408a-88cb-c90fc64dc738", null, "Customer", "CUSTOMER" });
        }
    }
}
