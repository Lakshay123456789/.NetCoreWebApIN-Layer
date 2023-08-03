using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class FivthOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "forgetPasswords",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forgetPasswords", x => x.Email);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "634a60ec-96bc-4f37-937f-27ba52f58d41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "032c2e17-23ec-4ef4-9255-91f106ec5165", "AQAAAAEAACcQAAAAEJZ9INGH31/iRCG2aE3TiBlimshstYblMJ35E35zpBTWrDNLzt0S+rlytkCUNxX7Zw==", "35a2ae05-2142-46f2-a433-ce0c49d89b36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80d49e8-a97c-45e6-babf-0760a6b86814",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9caee0e9-5c82-44e7-b464-504326b8cbbd", "AQAAAAEAACcQAAAAEITIuCOe2S+VjllDx5/SSW5uJJi0hr1owrnp+WkTQ2j+QYv9hMHwmnZzO0xvF2UT4g==", "4d0ec665-e364-49b5-b1c0-206e5c1dd16c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forgetPasswords");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "634a60ec-96bc-4f37-937f-27ba52f58d41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce7e9a62-a3c7-40bb-9311-b9eac951536e", "AQAAAAEAACcQAAAAENwhpZqTtt+R6GgtLzrjA5vFpTgU8f/oyEd1vXTusxtcZzN2u0ypzrXfI5j+Znx54g==", "5bfa2793-6e74-4715-9234-832ba0045357" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80d49e8-a97c-45e6-babf-0760a6b86814",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3d60955-a910-422d-86bf-663df6155cbf", "AQAAAAEAACcQAAAAECT+eArIgAMv07ts8wfwP1zyHKt8qyKsJWN64vEVR+MhrnFgtFXp9S9FTftsEYz9tw==", "ac210f4f-4a82-4a8b-9c29-e2e4ba0d0b6c" });
        }
    }
}
