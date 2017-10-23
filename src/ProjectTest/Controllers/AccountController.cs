using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProjectTest.ViewModel;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly SignInManager<IdentityUser> _signManager;
    

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }
        public IActionResult Login(string reternUrl)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            loginViewModel.returnUrl = reternUrl;
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = await _userManager.FindByNameAsync(login.userName);

            if (user !=null)
            {
                var result = await _signManager.PasswordSignInAsync(user, login.password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(login.returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(login.returnUrl);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User Name or Password not found");
            }
            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser();
                user.UserName = loginViewModel.userName;
                var result = await _userManager.CreateAsync(user, loginViewModel.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SigunOut()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
