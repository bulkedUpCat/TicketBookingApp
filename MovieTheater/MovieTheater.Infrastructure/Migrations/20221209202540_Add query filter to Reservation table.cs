using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class AddqueryfiltertoReservationtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
