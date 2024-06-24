using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TugasAkhir_VsCode.Data;
using TugasAkhir_VsCode.Models;
using TugasAkhir_VsCode.Models.ViewModel;

namespace TugasAkhir_VsCode.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area("Admin")]
public class ShopController : Controller
{

    private readonly ApplicationDbContext ctx;
    
    public ShopController(ApplicationDbContext c)
    {
        ctx = c;
    }

    public int ConvertToInt32(string x)
    {
        return Convert.ToInt32(x);
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost, ActionName("data-load")]
    public async Task<IActionResult> GenerateDataTable([FromBody] Dictionary<string, object> filterParams)
    {
        try
        {
            var loadData = await ctx.tb_pemesanan.ToListAsync();

            return Ok(new { Status = "1", Message = "", Data = loadData });
        }
        catch (Exception ex) 
        { 
            return Ok(new { Status = "0", Message = "Error get data table" });
        }
    }

    public async Task<IActionResult> AddBooking()
    {
        var dateNow = DateTime.Now.ToString("ddMMyy");

        var result = await ctx.tb_pemesanan.OrderByDescending(x => x.id_transaksi).ToListAsync();
        var objData = new BookingTransaksi();
        string valSplit = "PSN" + dateNow;
        int id = 1;

        if (result.Count > 0)
        {
            if (valSplit.Equals(result[0].id_transaksi.Substring(0, 9)))
            {
                var tamp = result[0].id_transaksi.Split(valSplit);
                id = ConvertToInt32(tamp[1]) + 1;
            }
        }
        
        string vnopsn = "PSN" + dateNow + id.ToString("00000");

        var order = new Order()
        {
            NoTransaksi = vnopsn
        };

        objData.Item = ctx.tb_items.ToList();
        objData.Order = order;

        return View(objData);
    }

    [HttpPost, ActionName("add-Pesanan")]
    public async Task<IActionResult> AddBooking([FromBody] Order order)
    {
        try
        {

            Transaction transaksi = new Transaction()
            {
                id_transaksi = order.NoTransaksi,
                nama_pelanggan = order.Nama,
                alamat_lengkap = order.Alamat,
                provinsi = order.Prov,
                kota = order.Kota,
                no_telp = order.NoTelp,
                status_pemesanan = order.Stat,
                status_bayar = order.StatBayar,
                total_bayar = order.JmlBayar,
                total = order.TotalBelanja,
                tanggal_pemesanan = DateTime.Now
            };

            ctx.Add(transaksi);
            await ctx.SaveChangesAsync();

            var trans = await ctx.tb_pemesanan.FirstOrDefaultAsync(x => x.id_transaksi == order.NoTransaksi);

            foreach (var data in order.Items)
            {
                TransactionItems orderItem = new TransactionItems()
                {
                    id_transaction = trans,
                    kode_barang = data.KodeBarang,
                    jumlah_barang = data.Jumlah,
                    total_barang = data.Total
                };

                ctx.Add(orderItem);
                await ctx.SaveChangesAsync();
            }

            return Ok(new { Status = "1", Message = "Data has been Saved Successfully"});

        }
        catch (Exception ex) {
            return Ok(new { Status = "0", Message = "Error data saved"});
        }
    }

    public async Task<IActionResult> DetailBooking(string id)
    {
        var objData = new BookingTransaksi();

        var result = await ctx.tb_pemesanan.FirstOrDefaultAsync(x => x.id_transaksi == id);
        var result2 = await ctx.tb_pemesanan_item.Where(x => x.id_transaction.id_transaksi == id).ToListAsync();

        List<OrderItem> dataOrderItem = new List<OrderItem>();
        //var 
        foreach (var data in result2)
        {
            var item = await ctx.tb_items.FirstOrDefaultAsync(x => x.Kode_barang == data.kode_barang);
            var tamp = new OrderItem()
            {
                KodeBarang = item.Kode_barang,
                NamaBarang = item.Nama_barang,
                Harga = ConvertToInt32(item.Harga_jual.ToString()),
                Jumlah = data.jumlah_barang,
                Total = data.total_barang
            };

            dataOrderItem.Add(tamp);
        }

        var order = new Order()
        {
            NoTransaksi = result.id_transaksi,
            Nama = result.nama_pelanggan,
            Alamat = result.alamat_lengkap,
            Prov = result.provinsi,
            Kota = result.kota,
            NoTelp = result.no_telp,
            Stat = result.status_pemesanan,
            StatBayar = result.status_bayar,
            JmlBayar = result.total_bayar,
            TotalBelanja = result.total,
            Items = dataOrderItem
        };

        objData.Order = order;
        objData.Item = ctx.tb_items.ToList();

        return View(objData);
    }

    [HttpPost, ActionName("update-pesanan")]
    public async Task<IActionResult> UpdatePesanan([FromBody] Order order)
    {
        try
        {
            Transaction transaksi = new Transaction()
            {
                id_transaksi = order.NoTransaksi,
                nama_pelanggan = order.Nama,
                alamat_lengkap = order.Alamat,
                provinsi = order.Prov,
                kota = order.Kota,
                no_telp = order.NoTelp,
                status_pemesanan = order.Stat,
                status_bayar = order.StatBayar,
                total_bayar = order.JmlBayar,
                total = order.TotalBelanja,
                tanggal_pemesanan = DateTime.Now
            };

            ctx.tb_pemesanan.Update(transaksi);
            await ctx.SaveChangesAsync();

            var trans = await ctx.tb_pemesanan.FirstOrDefaultAsync(x => x.id_transaksi == order.NoTransaksi);
            var orderItem = ctx.tb_pemesanan_item.Where(x => x.id_transaction.id_transaksi == order.NoTransaksi).ToList(); 
            
            foreach (var del in orderItem)
            {
                ctx.tb_pemesanan_item.Remove(del);
                await ctx.SaveChangesAsync();
            }

            foreach (var data in order.Items)
            {
                TransactionItems addOrderItem = new TransactionItems()
                {
                    id_transaction = trans,
                    kode_barang = data.KodeBarang,
                    jumlah_barang = data.Jumlah,
                    total_barang = data.Total
                };

                ctx.Add(addOrderItem);
                await ctx.SaveChangesAsync();
            }

            return Ok(new { Status = "1", Message = "Error data saved" });
        }
        catch (Exception ex)
        {
            return Ok(new { Status = "0", Message = "Error data saved" });
        }
    }

}