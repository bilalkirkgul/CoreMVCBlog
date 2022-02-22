using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [Authorize] //Namespace seviyesinde Controller ve actionlar için sisteme giriş istedik. aksi taktirde giriş yapamalar.
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
