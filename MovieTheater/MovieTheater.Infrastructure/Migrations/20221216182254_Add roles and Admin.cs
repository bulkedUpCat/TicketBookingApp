using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class AddrolesandAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "330ff094-ffe9-4f35-b117-821646a210b7", "d0b54878-ad7a-4d81-bc6f-33b1a5ea01a0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "991bcf90-47d0-4f83-ad30-4e3babaa02a1", "66130162-ff2e-4d3d-86b7-cd4d22890296", "Member", "MEMBER" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3e3e8ea-7c2f-4c88-bc82-8bfb7d282752", "806f8404-61b2-4559-8bad-ed696f484faa", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "330ff094-ffe9-4f35-b117-821646a210b7");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "991bcf90-47d0-4f83-ad30-4e3babaa02a1");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f3e3e8ea-7c2f-4c88-bc82-8bfb7d282752");

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
    }
}
