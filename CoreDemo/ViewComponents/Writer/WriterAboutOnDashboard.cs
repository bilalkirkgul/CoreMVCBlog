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

        public IViewComponentResult Invoke()
        {

            //Dashbord Index Sayfası yazar Hakkında kısmı
           var writerId = int.Parse(User.Identity.Name);
           var values = writerService.GetById(writerId);
            return View(values);
        }


    }
}
