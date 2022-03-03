using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {

        private readonly IWriterService writerService;

        public WriterMessageNotification(IWriterService writer)
        {
           this.writerService = writer;
        }


        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
