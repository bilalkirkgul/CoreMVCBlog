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
   public class EfCategoryRepository : GenericRepository<Category>, ICategoryDAL
    {

      

    }
}
