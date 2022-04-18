using BLL.Abstract;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous] //proje seviyesinde tanımlanan bütün kurallardan muaf olmak için kullandım
    public class LoginController : Controller
    {
        //SignInManager<AppUser> kullanıldı Account Controllerde Kendi oluşturduğum service üzerinden kontrol sağlıyordum burda direk kütüphane aracılığı ile işlem yapıyorum..
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

 
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInVM value)
        {
           
            if (ModelState.IsValid)
            {
                //false = hatırlasınmı 
                //true = 5 kez yanlış girildiğinde belli süre banlanıyor..
                var result = await _signInManager.PasswordSignInAsync(value.UserName, value.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Kullanıcı bilgilerinizi kontrol ediniz";
                return View();
            }

        }
    }
}
