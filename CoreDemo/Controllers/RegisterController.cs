using BLL.Abstract;
using BLL.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        private readonly IWriterService writerService;

        public RegisterController(IWriterService writerService)
        {
            this.writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p, string password2)
        {

            if (p.WriterPassword==password2)
            {
                WriterValidator wrudes = new WriterValidator();
                ValidationResult result = wrudes.Validate(p);

                if (result.IsValid)
                {
                    //writerService.Insert(p);
                    return RedirectToAction("Index", "Blog");
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
    }
}
