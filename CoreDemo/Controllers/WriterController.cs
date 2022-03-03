using BLL.Abstract;
using BLL.ValidationRules;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    /*[Authorize]*/ //Namespace seviyesinde Controller ve actionlar için sisteme giriş için yetki sınırlandırması yaptık. writer olamayan buraya giremeyecek..
    // app.UseAuthentication() kontrolü sağlandığında buraya giriş yapabiliriz..
    [AllowAnonymous]
    public class WriterController : Controller
    {
        private readonly IWriterService writerService;

        public WriterController(IWriterService writerService)
        {
            this.writerService = writerService;
        }
      
        public IActionResult Index()
        {
            int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            var dataValues = writerService.GetById(value);
            return View(dataValues);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            //int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            var dataValues = writerService.GetById(3);
            return View(dataValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator wl = new WriterValidator();
            FluentValidation.Results.ValidationResult result = wl.Validate(writer);

            if (result.IsValid)
            {
                writer.WriterStatus = true;
                writerService.Update(writer);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                //Tüm hataları dön propertysine hata mesajını ekle
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }

        public IActionResult WriterSlidebar()
        {
            int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            var dataValues = writerService.GetById(value);
            return PartialView("WriterSlidebar",dataValues);
        }

        public IActionResult WriterNavbar()
        {
            int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            var dataValues = writerService.GetById(value);
             return PartialView("WriterNavbar",dataValues);
        }


    }
}
