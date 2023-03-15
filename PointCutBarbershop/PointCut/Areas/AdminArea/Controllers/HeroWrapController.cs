using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Gallery;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.Services.Interfaces;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class HeroWrapController : Controller
    {
        private readonly IHeroWrapService _service;
        public HeroWrapController(IHeroWrapService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var herowraps= await _service.GetAllAsync();
            return View(herowraps);
        }


        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HeroWrapDto heroWrapDto)
        {
            await _service.CreateAsync(heroWrapDto);
            return RedirectToAction("Index", "HeroWrap");
        }
        #endregion



        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var heroWrap = await _service.GetAsync(Id);

            if (heroWrap == null) return NotFound();
            return View(heroWrap);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, HeroWrapEditDto heroWrapEditDto)
        {

            if (Id == null) return BadRequest();

            await _service.UpdateAsync(Id, heroWrapEditDto);

            return RedirectToAction("Index", "HeroWrap");
        }

        #endregion
    }
}
