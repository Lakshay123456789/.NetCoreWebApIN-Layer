using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b31f9c27-4c2d-4f82-9aa8-a5a10382ca98", "1", "Admin", "Admin" },
                    { "fa6f6c49-37f8-4447-a6bd-1c0a2a1353dc", "2", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "634a60ec-96bc-4f37-937f-27ba52f58d41", 0, "4700bff0-bfeb-4932-8a2e-f994552321c2", "", false, false, null, "admin123@gmail.com", "admin123@gmail.com", "AQAAAAEAACcQAAAAEKemTD+Ytr7yZ84TnUuCXq44T+3NNzFLZ7JFY8aMKIi/MQRYYBfJTy7MXyNBc26tWQ==", null, false, "94b37939-bc66-4a82-8469-b5fa59539be6", false, "admin123@gmail.com" },
                    { "c80d49e8-a97c-45e6-babf-0760a6b86814", 0, "56655026-28bd-490e-8c96-9719e17ba39c", "user123@gmail.com", false, false, null, "user123@gmail.com", "user123@gmail.com", "AQAAAAEAACcQAAAAEMiw18L4qnoQERFqUVSG2+ckgayAvMr/DE61aKhqFXy1HiI1HHx24W7+zqDWBEZ6CA==", null, false, "e3afc575-93af-45f5-99a3-61f1b756c03f", false, "user123@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b31f9c27-4c2d-4f82-9aa8-a5a10382ca98", "634a60ec-96bc-4f37-937f-27ba52f58d41" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fa6f6c49-37f8-4447-a6bd-1c0a2a1353dc", "c80d49e8-a97c-45e6-babf-0760a6b86814" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b31f9c27-4c2d-4f82-9aa8-a5a10382ca98", "634a60ec-96bc-4f37-937f-27ba52f58d41" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa6f6c49-37f8-4447-a6bd-1c0a2a1353dc", "c80d49e8-a97c-45e6-babf-0760a6b86814" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b31f9c27-4c2d-4f82-9aa8-a5a10382ca98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa6f6c49-37f8-4447-a6bd-1c0a2a1353dc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "634a60ec-96bc-4f37-937f-27ba52f58d41");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80d49e8-a97c-45e6-babf-0760a6b86814");
        }
    }
}
