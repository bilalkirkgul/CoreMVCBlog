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
    class AdminManager : IAdminService
    {
        IAdminDAL adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            this.adminDAL = adminDAL;
        }
        public void Insert(Admin entity)
        {
            adminDAL.Insert(entity);
        }

        public void Update(Admin entity)
        {
            adminDAL.Update(entity);
        }

        public void Delete(Admin entity)
        {
            
            adminDAL.Delete(entity);
        }

        public Admin GetById(int entityId)
        {
            return adminDAL.Get(a=>a.AdminID==entityId);
        }

        public List<Admin> GetList()
        {
            return adminDAL.GetListAll();
        }

     
    }
}
