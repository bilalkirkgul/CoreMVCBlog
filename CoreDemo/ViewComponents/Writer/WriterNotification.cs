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
        INotificationService notificationService;

        public WriterNotification(INotificationService notification)
        {
            notificationService = notification;
        }

        public IViewComponentResult Invoke()
        {
            var values = notificationService.GetList();
            return View(values);
        }
    }
}
