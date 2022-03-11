using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {

        private readonly IMessageService messageService;

        public WriterMessageNotification(IMessageService message)
        {
            this.messageService = message;
        }

        public IViewComponentResult Invoke()
        {
            //sesiondan gelen değer yakalanacak..
            //kendine gelen mesajları görme işlemi
            string p;
            p = "alindoga@hotmail.com";           
            var values = messageService.GetInboxListByWriter(p);
            return View(values);
        }

    }
}
