using BLL.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
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
            var writerName = User.Identity.Name;
            ViewBag.Mail = writerName;
            //var values = writerService.GetById(writerId);
            return View();
        }


    }
}
