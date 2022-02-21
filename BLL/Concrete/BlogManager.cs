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
     class BlogManager : IBlogService
    {
        IBlogDAL blogDAL;
        public BlogManager(IBlogDAL blog)
        {
            blogDAL = blog;
        }
        public void Insert(Blog blog)
        {
            blogDAL.Insert(blog);
        }
        public void Delete(Blog blog)
        {
            blogDAL.Delete(blog);
        }
        public void Update(Blog blog)
        {
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



        public List<Blog> GetBlogListCategory()
        {
            //dal katmanında includes işlemi yaptım
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

        public List<Blog> GetListBlogInWriter()
        {
            //blokların yazar bilgilerini çekmek için oluşturuldu. dal da tanımlama yapıldı
            return blogDAL.GetListBlogInWriter();
        }
    }
}
