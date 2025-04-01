using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class khoanupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoaiThietBi",
                table: "TongHopKhoan",
                newName: "DonViTinh");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2b2a8f6-154e-489f-b9d9-42ac8507abbb", "AQAAAAIAAYagAAAAEJh/Mue7bSBCflh6kE7f5Ia23/7/6ENOcEeYUkXdullxihjCVcV4MpfqM9YXmCC5RQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DonViTinh",
                table: "TongHopKhoan",
                newName: "LoaiThietBi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e965c873-357c-4e86-98fc-5eb02e8afc29", "AQAAAAIAAYagAAAAEN+2WypX7N/Lm3QBykO9TXJ9y0FiRzAtHSqVbl2Kni5l5Gff5gA+A1RaaiT9KwCGsQ==" });
        }
    }
}
