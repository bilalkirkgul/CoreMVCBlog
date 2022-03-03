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

        private readonly IBlogService blogService;

        public LastThreeBlog(IBlogService blog)
        {
            this.blogService = blog;
        }

        public IViewComponentResult Invoke() //Son 3 blog listeleme işlemi
        {
            var values = blogService.GetListBlogInWriter().OrderByDescending(a => a.BlogCreateDate).Take(3);
            return View(values);
        }

    }
}
