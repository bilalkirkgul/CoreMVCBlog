using BLL.Abstract;
using DAL.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDAL blogDAL;
        public BlogManager(IBlogDAL blog)
        {
            blogDAL = blog;
        }


        public void Add(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogListCategory()
        {
           return blogDAL.GetListWithCategory();
        }

        public Blog GetById(int blogId)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()
        {
           return blogDAL.GetAll().ToList();
        }

        public void Update(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
