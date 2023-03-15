using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Team;
using ServiceLayer.DTOs.Testimonial;
using ServiceLayer.Services.Interfaces;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _service;
        public TestimonialController(ITestimonialService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var testimonials= await _service.GetAllAsync();
            return View(testimonials);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TestimonialDto testimonialDto)
        {
            await _service.CreateAsync(testimonialDto);
            return RedirectToAction("Index", "Testimonial");
        }
        #endregion



        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var testimonial = await _service.GetAsync(Id);

            if (testimonial == null) return NotFound();
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, TestimonialEditDto testimonialEditDto)
        {

            if (Id == null) return BadRequest();

            await _service.UpdateAsync(Id, testimonialEditDto);

            return RedirectToAction("Index", "Testimonial");
        }

        #endregion
    }
}
