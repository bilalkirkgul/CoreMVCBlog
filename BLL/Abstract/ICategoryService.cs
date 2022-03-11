using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface ICategoryService : IGenericBLL<Category>
    {
        /// <summary>
        /// Kategorinin kaç tane blogu var onu görmek için oluşturulmuş method
        /// </summary>
        /// <returns></returns>
        List<Category> GetListCategoryBlogCountList();

    }
}
