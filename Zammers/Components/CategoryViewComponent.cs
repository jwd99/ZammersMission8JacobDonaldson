using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Zammers.Models;

namespace Zammers.Components
{
    public class CategoryViewComponent : ViewComponent 
    {
        private IZammerRepo repo2 { get; set; }

        public CategoryViewComponent(IZammerRepo holder)
        {//USes the Repo which sets up what we normally put here
            repo2 = holder;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo2.Books
                .Select(b => b.Category)
                .Distinct()
                .OrderBy(b => b);


            return View(categories);
        }
    }
}
