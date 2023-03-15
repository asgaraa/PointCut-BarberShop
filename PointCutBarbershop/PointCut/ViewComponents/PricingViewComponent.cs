using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace PointCut.ViewComponents
{
	public class PricingViewComponent:ViewComponent
	{
		private readonly IPricingService _service;
		public PricingViewComponent(IPricingService service)
		{
			_service= service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var pricing = await _service.GetAllAsync();
			return (await Task.FromResult(View(pricing)));
		}
	}
}
