using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.HeroWrap;
using ServiceLayer.DTOs.Team;
using ServiceLayer.Services.Interfaces;

namespace PointCut.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeamController : Controller
    {
        private readonly ITeamService _service;
        public TeamController(ITeamService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var teams= await _service.GetAllAsync();
            return View(teams);
        }

        #region Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeamDto teamDto)
        {
            await _service.CreateAsync(teamDto);
            return RedirectToAction("Index", "Team");
        }
        #endregion



        #region Edit
        public async Task<IActionResult> Edit(string Id)
        {
            var team = await _service.GetAsync(Id);

            if (team == null) return NotFound();
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string Id, TeamEditDto teamEditDto)
        {

            if (Id == null) return BadRequest();

            await _service.UpdateAsync(Id, teamEditDto);

            return RedirectToAction("Index", "Team");
        }

        #endregion
    }
}
