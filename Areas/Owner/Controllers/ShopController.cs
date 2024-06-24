using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TugasAkhir_VsCode.Data;

namespace TugasAkhir_VsCode.Areas.Owner.Controllers
{

	[Authorize(Roles = "Owner")]
	[Area("Owner")]
	public class ShopController : Controller
	{

        private readonly ApplicationDbContext ctx;

        public ShopController(ApplicationDbContext c)
        {
            ctx = c;
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
    }
}
