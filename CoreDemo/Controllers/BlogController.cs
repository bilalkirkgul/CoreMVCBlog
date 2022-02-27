using BLL.Abstract;
using BLL.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.blogService = blog;
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
        public IActionResult BlogListByWriter(int writerID)
        {
            var values = blogService.WriterBlogInCategoryByID(2);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {

            BlogValidator blogRudes = new BlogValidator();
            FluentValidation.Results.ValidationResult validations = blogRudes.Validate(blog);
            if (validations.IsValid)
            {
                blog.WriterID = 3;
                //blogService.Insert(blog);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                //Tüm hataları dön propertysine hata mesajını ekle
                foreach (var item in validations.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }

    }
}
