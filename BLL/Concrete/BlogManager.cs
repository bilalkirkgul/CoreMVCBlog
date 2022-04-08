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
     class BlogManager : IBlogService
    {
        //EfBlogRepository efBlogRepository;
        //public BlogManager()
        //{
        //    efBlogRepository = new EfBlogRepository();
        //}

        //Yorum satırına alınan yapı sağlıksız bir yapıyı temsil eder. Burada alt sınıflara tam bağımlılık oluşmuş olur. solid D'si çiğnenmiş olur.
        //DAL katmanında DependencyInjection klasörü içierisnde EfContextDAL classı oluşturdum. Bu yapıyı kurarken xInterface çağrıldığında beraberinde zaten ilgili olduğu xRepository clasınıda bağlamış olduğumdan xRepository iş sorumluluğunu buraya aktarmış oldum.


        private readonly IBlogDAL blogDAL;

        public BlogManager(IBlogDAL blog)
        {
            this.blogDAL = blog;
        }
        public void Insert(Blog blog)
        {
            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Now;
            blogDAL.Insert(blog);
        }
        public void Delete(Blog blog)
        {
            blog.BlogStatus = false;
            blogDAL.Update(blog);
        }
        public void Update(Blog blog)
        {          
            blog.BlogCreateDate = DateTime.Now;
            blogDAL.Update(blog);
        }
        public List<Blog> GetList()
        {
            return blogDAL.GetListAll();
        }
        public Blog GetById(int entityId)
        {
            return blogDAL.Get(a => a.BlogID == entityId);
        }


        /// <summary>
        /// Dal katmanında includes işlemi yaptım blog bilgilerini çağırırken içerisine category tüm bilgilerinide dahil ettim.
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetListBlogInCategory()
        {
            
           return blogDAL.GetListWithCategory();
        }
        public List<Blog> GetBlogByIDList(int id)
        {
            //getbyId tek eleman döndürüyordu bununla birden fazla elman aldık
            return blogDAL.GetListAll(a=>a.BlogID==id);
        }
        /// <summary>
        /// Yazarın Blokları
        /// </summary>
        /// <param name="writerId">YazarID</param>
        /// <returns></returns>
        public List<Blog> GetBlogListByWriter(int writerId)
        {    //yazarın blokları     
            return blogDAL.GetListAll(a => a.WriterID == writerId).ToList();
        }
        /// <summary>
        /// Yazarın bloglarını listelerken kategori bilgilerinide çekme işlemi.
        /// </summary>
        /// <param name="writerId">YazarId</param>
        /// <returns></returns>
        public List<Blog> GetListWithCategoryByWriter(int writerId)
        {
            return blogDAL.GetListWithCategoryByWriter(writerId);
        }

        public List<Blog> GetListBlogInWriter()
        {
            //dal katmanında includes işlemi yaptım blog bilgilerini çağırırken içerisine writerin tüm bilgilerinide dahil ettim.
            return blogDAL.GetListBlogInWriter();
        }
        /// <summary>
        /// Status durumu True olan blogları listeleme için oluşturulan method
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetListStatusTrue()
        {
            return blogDAL.GetListAll(a=>a.BlogStatus==true);
        }
    }
}
