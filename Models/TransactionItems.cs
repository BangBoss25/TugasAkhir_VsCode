namespace TugasAkhir_VsCode.Models
{
	public class TransactionItems
	{
		public int Id { get; set; }
		public Transaction id_transaction { get; set; }
		public Items id_barang { get; set; }
		public int jumlah_barang { get; set; }
		public int total_barang { get; set; }
	}
}
