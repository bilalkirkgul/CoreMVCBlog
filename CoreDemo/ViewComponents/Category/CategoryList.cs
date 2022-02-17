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

        CategoryManager category = new CategoryManager(new EfCategoryRepository());


        public IViewComponentResult Invoke()
        {
            var values = category.GetList().ToList();            
            return View(values);
        }

    }
}
