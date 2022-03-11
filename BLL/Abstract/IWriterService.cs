using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface IWriterService : IGenericBLL<Writer>
    {
        /// <summary>
        /// Login Auto.
        /// </summary>
        /// <param name="mail">WriterMail</param>
        /// <param name="password">WriterPassword</param>
        /// <returns></returns>
        Writer GetLoginCheck(string mail, string password);
        
    }
}
