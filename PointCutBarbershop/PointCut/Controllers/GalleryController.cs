using Microsoft.AspNetCore.Mvc;

namespace PointCut.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
