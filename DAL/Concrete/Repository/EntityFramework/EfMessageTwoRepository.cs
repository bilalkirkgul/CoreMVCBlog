using DAL.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repository.EntityFramework
{
    class EfMessageTwoRepository: GenericRepository<MessageTwo>, IMessageTwoDAL
    {


        public List<MessageTwo> GetListMessageInReceiverWriter(int receiverId)
        {

            //Alıcı id'sine göre mesajları listeleme işlemi için oluşturdum. SenderUser Gönderen kişinin profil bilgilerine ulaşma işlmei için includes yapıldı..

            using (var c = new BlogDbContext())
                return c.MessageTwos.Include(a => a.SenderUser).Where(a=>a.ReceiverID==receiverId).ToList();
        }
        public MessageTwo GetMessageInReceiverWriter(int messageId)
        {

            //Tekil olarak Mesaj id'sine göre mesajı listeleme işlemi yaoparken SenderUser Mesajı Gönderen kişinin profil bilgilerine ulaşma işlmei için includes yapıldı..

            using (var c = new BlogDbContext())
                return c.MessageTwos.Where(a=>a.MessageID== messageId).Include(a => a.SenderUser).SingleOrDefault();
        }



    }
}
