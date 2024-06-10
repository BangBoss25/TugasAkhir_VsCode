using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TugasAkhir_VsCode.Data;
using TugasAkhir_VsCode.Data.Helper;
using TugasAkhir_VsCode.Models;
using TugasAkhir_VsCode.Models.ViewModel;
using TugasAkhir_VsCode.Services;

namespace TugasAkhir_VsCode.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area("Admin")]
public class ItemController : Controller
{

    private readonly ApplicationDbContext _context;
    private readonly FileService _file;

    public ItemController(ApplicationDbContext ctx, FileService file)
    {
        _context = ctx;
        _file = file;
    }

    public IActionResult Index()
    {
        var item = from i in _context.tb_items select i;

        return View(item);
    }

    public int ConvertToInt32(string x)
    {
        return Convert.ToInt32(x);
    }

    public async Task<IActionResult> AddItem()
    {
        var result = await _context.tb_items.OrderByDescending(x => x.Kode_barang).ToListAsync();
        string barangId = "";
        int id = 1;
        string year = DateTime.Now.Year.ToString();
        string valSplit = "B" + year.Substring(2);

        if (result.Count > 0)
        {
            var tamp = result[0].Kode_barang.Split(valSplit);
            id = ConvertToInt32(tamp[1]) + 1;
        }

        barangId = "B" + year.Substring(2) + id.ToString("00000");
        Console.WriteLine("Cek Barang : " + barangId + "," + year.Substring(2));

        var itemVm = new ItemVm()
        {
            Kode_barang = barangId,
            Stok_barang = 0
        };

        return View(itemVm);
    }

    [HttpPost]
    public async Task<IActionResult> AddItem(ItemVm paramItem, IFormFile image1)
    {
        string valItemName = paramItem.Nama_barang ?? "";
        string valItemModal = paramItem.Harga_modal ?? "";
        string valItemJual = paramItem.Harga_jual ?? "";
        string valItemStok = paramItem.Stok_barang.ToString() ?? "";
        string valItemWarna = paramItem.Warna ?? "";
        string valItemUkuran = paramItem.Ukuran ?? "";
        string valItemDeskripsi = paramItem.Deskripsi ?? "";
        bool validation = true;

        if (valItemName == "") { ViewBag.Error = "Field Nama Barang is required,"; validation = false; }
        if (valItemModal == "") { ViewBag.Error += "Field Harga Modal is required,"; validation = false; }
        if (valItemJual == "") { ViewBag.Error += "Field Harga Jual is required,"; validation = false; }
        if (valItemStok == "") { ViewBag.Error += "Field Stok Barang is required,"; validation = false; }
        if (valItemWarna == "") { ViewBag.Error += "Field Warna Tersedia is required,"; validation = false; }
        if (valItemUkuran == "") { ViewBag.Error += "Field Ukuran is required,"; validation = false; }
        if (valItemDeskripsi == "") { ViewBag.Error += "Field Keterang is required,"; validation = false; }

        if (validation)
        {
            string user = User.getUsername();

            var pathImage1 = _file.SaveFile(image1, paramItem.Kode_barang, "1").Result;

            Items dt = new Items()
            {
                Kode_barang = paramItem.Kode_barang,
                Nama_barang = valItemName,
                Harga_modal = Convert.ToInt64(valItemModal),
                Harga_jual = Convert.ToInt64(valItemJual),
                Stok_barang = Convert.ToInt32(valItemStok),
                Deskripsi = valItemDeskripsi,
                Bahan = paramItem.Bahan,
                Ukuran = paramItem.Ukuran,
                Warna = paramItem.Warna,
                PathImage1 = pathImage1 == "" ? null : pathImage1,
                Image1 = pathImage1 == "" ? null : pathImage1.Split('/')[3],
                VMODI = user,
                DMODI = DateTime.Now
            };

            _context.Add(dt);
            await _context.SaveChangesAsync();

            ViewBag.Message = "Data has been Saved Successfully";
        }

        return View();
    }

    [HttpGet]
    public async Task<IActionResult> EditItem(string id)
    {
        var result = await _context.tb_items.FirstOrDefaultAsync(x => x.Kode_barang == id);

        ItemVm detailItem = new ItemVm()
        {
            Kode_barang = result.Kode_barang,
            Nama_barang = result.Nama_barang,
            Harga_modal = result.Harga_modal.ToString(),
            Harga_jual = result.Harga_jual.ToString(),
            Stok_barang = Convert.ToInt32(result.Stok_barang),
            Deskripsi = result.Deskripsi,
            pathImage1 = result.PathImage1,
            image1 = result.Image1,
            dmodi = result.DMODI
        };

        return View(detailItem);
    }

    [HttpPost]
    public async Task<IActionResult> EditItem(ItemVm param, IFormFile image1)
    {
        bool validation = true;

        if (string.IsNullOrEmpty(param.Nama_barang)) { ViewBag.Error = "Field Nama Barang is required,"; validation = false; }
        if (string.IsNullOrEmpty(param.Harga_modal)) { ViewBag.Error += "Field Harga Modal is required,"; validation = false; }
        if (string.IsNullOrEmpty(param.Harga_jual)) { ViewBag.Error += "Field Harga Jual is required,"; validation = false; }
        if (string.IsNullOrEmpty(param.Stok_barang.ToString())) { ViewBag.Error += "Field Stok Barang is required,"; validation = false; }
        if (string.IsNullOrEmpty(param.Deskripsi)) { ViewBag.Error += "Field Keterang is required,"; validation = false; }

        if (validation)
        {
            
            ViewBag.Message = "Data has been Saved Successfully";
        }
        else
        {
            var result = new Items();
            if (image1 == null) {
                result = await _context.tb_items.FirstOrDefaultAsync(x => x.Kode_barang == param.Kode_barang);
            }

            ItemVm editView = new ItemVm()
            {
                Kode_barang = param.Kode_barang,
                Nama_barang = param.Nama_barang,
                Harga_modal = param.Harga_modal == null ? "" : param.Harga_modal.ToString(),
                Harga_jual = param.Harga_jual == null ? "" : param.Harga_jual.ToString(),
                Stok_barang = Convert.ToInt32(param.Stok_barang),
                Deskripsi = param.Deskripsi,
                pathImage1 = result.PathImage1 == "" ? null : result.PathImage1, 
                image1 = image1 == null ? param.image1 : image1.FileName,
                dmodi = param.dmodi
            };

            return View(editView);
        }

        return View();
    }

    public async Task<IActionResult> DeleteItem(string id)
    {
        var cari = await _context.tb_items.Where(i => i.Kode_barang == id).FirstOrDefaultAsync();

        if (cari == null)
        {
            return NotFound();
        }

        _context.tb_items.Remove(cari);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DetailItem(string id)
    {
        var result = await _context.tb_items.FirstOrDefaultAsync(x => x.Kode_barang == id);

        ItemVm detailItem = new ItemVm()
        {
            Kode_barang = result.Kode_barang,
            Nama_barang = result.Nama_barang,
            Harga_modal = result.Harga_modal.ToString(),
            Harga_jual = result.Harga_jual.ToString(),
            Stok_barang = Convert.ToInt32(result.Stok_barang),
            Deskripsi = result.Deskripsi,
            pathImage1 = result.PathImage1,
            image1 = result.Image1,
            dmodi = result.DMODI
        };

        return View(detailItem);
    }

}