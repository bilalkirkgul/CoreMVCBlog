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

        ICategoryService categoryService;

        public CategoryList(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = categoryService.GetList().ToList();            
            return View(values);
        }

    }
}
