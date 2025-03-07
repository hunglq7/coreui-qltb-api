using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Nhatkyquatgio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NhatKyQuatGio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonghopquatgioId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyQuatGio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyQuatGio_TonghopQuatgio_TonghopquatgioId",
                        column: x => x.TonghopquatgioId,
                        principalTable: "TonghopQuatgio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyQuatGio_TonghopquatgioId",
                table: "NhatKyQuatGio",
                column: "TonghopquatgioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhatKyQuatGio");

          
        }
    }
}
