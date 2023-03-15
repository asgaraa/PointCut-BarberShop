using Microsoft.AspNetCore.Mvc;

namespace PointCut.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
