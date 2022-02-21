using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class LastThreeBlog: ViewComponent
    {

        IBlogService blogService;

        public LastThreeBlog(IBlogService blog)
        {
            this.blogService = blog;
        }

        public IViewComponentResult Invoke()
        {
            var values = blogService.GetListBlogInWriter().OrderByDescending(a => a.BlogCreateDate).ThenBy(a=>a.BlogID).TakeLast(3);
            return View(values);
        }

    }
}
