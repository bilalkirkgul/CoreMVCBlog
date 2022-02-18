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
  public  class CategoryManager : ICategoryService
    {
        ICategoryDAL categoryDAL;

        public CategoryManager(ICategoryDAL category)
        {
            categoryDAL = category;
        }

        public void Insert(Category category)
        {
            categoryDAL.Insert(category);
        }

        public void Delete(Category category)
        {
            categoryDAL.Delete(category);
        }

        public Category GetById(int categoryId)
        {
            return categoryDAL.GetById(a=>a.CategoryID==categoryId);
        }

        public List<Category> GetList()
        {
            return categoryDAL.GetListAll().ToList();
        }
       
        public void Update(Category category)
        {
            categoryDAL.Update(category);    
        }
    }
}
