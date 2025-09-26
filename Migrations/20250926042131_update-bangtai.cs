using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatebangtai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenBangTai",
                table: "DanhMucBangTai",
                newName: "TenThietBi");
           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {           

            migrationBuilder.RenameColumn(
                name: "TenThietBi",
                table: "DanhMucBangTai",
                newName: "TenBangTai");

            
        }
    }
}
