using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.Interfaces;

namespace PointCut.ViewComponents
{
	public class GalleryViewComponent:ViewComponent
	{
		private readonly IGalleryService _service;

		public GalleryViewComponent(IGalleryService service)
		{
			_service= service;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var galleries = await _service.GetAllAsync();
			return (await Task.FromResult(View(galleries)));
		}
	}
}
