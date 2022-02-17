using BLL.Concrete;
using DAL.Concrete.Repository.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int blogid)
        {

            #region id numarasına göre blog listeleme işlemi yaptım. getbyId ile değişecek
            //ViewBag.i = blogid; //gerek kalmadı
            //var values = bm.GetBlogByIDList(blogid); 
            #endregion
            var values = bm.GetById(blogid);
            return View(values);
        }
    }
}
