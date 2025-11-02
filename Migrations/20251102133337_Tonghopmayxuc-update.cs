using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghopmayxucupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "duPhong",
                table: "TongHopNeo",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "duPhong",
                table: "TongHopMayCao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "duPhong",
                table: "TongHopKhoan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "duPhong",
                table: "Tonghopgiacotthuyluc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "duPhong",
                table: "TongHopBangTai",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "duPhong",
                table: "TonghopBalang",
                type: "bit",
                nullable: false,
                defaultValue: false);

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duPhong",
                table: "TongHopNeo");

            migrationBuilder.DropColumn(
                name: "duPhong",
                table: "TongHopMayCao");

            migrationBuilder.DropColumn(
                name: "duPhong",
                table: "TongHopKhoan");

            migrationBuilder.DropColumn(
                name: "duPhong",
                table: "Tonghopgiacotthuyluc");

            migrationBuilder.DropColumn(
                name: "duPhong",
                table: "TongHopBangTai");

            migrationBuilder.DropColumn(
                name: "duPhong",
                table: "TonghopBalang");

           
        }
    }
}
