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

        private readonly IBlogService blogService;

        public BlogListDashboard(IBlogService blog)
        {
            this.blogService = blog;
        }

        public IViewComponentResult Invoke() //Yazara genel son 10 blog listemelemesi.
        {
            var values = blogService.GetListBlogInCategory().OrderByDescending(a=>a.BlogCreateDate).Take(10);
            return View(values);
        }


    }
}
