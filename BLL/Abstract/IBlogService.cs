using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface IBlogService : IGenericBLL<Blog>
    {      
        List<Blog> GetBlogListCategory();
        List<Blog> GetBlogByIDList(int id);
        List<Blog> GetBlogListByWriter(int writerId);
        List<Blog> GetListBlogInWriter();
        List<Blog> GetListWithCategoryByWriter(int writerId);
    }
}
