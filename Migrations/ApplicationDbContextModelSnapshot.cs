﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TugasAkhir_VsCode.Data;

#nullable disable

namespace TugasAkhir_VsCode.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TugasAkhir_VsCode.Models.Items", b =>
                {
                    b.Property<string>("Kode_barang")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Bahan")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DMODI")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Deskripsi")
                        .HasColumnType("longtext");

                    b.Property<long>("Harga_jual")
                        .HasColumnType("bigint");

                    b.Property<long>("Harga_modal")
                        .HasColumnType("bigint");

                    b.Property<string>("Image1")
                        .HasColumnType("longtext");

                    b.Property<string>("Nama_barang")
                        .HasColumnType("longtext");

                    b.Property<string>("PathImage1")
                        .HasColumnType("longtext");

                    b.Property<int>("Stok_barang")
                        .HasColumnType("int");

                    b.Property<string>("Ukuran")
                        .HasColumnType("longtext");

                    b.Property<string>("VMODI")
                        .HasColumnType("longtext");

                    b.Property<string>("Warna")
                        .HasColumnType("longtext");

                    b.HasKey("Kode_barang");

                    b.ToTable("tb_items");
                });

            modelBuilder.Entity("TugasAkhir_VsCode.Models.Roles", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("RolesId");

                    b.ToTable("tb_roles");
                });

            modelBuilder.Entity("TugasAkhir_VsCode.Models.Transaction", b =>
                {
                    b.Property<string>("id_transaksi")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("alamat_lengkap")
                        .HasColumnType("longtext");

                    b.Property<string>("kota")
                        .HasColumnType("longtext");

                    b.Property<string>("nama_pelanggan")
                        .HasColumnType("longtext");

                    b.Property<string>("no_telp")
                        .HasColumnType("longtext");

                    b.Property<string>("provinsi")
                        .HasColumnType("longtext");

                    b.Property<string>("status_bayar")
                        .HasColumnType("longtext");

                    b.Property<string>("status_pemesanan")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("tanggal_pemesanan")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("total")
                        .HasColumnType("int");

                    b.Property<int>("total_bayar")
                        .HasColumnType("int");

                    b.HasKey("id_transaksi");

                    b.ToTable("tb_pemesanan");
                });

            modelBuilder.Entity("TugasAkhir_VsCode.Models.TransactionItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ItemsKode_barang")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("id_transactionid_transaksi")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("jumlah_barang")
                        .HasColumnType("int");

                    b.Property<int>("total_barang")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemsKode_barang");

                    b.HasIndex("id_transactionid_transaksi");

                    b.ToTable("tb_pemesanan_item");
                });

            modelBuilder.Entity("TugasAkhir_VsCode.Models.Users", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("BgEffDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Role_User")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("tb_users");

                    b.HasData(
                        new
                        {
                            UserId = "U0001",
                            BgEffDate = new DateTime(2024, 6, 18, 0, 16, 51, 413, DateTimeKind.Local).AddTicks(1754),
                            Name = "Administrator",
                            Password = "Admin2024",
                            Role_User = "Admin",
                            Status = "0",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("TugasAkhir_VsCode.Models.TransactionItems", b =>
                {
                    b.HasOne("TugasAkhir_VsCode.Models.Items", "Items")
                        .WithMany()
                        .HasForeignKey("ItemsKode_barang");

                    b.HasOne("TugasAkhir_VsCode.Models.Transaction", "id_transaction")
                        .WithMany()
                        .HasForeignKey("id_transactionid_transaksi");

                    b.Navigation("Items");

                    b.Navigation("id_transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
