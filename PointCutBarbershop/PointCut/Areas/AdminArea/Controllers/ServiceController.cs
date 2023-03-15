using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Salon;
using ServiceLayer.DTOs.Services;
using ServiceLayer.Services.Interfaces;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ServiceController : Controller
    {
        private readonly IServicesService _service;
        public ServiceController(IServicesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _service.GetAllAsync();
            return View(services);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicesDto servicesDto)
        {
            await _service.CreateAsync(servicesDto);
            return RedirectToAction("Index", "Service");
        }
        #endregion


        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var servis = await _service.GetAsync(Id);

            if (servis == null) return NotFound();
            return View(servis);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, ServicesEditDto servicesEditDto)
        {

            if (Id == null) return BadRequest();

            await _service.UpdateAsync(Id, servicesEditDto);

            return RedirectToAction("Index", "Service");
        }

        #endregion

    }
}
