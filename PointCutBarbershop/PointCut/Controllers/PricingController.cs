using Microsoft.AspNetCore.Mvc;

namespace PointCut.Controllers
{
	public class PricingController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
