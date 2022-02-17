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
    public class BlogManager : IBlogService
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
        public Blog GetById(int blogId)
        {
            return blogDAL.GetById(a => a.BlogID == blogId);
        }
        public List<Blog> GetBlogListCategory()
        {
            //dal catmanında includes işlemi yaptım
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
            return blogDAL.GetListAll(a => a.WriterID == writerId);
        }
    }
}
