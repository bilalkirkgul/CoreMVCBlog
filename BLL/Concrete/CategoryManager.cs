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

        public void Insert(Category category)
        {
            categoryDAL.Insert(category);
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
       
        public void Update(Category category)
        {
            categoryDAL.Update(category);    
        }

        public List<Category> GetListCategoryBlogCountList()
        {
            return categoryDAL.GetListCategoryBlogCountList();
        }
    }
}
