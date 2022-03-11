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
        /// <summary>
        /// Blog Listeleme işlemi yapılırken bloglara ait categorilerinde bilgilerini çekmek için hazırlandı
        /// </summary>
        /// <returns></returns>
        List<Blog> GetListBlogInCategory();
        List<Blog> GetBlogByIDList(int id);
        /// <summary>
        /// Yazarın Blokları
        /// </summary>
        /// <param name="writerId">YazarID</param>
        /// <returns></returns>
        List<Blog> GetBlogListByWriter(int writerId);

        /// <summary>
        /// Blog listeleme işlemi yapılırken writerin bilgilerinide beraberinde çekme için hazırlandı
        /// </summary>
        /// <returns></returns>
        List<Blog> GetListBlogInWriter();

        /// <summary>
        /// Yazarın bloglarını listelerken kategori bilgilerinide çekme işlemi.
        /// </summary>
        /// <param name="writerId">YazarId</param>
        /// <returns></returns>
        List<Blog> GetListWithCategoryByWriter(int writerId);

        /// <summary>
        /// Status durumu True olan blogları listeleme için oluşturulan method
        /// </summary>
        /// <returns></returns>
        List<Blog> GetListStatusTrue();
    }
}
