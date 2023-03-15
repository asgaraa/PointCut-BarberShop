using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PointCut.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {

        public NavbarViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           


            return (await Task.FromResult(View()));
        }
    }
}
