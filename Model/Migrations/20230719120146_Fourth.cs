using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

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
    }
}
