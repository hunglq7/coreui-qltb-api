using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class nhatkytonghoptoitruc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhatkyTonghoptoitruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonghoptoitrucId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatkyTonghoptoitruc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatkyTonghoptoitruc_TongHopToiTruc_TonghoptoitrucId",
                        column: x => x.TonghoptoitrucId,
                        principalTable: "TongHopToiTruc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyTonghoptoitruc_TonghoptoitrucId",
                table: "NhatkyTonghoptoitruc",
                column: "TonghoptoitrucId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhatkyTonghoptoitruc");

            
        }
    }
}
