using BLL.Abstract;
using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IActionResult WriterSlidebar()
        {
            int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            var dataValues = writerService.GetById(value);
            return PartialView();
        }

        public IActionResult WriterNavbar()
        {
            int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            var dataValues = writerService.GetById(value);
            return PartialView();
        }


    }
}
