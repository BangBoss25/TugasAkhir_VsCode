using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TugasAkhir_VsCode.Migrations
{
    /// <inheritdoc />
    public partial class Inittb_items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_items",
                columns: table => new
                {
                    Kode_barang = table.Column<string>(type: "varchar(255)", nullable: false),
                    Nama_barang = table.Column<string>(type: "longtext", nullable: true),
                    Harga_modal = table.Column<long>(type: "bigint", nullable: false),
                    Harga_jual = table.Column<long>(type: "bigint", nullable: false),
                    Stok_barang = table.Column<int>(type: "int", nullable: false),
                    Deskripsi = table.Column<string>(type: "longtext", nullable: true),
                    PathImage1 = table.Column<string>(type: "longtext", nullable: true),
                    Image1 = table.Column<string>(type: "longtext", nullable: true),
                    Bahan = table.Column<string>(type: "longtext", nullable: true),
                    Warna = table.Column<string>(type: "longtext", nullable: true),
                    Ukuran = table.Column<string>(type: "longtext", nullable: true),
                    VMODI = table.Column<string>(type: "longtext", nullable: true),
                    DMODI = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_items", x => x.Kode_barang);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_roles",
                columns: table => new
                {
                    RolesId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_roles", x => x.RolesId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true),
                    Username = table.Column<string>(type: "longtext", nullable: true),
                    Password = table.Column<string>(type: "longtext", nullable: true),
                    BgEffDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: true),
                    Role_User = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_users", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tb_users",
                columns: new[] { "UserId", "BgEffDate", "Name", "Password", "Role_User", "Status", "Username" },
                values: new object[] { "U0001", new DateTime(2024, 2, 2, 20, 1, 17, 734, DateTimeKind.Local).AddTicks(6899), "Administrator", "Admin2024", "Admin", "0", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_items");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tb_users");
        }
    }
}
