using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TugasAkhir_VsCode.Areas.Owner.Controllers;

[Authorize(Roles = "Owner")]
[Area("Owner")]
public class UsersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddUser()
    {
        return View();
    }
}