using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Practice.Migrations
{
    /// <inheritdoc />
    public partial class addedFirstName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "96235186-2eaa-4540-9f85-55d5e213928d", null, "Administration", "ADMINISTRATION" },
                    { "cd48b941-9fa9-4e05-be99-25b55bdb5516", null, "Dealer", "DEALER" },
                    { "def96f05-d77d-4fb1-81c3-4f14e8775822", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96235186-2eaa-4540-9f85-55d5e213928d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd48b941-9fa9-4e05-be99-25b55bdb5516");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "def96f05-d77d-4fb1-81c3-4f14e8775822");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Bookings");

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
    }
}
