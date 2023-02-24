using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class Addsroleconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
