using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class Removespricefromseataddstoscreeningaddspriceoffsettoseat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "465ca3fa-9a6b-4be6-896f-f309b983fcaf");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b5a019a7-3ed7-4a2d-aea3-5cc1e79989ee");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f4ec5d79-0644-4378-bd62-44138819dfe0");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Seats",
                newName: "PriceOffset");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Screenings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "087ea5b7-833b-4d7d-a0c3-0ed83a22c219", "5c5aadc6-1a64-404a-8b39-3a2efa44ff62", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2025de1-7954-45ef-aea5-fc307307e19c", "2d962473-f7cc-4884-a69b-c2c14978a40c", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5622864-62d7-472a-965a-823db594c232", "0ede0746-3965-494b-9f48-6fc6fe89799b", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "087ea5b7-833b-4d7d-a0c3-0ed83a22c219");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a2025de1-7954-45ef-aea5-fc307307e19c");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d5622864-62d7-472a-965a-823db594c232");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Screenings");

            migrationBuilder.RenameColumn(
                name: "PriceOffset",
                table: "Seats",
                newName: "Price");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "465ca3fa-9a6b-4be6-896f-f309b983fcaf", "f953cf34-91b4-4c00-b5b3-8a674e85467c", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5a019a7-3ed7-4a2d-aea3-5cc1e79989ee", "60b4b21f-da23-41d3-8665-76d271548649", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4ec5d79-0644-4378-bd62-44138819dfe0", "9291fd4b-5efd-47bd-a5de-a5e63efbceae", "Member", "MEMBER" });
        }
    }
}
