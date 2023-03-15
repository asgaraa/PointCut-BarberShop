using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace PointCut.ViewComponents
{
	public class FtcoViewComponent:ViewComponent
	{
		private readonly ISalonService _service;
		public FtcoViewComponent(ISalonService service)
		{
			_service = service;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{


			var salon = await _service.GetAllAsync();
			return (await Task.FromResult(View(salon)));
		}
	}
}
