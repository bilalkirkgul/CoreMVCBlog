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

        IMessageTwoService messageTwoService;

        public WriterMessageNotification(IMessageTwoService message)
        {
            this.messageTwoService = message;
        }

        //Yazara gönderilen mesajların bildirimi.
        public IViewComponentResult Invoke()
        {
            int userId = int.Parse(User.Identity.Name);      
            var values = messageTwoService.GetInboxListReceiverByWriter(userId); //alıcıya ait msjların listeleme methodu kullanıldı
            ViewBag.MessageCount = values.Count();
            return View(values);
        }

    }
}
