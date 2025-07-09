using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class thongsobienap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThongSoKyThuatBienAp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BienapId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuatBienAp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatBienAp_DanhmucBienap_BienapId",
                        column: x => x.BienapId,
                        principalTable: "DanhmucBienap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b41cdb0-2ea4-4982-ba1c-ad637df06416", "AQAAAAIAAYagAAAAEAQl7h9UkW2UkI2xbquunH0/qcSO6od4ZZ+plkC+KjalOs4rlok/hDErWNiGhRDF4Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatBienAp_BienapId",
                table: "ThongSoKyThuatBienAp",
                column: "BienapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongSoKyThuatBienAp");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e17d7035-1963-4c7f-b264-2b03a1ffc754", "AQAAAAIAAYagAAAAEM30S2gdc/lnyIPdMfAFWY+0Ndi/dOwsSuGp9LDrfmd6tWQO+sK24sMHxxY3trEnxQ==" });
        }
    }
}
