using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using TugasAkhir_VsCode.Data;
using TugasAkhir_VsCode.Models;

namespace TugasAkhir_VsCode.Controllers;

public class LoginController : Controller
{

    private readonly ApplicationDbContext context;

    public LoginController(ApplicationDbContext ctx)
    {
        context = ctx;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Users param)
    {
        string paramUser = param.Username != null ? param.Username : "";
        string paramPass = param.Password != null ? param.Password : "";

        var cekUser = context.tb_users
                    .Where(x => x.Username == param.Username
                        && x.Password == param.Password).FirstOrDefault();

        if (cekUser != null)
        {
            if (cekUser.Username == paramUser && cekUser.Password == paramPass && cekUser.Status == "0")
            {
                var claims = new List<Claim>
                {
                    new Claim("Username", value: cekUser.Name),
                    new Claim("Role", value: cekUser.Role_User),
                    new Claim("User_Id", value: cekUser.UserId)
                };

                await HttpContext.SignInAsync(new ClaimsPrincipal(
                   new ClaimsIdentity(claims, "Cookies", "Username", "Role")
                ));

                if (cekUser.Role_User == "Admin")
                    return Redirect("/Admin/Home");
                else
                    return Redirect("/Owner/Home");
            }
            else
            {
                ViewBag.Message = " Invalid Username or Password ";
            }
        }
        else
        {
            ViewBag.Message = " Invalid Username or Password ";
        }

        return View(param);
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }

}