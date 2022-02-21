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
    class ContactManager : IContactService
    {
        IContactDAL contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            this.contactDAL = contactDAL;
        }

        public void Insert(Contact entity)
        {
            contactDAL.Insert(entity);
        }

        public void Update(Contact entity)
        {
            contactDAL.Update(entity);
        }
        public void Delete(Contact entity)
        {
            contactDAL.Delete(entity);
        }

        public Contact GetById(int entityId)
        {
            return contactDAL.Get(a=>a.ContactID== entityId);
        }

        public List<Contact> GetList()
        {
            throw new NotImplementedException();
        }

       
    }
}
