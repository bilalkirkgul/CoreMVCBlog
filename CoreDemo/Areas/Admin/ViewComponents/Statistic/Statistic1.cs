using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {

        private readonly IBlogService blogService;
        private readonly IContactService contactService;
        private readonly ICommentService commentService;
        public Statistic1(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            this.blogService = blogService;
            this.contactService = contactService;
            this.commentService = commentService;
        }


        public IViewComponentResult Invoke()
        {
            //Includes işlemi yapılabilinirdi ama ilerleyen dönemlerde ajax ile veri çekeceğim için gerek duymadım.

            ViewBag.BlogCount = blogService.GetListStatusTrue().Count();
            ViewBag.ContactCount = contactService.GetList().Count();
            ViewBag.CommentCount = commentService.GetList().Count();


            #region Hava Durumu Api'si alındı

            string api = "9b69a01640a0ef369ae4e2a8e5f300e7";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.Sicaklik = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            #endregion


            return View();
        }

    }
}
