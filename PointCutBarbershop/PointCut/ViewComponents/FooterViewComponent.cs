using Microsoft.AspNetCore.Mvc;

namespace PointCut.ViewComponents
{
	public class FooterViewComponent:ViewComponent
	{
		public FooterViewComponent()
		{
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			return (await Task.FromResult(View()));
		}
	}
}
