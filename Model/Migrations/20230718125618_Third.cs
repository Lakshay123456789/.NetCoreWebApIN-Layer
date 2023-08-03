using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddToCarts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    IsCheckOut = table.Column<bool>(type: "bit", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddToCarts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "634a60ec-96bc-4f37-937f-27ba52f58d41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53494590-ac9c-4b27-beca-adafbdec9325", "AQAAAAEAACcQAAAAEFY8uUhpIuzmXWuNkcLHjYP7Vn18oPXtKbfxN+kng24O2LZtXNl9/zvNINnn8wSNdQ==", "88f02059-f00c-4ac2-81c0-cf916b3e178d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80d49e8-a97c-45e6-babf-0760a6b86814",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ca6b5a7-1d06-4ac2-8f53-10b1e13153c3", "AQAAAAEAACcQAAAAEMTg04K2bp08+oL/vYEnX8fMfdQjpuyhSMWxGIfor0fd4wFFpH2clnbnFm1P2Sjuiw==", "071a4159-3656-4517-885f-9afa48d9b533" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddToCarts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "634a60ec-96bc-4f37-937f-27ba52f58d41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4700bff0-bfeb-4932-8a2e-f994552321c2", "AQAAAAEAACcQAAAAEKemTD+Ytr7yZ84TnUuCXq44T+3NNzFLZ7JFY8aMKIi/MQRYYBfJTy7MXyNBc26tWQ==", "94b37939-bc66-4a82-8469-b5fa59539be6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c80d49e8-a97c-45e6-babf-0760a6b86814",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56655026-28bd-490e-8c96-9719e17ba39c", "AQAAAAEAACcQAAAAEMiw18L4qnoQERFqUVSG2+ckgayAvMr/DE61aKhqFXy1HiI1HHx24W7+zqDWBEZ6CA==", "e3afc575-93af-45f5-99a3-61f1b756c03f" });
        }
    }
}
