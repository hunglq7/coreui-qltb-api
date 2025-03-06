using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class thongsoquatgioedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhmucQuatgio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucQuatgio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongsoQuatgio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuatgioId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThongSo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsoQuatgio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsoQuatgio_DanhmucQuatgio_QuatgioId",
                        column: x => x.QuatgioId,
                        principalTable: "DanhmucQuatgio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_ThongsoQuatgio_QuatgioId",
                table: "ThongsoQuatgio",
                column: "QuatgioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongsoQuatgio");

            migrationBuilder.DropTable(
                name: "DanhmucQuatgio");

           
        }
    }
}
