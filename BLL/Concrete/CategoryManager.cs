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
        ICategoryDAL categoryDAL;

        public CategoryManager(ICategoryDAL category)
        {
            categoryDAL = category;
        }

        public void Add(Category category)
        {
            categoryDAL.Insert(category);
        }

        public void Delete(Category category)
        {
            categoryDAL.Delete(category);
        }

        public Category GetById(int categoryId)
        {
            return categoryDAL.GetById(categoryId);
        }

        public List<Category> GetList()
        {
            return categoryDAL.GetAll().ToList();
        }

        public void Update(Category category)
        {
            categoryDAL.Update(category);    
        }
    }
}
