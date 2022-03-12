using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {

        IMessageTwoService messageTwoService;

        public MessageController(IMessageTwoService messageTwoService)
        {
            this.messageTwoService = messageTwoService;
        }

        public IActionResult InBox()
        {

            int userId = int.Parse(User.Identity.Name);
            var dataValues = messageTwoService.GetInboxListReceiverByWriter(userId);
            return View(dataValues);
        }
        public IActionResult MessageDetails(int? messageId)
        {         
            if (messageId.HasValue)
            {
                var dataValues = messageTwoService.GetByMessageIdAndSender(messageId.Value);
                return View(dataValues);
            }
            else
            {
                return View();
            }
        }

    }
}
