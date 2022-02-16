using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IGenericDAL<TEntity> where TEntity : class
    {
        //GetAll işlemi ve get işlemi revize edilecek (Expression<Func<TEntity,bool>>filter) 
        void Insert(TEntity entitiy);
        void Delete(TEntity entitiy);
        void Update(TEntity entitiy);
        List<TEntity> GetListAll();
        TEntity GetById(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetListAll(Expression<Func<TEntity, bool>> filter);

    }
}
