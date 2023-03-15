using Microsoft.AspNetCore.Mvc;

namespace PointCut.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
