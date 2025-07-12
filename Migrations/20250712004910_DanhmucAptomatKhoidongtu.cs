using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class DanhmucAptomatKhoidongtu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "669f9668-1f90-404b-94fa-332f4f504dec", "AQAAAAIAAYagAAAAEPEpZskF7E1xWoOhgV2RIY8NuHSXE6c56oa88TxhqFBeyyiYl4HesOEGXbIzdKD06A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e384308-5b25-470d-b708-e31fa08d20e9", "AQAAAAIAAYagAAAAELpmaMY1/4flCxKoH8hNDIfMZAUnP2Pe/xB7Pow5l7siLMWuXugVdwQdFyeDskft7Q==" });
        }
    }
}
