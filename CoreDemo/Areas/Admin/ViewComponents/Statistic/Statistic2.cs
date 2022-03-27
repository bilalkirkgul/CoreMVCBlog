using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2 : ViewComponent
    {
        IBlogService blogService;

        public Statistic2(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            //var values = blogService.GetList().OrderByDescending(a=>a.BlogID).Select(a=>a.BlogTitle).Take(1).FirstOrDefault();
            var values = blogService.GetListBlogInWriter().OrderByDescending(a=>a.BlogID).Take(1).SingleOrDefault();
            return View(values);
        }

    }
}
