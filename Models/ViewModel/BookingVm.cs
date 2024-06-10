namespace TugasAkhir_VsCode.Models.ViewModel;

public class BookingVm
{
    public string? No_Pesanan { get; set; }
    public string? Nama_Pemesan { get; set; }
    public string? No_Telp { get; set; }
    public string? Provinsi { get; set; }
    public string? Kota { get; set; }
    public string? Alamat_Lengkap { get; set; }
    public string? Status { get; set; }
}

public class BookingTransaksi
{
    public BookingVm Booking { get; set; }
    public List<Items> Item { get; set; }

    public BookingTransaksi()
    {
        Booking = new BookingVm();
        Item = new List<Items>();
    }
}