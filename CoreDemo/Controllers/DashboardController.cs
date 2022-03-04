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
    public class DashboardController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        public DashboardController(IBlogService blog, ICategoryService category)
        {
            this.blogService = blog;
            this.categoryService = category;
        }



        [AllowAnonymous]
        public IActionResult Index()
        {
           
            ViewBag.TotalBlog = blogService.GetList().Count();
            ViewBag.WriterTotalBlog = blogService.GetBlogListByWriter(3).Count();
            ViewBag.TotalCategories = categoryService.GetList().Count();
           //int value = int.Parse(User.FindFirstValue(ClaimTypes.UserData));
            return View();
        }
    }
}
