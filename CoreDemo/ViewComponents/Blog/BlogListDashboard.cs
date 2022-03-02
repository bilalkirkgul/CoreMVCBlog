using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {

        IBlogService blogService;

        public BlogListDashboard(IBlogService blog)
        {
            this.blogService = blog;
        }

        public IViewComponentResult Invoke()
        {
            var values = blogService.GetListBlogInCategory().OrderByDescending(a=>a.BlogCreateDate).Take(10);
            return View(values);
        }


    }
}
