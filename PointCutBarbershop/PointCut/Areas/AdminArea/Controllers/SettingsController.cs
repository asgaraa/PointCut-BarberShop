using Microsoft.AspNetCore.Mvc;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
