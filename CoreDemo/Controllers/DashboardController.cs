using BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class DashboardController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        private readonly IWriterService writerService;

        public DashboardController(IBlogService blog, ICategoryService category, IWriterService writer)
        {
            this.blogService = blog;
            this.categoryService = category;
            this.writerService = writer;
        }

        


        //[AllowAnonymous]
        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            var writerId = 0;
            var writers = writerService.GetList().ToList();
            foreach (var item in writers)
            {
                if (item.WriterMail==userMail)
                {
                    writerId = item.WriterID;
                    break;
                }
            }


            ViewBag.TotalBlog = blogService.GetListStatusTrue().Count();
            ViewBag.WriterTotalBlog = blogService.GetBlogListByWriter(writerId).Count();
            ViewBag.TotalCategories = categoryService.GetList().Count();
           //int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            return View();
        }
    }
}
