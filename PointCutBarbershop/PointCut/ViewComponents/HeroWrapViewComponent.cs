using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace PointCut.ViewComponents
{
	public class HeroWrapViewComponent:ViewComponent
	{
		private readonly IHeroWrapService _service;

		public HeroWrapViewComponent(IHeroWrapService service)
		{
			_service = service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			
			var herowrap = await _service.GetAllAsync();
			return (await Task.FromResult(View(herowrap)));
		}
	}
}
