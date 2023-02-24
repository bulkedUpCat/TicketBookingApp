using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTheater.Infrastructure.Migrations
{
    public partial class Addidentitydbinitilializer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "4096c786-5577-4bb2-80c9-9c105b90e16f", "d9f4bb7d-7411-4706-995f-560c7e5b1972", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "71be2e68-fa38-4de3-b253-d34f1c16cc9a", "baf17a47-bf30-42e1-a31e-fac07868dc02", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3470262F-7571-ED11-B214-D41B81B14CB3", 0, "8288ed6b-3972-47c1-a4bc-fa4fa26e02f5", "smith@gmail.com", true, false, null, "SMITH@GMAIL.COM", "Admin", "AQAAAAEAACcQAAAAEDkYL3RUU/7ScDdxXvD9hB8eYViSrUANyvEFA9M3SPX4HVqrKWaSf8GpATYde6Wibw==", "+38012345678", false, "7JBROKPX4RLYJCPXDGP2COQ25X2DFUN5", false, "Admin" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "71be2e68-fa38-4de3-b253-d34f1c16cc9a", "3470262F-7571-ED11-B214-D41B81B14CB3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4096c786-5577-4bb2-80c9-9c105b90e16f");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "71be2e68-fa38-4de3-b253-d34f1c16cc9a", "3470262F-7571-ED11-B214-D41B81B14CB3" });

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "71be2e68-fa38-4de3-b253-d34f1c16cc9a");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: "3470262F-7571-ED11-B214-D41B81B14CB3");

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
    }
}
