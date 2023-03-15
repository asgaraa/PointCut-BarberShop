using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PointCut.Areas.AdminArea.Controllers
{
	[Area("AdminArea")]
	public class DashboardController : Controller
	{
        private readonly UserManager<AppUser> _userManager;
		public DashboardController(UserManager<AppUser> userManager)
		{
			_userManager= userManager;
		}
        public async  Task<IActionResult> Index()
		{
            var user =await _userManager.GetUserAsync(User);

			if (user == null)
			{
				return RedirectToAction("Login", "Account");
			}
			else
			{
				return View();
			}
           
		}
	}
}
