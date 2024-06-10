using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TugasAkhir_VsCode.Data;

namespace TugasAkhir_VsCode.Areas.Admin.Controllers;

[Authorize(Roles = "Admin")]
[Area("Admin")]

public class ChartController : Controller
{

    private readonly ApplicationDbContext ctx;
    
    public ChartController(ApplicationDbContext c)
    {
        ctx = c;
    }

    public ActionResult Index()
    {
        return View();
    }
    
}