using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Blog
{
    public class WriterByLastBlog: ViewComponent
    {

        IBlogService blogService;

        public WriterByLastBlog(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke(int writerId)
        {
            var values = blogService.GetBlogListByWriter(writerId);            
            return View(values);
        }


    }
}
