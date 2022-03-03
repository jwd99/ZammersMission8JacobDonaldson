using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zammers.Models;

namespace Zammers.Components
{
    public class CarticonViewComponent : ViewComponent
    {
        private Basket basket;
        public CarticonViewComponent(Basket basketservices)
        {
            basket = basketservices;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
