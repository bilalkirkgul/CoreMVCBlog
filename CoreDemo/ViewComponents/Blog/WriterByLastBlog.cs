using BLL.Concrete;
using DAL.Concrete.Repository.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class WriterByLastBlog: ViewComponent
    {

        BlogManager blogManager = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke(int writerId)
        {
            var values = blogManager.GetBlogListByWriter(2);
            //ViewBag.b = writerId;
            return View(values);
        }


    }
}
