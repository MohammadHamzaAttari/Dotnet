using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Practice.Migrations
{
    /// <inheritdoc />
    public partial class datatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<double>(
                name: "TrimPrice",
                table: "Bookings",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01fccd14-39f7-4b05-9981-036bbf3e81eb", null, "Dealer", "DEALER" },
                    { "0203fa12-bbe0-4d91-b143-ad1687549371", null, "Administration", "ADMINISTRATION" },
                    { "983bda1c-a3d2-42d1-a017-ef66a46e4d6a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01fccd14-39f7-4b05-9981-036bbf3e81eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0203fa12-bbe0-4d91-b143-ad1687549371");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "983bda1c-a3d2-42d1-a017-ef66a46e4d6a");

            migrationBuilder.AlterColumn<string>(
                name: "TrimPrice",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

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
    }
}
