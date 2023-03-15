using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace PointCut.ViewComponents
{
	public class TeamViewComponent:ViewComponent
	{
		private readonly ITeamService _service;

		public TeamViewComponent(ITeamService service)
		{
			_service= service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var team = await _service.GetAllAsync();
			return (await Task.FromResult(View(team)));
		}
	}
}
