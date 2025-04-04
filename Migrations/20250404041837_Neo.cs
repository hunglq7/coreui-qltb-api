using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Neo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhmucNeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucNeo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca520e21-97d6-49c8-ac99-85fb99580c95", "AQAAAAIAAYagAAAAEEy2HmXDrhYQAjLXwNsJlG/7eqUMs//twnVah/ODpj0AX0mF/nDZ6Nnuk5M3VQRBWA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhmucNeo");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f64370c3-6f49-45f4-b5e6-d58a91a0c28e", "AQAAAAIAAYagAAAAEDzLzx4TAfubDrPsOC5Wsj/9Aaetx9YlzGYHJEoy2PfXm/U5HNhbxDGmt883wadX/g==" });
        }
    }
}
