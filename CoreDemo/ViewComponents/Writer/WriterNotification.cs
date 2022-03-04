using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    //yazar bildirimleri
    public class WriterNotification : ViewComponent
    {
       private readonly IWriterService writerService;

        public WriterNotification(IWriterService writer)
        {
          this.writerService = writer;
        }


        public IViewComponentResult Invoke()
        {
            //Writer Tema navbar
            return View();
        }
    }
}
