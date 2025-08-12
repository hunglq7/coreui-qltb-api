using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Nhatkyaptomatkhoidongtu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhatkyAptomatKhoidongtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThietBiId = table.Column<int>(type: "int", nullable: false),
                    NgayThang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ThongsoAptomatKhoidongtuId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatkyAptomatKhoidongtu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatkyAptomatKhoidongtu_ThongsoAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                        column: x => x.ThongsoAptomatKhoidongtuId,
                        principalTable: "ThongsoAptomatKhoidongtu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NhatkyAptomatKhoidongtu_TongHopAptomatKhoidongtu_ThietBiId",
                        column: x => x.ThietBiId,
                        principalTable: "TongHopAptomatKhoidongtu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyAptomatKhoidongtu_ThietBiId",
                table: "NhatkyAptomatKhoidongtu",
                column: "ThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "NhatkyAptomatKhoidongtu",
                column: "ThongsoAptomatKhoidongtuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhatkyAptomatKhoidongtu");

           
        }
    }
}
