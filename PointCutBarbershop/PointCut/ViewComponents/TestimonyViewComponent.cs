using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace PointCut.ViewComponents
{
	public class TestimonyViewComponent:ViewComponent
	{
		private readonly ITestimonialService _service;
		public TestimonyViewComponent(ITestimonialService service)
		{
			_service= service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var model = await _service.GetAllAsync();
			return (await Task.FromResult(View(model)));
		}
	}
}
