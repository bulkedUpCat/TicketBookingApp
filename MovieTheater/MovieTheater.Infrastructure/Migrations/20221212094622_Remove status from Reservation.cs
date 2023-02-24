using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class RemovestatusfromReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "168cdaec-1196-4b37-a1e9-9f7f08c48ad7");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8ca421d1-48fa-4035-a5a0-a061bd51968d");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bdd6796f-f9f3-46f3-b066-d484e8f1c33a");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "099ac1b4-4b9b-4a18-b1a6-f58e64bbea37", "8be3dfcb-5a7a-4201-8e5f-6107ccc4559f", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ac2e80c-e79e-466c-9d35-0021cb521d56", "5e6079d6-1acb-4b38-9cc9-8dd6946034ce", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0c777b4-5c72-4bc5-ac95-358ab90def8d", "2124c56f-aa9c-4109-a984-79fe41ee1b76", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "099ac1b4-4b9b-4a18-b1a6-f58e64bbea37");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8ac2e80c-e79e-466c-9d35-0021cb521d56");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e0c777b4-5c72-4bc5-ac95-358ab90def8d");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "168cdaec-1196-4b37-a1e9-9f7f08c48ad7", "919153b2-31e1-4f0d-9539-b5544b86e911", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ca421d1-48fa-4035-a5a0-a061bd51968d", "8568b159-281e-423a-bcc2-cd49c0172cb6", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bdd6796f-f9f3-46f3-b066-d484e8f1c33a", "dd7b8efe-8ee3-4b19-a438-afa44239bdb1", "Visitor", "VISITOR" });
        }
    }
}
