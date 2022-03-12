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
    class MessageTwoManager : IMessageTwoService
    {
        IMessageTwoDAL messageTwoDAL;

        public MessageTwoManager(IMessageTwoDAL messageTwoDAL)
        {
            this.messageTwoDAL = messageTwoDAL;
        }

        public void Insert(MessageTwo entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MessageTwo entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(MessageTwo entity)
        {
            throw new NotImplementedException();
        }

        public MessageTwo GetById(int entityId)
        {
            return messageTwoDAL.Get(a=>a.MessageID==entityId);
        }

    
        public List<MessageTwo> GetList()
        {
            return messageTwoDAL.GetListAll();
        }

        /// <summary>
        ///Receiver "Alıcı" - ReceiverWriter seçili id' ye gönderilen mesajları listeleme işlemi. 
        /// </summary>
        /// <param name="id">Sisteme giriş yapan kullanıcının parametresi veilecek</param>
        /// <returns></returns>
        public List<MessageTwo> GetInboxListReceiverByWriter(int id)
        {
            return messageTwoDAL.GetListMessageInReceiverWriter(id);
        }

        /// <summary>
        /// Mesaj detay listelemesi yaparken mesajı gönderen kişinin prifil bilgileri almak için oluşturulan method
        /// </summary>
        /// <param name="entityId">Mesajlar listesinden yakalayacağımız mesajın Id numarası</param>
        /// <returns></returns>

        public MessageTwo GetByMessageIdAndSender(int id)
        {
            return messageTwoDAL.GetMessageInReceiverWriter(id);
        }



    }
}
