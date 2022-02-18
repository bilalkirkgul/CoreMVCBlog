﻿using BLL.Abstract;
using BLL.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        
        IWriterService writerService;

        public RegisterController(IWriterService writerService)
        {
            this.writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {

            WriterValidator wrudes = new WriterValidator();
            ValidationResult result = wrudes.Validate(p);

            if (result.IsValid)
            {
                writerService.Insert(p);
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
    }
}