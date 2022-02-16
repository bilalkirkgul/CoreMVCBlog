using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>()
            {
                new UserComment{
                    Id=1,
                    UserName="Bilal"
                },new UserComment
                {
                    Id=2,
                    UserName="Semra"
                }
            };
            return View(commentValues);
        }

    }
}
