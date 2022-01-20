using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repository
{
    public class GenericRepository<TEntity> : IGenericDAL<TEntity> where TEntity : class
    {

        //Todo :Crud işlemleri EntityState yapısı ile revize edilecek

        public void Delete(TEntity entitiy)
        {
            using var context = new BlogDbContext();
            context.Remove(entitiy);
            context.SaveChanges();
        }

        public ICollection<TEntity> GetAll()
        {
            using var context = new BlogDbContext();
           return context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int entityId)
        {
            using var context = new BlogDbContext();
            return context.Set<TEntity>().Find(entityId);
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
