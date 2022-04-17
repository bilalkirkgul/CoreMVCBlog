using BLL.Abstract;
using BLL.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index(int page = 1)
        {   //X.PagedList ve XPAgedList.MVC.Core Paketleri projeye dahil edildi.
            //başlangıç değeri olarak 1 verdik ve her sayfada kaç değer istiyorsak ayrıca belirtiyoruz..
            //ToPagedList() using X.PagedList kütüpanesinden geliyor..
            //Index sayfasında  @Html.PagedListPager((IPagedList)Model,page=>Url.Action("Index",new { page})) ayarlaması yaptık.
            var dataValues = categoryService.GetList().ToPagedList(page, 3);
            return View(dataValues);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator blogRudes = new CategoryValidator();
            FluentValidation.Results.ValidationResult validations = blogRudes.Validate(category);
            if (validations.IsValid)
            {
                //var WriterID = int.Parse(User.Identity.Name);
                category.CategoryStatus = true;
                categoryService.Insert(category);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
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


        public IActionResult StatusFalseCategory(int categoryId)
        {
            var deleteCategory = categoryService.GetById(categoryId);
            deleteCategory.CategoryStatus = false;
            categoryService.Update(deleteCategory);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
        public IActionResult StatusTrueCategory(int categoryId)
        {
            var deleteCategory = categoryService.GetById(categoryId);
            deleteCategory.CategoryStatus = true;
            categoryService.Update(deleteCategory);
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }


    }
}
