using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class AddmovielanguageidtoScreeningtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "MovieLanguageId",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4cadecf2-1967-4612-9a5f-815ce5b02092", "d6c4e0a2-1e97-44f1-973e-3a43fc7331e5", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d0bbf459-e3ee-4ae8-b12e-478ca1c0e8c2", "5ba28543-f79d-4218-a507-14384012392e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1c92ce4-a0ce-4bbe-9869-3710b2ae1c67", "a0884473-0ce9-43f9-a98a-cd01c2606e66", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4cadecf2-1967-4612-9a5f-815ce5b02092");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d0bbf459-e3ee-4ae8-b12e-478ca1c0e8c2");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e1c92ce4-a0ce-4bbe-9869-3710b2ae1c67");

            migrationBuilder.DropColumn(
                name: "MovieLanguageId",
                table: "Screenings");

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
    }
}
