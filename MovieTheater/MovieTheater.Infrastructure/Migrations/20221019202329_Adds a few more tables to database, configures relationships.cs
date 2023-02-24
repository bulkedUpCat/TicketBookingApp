using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class Addsafewmoretablestodatabaseconfiguresrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MovieDirectorId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductionCompanyId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MovieDirectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieLanguages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieMovieLanguage",
                columns: table => new
                {
                    MovieLanguagesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieLanguage", x => new { x.MovieLanguagesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieMovieLanguage_MovieLanguages_MovieLanguagesId",
                        column: x => x.MovieLanguagesId,
                        principalTable: "MovieLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMovieLanguage_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieProductionCountry",
                columns: table => new
                {
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductionCountriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieProductionCountry", x => new { x.MoviesId, x.ProductionCountriesId });
                    table.ForeignKey(
                        name: "FK_MovieProductionCountry_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieProductionCountry_ProductionCountries_ProductionCountriesId",
                        column: x => x.ProductionCountriesId,
                        principalTable: "ProductionCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieDirectorId",
                table: "Movies",
                column: "MovieDirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProductionCompanyId",
                table: "Movies",
                column: "ProductionCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieLanguage_MoviesId",
                table: "MovieMovieLanguage",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieProductionCountry_ProductionCountriesId",
                table: "MovieProductionCountry",
                column: "ProductionCountriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieDirectors_MovieDirectorId",
                table: "Movies",
                column: "MovieDirectorId",
                principalTable: "MovieDirectors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ProductionCompany_ProductionCompanyId",
                table: "Movies",
                column: "ProductionCompanyId",
                principalTable: "ProductionCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieDirectors_MovieDirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ProductionCompany_ProductionCompanyId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MovieMovieLanguage");

            migrationBuilder.DropTable(
                name: "MovieProductionCountry");

            migrationBuilder.DropTable(
                name: "ProductionCompany");

            migrationBuilder.DropTable(
                name: "MovieLanguages");

            migrationBuilder.DropTable(
                name: "ProductionCountries");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieDirectorId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ProductionCompanyId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "MovieDirectorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ProductionCompanyId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Genres");
        }
    }
}
