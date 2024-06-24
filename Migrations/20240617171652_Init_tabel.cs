using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TugasAkhir_VsCode.Migrations
{
    /// <inheritdoc />
    public partial class Init_tabel : Migration
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
                name: "tb_pemesanan",
                columns: table => new
                {
                    id_transaksi = table.Column<string>(type: "varchar(255)", nullable: false),
                    nama_pelanggan = table.Column<string>(type: "longtext", nullable: true),
                    alamat_lengkap = table.Column<string>(type: "longtext", nullable: true),
                    provinsi = table.Column<string>(type: "longtext", nullable: true),
                    kota = table.Column<string>(type: "longtext", nullable: true),
                    no_telp = table.Column<string>(type: "longtext", nullable: true),
                    status_pemesanan = table.Column<string>(type: "longtext", nullable: true),
                    status_bayar = table.Column<string>(type: "longtext", nullable: true),
                    total_bayar = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<int>(type: "int", nullable: false),
                    tanggal_pemesanan = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pemesanan", x => x.id_transaksi);
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

            migrationBuilder.CreateTable(
                name: "tb_pemesanan_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_transactionid_transaksi = table.Column<string>(type: "varchar(255)", nullable: true),
                    ItemsKode_barang = table.Column<string>(type: "varchar(255)", nullable: true),
                    jumlah_barang = table.Column<int>(type: "int", nullable: false),
                    total_barang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pemesanan_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_pemesanan_item_tb_items_ItemsKode_barang",
                        column: x => x.ItemsKode_barang,
                        principalTable: "tb_items",
                        principalColumn: "Kode_barang");
                    table.ForeignKey(
                        name: "FK_tb_pemesanan_item_tb_pemesanan_id_transactionid_transaksi",
                        column: x => x.id_transactionid_transaksi,
                        principalTable: "tb_pemesanan",
                        principalColumn: "id_transaksi");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "tb_users",
                columns: new[] { "UserId", "BgEffDate", "Name", "Password", "Role_User", "Status", "Username" },
                values: new object[] { "U0001", new DateTime(2024, 6, 18, 0, 16, 51, 413, DateTimeKind.Local).AddTicks(1754), "Administrator", "Admin2024", "Admin", "0", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_tb_pemesanan_item_id_transactionid_transaksi",
                table: "tb_pemesanan_item",
                column: "id_transactionid_transaksi");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pemesanan_item_ItemsKode_barang",
                table: "tb_pemesanan_item",
                column: "ItemsKode_barang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pemesanan_item");

            migrationBuilder.DropTable(
                name: "tb_roles");

            migrationBuilder.DropTable(
                name: "tb_users");

            migrationBuilder.DropTable(
                name: "tb_items");

            migrationBuilder.DropTable(
                name: "tb_pemesanan");
        }
    }
}
