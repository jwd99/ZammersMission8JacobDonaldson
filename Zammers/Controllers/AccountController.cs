using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zammers.Models;

namespace Zammers.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userM, SignInManager<IdentityUser> signM)
        {
            userManager = userM;
            signInManager = signM;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UserModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        //This was in the book and I think it is for Cross side scripting prevention
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(userModel.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if((await signInManager.PasswordSignInAsync(user, userModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(userModel?.ReturnUrl ?? "/Admin");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid Username or Password!!");
            return View(userModel);
        }
       
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

    }
}
