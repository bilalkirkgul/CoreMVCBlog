using BLL.Abstract;
using BLL.ValidationRules;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
            int userId = int.Parse(User.Identity.Name);
            var dataValues = writerService.GetById(userId);
            return View(dataValues);
        }

        [HttpGet]
        public IActionResult EditProfile()
        {
            int userId = int.Parse(User.Identity.Name);
            var dataValues = writerService.GetById(userId);
            return View(dataValues);
        }
        [HttpPost]
        public IActionResult EditProfile(Writer writer)
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


        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddWriter(AddProfileImage addProfile)
        {
            Writer writer = new Writer();          
            if (addProfile.WriterImg != null)
            {
                var extension = Path.GetExtension(addProfile.WriterImg.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImgFiles/", newImageName);
                var stream = new FileStream(location, FileMode.Create);
                addProfile.WriterImg.CopyTo(stream);
                writer.WriterImg = newImageName;               
            }
            writer.WriterMail = addProfile.WriterMail;
            writer.WriterName = addProfile.WriterName;
            writer.WriterPassword = addProfile.WriterPassword;
            writer.WriterStatus = true;
            writer.WriterAbout = addProfile.WriterAbout;
            writerService.Insert(writer);
            return RedirectToAction("Index", "Dashboard");
        }

        //Todo: WriterLayoutPartial içerisine taşınacak...
        public PartialViewResult WriterSlidebar()
        {
            //int value = int.Parse(User.Identity.Name);
            //var dataValues = writerService.GetById(value);
            //return PartialView("WriterSlidebar", dataValues);
            return PartialView();
        }
        public PartialViewResult WriterNavbar()
        {
            //int value = int.Parse(User.Identity.Name);
            //var dataValues = writerService.GetById(value);
            //return PartialView("WriterNavbar", dataValues);
            return PartialView();
        }


    }
}
