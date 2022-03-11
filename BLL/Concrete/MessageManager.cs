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
    class MessageManager : IMessageService
    {
        IMessageDAL messageDAL;

        public MessageManager(IMessageDAL message)
        {
            this.messageDAL = message;
        }
        public void Insert(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message GetById(int entityId)
        {
            return messageDAL.Get(a => a.MessageID == entityId);
        }

        public List<Message> GetList()
        {
            return messageDAL.GetListAll();
        }

        //gelen mesaj // login olan kişiye gelen mesajları gösterir.
        public List<Message> GetInboxListByWriter(string p)
        {
            return messageDAL.GetListAll(a => a.Receiver == p);
        }
    }
}
