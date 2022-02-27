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
        IWriterService writerService;

        public WriterNotification(IWriterService writer)
        {
            writerService = writer;
        }


        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
