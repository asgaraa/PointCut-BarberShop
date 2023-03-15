using Microsoft.AspNetCore.Mvc;

namespace PointCut.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


		public IActionResult Services()
		{
			return View();
		}

		public IActionResult Galleries()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}
	}
}
