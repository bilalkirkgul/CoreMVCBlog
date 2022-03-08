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
    class WriterManager : IWriterService
    {
       private readonly IWriterDAL writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            this.writerDAL = writerDAL;
        }
        public void Insert(Writer writer)
        {
            writerDAL.Insert(writer);
        }

        public void Update(Writer entity)
        {
            writerDAL.Update(entity);
        }

        public void Delete(Writer entity)
        {
            entity.WriterStatus = false;
            writerDAL.Update(entity);
        }

        public Writer GetById(int entityId)
        {
          return  writerDAL.Get(a=>a.WriterID==entityId);
        }

        public List<Writer> GetList()
        {
            return writerDAL.GetListAll();
        }
      
        
        /// <summary>
        /// Login Auto.
        /// </summary>
        /// <param name="mail">WriterMail</param>
        /// <param name="password">WriterPassword</param>
        /// <returns></returns>
        public Writer GetLoginCheck(string mail, string password)
        {
            return writerDAL.Get(x => x.WriterMail == mail && x.WriterPassword == password);
        }

       
    }
}
