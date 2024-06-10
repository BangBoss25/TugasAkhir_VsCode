using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TugasAkhir_VsCode.Areas.Owner.Controllers
{
    [Authorize(Roles = "Owner")]
    [Area("Owner")]
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
