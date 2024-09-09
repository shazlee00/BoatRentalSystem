using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoatRentalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCustomerIdname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3b7154a-29d4-4a80-bb95-c755b364bbe9");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Customers",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5e51d44a-9b49-408a-88cb-c90fc64dc738", null, "Customer", "CUSTOMER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5e51d44a-9b49-408a-88cb-c90fc64dc738");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Customers",
                newName: "UserID");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b3b7154a-29d4-4a80-bb95-c755b364bbe9", null, "Customer", "CUSTOMER" });
        }
    }
}
