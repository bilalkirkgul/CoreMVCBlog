using BLL.Abstract;
using DAL.Abstract;
using DAL.Concrete.Repository.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
   class CategoryManager : ICategoryService
    {

        private readonly ICategoryDAL categoryDAL;

        public CategoryManager(ICategoryDAL category)
        {
            this.categoryDAL = category;
        }

        void CheckCategoryName(string categoryName)
        {
            var categories = categoryDAL.GetListAll();

            foreach (var item in categories)
            {
                if (item.CategoryName==categoryName)
                {
                    throw new Exception("Kayıtlarımızda bu isim de bir kategori zaten mevcut");
                }
            }

        }
        public void Insert(Category category)
        {
            CheckCategoryName(category.CategoryName);
            categoryDAL.Insert(category);
        }
        public void Update(Category category)
        {
            categoryDAL.Update(category);
        }


        public void Delete(Category category)
        {
            categoryDAL.Delete(category);
        }

        public Category GetById(int entityId)
        {
            return categoryDAL.Get(a=>a.CategoryID== entityId);
        }

        public List<Category> GetList()
        {
            return categoryDAL.GetListAll().ToList();
        }
       
      
        public List<Category> GetListCategoryBlogCountList()
        {
            return categoryDAL.GetListCategoryBlogCountList();
        }
    }
}
