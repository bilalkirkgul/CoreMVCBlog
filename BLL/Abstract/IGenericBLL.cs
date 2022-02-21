using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface IGenericBLL<TEntity>
        where TEntity:class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);

        void Delete(TEntity entity);
        List<TEntity> GetList();
        TEntity GetById(int entityId);
    }
}
