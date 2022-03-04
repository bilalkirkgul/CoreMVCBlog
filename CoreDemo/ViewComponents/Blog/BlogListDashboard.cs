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

        public IViewComponentResult Invoke() //Yazara kendine özel sayfasında genel son 10 blog listemelemesi.
        {
            //Writer Dashboard sayfasında kullanıldı...
            var values = blogService.GetListBlogInCategory().OrderByDescending(a=>a.BlogCreateDate).Take(10);
            return View(values);
        }


    }
}
