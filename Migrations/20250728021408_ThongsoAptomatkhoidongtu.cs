using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ThongsoAptomatkhoidongtu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThongsoAptomatKhoidongtu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AptomatKhoidongtuId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThongSo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsoAptomatKhoidongtu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsoAptomatKhoidongtu_DanhmucAptomatKhoidongtu_AptomatKhoidongtuId",
                        column: x => x.AptomatKhoidongtuId,
                        principalTable: "DanhmucAptomatKhoidongtu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_ThongsoAptomatKhoidongtu_AptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                column: "AptomatKhoidongtuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongsoAptomatKhoidongtu");

           
        }
    }
}
