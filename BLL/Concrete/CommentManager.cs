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
    public class CommentManager : ICommentService
    {
        ICommentDAL commentDAL;
        public CommentManager(ICommentDAL comment)
        {
            commentDAL = comment;
        }

        public void Insert(Comment comment)
        {
            commentDAL.Insert(comment);
        }
        public void Delete(Comment comment)
        {
            commentDAL.Delete(comment);
        }
        public void Update(Comment comment)
        {
            commentDAL.Update(comment);
        }

        public List<Comment> GetList()
        {
            return commentDAL.GetListAll();
        }
        public Comment GetById(int commentId)
        {
            return commentDAL.GetById(a => a.CommentID == commentId);
        }


        public List<Comment> GetCommentByList(int id)
        {
            //blogIdsine göre çoklu yorumları listeleme
            return commentDAL.GetListAll(a => a.BlogID == id);
        }
        
    }
}
