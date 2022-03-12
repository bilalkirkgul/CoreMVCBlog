using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface IMessageTwoService : IGenericBLL<MessageTwo>
    {
        /// <summary>
        ///Receiver "Alıcı" - ReceiverWriter seçili id' ye gönderilen mesajları listeleme işlemi. 
        /// </summary>
        /// <param name="id">Sisteme giriş yapan kullanıcının parametresi veilecek</param>
        /// <returns></returns>
        List<MessageTwo> GetInboxListReceiverByWriter(int id);




        /// <summary>
        /// Mesajın detayını listeleme yaparken mesajı gönderen kişinin prifil bilgileri almak için oluşturulan method
        /// </summary>
        /// <param name="entityId">Mesajlar listesinden yakalayacağımız mesajın Id numarası</param>
        /// <returns></returns>
        MessageTwo GetByMessageIdAndSender(int id);
    }
}
