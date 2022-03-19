using BLL.Abstract;
using BLL.ValidationRules;
using CoreDemo.Models;
using CoreDemo.Models.AccountVM;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IWriterService writerService;

        public AccountController(IWriterService writerService)
        {
            this.writerService = writerService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM user)
        {

            if (!string.IsNullOrEmpty(user.Password) || !string.IsNullOrEmpty(user.PasswordTwo))
            {
                if (user.Password == user.PasswordTwo)
                {
                    Writer writer = new Writer()
                    {
                        WriterName = user.UserName,
                        WriterImg = user.UserImg,
                        WriterMail = user.Email,
                        WriterPassword = user.Password
                    };
                    WriterValidator wrudes = new WriterValidator();
                    ValidationResult result = wrudes.Validate(writer);
                    if (result.IsValid)
                    {
                        writerService.Insert(writer);
                        return RedirectToAction("Index", "Writer");
                    }
                    else
                    {
                        //Tüm hataları dön propertysine hata mesajını ekle
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Parolalar eşleşmiyor, Lütfen paralanızı kontrol ediniz";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Parola boş geçilemez";
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            var loginWriter = writerService.GetLoginCheck(loginVM.Email, loginVM.Password);
            if (loginWriter is not null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,loginWriter.WriterID.ToString()),
                    new Claim(ClaimTypes.UserData,loginWriter.WriterName.ToString()),
                    new Claim(ClaimTypes.Email,loginWriter.WriterMail)

                };

                //burada Authentiontype bilgisi tutuluyor. string alana type bilgisi geçilebilinir. örneğin admin, writer vs vs.
                //var userIdentity = new ClaimsIdentity(claims, "a");
                //ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(principal));
                //return RedirectToAction("Index", "Dashboard");


                #region 2. alternatif yol
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));


                if (loginWriter.WriterID==3)
                {
                    return RedirectToAction("Index", "Category",new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Dashboard");
                }

               
                
                #endregion

            }
            else
            {
                ViewBag.Message = "Kullanıcı bilgilerinizi kontrol edin";
                return View();
            }

        }

        //public IActionResult LoginName()
        //{
        //    string name = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    return PartialView("_loginModel", name);
        //}

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Blog");
        }

    }
}
