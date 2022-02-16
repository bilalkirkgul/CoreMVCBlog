﻿using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repository
{
    public class GenericRepository<TEntity> : IGenericDAL<TEntity> where TEntity : class
    {

     

        public void Delete(TEntity entitiy)
        {
            using var context = new BlogDbContext();
            context.Remove(entitiy);
            context.SaveChanges();
        }

      
        public TEntity GetById(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new BlogDbContext();
            return context.Set<TEntity>().Where(filter).SingleOrDefault();
        }

        public List<TEntity> GetListAll(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new BlogDbContext();
            return context.Set<TEntity>().Where(filter).ToList();
          
        }
        /// <summary>
        /// Filtresiz çokli seçme için oluşturuldu
        /// </summary>
        /// <returns></returns>
        public List<TEntity> GetListAll()
        {
            using var context = new BlogDbContext();
            return context.Set<TEntity>().ToList();
        }


        public void Insert(TEntity entitiy)
        {
            using var context = new BlogDbContext();
            context.Add(entitiy);
            context.SaveChanges();
        }

        public void Update(TEntity entitiy)
        {
            using var context = new BlogDbContext();
            context.Update(entitiy);
            context.SaveChanges();
        }
    }
}
