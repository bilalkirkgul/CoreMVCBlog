using BLL.Abstract;
using BLL.Concrete;
using DAL.Concrete.Repository.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
       private readonly ICommentService commentService;

        public CommentListByBlog(ICommentService commentService)
        {
            this.commentService = commentService;
        }



        public IViewComponentResult Invoke(int id)
        {
            //Blog sayfası yüklenirken beraberinde o bloğa ait yorumları da görmek için bu compenenti oluşturdum. burada almış olduğum parametre blog id sini temsil etmektedir. paramotre bu componente blogreadall sayfasında aktarılıyor. orayada blogreadAll Actionunda yakalanıp veriliyor . GetCommentByList Blog id sine göre yorumları getirme methodudur. ( bkn. bll katmanı commentmaneger).. 
            //blogId sine göre yorumları getirdimm

            var values = commentService.GetCommentByList(id);
            if (values.Count >= 1)
            {
                return View(values);
            }
            else
            {
                ViewBag.Message = "henüz blog için yorum yapılmamış. İlk yorumu siz yapmak ister misiniz ??";
                return View(values);
            }


        }



    }

}

