using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TugasAkhir_VsCode.Migrations
{
    /// <inheritdoc />
    public partial class tb_pemesanan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    status_bayar = table.Column<string>(type: "longtext", nullable: true),
                    total = table.Column<int>(type: "int", nullable: false),
                    tanggal_pemesanan = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pemesanan", x => x.id_transaksi);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_pemesanan_item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    id_transactionid_transaksi = table.Column<string>(type: "varchar(255)", nullable: true),
                    id_barangKode_barang = table.Column<string>(type: "varchar(255)", nullable: true),
                    jumlah_barang = table.Column<int>(type: "int", nullable: false),
                    total_barang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pemesanan_item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_pemesanan_item_tb_items_id_barangKode_barang",
                        column: x => x.id_barangKode_barang,
                        principalTable: "tb_items",
                        principalColumn: "Kode_barang");
                    table.ForeignKey(
                        name: "FK_tb_pemesanan_item_tb_pemesanan_id_transactionid_transaksi",
                        column: x => x.id_transactionid_transaksi,
                        principalTable: "tb_pemesanan",
                        principalColumn: "id_transaksi");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "tb_users",
                keyColumn: "UserId",
                keyValue: "U0001",
                column: "BgEffDate",
                value: new DateTime(2024, 6, 13, 21, 55, 8, 825, DateTimeKind.Local).AddTicks(6198));

            migrationBuilder.CreateIndex(
                name: "IX_tb_pemesanan_item_id_barangKode_barang",
                table: "tb_pemesanan_item",
                column: "id_barangKode_barang");

            migrationBuilder.CreateIndex(
                name: "IX_tb_pemesanan_item_id_transactionid_transaksi",
                table: "tb_pemesanan_item",
                column: "id_transactionid_transaksi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_pemesanan_item");

            migrationBuilder.DropTable(
                name: "tb_pemesanan");

            migrationBuilder.UpdateData(
                table: "tb_users",
                keyColumn: "UserId",
                keyValue: "U0001",
                column: "BgEffDate",
                value: new DateTime(2024, 5, 18, 14, 35, 15, 238, DateTimeKind.Local).AddTicks(2780));
        }
    }
}
