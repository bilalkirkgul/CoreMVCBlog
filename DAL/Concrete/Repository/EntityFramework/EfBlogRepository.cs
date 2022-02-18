using DAL.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repository.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDAL
    {
        public List<Blog> GetListWithCategory()
        {
            using (var c = new BlogDbContext())
                return c.Blogs.Include(a => a.Category).ToList();
        }

        public List<Blog> GetListBlogInWriter()
        {
            using (var c = new BlogDbContext())
                return c.Blogs.Include(a => a.Writer).ToList();
        }
    }
}
