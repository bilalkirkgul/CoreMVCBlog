using BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService;         
        }
        public IActionResult Index()
        {
            var values = aboutService.GetList();    
            return View(values);
        }

        public PartialViewResult SocialMedyaAbout()
        {
            return PartialView();
        }
    }
}
