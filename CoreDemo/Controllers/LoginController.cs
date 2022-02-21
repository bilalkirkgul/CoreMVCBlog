using BLL.Abstract;
using EntityLayer.Concrete;
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
    public class LoginController : Controller
    {
        IWriterService writerService;
        public LoginController(IWriterService writer)
        {
            writerService = writer;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var dataValues = writerService.GetLoginCheck(writer.WriterMail, writer.WriterPassword);
            if (dataValues!=null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,dataValues.WriterMail),
                    new Claim(ClaimTypes.UserData,dataValues.WriterID.ToString()),
                    new Claim(ClaimTypes.NameIdentifier,dataValues.WriterName)

                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                ViewBag.Message = "Hatalı Giriş Yapıldı";
                return View();
            }

            
        }
    }
}
