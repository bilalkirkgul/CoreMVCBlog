using DAL.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Repository.EntityFramework
{
    class EfAboutRepository : GenericRepository<About>, IAboutDAL
    {
    }
}
