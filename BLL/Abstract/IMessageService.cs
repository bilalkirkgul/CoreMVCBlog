using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface IMessageService:IGenericBLL<Message>
    {
        List<Message> GetInboxListByWriter(string p);
    }
}
