using BLL.Abstract;
using BLL.Concrete;
using DAL.Concrete.Repository.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryList: ViewComponent
    {

        private readonly ICategoryService categoryService;

        public CategoryList(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            //Kategorilerin kaçar tane blogları var onu öğrenmek için bll ve dal da method oluşturuldu.
            //blog BlogReadAll listeleme sayfasında kullanıldı..
            var values = categoryService.GetListCategoryBlogCountList().ToList();
            return View(values);
        }

    }
}
