using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface IBlogService
    {
        void Insert(Blog blog);
        void Delete(Blog blog);
        void Update(Blog blog);
        List<Blog> GetList();       
        Blog GetById(int blogId);
        List<Blog> GetBlogListCategory();
        List<Blog> GetBlogByIDList(int id);

        List<Blog> GetBlogListByWriter(int id);

    }
}
