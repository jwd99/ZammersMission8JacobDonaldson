using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zammers.Models;

namespace Zammers.Controllers
{
    public class CheckoutController : Controller
    {

        private ICheckoutRepo repo { get; set; }
        private Basket basket { get; set; }
        //brings in both basket and repos
        public CheckoutController(ICheckoutRepo temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
       [HttpGet]
        public IActionResult Checkout()
        {
            return View(new checkoutInfo());
        }

        public IActionResult Checkout( checkoutInfo checkout)
        {
            //for errors it will keep the page from moving on
            if(basket.Items.Count() ==0)
            {
                ModelState.AddModelError("", "Your cart is empty");
            }
            if(ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveOrder(checkout);

                basket.ClearBasket();
                return RedirectToPage("/Confirm");
            }
            else
            {
                return View();
            }

        }
    }
}
