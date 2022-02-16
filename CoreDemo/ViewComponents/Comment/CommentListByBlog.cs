using BLL.Concrete;
using DAL.Concrete.Repository.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {

        CommentManager comment = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke()
        {
            var values = comment.GetCommentByList(4);
            return View(values);
        }

    }
}
