using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Practice.Migrations
{
    /// <inheritdoc />
    public partial class addedUserid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25a153c5-b1c0-4614-800b-452e329e908e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "586abedc-c959-4d11-9059-96b59e47f9ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef5d7092-bf3f-4f1f-839c-82c0c2bd09c2");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "595515c6-2126-43e0-9de4-74abbac1549d", null, "Administration", "ADMINISTRATION" },
                    { "8fddb13c-f519-4713-94db-baa3c924faa1", null, "Dealer", "DEALER" },
                    { "c3e21a8b-6bb0-4ddc-b77e-bf7856577898", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "595515c6-2126-43e0-9de4-74abbac1549d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fddb13c-f519-4713-94db-baa3c924faa1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3e21a8b-6bb0-4ddc-b77e-bf7856577898");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bookings");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25a153c5-b1c0-4614-800b-452e329e908e", null, "Dealer", "DEALER" },
                    { "586abedc-c959-4d11-9059-96b59e47f9ec", null, "User", "USER" },
                    { "ef5d7092-bf3f-4f1f-839c-82c0c2bd09c2", null, "Administration", "ADMINISTRATION" }
                });
        }
    }
}
