using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Category
{
    public class CategoryListDashboard: ViewComponent 
    {
        private readonly ICategoryService categoryService;

        public CategoryListDashboard(ICategoryService category)
        {
           this.categoryService = category;
        }

        public IViewComponentResult Invoke()
        {
            var values = categoryService.GetList();
            return View(values);
        }

    }
}
