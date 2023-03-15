using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.Salon;
using ServiceLayer.Services.Interfaces;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class GalleryController : Controller
    {
        private readonly IGalleryService _service;
        public GalleryController(IGalleryService service)
        {
            _service= service;
        }
        public async Task<IActionResult> Index()
        {
            var galleries = await _service.GetAllAsync();
            return View(galleries);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GalleryDto galleryDto)
        {
            await _service.CreateAsync(galleryDto);
            return RedirectToAction("Index","Gallery");
        }
        #endregion



        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var gallery = await _service.GetAsync(Id);

            if (gallery == null) return NotFound();
            return View(gallery);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, GalleryEditDto galleryEditDto)
        {

            if (Id == null) return BadRequest();

            await _service.UpdateAsync(Id, galleryEditDto);

            return RedirectToAction("Index", "Gallery");
        }

        #endregion
    }
}
