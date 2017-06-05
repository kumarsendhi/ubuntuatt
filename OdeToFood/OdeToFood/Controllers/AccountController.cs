using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.UserName, FirstName=model.FirstName, LastName=model.LastName, Email=model.Email,AlternateEmail=model.AlternateEmail,PhoneNumber=model.PhoneNumber,Organisation=model.Organisation,Position=model.Position};

               var createResult=  await _userManager.CreateAsync(user, model.Password);
                if (createResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in createResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
