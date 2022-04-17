using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        
        //IdentityUser Model Kullanılacak.. Create vs 123-124
        //Microsoft.AspNetCore.Identity; _userManager.CreateAsync
        //Microsoft.AspNetCore.Identity.EntityFrameworkCore paketleri yüklendi

        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpVM userSignUpVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Email = userSignUpVM.Mail,
                    UserName = userSignUpVM.UserName,
                    NameSurname = userSignUpVM.NameSurname,

                };
                //şifrede büyük-küçük-rakam ve karakter zorunlu
                //bilalL123*
                var result = await _userManager.CreateAsync(user, userSignUpVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View(userSignUpVM);
        }
    }
}
