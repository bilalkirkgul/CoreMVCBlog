﻿using BLL.Abstract;
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
            blog.BlogStatus = true;
            blog.BlogCreateDate = DateTime.Now;
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
            //dal katmanında includes işlemi yaptım blog bilgilerini çağırırken içerisine category tüm bilgilerinide dahil ettim.
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
        public List<Blog> WriterBlogInCategoryByID(int writerId)
        {
            return blogDAL.WriterBlogInCategoryByID(writerId);
        }

        public List<Blog> GetListBlogInWriter()
        {
            //dal katmanında includes işlemi yaptım blog bilgilerini çağırırken içerisine writerin tüm bilgilerinide dahil ettim.
            return blogDAL.GetListBlogInWriter();
        }

        
    }
}
