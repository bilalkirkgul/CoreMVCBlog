using BLL.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
   
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService comment)
        {
            this.commentService = comment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;            
            //commentService.Insert(comment);
            return PartialView();
        }
        //public PartialViewResult CommentListByBlog(int id)
        //{
        //    var values = cm.GetCommentByList(id);
        //    return PartialView(values);
        //}
    }
}
