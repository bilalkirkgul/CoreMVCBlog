using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IBlogDAL : IGenericDAL<Blog>
    {

        List<Blog> GetListWithCategory();
        List<Blog> GetListBlogInWriter();
        List<Blog> GetListWithCategoryByWriter(int writerId);
      

    }
}
