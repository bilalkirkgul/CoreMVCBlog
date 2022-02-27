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

        IWriterService writerService;

        public WriterMessageNotification(IWriterService writer)
        {
            writerService = writer;
        }


        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
