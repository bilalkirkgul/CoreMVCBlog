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
     
        void Insert(TEntity entitiy);
        void Delete(TEntity entitiy);
        void Update(TEntity entitiy);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetListAll(Expression<Func<TEntity, bool>> filter=null);

    }
}
