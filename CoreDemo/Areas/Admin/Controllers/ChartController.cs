using CoreDemo.Areas.Admin.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult CategoryChart()
        {
            List<CategoryChart> list = new List<CategoryChart>();
            list.Add(new CategoryChart { categoryname = "Teknoloji", categorycount = 10 });
            list.Add(new CategoryChart { categoryname = "Yazılım", categorycount = 15 });
            list.Add(new CategoryChart { categoryname = "Spor", categorycount = 5 });
            return Json(new { jsonlist = list });

        }

    }
}
