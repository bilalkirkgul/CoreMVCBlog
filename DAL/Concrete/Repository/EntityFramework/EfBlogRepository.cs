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
        //GenericRepository sınıfı içerisindeki methodlara göre işlem yapacak.
        //TEntity' e denk gelen kısım hangi entity classıysa burada belirttim.
        //BLL katmanında DAL katmanına ulaşmak için Solid kurallarına göre hareket edeceğimden interfaceler aracılığıyla ilişki kuruyorum. O yüzden IBlogDAL imzası bırakıyoruz. IBlogDAL BLL katmanından çağrıldığında burada belirtilen işlemler yapılacak. Ve burada belirtilen bütün methodlar ulaşılabilinecek..



        public List<Blog> GetListWithCategory()
        {
            using (var c = new BlogDbContext())
                return c.Blogs.Where(a=>a.BlogStatus==true).Include(a => a.Category).ToList();
        }

        public List<Blog> GetListBlogInWriter()
        {
            using (var c = new BlogDbContext())
                return c.Blogs.Where(a=>a.BlogStatus==true).Include(a => a.Writer).ToList();
        }
        public List<Blog> GetListWithCategoryByWriter(int writerId)
        {
            //Yazarın Kendine ait bloglarının listelemek istediğinde kategorilerle birlikte databaseden çekme işlemi yaptığım method..
            using (var c = new BlogDbContext())
                return c.Blogs.Where(a=>a.WriterID==writerId).Include(a => a.Category).ToList();
        }

      

    }
}
