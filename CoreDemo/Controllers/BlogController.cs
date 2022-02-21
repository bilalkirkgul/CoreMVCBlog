using BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous] // Startup da tanımladığımız bütün [Authorize] kısıtlamasını namespace seviyesinde burada geçersiz saydık..
    public class BlogController : Controller
    {
        //BlogManager bm = new BlogManager(new EfBlogRepository()); //dependencyInjection yaptım ve interfaceler aracılığıyla hareket ettim. dolayısıyla dal ef class newlemeye gerek kalmadı

        IBlogService blogService;

        public BlogController(IBlogService blog)
        {
            blogService = blog;
        }
        /*[AllowAnonymous]*/ //Actionu kısıtlama dışında tuttum
        public IActionResult Index()
        {
            var values = blogService.GetBlogListCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int blogid)
        {

            #region id numarasına göre blog listeleme işlemi yaptım. getbyId ile değişecek
            //ViewBag.i = blogid; //gerek kalmadı
            //var values = bm.GetBlogByIDList(blogid); 
            #endregion
            var values = blogService.GetById(blogid);
            return View(values);
        }

     
    }
}
