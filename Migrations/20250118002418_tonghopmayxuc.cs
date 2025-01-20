using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class tonghopmayxuc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.CreateTable(
                name: "MayXuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NamSanXuat = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    HangSanXuat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MayXuc", x => x.Id);
                });

            

            migrationBuilder.CreateTable(
                name: "ThongsokythuatMayxuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MayXucId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsokythuatMayxuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsokythuatMayxuc_MayXuc_MayXucId",
                        column: x => x.MayXucId,
                        principalTable: "MayXuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

     

            migrationBuilder.CreateTable(
                name: "TongHopMayXuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MayXucId = table.Column<int>(type: "int", nullable: false),
                    MaQuanLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LoaiThietBiId = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    PhongBanId = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopMayXuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopMayXuc_LoaiThietBi_LoaiThietBiId",
                        column: x => x.LoaiThietBiId,
                        principalTable: "LoaiThietBi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopMayXuc_MayXuc_MayXucId",
                        column: x => x.MayXucId,
                        principalTable: "MayXuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopMayXuc_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

      

            migrationBuilder.CreateTable(
                name: "NhatkyMayxuc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TonghopmayxucId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatkyMayxuc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatkyMayxuc_TongHopMayXuc_TonghopmayxucId",
                        column: x => x.TonghopmayxucId,
                        principalTable: "TongHopMayXuc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

       

            migrationBuilder.CreateIndex(
                name: "IX_NhatkyMayxuc_TonghopmayxucId",
                table: "NhatkyMayxuc",
                column: "TonghopmayxucId");

           

            migrationBuilder.CreateIndex(
                name: "IX_ThongsokythuatMayxuc_MayXucId",
                table: "ThongsokythuatMayxuc",
                column: "MayXucId");

     
            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayXuc_LoaiThietBiId",
                table: "TongHopMayXuc",
                column: "LoaiThietBiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayXuc_MayXucId",
                table: "TongHopMayXuc",
                column: "MayXucId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayXuc_PhongBanId",
                table: "TongHopMayXuc",
                column: "PhongBanId");

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropTable(
                name: "NhatkyMayxuc");           

            migrationBuilder.DropTable(
                name: "ThongsokythuatMayxuc");            

            migrationBuilder.DropTable(
                name: "TongHopMayXuc");           

            migrationBuilder.DropTable(
                name: "MayXuc");

           
        }
    }
}
