using BLL.Abstract;
using BLL.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    /*[AllowAnonymous]*/ // Startup da tanımladığımız bütün [Authorize] kısıtlamasını namespace seviyesinde burada geçersiz saydık..
    public class BlogController : Controller
    {
        //BlogManager bm = new BlogManager(new EfBlogRepository()); //dependencyInjection yaptım ve interfaceler aracılığıyla hareket ettim. dolayısıyla dal ef class burada newlemeye gerek kalmadı

        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        public BlogController(IBlogService blog, ICategoryService category)
        {
            this.blogService = blog;
            this.categoryService = category;
        }
        [AllowAnonymous] //Actionu kısıtlama dışında tuttum
        public IActionResult Index()
        {  
            //Bloglar categori bilgileri ile birlikte sayfaya yükleniyor. Bunun için bll ve dal katmanlarında yapı oluşturdum. dalda Includes işlemi yaptım..
            //Silinen, durumu false olan bloglar bura da gözükmemektedir.
            var values = blogService.GetListBlogInCategory();
            return View(values);
        }
        [AllowAnonymous]
        public IActionResult BlogReadAll(int blogid)
        {   //parametre Blog indexden gelmektedir.
            //seçili bloğun detayı görme actionu 
            var values = blogService.GetById(blogid);
            return View(values);
        }

             
        public IActionResult BlogListByWriter()
        {
            //WriterTema Bölümü
            //Yazarın Kendine ait bloglarının listelendiği sayfa
            //Bu bölümde durumu false olanlarda gözükmektedir.
            int WriterID = int.Parse(User.Identity.Name);
            var values = blogService.GetListWithCategoryByWriter(WriterID).ToList();
            return View(values);
        }
        public void GetListCategories()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var item in categoryService.GetList())
            {
                selectListItems.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryID.ToString() });
            }

            ViewBag.Categories = selectListItems;
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            GetListCategories();
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog blog)
        {
            GetListCategories();
            BlogValidator blogRudes = new BlogValidator();
            FluentValidation.Results.ValidationResult validations = blogRudes.Validate(blog);
            if (validations.IsValid)
            {              
                blog.WriterID = int.Parse(User.Identity.Name);
                //string mail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value.ToString();
                blogService.Insert(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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

    
        [HttpGet]
        public IActionResult UpdateBlog(int? blogId)
        {
            GetListCategories();
            if (blogId.HasValue)
            {
                Blog updateBlog = blogService.GetById(blogId.Value);
                return View(updateBlog);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult UpdateBlog(Blog blog)
        {
            GetListCategories();
            BlogValidator blogRudes = new BlogValidator();
            FluentValidation.Results.ValidationResult validations = blogRudes.Validate(blog);
            if (validations.IsValid)
            {             
                blog.WriterID = int.Parse(User.Identity.Name);
                blog.BlogStatus = true;
                blogService.Update(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
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
        public IActionResult DeleteBlog(int? blogId)
        {
            if (blogId.HasValue)
            {
                Blog deleteBlog = blogService.GetById(blogId.Value);
                blogService.Delete(deleteBlog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                return View();
            }
        }


    }
}
