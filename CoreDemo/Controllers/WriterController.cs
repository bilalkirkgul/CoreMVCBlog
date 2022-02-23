using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    /*[Authorize]*/ //Namespace seviyesinde Controller ve actionlar için sisteme giriş için yetki sınırlandırması yaptık. writer olamayan buraya giremeyecek..
    // app.UseAuthentication() kontrolü sağlandığında buraya giriş yapabiliriz..
    [AllowAnonymous]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
