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
    class AboutManager : IAboutService
    {

        IAboutDAL aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            this.aboutDAL = aboutDAL;
        }

        public void Insert(About entity)
        {
            throw new NotImplementedException();
        }

        public void Update(About entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(About entity)
        {
            throw new NotImplementedException();
        }

        public About GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
           return aboutDAL.GetListAll();
        }

     
    }
}
