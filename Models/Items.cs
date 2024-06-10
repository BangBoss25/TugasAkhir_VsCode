using System.ComponentModel.DataAnnotations;

namespace TugasAkhir_VsCode.Models;

public class Items
{
    [Key]
    public string? Kode_barang { get; set; }
    public string? Nama_barang { get; set; }
    public long Harga_modal { get; set; }
    public long Harga_jual { get; set; }
    public int Stok_barang { get; set; }
    public string? Deskripsi { get; set; }
    public string? PathImage1 { get; set; }
    public string? Image1 { get; set; }
    public string? Bahan { get; set; }
    public string? Warna { get; set; }
    public string? Ukuran { get; set; }
    public string? VMODI { get; set; }
    public DateTime DMODI { get; set; }
}