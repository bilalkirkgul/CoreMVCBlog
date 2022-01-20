using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface IGenericDAL<TEntitiy> where TEntitiy : class
    {
        //GetAll işlemi ve get işlemi revize edilecek (Expression<Func<TEntity,bool>>filter) 
        void Insert(TEntitiy entitiy);
        void Delete(TEntitiy entitiy);
        void Update(TEntitiy entitiy);
        ICollection<TEntitiy> GetAll();
        TEntitiy GetById(int entityId);
    }
}
