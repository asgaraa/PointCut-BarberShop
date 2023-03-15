using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.DTOs.Pricing;
using ServiceLayer.Services.Interfaces;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class PricingController : Controller
    {
        private readonly IPricingService _service;
        public PricingController(IPricingService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var pricings= await _service.GetAllAsync();
            return View(pricings);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PricingDto pricingDto)
        {
            await _service.CreateAsync(pricingDto);
            return RedirectToAction("Index", "Pricing");
        }
        #endregion



        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var pricing = await _service.GetAsync(Id);

            if (pricing == null) return NotFound();
            return View(pricing);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, PricingEditDto pricingEditDto)
        {

            if (Id == null) return BadRequest();

            await _service.UpdateAsync(Id, pricingEditDto);

            return RedirectToAction("Index", "Pricing");
        }

        #endregion
    }
}
