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
   public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDAL newsLetterDAL;

        public NewsLetterManager(INewsLetterDAL newsLetterDAL)
        {
            this.newsLetterDAL = newsLetterDAL;
        }

        public void Add(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            newsLetterDAL.GetListAll();
        }
    }
}
