using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class updatedanhmuckhoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a9b6e5db-3b71-47ca-a582-69bf119f50e8", "AQAAAAIAAYagAAAAEA/wFwSZF4cDFkHjlf6b/W7VuQ6AAw8gZY/ZJpQBIKivA+g/nREIvsLIcXukpLAE8A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "940c0ca9-0090-427c-9164-9e97a213183f", "AQAAAAIAAYagAAAAEMOMSecv0mVP4OdCtjr0twcCQalKJQ50wGlxcNSuqwP3ByIyeT0Ex6KFQCDeps3+Jg==" });
        }
    }
}
