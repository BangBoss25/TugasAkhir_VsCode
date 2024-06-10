using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TugasAkhir_VsCode.Data;
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

    public async Task<IActionResult> AddBooking()
    {
        var dateNow = DateTime.Now.ToString("ddMMyy");

        var result = await ctx.tb_bookings.OrderByDescending(x => x.VNOPSN).ToListAsync();
        var objData = new BookingTransaksi();
        string valSplit = "PSN" + dateNow;
        int id = 1;

        if (result.Count > 0)
        {
            var tamp = result[0].VNOPSN.Split(valSplit);
            id = ConvertToInt32(tamp[1]) + 1;
        }
        
        string vnopsn = "PSN" + dateNow + id.ToString("00000");

        var bookingVm = new BookingVm()
        {
            No_Pesanan = vnopsn
        };

        objData.Item = ctx.tb_items.ToList();
        objData.Booking = bookingVm;

        return View(objData);
    }

}