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
    class NewsLetterManager : INewsLetterService
    {
       private readonly INewsLetterDAL newsLetterDAL;

        public NewsLetterManager(INewsLetterDAL newsLetterDAL)
        {
            this.newsLetterDAL = newsLetterDAL;
        }

        public void Insert(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            newsLetterDAL.GetListAll();
        }

        public void Update(NewsLetter entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(NewsLetter entity)
        {
            throw new NotImplementedException();
        }

        public NewsLetter GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<NewsLetter> GetList()
        {
            throw new NotImplementedException();
        }

    
    }
}
