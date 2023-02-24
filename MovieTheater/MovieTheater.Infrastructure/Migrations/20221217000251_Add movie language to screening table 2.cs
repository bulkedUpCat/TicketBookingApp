using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class Addmovielanguagetoscreeningtable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MovieLanguageId",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieLanguageId",
                table: "Screenings",
                column: "MovieLanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Screenings_MovieLanguages_MovieLanguageId",
                table: "Screenings",
                column: "MovieLanguageId",
                principalTable: "MovieLanguages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screenings_MovieLanguages_MovieLanguageId",
                table: "Screenings");

            migrationBuilder.DropIndex(
                name: "IX_Screenings_MovieLanguageId",
                table: "Screenings");

            migrationBuilder.AlterColumn<Guid>(
                name: "MovieLanguageId",
                table: "Screenings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
