using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghopgiacotthuyluc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tonghopgiacotthuyluc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThietBiId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tonghopgiacotthuyluc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tonghopgiacotthuyluc_Danhmucgiacotthuyluc_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "Danhmucgiacotthuyluc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tonghopgiacotthuyluc_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopgiacotthuyluc_DonViId",
                table: "Tonghopgiacotthuyluc",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopgiacotthuyluc_ThietBiId",
                table: "Tonghopgiacotthuyluc",
                column: "ThietBiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tonghopgiacotthuyluc");

            
        }
    }
}
