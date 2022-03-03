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
        //brings in the basket class and then sets a new basketservice var to hold for the cart summary
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
