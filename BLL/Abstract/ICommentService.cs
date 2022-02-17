using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
   public interface ICommentService
    {
        void Add(Comment comment);
        //void Delete(Comment comment);
        //void Update(Comment comment);

        List<Comment> GetList();
        //Comment GetById(int commentId);

      
    }
}
