using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghopaptomatkhoidongtu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TongHopAptomatKhoidongtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThietBiId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayKiemDinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopAptomatKhoidongtu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "DanhmucAptomatKhoidongtu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopAptomatKhoidongtu_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_TongHopAptomatKhoidongtu_DonViId",
                table: "TongHopAptomatKhoidongtu",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                column: "ThietBiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TongHopAptomatKhoidongtu");

           
        }
    }
}
