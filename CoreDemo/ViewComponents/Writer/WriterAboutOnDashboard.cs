using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard : ViewComponent
    {

        private readonly IWriterService writerService;
        public WriterAboutOnDashboard(IWriterService writer)
        {
           this.writerService = writer;
        }

        public IViewComponentResult Invoke(int writerID)
        {
            var values = writerService.GetById(writerID);
            return View(values);
        }


    }
}
