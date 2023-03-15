using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace PointCut.ViewComponents
{
	public class ServicesViewComponent:ViewComponent
	{
		private readonly IServicesService _service;
		public ServicesViewComponent(IServicesService service)
		{
			_service= service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var services = await _service.GetAllAsync();
			return (await Task.FromResult(View(services)));
		}
	}
}
