using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TugasAkhir_VsCode.Migrations
{
    /// <inheritdoc />
    public partial class InittableDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_users",
                keyColumn: "UserId",
                keyValue: "U0001",
                column: "BgEffDate",
                value: new DateTime(2024, 2, 2, 20, 3, 26, 154, DateTimeKind.Local).AddTicks(7145));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tb_users",
                keyColumn: "UserId",
                keyValue: "U0001",
                column: "BgEffDate",
                value: new DateTime(2024, 2, 2, 20, 1, 17, 734, DateTimeKind.Local).AddTicks(6899));
        }
    }
}
