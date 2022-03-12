using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
   public interface IMessageTwoDAL:IGenericDAL<MessageTwo>
    {
        List<MessageTwo> GetListMessageInReceiverWriter(int receiverId);
        MessageTwo GetMessageInReceiverWriter(int messageId);
    }
}
