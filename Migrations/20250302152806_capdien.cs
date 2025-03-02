using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class capdien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capdien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenthietbi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capdien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tonghopcapdien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Maquanly = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonviId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapdienId = table.Column<int>(type: "int", nullable: false),
                    Donvitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tondauthang = table.Column<int>(type: "int", nullable: false),
                    Nhaptrongky = table.Column<int>(type: "int", nullable: false),
                    Xuattrongky = table.Column<int>(type: "int", nullable: false),
                    Toncuoithang = table.Column<int>(type: "int", nullable: false),
                    Dangsudung = table.Column<int>(type: "int", nullable: false),
                    Duphong = table.Column<int>(type: "int", nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tonghopcapdien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tonghopcapdien_Capdien_CapdienId",
                        column: x => x.CapdienId,
                        principalTable: "Capdien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tonghopcapdien_PhongBan_DonviId",
                        column: x => x.DonviId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopcapdien_CapdienId",
                table: "Tonghopcapdien",
                column: "CapdienId");

            migrationBuilder.CreateIndex(
                name: "IX_Tonghopcapdien_DonviId",
                table: "Tonghopcapdien",
                column: "DonviId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tonghopcapdien");

            migrationBuilder.DropTable(
                name: "Capdien");

           
        }
    }
}
