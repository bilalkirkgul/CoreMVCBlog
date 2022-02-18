using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        IAboutService aboutService;
        IBlogService blogService;

        public AboutController(IAboutService aboutService, IBlogService blog)
        {
            this.aboutService = aboutService;
            this.blogService = blog;
        }

       

        public IActionResult Index()
        {
            var values = aboutService.GetList();
            var values2 = blogService.GetList();
            var tuple = (values,values2);
            return View(tuple);
        }

        public PartialViewResult SocialMedyaAbout()
        {
            return PartialView();
        }
    }
}
