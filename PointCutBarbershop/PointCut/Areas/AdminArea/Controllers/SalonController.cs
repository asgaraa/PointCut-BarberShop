using DomainLayer.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceLayer.DTOs.Salon;
using ServiceLayer.Services.Interfaces;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SalonController : Controller
    {
        private readonly ISalonService _service;
        public SalonController(ISalonService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var salon = await _service.GetAllAsync();
            return View(salon);
        }


        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalonDto salonDto)
        {
            await _service.CreateAsync(salonDto);     
            return RedirectToAction(nameof(Index));
        }
        #endregion


        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var salon = await _service.GetAsync(Id); 
        
            if (salon == null) return NotFound();
            return View(salon);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, SalonEditDto eventVM)
        {

            if (Id == null) return BadRequest();
            
            await _service.UpdateAsync(Id, eventVM);

            return RedirectToAction("Index","Salon");
        }

        #endregion

    }
}
