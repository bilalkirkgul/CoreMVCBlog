﻿using BLL.Concrete;
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

        CommentManager comment = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int id)
        {
           //Blog sayfası yüklenirken beraberinde o bloğa ait yorumları da görmek için bu compenenti oluşturdum. burada almış olduğum parametre blog id sini temsil etmektedir. paramotre bu componente blogreadall sayfasında aktarılıyor. orayada blogreadAll Actionunda yakalanıp veriliyor . GetCommentByList Blog id sine göre yorumları getirme methodudur. ( bkn. bll katmanı commentmaneger).. 

            var values = comment.GetCommentByList(id);
            if (values.Count>=1)
            {
                return View(values);
            }
            else
            {
                ViewBag.Message = "Blog için yorum yapılmamış ilk yorumu siz yapmak ister misiniz ??";
                return View(values);
            }
       
            
        }



    }

}

