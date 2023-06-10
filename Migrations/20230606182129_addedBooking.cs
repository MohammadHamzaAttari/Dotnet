using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Practice.Migrations
{
    /// <inheritdoc />
    public partial class addedBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "200df382-260b-46e3-a187-2122d2e40e4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bf53c4b-ee80-4096-8bff-2624bb22d5da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac7ec4bf-0ca0-4607-aeed-7e783ed6dbc3");

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrimName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrimPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "200df382-260b-46e3-a187-2122d2e40e4e", null, "Administration", "ADMINISTRATION" },
                    { "2bf53c4b-ee80-4096-8bff-2624bb22d5da", null, "Dealer", "DEALER" },
                    { "ac7ec4bf-0ca0-4607-aeed-7e783ed6dbc3", null, "User", "USER" }
                });
        }
    }
}
