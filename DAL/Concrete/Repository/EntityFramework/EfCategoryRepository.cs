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
   public class EfCategoryRepository : GenericRepository<Category>, ICategoryDAL
    {

        public List<Category> GetListCategoryBlogCountList()
        {
            using (var c = new BlogDbContext())
                return c.Categories.Include(a => a.Blogs.Where(a=>a.BlogStatus==true)).ToList();
            
        }

    }
}
