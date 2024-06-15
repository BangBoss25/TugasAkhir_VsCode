using System.ComponentModel.DataAnnotations;

namespace TugasAkhir_VsCode.Models
{
	public class Transaction
	{
		[Key]
		public string? id_transaksi {  get; set; }
		public string? nama_pelanggan { get; set; }
		public string? alamat_lengkap { get; set; }
		public string? provinsi { get; set; }
		public string? kota { get; set; }
		public string? no_telp { get; set; }
		public string? status_bayar {  get; set; }
		public int total { get; set; }
		public DateTime tanggal_pemesanan { get; set; }
	}
}
