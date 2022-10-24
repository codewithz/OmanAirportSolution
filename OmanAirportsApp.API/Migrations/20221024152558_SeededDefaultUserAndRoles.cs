using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OmanAirportsApp.API.Migrations
{
    public partial class SeededDefaultUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "f5cf48a1-726b-4742-89db-eeaad9cd66c7", "User", "USER" },
                    { "c7ac6cfe-1f10-4baf-b604-cde350db9554", "44d414d1-646b-492d-bcbb-2016077eddf5", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30a24107-d279-4e37-96fd-01af5b38cb27", 0, "b8c8632e-37c4-4264-a943-e5e738be1a1e", "user@omanairports.com", false, "System", "User", false, null, "USER@OMANAIRPORTS.COM", "USER@OMANAIRPORTS.COM", "AQAAAAEAACcQAAAAEMdZGbyZRPKSlMviZvcfYfQ/VdPUDQzoDzjIyCoM1zUTzdKHm2EJG/210hi6rHFBbg==", null, false, "58455633-ebbb-4e97-a26d-7754106084be", false, "user@omanairports.com" },
                    { "8e448afa-f008-446e-a52f-13c449803c2e", 0, "d91ccb0e-56ea-49f2-9774-d82fb1d5cbef", "admin@omanairports.com", false, "System", "Admin", false, null, "ADMIN@OMANAIRPORTS.COM", "ADMIN@OMANAIRPORTS.COM", "AQAAAAEAACcQAAAAEJNxpjXYK6DJtZT5KNl+U+R/e+rsTMZ3MKtCEToVnlHJ/KAyW41q7rRx0mlpb7nJdQ==", null, false, "cf016d01-0e30-4ef6-9f44-b1ff3838f622", false, "admin@omanairports.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "30a24107-d279-4e37-96fd-01af5b38cb27" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c7ac6cfe-1f10-4baf-b604-cde350db9554", "8e448afa-f008-446e-a52f-13c449803c2e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8343074e-8623-4e1a-b0c1-84fb8678c8f3", "30a24107-d279-4e37-96fd-01af5b38cb27" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7ac6cfe-1f10-4baf-b604-cde350db9554", "8e448afa-f008-446e-a52f-13c449803c2e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8343074e-8623-4e1a-b0c1-84fb8678c8f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7ac6cfe-1f10-4baf-b604-cde350db9554");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30a24107-d279-4e37-96fd-01af5b38cb27");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e448afa-f008-446e-a52f-13c449803c2e");
        }
    }
}
