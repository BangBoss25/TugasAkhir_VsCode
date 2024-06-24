using TugasAkhir_VsCode.Models.ViewModel;

namespace TugasAkhir_VsCode.Models.ViewModel
{
    public class Order
    {
        public string? NoTransaksi { get; set; }
        public string? Nama { get; set; }
        public string? Alamat { get; set; }
        public string? Prov { get; set; }
        public string? Kota { get; set; }
        public string? NoTelp { get; set; }
        public string? Stat { get; set; }
        public string? StatBayar { get; set; }
        public int JmlBayar { get; set; }
        public int TotalBelanja { get; set; }
        public List<OrderItem> Items { get; set; }
    }
    public class BookingTransaksi
    {
        public Order Order { get; set; }
        public List<Items> Item { get; set; }

        public BookingTransaksi()
        {
            Order = new Order();
            Item = new List<Items>();
        }
    }
}

