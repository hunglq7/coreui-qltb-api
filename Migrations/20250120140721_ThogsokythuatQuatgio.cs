using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ThogsokythuatQuatgio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThongsokythuatQuatgio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuatgioId = table.Column<int>(type: "int", nullable: false),
                    NuocSX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DuongKinhBanhCT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoBanhCT = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    TocDo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LuuLuong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HaAp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CongSuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KichThuoc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ChieuDai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsokythuatQuatgio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsokythuatQuatgio_QuatGio_QuatgioId",
                        column: x => x.QuatgioId,
                        principalTable: "QuatGio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           
            migrationBuilder.CreateIndex(
                name: "IX_ThongsokythuatQuatgio_QuatgioId",
                table: "ThongsokythuatQuatgio",
                column: "QuatgioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongsokythuatQuatgio");

           
        }
    }
}
