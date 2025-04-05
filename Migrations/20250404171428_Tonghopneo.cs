using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghopneo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TongHopNeo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeoId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TinhTrangKyThuat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopNeo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopNeo_DanhmucNeo_NeoId",
                        column: x => x.NeoId,
                        principalTable: "DanhmucNeo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopNeo_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "624e68bf-d526-4acd-8fb7-a3885cb05fd2", "AQAAAAIAAYagAAAAEP1h110N713pfDXVf17MyTc2Icjx8xl8J1B41YT3xxOUWlXN0aYjfG0BbRvVjUxC2Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_TongHopNeo_DonViId",
                table: "TongHopNeo",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopNeo_NeoId",
                table: "TongHopNeo",
                column: "NeoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TongHopNeo");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d47a6dc1-fc23-462c-a404-4a89ff76ffbd", "AQAAAAIAAYagAAAAEDi7muup+awNRnetruygZZauI1MW9eNlxNV7QVUEJmUcbnmJd409cOrJK9Spl16VKQ==" });
        }
    }
}
