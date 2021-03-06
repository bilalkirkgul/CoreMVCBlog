using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repository
{
    public class GenericRepository<TEntity> : IGenericDAL<TEntity>
        where TEntity : class
    {
        public void Insert(TEntity entitiy)
        {
            using var context = new BlogDbContext();
            //context.Add(entitiy);
            //context.Set<TEntity>().Add(entitiy);
            context.Entry(entitiy).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Update(TEntity entitiy)
        {
            using var context = new BlogDbContext();
            //context.Update(entitiy);
            //context.Set<TEntity>().Update(entitiy);
            context.Entry(entitiy).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void Delete(TEntity entitiy)
        {
            using var context = new BlogDbContext();
            //context.Remove(entitiy);
            context.Entry(entitiy).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new BlogDbContext();
            return context.Set<TEntity>().Where(filter).SingleOrDefault();           
        }

        public List<TEntity> GetListAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new BlogDbContext();
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }

    }
}
