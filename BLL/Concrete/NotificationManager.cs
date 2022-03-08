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
    class NotificationManager : INotificationService
    {
       private readonly INotificationDAL notificationDAL;
        public NotificationManager(INotificationDAL notification)
        {
            this.notificationDAL = notification;
        }
        public void Insert(Notification entity)
        {
            notificationDAL.Insert(entity);
        }

        public void Update(Notification entity)
        {
            notificationDAL.Update(entity);
        }
        public void Delete(Notification entity)
        {
            notificationDAL.Delete(entity);
        }

        public Notification GetById(int entityId)
        {
            return notificationDAL.Get(a=>a.NotificationID==entityId);
        }

        public List<Notification> GetList()
        {
            return notificationDAL.GetListAll();
        }

     
    }
}
