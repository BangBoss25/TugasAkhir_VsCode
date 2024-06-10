using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TugasAkhir_VsCode.Migrations
{
    /// <inheritdoc />
    public partial class InittableBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_bookings",
                columns: table => new
                {
                    VNOPSN = table.Column<string>(type: "varchar(255)", nullable: false),
                    VNAME = table.Column<string>(type: "longtext", nullable: true),
                    VNOTELP = table.Column<string>(type: "longtext", nullable: true),
                    VPROV = table.Column<string>(type: "longtext", nullable: true),
                    VKAB = table.Column<string>(type: "longtext", nullable: true),
                    VLOC = table.Column<string>(type: "longtext", nullable: true),
                    VSTAT = table.Column<string>(type: "longtext", nullable: true),
                    VPSNDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_bookings", x => x.VNOPSN);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tb_users",
                keyColumn: "UserId",
                keyValue: "U0001",
                column: "BgEffDate",
                value: new DateTime(2024, 5, 18, 14, 35, 15, 238, DateTimeKind.Local).AddTicks(2780));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_bookings");

            migrationBuilder.UpdateData(
                table: "tb_users",
                keyColumn: "UserId",
                keyValue: "U0001",
                column: "BgEffDate",
                value: new DateTime(2024, 2, 2, 20, 3, 26, 154, DateTimeKind.Local).AddTicks(7145));
        }
    }
}
