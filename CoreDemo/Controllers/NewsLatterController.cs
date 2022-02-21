using BLL.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{

    //Bu class partial olarak kullanıldı ileride değişecek. 

    public class NewsLatterController : Controller
    {
        INewsLetterService newsLetterService;

        public NewsLatterController(INewsLetterService newsLetter)
        {
            newsLetterService = newsLetter;
        }


        //Mail bülteni abone olma kısmı
        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetterService.Insert(newsLetter);
            return PartialView();
        }
    }
}
