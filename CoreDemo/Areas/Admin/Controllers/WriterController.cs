using CoreDemo.Areas.Admin.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public static List<WriterVM> writers = new List<WriterVM>
        {
            new WriterVM{Id=1,Name="Ali"},
            new WriterVM{Id=2,Name="Ahmet"},
            new WriterVM{Id=3,Name="Veli"},
            new WriterVM{Id=4,Name="Ayşe"},
        };

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }
        
        
        public IActionResult GetWriterByID(int writerId)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerId);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
      





    }
}
