using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {

        IBlogService blogService;
        IContactService contactService;
        ICommentService commentService;
        public Statistic1(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            this.blogService = blogService;
            this.contactService = contactService;
            this.commentService = commentService;
        }


        public IViewComponentResult Invoke()
        {
            ViewBag.BlogCount = blogService.GetListStatusTrue().Count();
            ViewBag.ContactCount = contactService.GetList().Count();
            ViewBag.CommentCount = commentService.GetList().Count();
            return View();
        }

    }
}
