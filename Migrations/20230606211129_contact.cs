using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Practice.Migrations
{
    /// <inheritdoc />
    public partial class contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31de88ce-8596-402e-95bd-9d68fa83ecc5", null, "Dealer", "DEALER" },
                    { "6fd5411c-130c-4c20-a0d3-3248031ab07a", null, "User", "USER" },
                    { "79111c44-ed8b-41c0-b3f6-0ffb0fcaa42a", null, "Administration", "ADMINISTRATION" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31de88ce-8596-402e-95bd-9d68fa83ecc5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6fd5411c-130c-4c20-a0d3-3248031ab07a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79111c44-ed8b-41c0-b3f6-0ffb0fcaa42a");

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
    }
}
