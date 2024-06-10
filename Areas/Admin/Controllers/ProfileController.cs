using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TugasAkhir_VsCode.Data;
using TugasAkhir_VsCode.Models;

namespace TugasAkhir_VsCode.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
	public class ProfileController : Controller
	{
		private readonly ApplicationDbContext ctx;

		public ProfileController(ApplicationDbContext context)
		{
			ctx = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			// var userId = User.GetUserId();
			// var dataUser = _context.Tb_Users.Where(x => x.UserId == userId).FirstOrDefault();

			// var prf = new ProfileViewModel()
			// {
			// 	Profile_UserId = userId,
			// 	Profile_Name = dataUser.Name,
			// 	Profile_Username = dataUser.Username,
			// 	Profile_Password = dataUser.Password
			// };

			return View();
		}
	}
}
