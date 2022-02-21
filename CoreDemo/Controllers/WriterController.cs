using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [Authorize] //Namespace seviyesinde Controller ve action Görüntü yetkilendirmesi işlemi yaptık. 
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
